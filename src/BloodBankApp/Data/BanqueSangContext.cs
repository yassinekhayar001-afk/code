using BloodBankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodBankApp.Data;

public class BanqueSangContext : DbContext
{
    public BanqueSangContext(DbContextOptions<BanqueSangContext> options) : base(options)
    {
    }

    public DbSet<Donneur> Donneurs => Set<Donneur>();
    public DbSet<Don> Dons => Set<Don>();
    public DbSet<ComposantSanguin> Composants => Set<ComposantSanguin>();
    public DbSet<TestSerologique> TestsSerologiques => Set<TestSerologique>();
    public DbSet<StockItem> Stock => Set<StockItem>();
    public DbSet<Distribution> Distributions => Set<Distribution>();
    public DbSet<IncidentHemovigilance> Incidents => Set<IncidentHemovigilance>();
    public DbSet<Utilisateur> Utilisateurs => Set<Utilisateur>();
    public DbSet<JournalAudit> JournalAudit => Set<JournalAudit>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Donneur>()
            .HasIndex(d => d.IdentifiantDonneur)
            .IsUnique();

        modelBuilder.Entity<Don>()
            .HasOne(d => d.Donneur)
            .WithMany(d => d.Dons)
            .HasForeignKey(d => d.DonneurId);

        modelBuilder.Entity<ComposantSanguin>()
            .HasOne(c => c.Don)
            .WithMany(d => d.Composants)
            .HasForeignKey(c => c.DonId);

        modelBuilder.Entity<TestSerologique>()
            .HasOne(t => t.Composant)
            .WithMany(c => c.Tests)
            .HasForeignKey(t => t.ComposantId);

        modelBuilder.Entity<Distribution>()
            .HasOne(d => d.Composant)
            .WithMany()
            .HasForeignKey(d => d.ComposantId);

        modelBuilder.Entity<IncidentHemovigilance>()
            .HasOne(i => i.Composant)
            .WithMany()
            .HasForeignKey(i => i.ComposantId);
    }
}
