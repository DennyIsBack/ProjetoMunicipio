using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMunicipio.Model
{
    [Table("municipios_ibge")]
    public class Municipio
    {
        [Column("cod_munic")]
        public int CodMunicipio { get; set; }

        [Column("uf"), StringLength(2)]
        public string Uf { get; set; }

        [Column("cod_uf")]
        public int CodUf { get; set; }

        [Column("nome_municipio")]
        public string NomeDoMunicipio { get; set; }

        [Column("capital_estado")]
        public string CapitalEstado { get; set; }

        [Column("populacao")]
        public long Populacao { get; set; }

        [NotMapped]
        public bool Capital => CapitalEstado?.Equals(" Sim", StringComparison.OrdinalIgnoreCase) == true;
    }
}
