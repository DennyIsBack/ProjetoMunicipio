using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using ProjetoMunicipio.Data;
using ProjetoMunicipio.Repository;
using ProjetoMunicipio.Data.DAO;
using ProjetoMunicipio.Model;

namespace ProjetoMunicipio.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        // repositorio de município
        private readonly MunicipioRepository _repository;

        public MainWindowViewModel()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseNpgsql("Host=localhost;Port=5432;Database=municipio_db;Trusted_Connection=true;")
                .Options;

            var ctx = new ApplicationDbContext(options);
            var dao = new MunicipioDAO(ctx);
            _repository = new MunicipioRepository(dao);

            // 2) comandos ligados aos botões
            BuscarPorNomeCmd = new RelayCommand(_ => BuscarPorNome());
            BuscarPopUfCmd = new RelayCommand(_ => BuscarPopulacao());
            ListarCapitaisCmd = new RelayCommand(_ => ListarCapitais());
        }

        // BINDING
        public string? NomeBusca { get; set; }
        public Municipio? MuniEncontrado { get; set; }
        public string? UfBusca { get; set; }
        public int? PopulacaoTotal { get; set; }
        public ObservableCollection<Municipio>? Capitais { get; set; }

        public ICommand? BuscarPorNomeCmd { get; }
        public ICommand? BuscarPopUfCmd { get; }
        public ICommand? ListarCapitaisCmd { get; }

        private void BuscarPorNome()
        {
            MuniEncontrado = _repository.BuscarPorNome(NomeBusca);
            OnPropertyChanged(nameof(MuniEncontrado));
        }

        private void BuscarPopulacao()
        {
            PopulacaoTotal = _repository.PopulacaoTotalPorUf(UfBusca);
            OnPropertyChanged(nameof(PopulacaoTotal));
        }

        private void ListarCapitais()
        {
            Capitais = new ObservableCollection<Municipio>(_repository.ListarCapitais());
            OnPropertyChanged(nameof(Capitais));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string nome) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
    }
}
