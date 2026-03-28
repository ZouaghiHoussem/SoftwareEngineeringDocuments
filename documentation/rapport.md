# Rapport des Diagrammes UML  
## Projet : Gestion d’un Club de Football (FCB)

---

## 1. Diagramme de Classes

Le diagramme de classes représente la structure interne du système.  
Il montre les principales entités du projet ainsi que leurs attributs, méthodes et relations.

Les classes principales sont :

- **Club**
- **Joueur**
- **Entraineur**
- **Match**
- **Entrainement**
- **StatMatch**

La classe **Club** est l’élément central du système.  
Un club contient plusieurs joueurs, entraîneurs, matchs et entraînements.  
Cela permet d’organiser toutes les informations autour d’une seule entité principale.

La classe **Joueur** contient les informations personnelles du joueur (nom, prénom, numéro, date de naissance, poste) ainsi que certaines méthodes comme le calcul de l’âge ou la validation des données.

La classe **Match** représente un match joué par le club avec sa date, son adversaire et son lieu.  
Les statistiques individuelles des joueurs pendant un match sont stockées dans la classe **StatMatch** (buts, passes, minutes jouées, cartons, etc.).

La classe **Entraineur** contient les informations liées aux entraîneurs du club.

Ce diagramme permet de comprendre :
- La structure des données
- Les relations entre les entités
- La logique métier du système

Il sert de base pour la conception de la base de données et du code.

---

## 2. Diagramme de Composants

Le diagramme de composants représente l’architecture globale de l’application.

Le système est structuré en plusieurs couches :

- **Frontend (Web Client / Browser)**
- **Application ASP.NET (UI)**
- **Business Layer (Services)**
- **DAO Layer (ADO.NET)**
- **Base de données SQL Server**

Le navigateur envoie des requêtes HTTP/HTTPS vers l’application ASP.NET.  
L’application appelle ensuite la couche Business qui contient la logique métier.

La couche DAO est responsable des opérations CRUD (Create, Read, Update, Delete) et communique directement avec la base de données SQL Server.

Un module d’authentification est également présent pour gérer la sécurité (connexion, rôles).  
Un système de logging permet d’enregistrer les erreurs.

Cette architecture en couches permet :

- Une séparation claire des responsabilités
- Une meilleure maintenance du code
- Une sécurité renforcée
- Une organisation professionnelle du projet

---

## 3. Diagramme de Cas d’Utilisation

Le diagramme de cas d’utilisation montre les interactions entre les utilisateurs et le système.

Deux acteurs principaux sont identifiés :

- **Gestionnaire du club**
- **Entraîneur**

Le gestionnaire peut :
- Gérer les informations du club
- Gérer les entraîneurs
- Gérer les joueurs
- Enregistrer un match
- Gérer les rapports

L’entraîneur peut :
- Consulter la liste des joueurs
- Consulter la fiche d’un joueur
- Rechercher un joueur
- Mettre à jour les statistiques d’un match

L’authentification est requise pour accéder aux fonctionnalités du système.

Certaines fonctionnalités incluent d’autres actions, par exemple :
- Gérer les rapports inclut le calcul des statistiques des joueurs.
- Enregistrer un match inclut la mise à jour des statistiques.


##Modification de ADR et SRS
nous avons modifié le fichier ADR afin de corriger les sections qui n’étaient pas complètes et pour qu’il corresponde mieux à notre projet réel.

Premièrement, nous avons complété la section Contraintes, en ajoutant les contraintes techniques et de temps, comme l’utilisation du langage C#, Visual Studio et ADO.NET, ainsi que le fait que le projet est réalisé par une petite équipe avec un temps limité.

Deuxièmement, nous avons clarifié la décision architecturale, en précisant que nous utilisons une application Desktop avec Windows Forms et ADO.NET, et nous avons expliqué pourquoi ce choix est plus adapté à notre projet, surtout pour faciliter le développement rapide et la gestion de l’interface.

Troisièmement, nous avons ajouté et complété la section Alternatives, en expliquant une autre option possible comme ASP.NET WebForms, avec ses avantages et ses inconvénients, afin de montrer que nous avons analysé d’autres solutions avant de faire notre choix.

Quatrièmement, nous avons complété la section Conséquences, en ajoutant les impacts positifs, comme la simplicité et la rapidité de développement, ainsi que les risques, comme le fait que l’application est limitée à un environnement Windows.

Cinquièmement, nous avons complété la section Validation, en expliquant comment vérifier que la décision fonctionne correctement, par exemple si l’application démarre sans erreur, si l’utilisateur peut se connecter et si les données sont bien récupérées depuis la base de données.

Enfin, nous avons ajouté les liens vers les diagrammes UML et les fichiers du projet, afin que le correcteur puisse facilement comprendre l’architecture et la décision prise.
