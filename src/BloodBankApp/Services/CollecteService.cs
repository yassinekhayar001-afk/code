using BloodBankApp.Models;

namespace BloodBankApp.Services;

public class CollecteService
{
    public Don CreerCollecte(Donneur donneur, TypeDon typeDon, int volumeMl, string site, string operateur)
    {
        return new Don
        {
            DonneurId = donneur.Id,
            Donneur = donneur,
            DateHeureCollecte = DateTime.Now,
            TypeDon = typeDon,
            VolumeMl = volumeMl,
            CodeBarresPoche = GenererCodeBarres(),
            SiteCollecte = site,
            OperateurCollecte = operateur
        };
    }

    private string GenererCodeBarres()
    {
        return $"BB-{DateTime.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid():N}".ToUpperInvariant();
    }
}
