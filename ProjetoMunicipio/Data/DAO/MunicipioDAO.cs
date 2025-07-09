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

        public Municipio GetByName(string nome) =>
            _contexto.Municipios
                .FirstOrDefault(m => m.NomeDoMunicipio.ToLower() == nome.ToLower());

        public int SumPopulacaoByUf(string uf) =>
            _contexto.Municipios
                .Where(m => m.Uf.ToLower() == uf.ToLower())
                .Sum(m => m.Populacao);

        public List<Municipio> GetCapitais() =>
            _contexto.Municipios
                .Where(m => m.Capital)
                .ToList();

        public List<Municipio> GetTodosMunicipios() =>
            _contexto.Municipios.ToList();
    }

}
