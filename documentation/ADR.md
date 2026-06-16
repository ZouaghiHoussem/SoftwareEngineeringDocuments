# ADR-001 — Authentification centralisée avec Singleton (ASP.NET WebForms)

Date : 2026-01-25  
Décideurs : Ahmad Errekab, Akram Boughlala  
Projet : FCB ClubManager  

## 1) Contexte

### Problème / besoin
Le projet doit gérer une connexion (login) avec deux types d’utilisateurs : **Admin** et **Entraîneur (Coach)**.  
Après authentification, l’utilisateur doit être redirigé vers le bon tableau de bord (**DashboardAdmin** ou **DashboardCoach**).  
Nous voulons aussi éviter de dupliquer la logique d’authentification dans plusieurs pages.

### Contraintes
- Technologie imposée / utilisée : **ASP.NET WebForms (C#)**
- IDE : **Visual Studio 2022**
- Équipe : **2 personnes**
- Délai : **courte période (remise de phase 2)**
- Objectif qualité : code clair, responsabilités séparées, maintenable

### Forces en présence
- Réduire la duplication de code
- Centraliser la vérification des identifiants
- Garder une logique simple et compréhensible (niveau cours)

## 2) Décision

Nous décidons d’utiliser **un Singleton** (ex : `Singleton.cs`) pour centraliser la logique d’authentification et la gestion des informations de l’utilisateur connecté (rôle, identifiant, etc.), dans une application **ASP.NET WebForms** (ex : `login.aspx`).

## 3) Alternatives considérées

### Option A — Authentification directement dans `login.aspx` (code-behind)
**Avantages**
- Très rapide à écrire au début
- Moins de fichiers

**Inconvénients**
- Logique mélangée à l’interface (faible séparation des responsabilités)
- Difficile à réutiliser si on ajoute d’autres pages
- Plus de duplication si on refait la même vérification ailleurs


## 4) Justification (Pourquoi cette décision ?)

- Le Singleton permet de **centraliser** la logique d’authentification dans un seul endroit.
- Il aide à garder `login.aspx` plus simple : la page appelle une méthode de connexion, puis redirige selon le rôle.
- C’est un **patron de conception clair** à démontrer (exigence du projet : au moins un patron).
- Avec une petite équipe et un délai court, c’est un compromis simple : **moins de duplication** et plus de clarté.

## 5) Conséquences

### Positives
- Une seule source de vérité pour la connexion / rôle
- Moins de duplication de code
- Plus facile à faire évoluer (ex : ajouter un nouveau rôle plus tard)

### Négatives / Risques
- En Web, un Singleton mal utilisé peut causer des problèmes si on y stocke des données “globales” partagées entre utilisateurs.
- Risque : mélanger “état utilisateur connecté” et “état global application”.

### Mesure de mitigation (solution)
- Le Singleton doit contenir **la logique** (ex : valider les identifiants / récupérer le rôle).
- Les données propres à l’utilisateur connecté (rôle, id) doivent être stockées de façon sûre :  
  - soit dans `Session`,  
  - soit via des variables passées/retournées par les méthodes,  
  - et **pas** comme un état global partagé pour tous.

## 6) Impact sur l’architecture / le code

- `login.aspx` : interface + appel de la logique de connexion
- `Singleton.cs` : logique de validation (ex : `Connexion(username, password)`), retour du rôle
- Redirection :
  - Admin → `DashboardAdmin.aspx`
  - Coach → `DashboardCoach.aspx`

## 7) Plan d’implémentation (court)

1. Créer `login.aspx` + champs username/password + bouton connexion
2. Créer `Singleton.cs` + méthode d’authentification
3. Après validation, rediriger vers la page selon le rôle
4. Ajouter un contrôle minimal : message d’erreur si identifiants invalides

## 8) Validation (comment vérifier)

- Si identifiants corrects Admin → redirection vers Dashboard Admin
- Si identifiants corrects Coach → redirection vers Dashboard Coach
- Si identifiants incorrects → message d’erreur affiché, aucune redirection
- Le code de validation n’est pas dupliqué dans plusieurs pages

## 9) Liens

- Code : `login.aspx`, `Singleton.cs`
- Tableau Agile : Epic “Authentification des utilisateurs”
- Diagrammes (à référencer dans le rapport) : Diagrammes ([Classe](https://github.com/diowte/SoftwareEngineeringDocuments/blob/main/documentation/DiagrammeClasseFCB.drawio))  ,
- ([composant](https://github.com/diowte/SoftwareEngineeringDocuments/blob/main/documentation/DiagrammeComposantFCB.drawio)) , (([UseCase](https://github.com/diowte/SoftwareEngineeringDocuments/blob/main/documentation/DiagrammeUseCaseFCB.drawio))
