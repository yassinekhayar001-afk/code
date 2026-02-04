using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBankApp.Models;

[Table("incidents_hemovigilance")]
public class IncidentHemovigilance
{
    [Key]
    [Column("id_incident")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("date_incident")]
    public DateTime DateIncident { get; set; }

    [Column("description_incident")]
    [MaxLength(4000)]
    public string DescriptionIncident { get; set; } = string.Empty;

    [Column("gravite")]
    [MaxLength(60)]
    public string Gravite { get; set; } = string.Empty;

    [Column("actions_correctives")]
    [MaxLength(2000)]
    public string? ActionsCorrectives { get; set; }

    [Column("composant_id")]
    public Guid? ComposantId { get; set; }

    public ComposantSanguin? Composant { get; set; }
}
