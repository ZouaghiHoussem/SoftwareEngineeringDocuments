 1. Introduction

Dans le cadre de ce projet, nous avons développé une application web nommée ClubManager.
L’objectif est de simuler un système réel de gestion d’un club de football.

Cette application permet de gérer plusieurs éléments essentiels :

les joueurs
les entraîneurs
les entraînements

Nous avons aussi intégré des règles métier pour rendre le système plus réaliste, comme la gestion des joueurs blessés et l’organisation des séances d’entraînement.

 2. Architecture générale du projet

Le projet est développé avec :

ASP.NET Web Forms
C#
SQL Server

L’architecture suit une logique simple :

Page ASPX (interface)
↓
Code Behind (.aspx.cs)
↓
ClubFacade (logique métier)
↓
DbSingleton (accès base de données)
↓
SQL Server

 Cette séparation permet :

une meilleure organisation
une maintenance plus facile
un code plus propre
 3. Gestion des utilisateurs et authentification

Le système possède une table Utilisateurs contenant :

Username
Password
Role

Lorsqu’un utilisateur se connecte :

Il entre ses informations
Le système vérifie dans la base de données
Le rôle est récupéré
L’utilisateur est redirigé vers :
Admin → DashboardAdmin
Entraîneur → DashboardEntraineur

 Cette logique est implémentée dans :

Login.aspx.cs
ClubFacade
DbSingleton
 4. Gestion des joueurs

Le module de gestion des joueurs permet de :

Ajouter un joueur
Modifier ses informations
Supprimer un joueur
Rechercher un joueur

Chaque joueur possède les attributs suivants :

Id
Nom
Prenom
Age
Poste
Numero
Etat
 État du joueur

L’attribut Etat est essentiel dans notre système :

Actif
Blessé

 Ce champ est utilisé pour contrôler la participation du joueur aux entraînements.

 5. Gestion des entraîneurs

Le module entraîneur permet :

Ajouter un entraîneur
Modifier ses informations
Supprimer un entraîneur

Chaque entraîneur possède :

Id
Nom
Prenom
Specialite
Experience
Username

 Le champ Username permet de relier l’entraîneur avec son compte utilisateur.

 6. Gestion des entraînements

Les entraîneurs peuvent gérer leurs propres séances.

Fonctionnalités :

Ajouter une séance
Supprimer une séance
Consulter leurs séances

Chaque entraînement contient :

DateSeance
Heure
Lieu
TypeEntrainement
CoachId
 7. Assignation des joueurs aux entraînements

Nous avons implémenté une relation many-to-many entre :

Joueur ↔ Entrainement

 Cette relation est gérée par la table :

EntrainementJoueurs

Contenant :

EntrainementId
JoueurId
 Fonctionnement

Lorsqu’un entraîneur crée une séance :

Il sélectionne plusieurs joueurs
Le système crée l’entraînement
Il récupère l’ID de la séance
Il enregistre chaque joueur dans la table relationnelle

 Cette logique est gérée dans :

GestionEntrainements.aspx.cs
ClubFacade
DbSingleton
 8. Gestion des joueurs blessés (règle métier)

Une règle importante a été ajoutée :

 Un joueur blessé ne peut pas être sélectionné

 Implémentation

Dans la méthode :

ChargerJoueurs()

Nous faisons :

if (etat == "Blessé")
{
    item.Enabled = false;
}

 Résultat :

Le joueur apparaît avec “(Blessé)”
Il est désactivé
Impossible de le sélectionner

 Cela améliore la cohérence du système.

 9. Validation des données

Nous avons ajouté plusieurs validations :

 Validation formulaire
Champs obligatoires
Format de la date
 Validation métier
Conflit d’entraînement (même heure)
Joueur blessé interdit
Coach valide obligatoire

Ces validations garantissent :

la cohérence des données
la fiabilité du système
 10. Gestion des suppressions (problème résolu)

Lors de la suppression d’un entraînement, une erreur est apparue.

 Cause :

EntrainementJoueurs dépend de Entrainements
 Solution

Nous avons modifié la méthode :

DeleteTraining()

pour :

Supprimer d’abord les relations
Puis supprimer l’entraînement

 Cela respecte l’intégrité référentielle.

 11. Design Patterns utilisés
 Singleton

Utilisé dans :

DbSingleton.cs

 Permet :

une seule connexion
éviter duplication
améliorer performance
 Facade

Utilisé dans :

ClubFacade.cs

 Permet :

simplifier les appels
centraliser la logique
réduire la complexité
Factory

Utilisé dans :

UserRoleFactory.cs

 Permet :

gérer les rôles
redirection automatique
code flexible
 12. Base de données

Tables utilisées :

Utilisateurs
Joueurs
Entraineurs
Entrainements
EntrainementJoueurs

Relations :

Entraineur → Entrainements (1..*)
Entrainement → Joueurs (*..*)

 13. Conclusion

Ce projet nous a permis de :

comprendre la gestion d’un système complet
utiliser une base de données relationnelle
appliquer des design patterns
implémenter des règles métier

Nous avons aussi amélioré la qualité du projet en ajoutant des validations et une logique réaliste.
