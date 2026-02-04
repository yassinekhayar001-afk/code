using BloodBankApp.Models;
using BloodBankApp.Services;
using Xunit;

namespace BloodBankApp.Tests;

public class ComposantServiceTests
{
    [Fact]
    public void CalculerDateExpiration_RetourneDateCorrectePourPlasma()
    {
        var service = new ComposantService();
        var datePreparation = new DateOnly(2024, 1, 15);

        var resultat = service.CalculerDateExpiration(TypeComposant.Plasma, datePreparation);

        Assert.Equal(new DateOnly(2025, 1, 15), resultat);
    }

    [Fact]
    public void CalculerDateExpiration_RetourneDateCorrectePourPlaquettes()
    {
        var service = new ComposantService();
        var datePreparation = new DateOnly(2024, 6, 1);

        var resultat = service.CalculerDateExpiration(TypeComposant.Plaquettes, datePreparation);

        Assert.Equal(new DateOnly(2024, 6, 6), resultat);
    }
}
