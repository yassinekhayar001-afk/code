CREATE TABLE donneurs (
  id_donneur UUID PRIMARY KEY,
  identifiant_donneur VARCHAR(20) UNIQUE NOT NULL,
  nom_complet VARCHAR(120) NOT NULL,
  cin VARCHAR(20) NOT NULL,
  date_naissance DATE,
  sexe INTEGER NOT NULL,
  groupe_sanguin INTEGER NOT NULL,
  statut_aptitude INTEGER NOT NULL,
  notes_medicales VARCHAR(4000)
);

CREATE TABLE dons (
  id_don UUID PRIMARY KEY,
  date_heure_collecte TIMESTAMP NOT NULL,
  type_don INTEGER NOT NULL,
  volume_ml INTEGER NOT NULL,
  code_barres_poche VARCHAR(60) NOT NULL,
  site_collecte VARCHAR(120) NOT NULL,
  operateur_collecte VARCHAR(120) NOT NULL,
  donneur_id UUID NOT NULL REFERENCES donneurs(id_donneur)
);

CREATE TABLE composants_sanguins (
  id_composant UUID PRIMARY KEY,
  code_barres_composant VARCHAR(60) NOT NULL,
  type_composant INTEGER NOT NULL,
  volume_ml INTEGER NOT NULL,
  date_preparation DATE NOT NULL,
  date_expiration DATE NOT NULL,
  conditions_stockage VARCHAR(160) NOT NULL,
  don_id UUID NOT NULL REFERENCES dons(id_don)
);

CREATE TABLE tests_serologiques (
  id_test UUID PRIMARY KEY,
  nom_test VARCHAR(80) NOT NULL,
  resultat VARCHAR(120) NOT NULL,
  statut_validation INTEGER NOT NULL,
  biologiste_validateur VARCHAR(120),
  date_validation TIMESTAMP,
  composant_id UUID NOT NULL REFERENCES composants_sanguins(id_composant)
);

CREATE TABLE stock (
  id_stock UUID PRIMARY KEY,
  type_composant INTEGER NOT NULL,
  groupe_sanguin INTEGER NOT NULL,
  quantite INTEGER NOT NULL,
  seuil_alerte INTEGER NOT NULL,
  statut_stock INTEGER NOT NULL
);

CREATE TABLE distributions (
  id_distribution UUID PRIMARY KEY,
  hopital VARCHAR(160) NOT NULL,
  identifiant_receveur VARCHAR(60) NOT NULL,
  nom_receveur VARCHAR(120) NOT NULL,
  groupe_sanguin_receveur INTEGER NOT NULL,
  compatibilite_validee BOOLEAN NOT NULL,
  date_distribution TIMESTAMP NOT NULL,
  composant_id UUID NOT NULL REFERENCES composants_sanguins(id_composant)
);

CREATE TABLE incidents_hemovigilance (
  id_incident UUID PRIMARY KEY,
  date_incident TIMESTAMP NOT NULL,
  description_incident VARCHAR(4000) NOT NULL,
  gravite VARCHAR(60) NOT NULL,
  actions_correctives VARCHAR(2000),
  composant_id UUID REFERENCES composants_sanguins(id_composant)
);

CREATE TABLE utilisateurs (
  id_utilisateur UUID PRIMARY KEY,
  nom_utilisateur VARCHAR(80) NOT NULL,
  nom_complet VARCHAR(120) NOT NULL,
  role INTEGER NOT NULL,
  actif BOOLEAN NOT NULL
);

CREATE TABLE journal_audit (
  id_audit UUID PRIMARY KEY,
  utilisateur VARCHAR(120) NOT NULL,
  action VARCHAR(200) NOT NULL,
  date_action TIMESTAMP NOT NULL,
  details VARCHAR(4000)
);
