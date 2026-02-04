using Microsoft.EntityFrameworkCore;

namespace BloodBankApp.Data;

public class BanqueSangContextFactory
{
    public BanqueSangContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<BanqueSangContext>()
            .UseSqlite("Data Source=banque_sang.db")
            .Options;

        return new BanqueSangContext(options);
    }
}
