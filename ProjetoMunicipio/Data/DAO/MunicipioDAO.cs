using Microsoft.EntityFrameworkCore;
using ProjetoMunicipio.DTOs;
using ProjetoMunicipio.Model;
using ProjetoMunicipio.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMunicipio.Data.DAO
{
    public class MunicipioDAO
    {
        private readonly ApplicationDbContext _contexto;

        public MunicipioDAO(ApplicationDbContext ctx) => _contexto = ctx;

        public Municipio? GetByName(string nome) =>
            _contexto.Municipios
                     .AsNoTracking()
                     .FirstOrDefault(m => m.NomeDoMunicipio != null
                                       && m.NomeDoMunicipio.ToLower() == nome.ToLower());

        public long SumPopulacaoByUf(string uf)
        {
            if (string.IsNullOrWhiteSpace(uf))
                return 0;

            return _contexto.Municipios
                            .Where(m => m.Uf != null && m.Uf.ToLower() == uf.ToLower())
                            .Select(m => (long?)m.Populacao)
                            .Sum() ?? 0;
        }

        public List<Municipio> GetCapitais() =>
            _contexto.Municipios
                     .AsNoTracking()
                     .Where(m => m.CapitalEstado == " Sim")
                     .ToList();


        public List<Municipio> GetTodosMunicipios() =>
            _contexto.Municipios
                     .AsNoTracking()
                     .ToList();
    }
}
