namespace ProjetoMunicipio.Controllers
{
    //public class MunicipioController : Controller
    //{
    //    private readonly MunicipioRepository _repository;
    //    public MunicipioController(MunicipioRepository repository) => _repository = repository;

    //    [HttpGet]
    //    public IActionResult BuscarPorNome(string nome)
    //    {
    //        if (string.IsNullOrWhiteSpace(nome))
    //            return View();
    //        var muni = _repository.BuscarPorNome(nome);
    //        return View("Detalhes", muni);
    //    }

    //    [HttpGet]
    //    public IActionResult PopulacaoEstado(string uf)
    //    {
    //        if (string.IsNullOrWhiteSpace(uf))
    //            return View();
    //        ViewBag.Uf = uf.ToUpper();
    //        ViewBag.Total = _repository.PopulacaoTotalPorUf(uf);
    //        return View();
    //    }

    //    [HttpGet]
    //    public IActionResult Capitais()
    //    {
    //        var lista = _repository.ListarCapitais();
    //        return View(lista);
    //    }
    //}
}
