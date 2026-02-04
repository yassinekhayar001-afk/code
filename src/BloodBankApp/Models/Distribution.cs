using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBankApp.Models;

[Table("distributions")]
public class Distribution
{
    [Key]
    [Column("id_distribution")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("hopital")]
    [MaxLength(160)]
    public string Hopital { get; set; } = string.Empty;

    [Column("identifiant_receveur")]
    [MaxLength(60)]
    public string IdentifiantReceveur { get; set; } = string.Empty;

    [Column("nom_receveur")]
    [MaxLength(120)]
    public string NomReceveur { get; set; } = string.Empty;

    [Column("groupe_sanguin_receveur")]
    public GroupeSanguin GroupeSanguinReceveur { get; set; }

    [Column("compatibilite_validee")]
    public bool CompatibiliteValidee { get; set; }

    [Column("date_distribution")]
    public DateTime DateDistribution { get; set; }

    [Column("composant_id")]
    public Guid ComposantId { get; set; }

    public ComposantSanguin? Composant { get; set; }
}
