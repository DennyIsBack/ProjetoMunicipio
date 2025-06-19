using ProjetoMunicipio.Data.DAO;
using ProjetoMunicipio.Model;

namespace ProjetoMunicipio.Repository
{
    public class MunicipioRepository
    {
        private readonly MunicipioDAO _dao;
        public MunicipioRepository(MunicipioDAO dao) => _dao = dao;

        public Municipio BuscarPorNome(string nome) =>
            _dao.GetByName(nome);

        public int PopulacaoTotalPorUf(string uf) =>
            _dao.SumPopulacaoByUf(uf);

        public List<Municipio> ListarCapitais() =>
            _dao.GetCapitais();
    }
}
