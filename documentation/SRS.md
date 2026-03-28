# Cahier des charges (SRS léger) — <Nom du projet>
**Équipe :** Ahmad Errekab, Akram Boughlala
**Date :** 2026.01.25
**Version :** v1.0

---

## 1. Contexte & objectif
Contexte :
La gestion d’un club de football amateur ou semi-professionnel repose souvent sur des outils non centralisés (papier, fichiers Excel, messages). Cela rend difficile le suivi des joueurs, des entraîneurs et des entraînements.

Objectif principal :
L’objectif du projet ClubManager est de fournir une application simple permettant de gérer un seul club de football, en centralisant les informations liées aux joueurs, aux entraîneurs et aux entraînements, afin de faciliter l’organisation interne du club.

Parties prenantes :
Gestionnaire du club, entraîneur principal, entraîneur assistant.

---

## 2. Portée (Scope)
### 2.1 Inclus (IN)
IN-1 : Gestion des informations du club (fiche unique)

IN-2 : Gestion des joueurs (ajout, modification, suppression)

IN-3 : Gestion des entraîneurs et de leurs rôles

IN-4 : Création et gestion des entraînements

IN-6 : Consultation de rapports simples (présence, effectif)

### 2.2 Exclu (OUT)

OUT-1 : Gestion de plusieurs clubs
OUT-2 : Gestion financière (salaires, budget, facturation)
OUT-3 : Application mobile
OUT-4 : Intégration avec des systèmes externes (fédération, API)
OUT-5 : Gestion complète des ressources humaines
OUT-6 : Analyse avancée avec intelligence artificielle

---

## 3. Acteurs / profils utilisateurs
Acteur A : Gestionnaire du club :
Rôle : gère l’application et les données du club.
Besoins : ajouter/modifier/supprimer les joueurs et les entraîneurs, créer des entraînements, consulter les statistiques.
Contraintes : veut une interface simple, rapide, sans étapes complexes.

Acteur B : Entraîneur :
Rôle : suit les joueurs et l’organisation des entraînements.
Besoins : consulter la liste des joueurs, voir le détail d’un joueur, consulter les rapports (statistiques).
Contraintes : accès limité (pas forcément suppression totale selon la politique du club).
---

## 4. Exigences fonctionnelles (FR)
FR-1 : Le système doit permettre de gérer les informations du club (fiche unique).

FR-2 : Le système doit permettre d’ajouter, modifier et supprimer un joueur.

FR-3 : Le système doit permettre d’ajouter, modifier et supprimer un entraîneur.

FR-4 : Le système doit permettre d’afficher la liste des joueurs avec recherche ou filtre (poste, statut).

FR-5 : Le système doit permettre d’afficher la fiche détaillée d’un joueur lorsqu’on le sélectionne (infos + statistiques).

FR-6 : Le système doit calculer et afficher les statistiques d’entraînement d’un joueur (présences, absences, retards, taux de présence).

FR-7 : Le système doit générer un rapport simple : top joueurs les plus présents + liste des joueurs absents fréquents.

FR-8 : Le système doit permettre d’enregistrer un match et mettre à jour les statistiques de match d’un joueur (buts, passes, minutes, cartons).

---

## 5. Exigences non fonctionnelles (NFR)
NFR-1 (Performance) : Le temps de réponse pour les actions principales doit être inférieur à 2 secondes.

NFR-2 (Sécurité) : L’accès au système est réservé aux utilisateurs autorisés (gestionnaire / entraîneur).

NFR-3 (UX) : L’interface doit être simple et compréhensible pour un utilisateur non technique.

NFR-4 (Qualité) : Le code doit être structuré et documenté pour faciliter la maintenance.

---

## 6. Contraintes
- **C-1 (Technologie) :** <C# avec Windows Forms ado.netet SQL Server>
- **C-2 (Plateforme) :** < Application Web>
- **C-3 (Délai) :** < Projet réalisé durant la session Hiver 2026 (15 semaines)>
- **C-4 (Outils) :** < Visual Studio, GitHub, Draw.io>

---

## 7. Données & règles métier (si applicable)
Entités principales : Club, Joueur, Entraîneur, Entraînement, Présence, StatistiquesJoueur.

Règles métier :
RM-1 : Un seul club est géré dans l’application.

RM-2 : Chaque joueur possède un numéro unique dans l’effectif.

RM-3 : Un match contient une date, une heure et un type.

RM-4 : Le taux de présence est calculé selon la formule :
(Nombre de présences / Nombre total d’entraînements) × 100.

---

## 8. Hypothèses & dépendances
### 8.1 Hypothèses
H-1 : Les utilisateurs (gestionnaire/entraîneur) ont accès à l’application sur un PC.

H-2 : Les données sont gérées localement (base de données locale ou fichiers selon la technologie du cours).

### 8.2 Dépendances

D-1 : Un système de stockage (BD locale ou fichiers) est disponible pour enregistrer joueurs/entraînements/statistiques.

D-2 : Les outils de développement requis sont installés (IDE, librairies du cours).

---

## 9. Critères d’acceptation globaux (Definition of Done – mini)
Gestion des joueurs, entraîneurs et entraînements fonctionnelle

 Fiche joueur affichant ses statistiques 

 Rapports simples  disponibles

 Tests basiques réalisés

 Gestion d’erreurs minimale (champs obligatoires, formats)

 Documentation à jour (UML )
