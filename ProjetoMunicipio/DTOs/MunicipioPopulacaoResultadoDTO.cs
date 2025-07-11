using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMunicipio.DTOs
{
    public class MunicipioPopulacaoResultadoDTO
    {
        public int Total { get; set; }
        public List<MunicipioDTO> Municipios { get; set; } = new();
    }
}
