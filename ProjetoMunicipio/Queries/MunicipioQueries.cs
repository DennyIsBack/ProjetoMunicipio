using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoMunicipio.DTOs;
using ProjetoMunicipio.Model;

namespace ProjetoMunicipio.Queries
{
    public static class MunicipioQueries
    {
        public static List<MunicipioDTO> ProjetarParaDTO(List<Municipio> municipios)
        {
            return municipios.Select(m => new MunicipioDTO
            {
                Nome = m.NomeDoMunicipio,
                Uf = m.Uf,
                Populacao = m.Populacao
            }).ToList();
        }
    }
}
