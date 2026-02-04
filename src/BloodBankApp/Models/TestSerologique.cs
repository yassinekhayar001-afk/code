using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBankApp.Models;

[Table("tests_serologiques")]
public class TestSerologique
{
    [Key]
    [Column("id_test")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("nom_test")]
    [MaxLength(80)]
    public string NomTest { get; set; } = string.Empty;

    [Column("resultat")]
    [MaxLength(120)]
    public string Resultat { get; set; } = string.Empty;

    [Column("statut_validation")]
    public StatutTest StatutValidation { get; set; } = StatutTest.EnAttente;

    [Column("biologiste_validateur")]
    [MaxLength(120)]
    public string? BiologisteValidateur { get; set; }

    [Column("date_validation")]
    public DateTime? DateValidation { get; set; }

    [Column("composant_id")]
    public Guid ComposantId { get; set; }

    public ComposantSanguin? Composant { get; set; }
}
