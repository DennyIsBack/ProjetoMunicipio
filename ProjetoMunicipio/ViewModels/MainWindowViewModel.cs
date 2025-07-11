using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using ProjetoMunicipio.Data;
using ProjetoMunicipio.Repository;
using ProjetoMunicipio.Data.DAO;
using ProjetoMunicipio.Model;
using ProjetoMunicipio.DTOs;
using ProjetoMunicipio.Services;

namespace ProjetoMunicipio.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly MunicipioService _service;

        public MainWindowViewModel()
        {
            // 1.1) configurar context + serviço
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseNpgsql(
                  "Host=localhost;Port=5432;Database=municipios;Username=postgres;Password=SuaSenhaAqui"
                )
                .Options;
            var ctx = new ApplicationDbContext(options);
            var dao = new MunicipioDAO(ctx);
            var repo = new MunicipioRepository(dao);
            _service = new MunicipioService(repo);

            BuscarPorNomeCmd = new RelayCommand(_ => BuscarPorNome());
            BuscarPopUfCmd = new RelayCommand(_ => BuscarPopulacao());
            ListarCapitaisCmd = new RelayCommand(_ => ListarCapitais());
            FiltrarPopCmd = new RelayCommand(_ => FiltrarPorPopulacao());
            ListarTop10NaoCapitaisCmd = new RelayCommand(_ => ListarTop10NaoCapitais());
            ListarEstadosMaiorQueCapitalCmd = new RelayCommand(_ => ListarEstadosMaiorQueCapital());
        }

        // 2) propriedades binding
        public string? NomeBusca { get; set; }
        public Municipio? MuniEncontrado { get; private set; }
        public string NomeEncontradoDisplay =>
            MuniEncontrado != null
              ? $"{MuniEncontrado.NomeDoMunicipio} – {MuniEncontrado.Uf} – População: {MuniEncontrado.Populacao:N0}"
              : "Não encontrado";

        public string? UfBusca { get; set; }
        public long PopulacaoTotal { get; private set; }

        public ObservableCollection<Municipio>? Capitais { get; private set; }

        // 3) propriedades para filtros/relatórios
        public int? PopMin { get; set; }
        public int? PopMax { get; set; }
        public int TotalFiltrados { get; private set; }
        public ObservableCollection<MunicipioDTO>? Filtrados { get; private set; }

        public ObservableCollection<MunicipioDTO>? Top10NaoCapitais { get; private set; }
        public ObservableCollection<MunicipioDTO>? EstadosComMaior { get; private set; }

        // 4) comandos expostos
        public ICommand BuscarPorNomeCmd { get; }
        public ICommand BuscarPopUfCmd { get; }
        public ICommand ListarCapitaisCmd { get; }
        public ICommand FiltrarPopCmd { get; }
        public ICommand ListarTop10NaoCapitaisCmd { get; }
        public ICommand ListarEstadosMaiorQueCapitalCmd { get; }

        private void BuscarPorNome()
        {
            MuniEncontrado = _service.BuscarPorNome(NomeBusca ?? "");
            OnPropertyChanged(nameof(MuniEncontrado));
            OnPropertyChanged(nameof(NomeEncontradoDisplay));
        }

        private void BuscarPopulacao()
        {
            PopulacaoTotal = _service.PopulacaoTotalPorUF(UfBusca ?? "");
            OnPropertyChanged(nameof(PopulacaoTotal));
        }

        private void ListarCapitais()
        {
            Capitais = new ObservableCollection<Municipio>(_service.ListarCapitais());
            OnPropertyChanged(nameof(Capitais));
        }

        private void FiltrarPorPopulacao()
        {
            var dto = _service.FiltrarPorPopulacao(PopMin, PopMax);
            TotalFiltrados = dto.Total;
            Filtrados = new ObservableCollection<MunicipioDTO>(dto.Municipios);
            OnPropertyChanged(nameof(TotalFiltrados));
            OnPropertyChanged(nameof(Filtrados));
        }

        private void ListarTop10NaoCapitais()
        {
            Top10NaoCapitais =
                new ObservableCollection<MunicipioDTO>(
                    _service.ListarTop10MaisPopulososNaoCapitais()
                );
            OnPropertyChanged(nameof(Top10NaoCapitais));
        }

        private void ListarEstadosMaiorQueCapital()
        {
            EstadosComMaior =
                new ObservableCollection<MunicipioDTO>(
                    _service.EstadosComCidadeMaisPopulosaQueCapital()
                );
            OnPropertyChanged(nameof(EstadosComMaior));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string nome) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
    }

}
