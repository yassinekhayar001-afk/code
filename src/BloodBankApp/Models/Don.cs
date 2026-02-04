using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBankApp.Models;

[Table("dons")]
public class Don
{
    [Key]
    [Column("id_don")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("date_heure_collecte")]
    public DateTime DateHeureCollecte { get; set; }

    [Column("type_don")]
    public TypeDon TypeDon { get; set; }

    [Column("volume_ml")]
    public int VolumeMl { get; set; }

    [Column("code_barres_poche")]
    [MaxLength(60)]
    public string CodeBarresPoche { get; set; } = string.Empty;

    [Column("site_collecte")]
    [MaxLength(120)]
    public string SiteCollecte { get; set; } = string.Empty;

    [Column("operateur_collecte")]
    [MaxLength(120)]
    public string OperateurCollecte { get; set; } = string.Empty;

    [Column("donneur_id")]
    public Guid DonneurId { get; set; }

    public Donneur? Donneur { get; set; }

    public ICollection<ComposantSanguin> Composants { get; set; } = new List<ComposantSanguin>();
}
