using BloodBankApp.Data;
using BloodBankApp.Models;

namespace BloodBankApp.Services;

public class JournalisationService
{
    private readonly BanqueSangContext _context;

    public JournalisationService(BanqueSangContext context)
    {
        _context = context;
    }

    public async Task JournaliserAsync(string utilisateur, string action, string? details = null)
    {
        _context.JournalAudit.Add(new JournalAudit
        {
            Utilisateur = utilisateur,
            Action = action,
            DateAction = DateTime.Now,
            Details = details
        });

        await _context.SaveChangesAsync();
    }
}
