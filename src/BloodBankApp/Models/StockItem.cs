using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBankApp.Models;

[Table("stock")]
public class StockItem
{
    [Key]
    [Column("id_stock")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("type_composant")]
    public TypeComposant TypeComposant { get; set; }

    [Column("groupe_sanguin")]
    public GroupeSanguin GroupeSanguin { get; set; }

    [Column("quantite")]
    public int Quantite { get; set; }

    [Column("seuil_alerte")]
    public int SeuilAlerte { get; set; }

    [Column("statut_stock")]
    public StatutStock StatutStock { get; set; } = StatutStock.Disponible;
}
