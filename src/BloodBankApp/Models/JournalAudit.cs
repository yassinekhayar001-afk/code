using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBankApp.Models;

[Table("journal_audit")]
public class JournalAudit
{
    [Key]
    [Column("id_audit")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("utilisateur")]
    [MaxLength(120)]
    public string Utilisateur { get; set; } = string.Empty;

    [Column("action")]
    [MaxLength(200)]
    public string Action { get; set; } = string.Empty;

    [Column("date_action")]
    public DateTime DateAction { get; set; }

    [Column("details")]
    [MaxLength(4000)]
    public string? Details { get; set; }
}
