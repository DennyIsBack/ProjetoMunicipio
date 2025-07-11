using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoMunicipio.DTOs;
using ProjetoMunicipio.Model;
using ProjetoMunicipio.Queries;
using ProjetoMunicipio.Repository;
using ProjetoMunicipio.Specifications;

namespace ProjetoMunicipio.Services
{
    internal class MunicipioService
    {
        private readonly MunicipioRepository _repository;

        public MunicipioService(MunicipioRepository repository)
        {
            _repository = repository;
        }

        public Municipio BuscarPorNome(string nome)
        {
            return _repository.BuscarPorNome(nome);
        }
        public int PopulacaoTotalPorUF(string uf)
        {
            return _repository.PopulacaoTotalPorUf(uf);
        }

        public List<Municipio> ListarCapitais()
        {
            return _repository.ListarCapitais();
        }

        public MunicipioPopulacaoResultadoDTO FiltrarPorPopulacao(int? min, int? max)
        {
            var municipios = _repository.ObterTodos();

            var spec = new PopulacaoRangeSpecification(min, max);
            var filtrados = municipios.Where(m => spec.IsSatisfiedBy(m)).ToList();

            return new MunicipioPopulacaoResultadoDTO
            {
                Total = filtrados.Count,
                Municipios = MunicipioQueries.ProjetarParaDTO(filtrados)
            };
        }

        public List<MunicipioDTO> ListarTop10MaisPopulososNaoCapitais()
        {
            var municipios = _repository.ObterTodos();

            var top10 = municipios
                .Where(m => !m.Capital)
                .OrderByDescending(m => m.Populacao)
                .Take(10)
                .ToList();

            return MunicipioQueries.ProjetarParaDTO(top10);
        }

        public List<MunicipioDTO> EstadosComCidadeMaisPopulosaQueCapital()
        {
            var municipios = _repository.ObterTodos();

            return municipios
                .GroupBy(m => m.Uf)
                .Where(g =>
                {
                    var capital = g.FirstOrDefault(m => m.Capital);
                    var maisPopulosa = g.OrderByDescending(m => m.Populacao).First();
                    return capital != null && maisPopulosa.Populacao > capital.Populacao;
                })
                .Select(g =>
                {
                    var maisPopulosa = g.OrderByDescending(m => m.Populacao).First();
                    return new MunicipioDTO
                    {
                        Uf = g.Key,
                        Nome = maisPopulosa.NomeDoMunicipio,
                        Populacao = maisPopulosa.Populacao
                    };
                })
                .ToList();
        }
    }
}
