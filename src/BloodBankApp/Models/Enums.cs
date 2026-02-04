namespace BloodBankApp.Models;

public enum Sexe
{
    Inconnu = 0,
    Femme = 1,
    Homme = 2
}

public enum TypeDon
{
    SangTotal = 0,
    Apherese = 1
}

public enum GroupeSanguin
{
    APositif,
    ANegatif,
    BPositif,
    BNegatif,
    ABPositif,
    ABNegatif,
    OPositif,
    ONegatif
}

public enum TypeComposant
{
    GlobulesRouges,
    Plasma,
    Plaquettes
}

public enum StatutStock
{
    Disponible,
    Reserve,
    EnQuarantaine,
    Expire,
    Detruit
}

public enum StatutTest
{
    EnAttente,
    Conforme,
    NonConforme
}

public enum RoleUtilisateur
{
    Administrateur,
    Biologiste,
    Technicien,
    Lecteur
}

public enum StatutAptitude
{
    Apte,
    InapteTemporaire,
    InapteDefinitif
}
