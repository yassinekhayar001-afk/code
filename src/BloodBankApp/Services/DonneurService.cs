using BloodBankApp.Data;
using BloodBankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodBankApp.Services;

public class DonneurService
{
    private readonly BanqueSangContext _context;

    public DonneurService(BanqueSangContext context)
    {
        _context = context;
    }

    public async Task<List<Donneur>> ObtenirDonneursAsync()
    {
        return await _context.Donneurs.AsNoTracking().OrderBy(d => d.NomComplet).ToListAsync();
    }

    public async Task AjouterDonneurAsync(Donneur donneur)
    {
        _context.Donneurs.Add(donneur);
        await _context.SaveChangesAsync();
    }
}
