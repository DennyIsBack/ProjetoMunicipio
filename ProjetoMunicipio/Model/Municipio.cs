using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMunicipio.Model
{
    [Table("municipio")]
    public class Municipio
    {
        [Column("cod_munic")]
        public int CodMunicipio { get; set; }

        [Column("uf"), StringLength(2)]
        public string Uf { get; set; }

        [Column("cod_uf")]
        public int CodUf { get; set; }

        [Column("nome_do_municipio")]
        public string NomeDoMunicipio { get; set; }

        [Column("capital")]
        public bool Capital { get; set; }

        [Column("populacao")]
        public int Populacao { get; set; }
    }
}
