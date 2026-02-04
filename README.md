# Banque de Sang - Centre de Transfusion (WPF .NET 8)

Application Windows de gestion d'un centre de transfusion sanguine, conçue avec WPF (.NET 8) et une architecture MVVM. L'interface et les données sont en français, et l'application couvre les modules métier essentiels du laboratoire de transfusion.

## Fonctionnalités principales
- **Gestion des donneurs** : identité, groupe sanguin, historique de dons, aptitude médicale.
- **Collecte de sang** : génération de codes-barres, traçabilité opérateur/site.
- **Transformation en composants** : GR, plasma, plaquettes, dates d'expiration.
- **Sérologie et dépistage** : VIH, VHB, VHC, syphilis, validation biologique.
- **Stock et distribution** : statut des unités, alertes de seuil, compatibilité.
- **Qualité et hémovigilance** : incidents, auditabilité.
- **Administration** : rôles et permissions (Admin, Biologiste, Technicien, Lecteur).

## Prérequis
- Windows 10/11
- .NET SDK 8.0
- PostgreSQL (optionnel) ou SQLite pour un démarrage local rapide

## Lancement rapide (SQLite)
1. Ouvrir le dossier `src/BloodBankApp` dans Visual Studio 2022.
2. Restaurer les packages NuGet.
3. Lancer l'application (F5).

## Télécharger le projet (ZIP)
Si vous n'avez pas encore le ZIP :
1. Ouvrez la page du dépôt du projet dans votre navigateur.
2. Cliquez sur **Code** → **Download ZIP**.
3. Décompressez le fichier ZIP dans un dossier facile à retrouver (ex. `Documents`).

## Où se trouve le dossier du projet ?
Si vous avez téléchargé un fichier ZIP, le dossier du projet est l'emplacement où vous l'avez **décompressé**. Vous devez y voir les dossiers `src`, `database` et `tests` ainsi que `README.md`.

Exemples d'emplacements courants sous Windows :
- `C:\Users\<VotreNom>\Documents\BloodBankApp`
- `C:\Users\<VotreNom>\Downloads\BloodBankApp`

Astuce : dans l'Explorateur Windows, utilisez la recherche et tapez **README.md** pour retrouver rapidement le dossier du projet.

## Configuration base de données
- Par défaut, l'application utilise **SQLite** : `banque_sang.db` (local).
- Pour PostgreSQL, remplacer `UseSqlite` dans `BanqueSangContextFactory` par `UseNpgsql` et fournir une chaîne de connexion.

## Architecture
- **Models** : entités EF Core (tables en français).
- **Data** : `DbContext`, factory de connexion et seed.
- **Services** : logique métier (dates d'expiration, collecte, alertes).
- **ViewModels** : MVVM, commandes et listes observables.
- **Views** : interface WPF/XAML.

## Jeux de données de démonstration
Des données de démonstration sont fournies dans `SeedData` pour faciliter la prise en main.

## Tests
- Tests unitaires pour les règles critiques (dates d'expiration, alertes stock).

## Schéma SQL
Le schéma PostgreSQL/SQLite est disponible dans `database/schema.sql`.

## Protection des données (GDPR)
- Journaux d'audit (qui, quoi, quand).
- Rôles et permissions.
- Traçabilité complète des produits.

## Licence
Projet interne - usage pédagogique et démonstration.
