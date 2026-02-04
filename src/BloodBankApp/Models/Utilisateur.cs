using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBankApp.Models;

[Table("utilisateurs")]
public class Utilisateur
{
    [Key]
    [Column("id_utilisateur")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("nom_utilisateur")]
    [MaxLength(80)]
    public string NomUtilisateur { get; set; } = string.Empty;

    [Column("nom_complet")]
    [MaxLength(120)]
    public string NomComplet { get; set; } = string.Empty;

    [Column("role")]
    public RoleUtilisateur Role { get; set; }

    [Column("actif")]
    public bool Actif { get; set; } = true;
}
