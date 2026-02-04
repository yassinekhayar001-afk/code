using BloodBankApp.Models;

namespace BloodBankApp.Services;

public class ComposantService
{
    public DateOnly CalculerDateExpiration(TypeComposant typeComposant, DateOnly datePreparation)
    {
        return typeComposant switch
        {
            TypeComposant.GlobulesRouges => datePreparation.AddDays(42),
            TypeComposant.Plasma => datePreparation.AddYears(1),
            TypeComposant.Plaquettes => datePreparation.AddDays(5),
            _ => datePreparation.AddDays(1)
        };
    }

    public string DeterminerConditionsStockage(TypeComposant typeComposant)
    {
        return typeComposant switch
        {
            TypeComposant.GlobulesRouges => "2-6°C",
            TypeComposant.Plasma => "-25°C ou moins",
            TypeComposant.Plaquettes => "20-24°C avec agitation",
            _ => "Standard"
        };
    }
}
