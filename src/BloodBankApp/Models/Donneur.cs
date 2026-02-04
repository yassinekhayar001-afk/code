using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBankApp.Models;

[Table("donneurs")]
public class Donneur
{
    [Key]
    [Column("id_donneur")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("identifiant_donneur")]
    [MaxLength(20)]
    public string IdentifiantDonneur { get; set; } = string.Empty;

    [Column("nom_complet")]
    [MaxLength(120)]
    public string NomComplet { get; set; } = string.Empty;

    [Column("cin")]
    [MaxLength(20)]
    public string Cin { get; set; } = string.Empty;

    [Column("date_naissance")]
    public DateTime? DateNaissance { get; set; }

    [Column("sexe")]
    public Sexe Sexe { get; set; }

    [Column("groupe_sanguin")]
    public GroupeSanguin GroupeSanguin { get; set; }

    [Column("statut_aptitude")]
    public StatutAptitude StatutAptitude { get; set; } = StatutAptitude.Apte;

    [Column("notes_medicales")]
    [MaxLength(4000)]
    public string? NotesMedicales { get; set; }

    public ICollection<Don> Dons { get; set; } = new List<Don>();
}
