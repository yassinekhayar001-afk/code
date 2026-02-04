using BloodBankApp.Models;

namespace BloodBankApp.Data;

public static class SeedData
{
    public static List<Donneur> GenererDonneurs()
    {
        return new List<Donneur>
        {
            new()
            {
                IdentifiantDonneur = "DNR-2024-0001",
                NomComplet = "Amina El Idrissi",
                Cin = "AA123456",
                DateNaissance = new DateTime(1990, 4, 12),
                Sexe = Sexe.Femme,
                GroupeSanguin = GroupeSanguin.APositif,
                StatutAptitude = StatutAptitude.Apte,
                NotesMedicales = "Aucun antécédent majeur."
            },
            new()
            {
                IdentifiantDonneur = "DNR-2024-0002",
                NomComplet = "Youssef Benali",
                Cin = "BB987654",
                DateNaissance = new DateTime(1985, 11, 3),
                Sexe = Sexe.Homme,
                GroupeSanguin = GroupeSanguin.ONegatif,
                StatutAptitude = StatutAptitude.Apte,
                NotesMedicales = "Donneur régulier."
            }
        };
    }

    public static List<StockItem> GenererStockInitial()
    {
        return new List<StockItem>
        {
            new()
            {
                TypeComposant = TypeComposant.GlobulesRouges,
                GroupeSanguin = GroupeSanguin.APositif,
                Quantite = 12,
                SeuilAlerte = 6,
                StatutStock = StatutStock.Disponible
            },
            new()
            {
                TypeComposant = TypeComposant.Plasma,
                GroupeSanguin = GroupeSanguin.ONegatif,
                Quantite = 4,
                SeuilAlerte = 5,
                StatutStock = StatutStock.Reserve
            }
        };
    }

    public static Utilisateur GenererUtilisateurDemo()
    {
        return new Utilisateur
        {
            NomUtilisateur = "biologiste.demo",
            NomComplet = "Dr. Salma Haddad",
            Role = RoleUtilisateur.Biologiste,
            Actif = true
        };
    }
}
