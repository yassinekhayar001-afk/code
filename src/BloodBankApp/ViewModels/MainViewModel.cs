using System.Collections.ObjectModel;
using BloodBankApp.Data;
using BloodBankApp.Models;
using BloodBankApp.Services;

namespace BloodBankApp.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly DonneurService _donneurService;
    private readonly CollecteService _collecteService;

    public MainViewModel()
    {
        _donneurService = new DonneurService(new BanqueSangContextFactory().CreateDbContext());
        _collecteService = new CollecteService();

        Sexes = new ObservableCollection<Sexe>((Sexe[])Enum.GetValues(typeof(Sexe)));
        GroupesSanguins = new ObservableCollection<GroupeSanguin>((GroupeSanguin[])Enum.GetValues(typeof(GroupeSanguin)));

        Donneurs = new ObservableCollection<Donneur>(SeedData.GenererDonneurs());
        Stock = new ObservableCollection<StockItem>(SeedData.GenererStockInitial());
        UtilisateurConnecte = SeedData.GenererUtilisateurDemo();

        NouveauDonneur = new Donneur
        {
            GroupeSanguin = GroupeSanguin.APositif,
            Sexe = Sexe.Femme,
            StatutAptitude = StatutAptitude.Apte
        };

        AjouterDonneurCommand = new RelayCommand(AjouterDonneur);
        GenererCollecteCommand = new RelayCommand(GenererCollecte);
    }

    public ObservableCollection<Donneur> Donneurs { get; }
    public ObservableCollection<StockItem> Stock { get; }
    public ObservableCollection<Sexe> Sexes { get; }
    public ObservableCollection<GroupeSanguin> GroupesSanguins { get; }

    private Donneur _nouveauDonneur = new();
    public Donneur NouveauDonneur
    {
        get => _nouveauDonneur;
        set
        {
            _nouveauDonneur = value;
            OnPropertyChanged();
        }
    }

    private Utilisateur _utilisateurConnecte = new();
    public Utilisateur UtilisateurConnecte
    {
        get => _utilisateurConnecte;
        set
        {
            _utilisateurConnecte = value;
            OnPropertyChanged();
        }
    }

    private string _collecteSelectionneeResume = "Aucune collecte générée.";
    public string CollecteSelectionneeResume
    {
        get => _collecteSelectionneeResume;
        set
        {
            _collecteSelectionneeResume = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand AjouterDonneurCommand { get; }
    public RelayCommand GenererCollecteCommand { get; }

    private async void AjouterDonneur()
    {
        if (string.IsNullOrWhiteSpace(NouveauDonneur.NomComplet))
        {
            return;
        }

        NouveauDonneur.IdentifiantDonneur = $"DNR-{DateTime.Now:yyyy}-{Donneurs.Count + 1:0000}";
        Donneurs.Add(NouveauDonneur);
        await _donneurService.AjouterDonneurAsync(NouveauDonneur);

        NouveauDonneur = new Donneur
        {
            GroupeSanguin = GroupeSanguin.APositif,
            Sexe = Sexe.Femme,
            StatutAptitude = StatutAptitude.Apte
        };
    }

    private void GenererCollecte()
    {
        var donneur = Donneurs.FirstOrDefault();
        if (donneur is null)
        {
            CollecteSelectionneeResume = "Veuillez enregistrer un donneur avant la collecte.";
            return;
        }

        var don = _collecteService.CreerCollecte(donneur, TypeDon.SangTotal, 450, "Centre principal", UtilisateurConnecte.NomComplet);
        CollecteSelectionneeResume = $"Collecte {don.CodeBarresPoche} - {don.DateHeureCollecte:dd/MM/yyyy HH:mm}";
    }
}
