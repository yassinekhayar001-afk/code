using BloodBankApp.Models;

namespace BloodBankApp.Services;

public class StockService
{
    public bool EstEnAlerte(StockItem stock)
    {
        return stock.Quantite <= stock.SeuilAlerte;
    }

    public StatutStock MettreAJourStatut(DateOnly dateExpiration)
    {
        var aujourdHui = DateOnly.FromDateTime(DateTime.Today);
        return dateExpiration < aujourdHui ? StatutStock.Expire : StatutStock.Disponible;
    }
}
