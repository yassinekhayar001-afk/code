using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBankApp.Models;

[Table("composants_sanguins")]
public class ComposantSanguin
{
    [Key]
    [Column("id_composant")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("code_barres_composant")]
    [MaxLength(60)]
    public string CodeBarresComposant { get; set; } = string.Empty;

    [Column("type_composant")]
    public TypeComposant TypeComposant { get; set; }

    [Column("volume_ml")]
    public int VolumeMl { get; set; }

    [Column("date_preparation")]
    public DateOnly DatePreparation { get; set; }

    [Column("date_expiration")]
    public DateOnly DateExpiration { get; set; }

    [Column("conditions_stockage")]
    [MaxLength(160)]
    public string ConditionsStockage { get; set; } = string.Empty;

    [Column("don_id")]
    public Guid DonId { get; set; }

    public Don? Don { get; set; }

    public ICollection<TestSerologique> Tests { get; set; } = new List<TestSerologique>();
}
