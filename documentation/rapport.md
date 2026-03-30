# Rapport du projet — FCB ClubManager
## 1. Présentation du projet
Le projet **FCB ClubManager** est une application web développée en **ASP.NET WebForms** avec une base de données **SQL Server LocalDB**.  
L’objectif principal de cette application est de faciliter la gestion d’un club de football en centralisant plusieurs fonctionnalités importantes dans une seule plateforme.
Le système permet de gérer :
- l’authentification des utilisateurs,
- les joueurs,
- les entraîneurs,
- les entraînements,
- ainsi qu’une interface adaptée selon le rôle de l’utilisateur.
Le projet a été conçu de manière progressive, en commençant par la connexion, puis en ajoutant les différentes fonctionnalités métiers, le design graphique, et enfin plusieurs **patrons de conception** demandés dans le cadre du cours.
---
## 2. Objectif du projet
L’objectif du projet est de proposer une application simple mais organisée pour la gestion interne d’un club de football.
À travers cette application, nous voulions :
- sécuriser l’accès grâce à un système de connexion,
- permettre à l’administrateur de gérer les éléments principaux du club,
- séparer les rôles entre administrateur et entraîneur,
- structurer le projet avec des patrons de conception,
- améliorer la lisibilité et la maintenance du code,
- proposer une interface moderne et claire.
---
## 3. Technologies utilisées
Le projet a été réalisé avec les technologies suivantes :
- **ASP.NET WebForms**
- **C#**
- **SQL Server LocalDB**
- **HTML / CSS / JavaScript**
- **Visual Studio**
- **GitHub** pour la gestion du dépôt
---
## 4. Structure générale du projet
Le projet a été organisé de manière à séparer les responsabilités entre les différentes parties du système.
### Structure principale
- `App_Code` : contient la logique centrale de l’application
- `App_Data` : contient la base de données locale
- `Assets` : contient les fichiers CSS, JavaScript et images
- `Command` : contient le patron Command
- `Observer` : contient le patron Observer
- `State` : contient le patron State
- pages `.aspx` : interface utilisateur
- fichiers `.cs` : logique associée aux pages
Cette organisation a permis d’obtenir un projet plus clair, plus professionnel, et plus facile à expliquer.
---
## 5. Fonctionnalités réalisées
## 5.1 Authentification
La première fonctionnalité développée a été la connexion des utilisateurs.
Une page `Login.aspx` a été créée afin de :
- saisir le nom d’utilisateur,
- saisir le mot de passe,
- vérifier les informations dans la base de données,
- récupérer le rôle de l’utilisateur,
- rediriger vers le bon dashboard.
Le système distingue actuellement deux rôles :
- **Admin**
- **Entraîneur**
Lorsque la connexion réussit :
- le nom d’utilisateur est stocké dans la session,
- le rôle est stocké dans la session,
- l’utilisateur est redirigé vers la page correspondant à son rôle.
Cette fonctionnalité permet donc de sécuriser l’accès à l’application et d’adapter l’interface selon le type d’utilisateur.
---
## 5.2 Dashboard Administrateur
Le dashboard administrateur a été réalisé pour donner accès aux fonctionnalités principales du projet.
Depuis cette page, l’administrateur peut accéder à :
- la gestion des joueurs,
- la gestion des entraîneurs,
- la gestion des entraînements,
- la déconnexion.
La page vérifie également que l’utilisateur connecté possède bien le rôle `Admin`.  
Si ce n’est pas le cas, il est redirigé vers la page de connexion.
Cette vérification garantit que les fonctions d’administration restent protégées.
---
## 5.3 Dashboard Entraîneur
Un dashboard entraîneur a également été créé comme base d’interface spécifique au rôle entraîneur.
Cette page contient :
- l’affichage du nom de l’utilisateur connecté,
- une interface dédiée au rôle entraîneur,
- la déconnexion,
- la vérification de session et du rôle.
Même si cette partie reste encore à enrichir fonctionnellement, elle a été mise en place pour assurer la séparation des rôles dans l’application.
---
## 5.4 Gestion des joueurs
La gestion des joueurs est l’une des parties centrales du projet.
Une page `GestionJoueurs.aspx` a été développée pour permettre :
- l’ajout d’un joueur,
- la modification d’un joueur,
- la suppression d’un joueur,
- l’affichage de la liste des joueurs,
- la sélection d’un joueur pour modification.
Chaque joueur possède plusieurs informations :
- nom,
- prénom,
- âge,
- poste,
- numéro,
- état.
La page contient :
- un formulaire pour saisir ou modifier les informations,
- un `GridView` pour afficher la liste des joueurs,
- des boutons d’action pour ajouter, modifier, annuler ou supprimer.
Cette fonctionnalité a été importante car elle a servi de base pour intégrer plusieurs patrons de conception, notamment **Command** et **State**.
---
## 5.5 Gestion des entraîneurs
Une page `GestionEntraineurs.aspx` a été développée pour gérer les entraîneurs du club.
Les opérations disponibles sont :
- ajouter un entraîneur,
- modifier un entraîneur,
- supprimer un entraîneur,
- afficher la liste des entraîneurs,
- sélectionner un entraîneur pour modification.
Chaque entraîneur possède :
- nom,
- prénom,
- spécialité,
- expérience.
Comme pour les joueurs, la gestion des entraîneurs repose sur :
- un formulaire,
- un tableau d’affichage,
- une logique de validation,
- une protection par session et rôle.
---
## 5.6 Gestion des entraînements
Une page `GestionEntrainements.aspx` a été mise en place pour gérer les séances d’entraînement.
Cette fonctionnalité permet :
- d’ajouter une séance,
- de supprimer une séance,
- d’afficher la liste des séances,
- de choisir l’entraîneur responsable.
Chaque séance contient :
- la date,
- l’heure,
- le lieu,
- le type d’entraînement,
- l’entraîneur associé.
Cette partie a également permis d’intégrer le patron **Observer**, grâce à un système simple de notifications lorsqu’une séance est ajoutée ou supprimée.
---
## 6. Base de données
La base de données contient plusieurs tables principales :
- `Utilisateurs`
- `Joueurs`
- `Entraineurs`
- `Entrainements`
### Table Utilisateurs
Elle sert à stocker :
- le nom d’utilisateur,
- le mot de passe,
- le rôle.
Elle est utilisée pour la connexion.
### Table Joueurs
Elle contient les informations sur les joueurs du club.
### Table Entraineurs
Elle contient les informations sur les entraîneurs.
### Table Entrainements
Elle contient les séances d’entraînement, avec une liaison vers un entraîneur.
La base de données est manipulée à travers la classe `DbSingleton`.
---
## 7. Patrons de conception utilisés
L’un des objectifs du projet était d’intégrer plusieurs patrons de conception vus en cours.  
Nous avons utilisé les patrons suivants :
- Singleton
- Facade
- Command
- State
- Observer
---
## 7.1 Patron Singleton
Le patron **Singleton** a été utilisé dans la classe `DbSingleton`.
### Rôle dans le projet
Cette classe centralise l’accès à la base de données.  
Elle contient une seule instance partagée dans toute l’application.
### Pourquoi ce choix
Nous voulions éviter la création répétée de plusieurs objets pour l’accès à la base de données.
### Ce que cela apporte
- centralisation de la logique de base de données,
- réduction de la duplication du code,
- meilleure organisation,
- accès unique à la base.
### Exemple dans le projet
La classe `DbSingleton` est utilisée pour :
- récupérer un utilisateur,
- récupérer les joueurs,
- ajouter un joueur,
- modifier un joueur,
- supprimer un joueur,
- récupérer les entraîneurs,
- gérer les entraînements.
---
## 7.2 Patron Facade
Le patron **Facade** a été utilisé avec la classe `ClubFacade`.
### Rôle dans le projet
Cette classe sert d’intermédiaire entre les pages WebForms et la classe `DbSingleton`.
Au lieu d’appeler directement la base de données dans chaque page, les pages utilisent la façade.
### Pourquoi ce choix
Nous voulions simplifier les appels aux fonctionnalités principales et éviter que les pages deviennent trop dépendantes de la logique d’accès aux données.
### Ce que cela apporte
- simplifie les appels depuis les pages,
- réduit le couplage,
- centralise les fonctionnalités principales,
- rend le projet plus lisible.
### Exemple dans le projet
`ClubFacade` contient des méthodes comme :
- `LoginUser`
- `GetPlayers`
- `AddPlayer`
- `UpdatePlayer`
- `DeletePlayer`
- `GetCoaches`
- `AddTraining`
---
## 7.3 Patron Command
Le patron **Command** a été utilisé dans la gestion des joueurs.
### Fichiers concernés
- `ICommand.cs`
- `AddPlayerCommand.cs`
- `UpdatePlayerCommand.cs`
- `DeletePlayerCommand.cs`
### Rôle dans le projet
Au lieu d’exécuter directement les actions sur les joueurs dans la page, nous avons encapsulé chaque action dans une classe distincte.
### Pourquoi ce choix
Nous voulions mieux séparer les actions métiers du reste de la page.
### Ce que cela apporte
- meilleure organisation du code,
- actions clairement séparées,
- plus grande flexibilité,
- possibilité d’étendre facilement le système plus tard.
### Exemple
- ajout d’un joueur → `AddPlayerCommand`
- modification d’un joueur → `UpdatePlayerCommand`
- suppression d’un joueur → `DeletePlayerCommand`
---
## 7.4 Patron State
Le patron **State** a été utilisé pour gérer l’état du joueur.
### Fichiers concernés
- `IPlayerState.cs`
- `ActiveState.cs`
- `InjuredState.cs`
- `SuspendedState.cs`
- `UnavailableState.cs`
- `PlayerStateFactory.cs`
### Rôle dans le projet
L’état d’un joueur n’est pas seulement un simple texte.  
Nous avons créé des classes spécifiques pour représenter les différents états possibles.
### États gérés
- Actif
- Blessé
- Suspendu
- Indisponible
### Pourquoi ce choix
Nous voulions une représentation plus propre et plus extensible des états du joueur.
### Ce que cela apporte
- logique métier plus claire,
- séparation entre les états,
- plus facile à faire évoluer,
- évite de tout gérer avec de simples chaînes de caractères.
---
## 7.5 Patron Observer
Le patron **Observer** a été utilisé dans la gestion des entraînements.
### Fichiers concernés
- `IObserver.cs`
- `ISubject.cs`
- `Notification.cs`
- `EntrainementSubject.cs`
### Rôle dans le projet
Lorsqu’une séance est ajoutée ou supprimée, une notification est automatiquement affichée.
### Pourquoi ce choix
Nous voulions mettre en place un mécanisme simple où un changement dans les entraînements entraîne automatiquement une mise à jour d’un autre élément : ici, le message de notification.
### Ce que cela apporte
- système plus dynamique,
- logique d’événements mieux séparée,
- notification automatique,
- bonne démonstration du patron Observer.
---
## 8. Interface et design
Au début, l’application contenait seulement des pages HTML très simples.  
Ensuite, nous avons amélioré l’interface graphique pour donner un aspect plus professionnel au projet.
### Éléments réalisés
- un seul fichier CSS global : `main.css`
- un seul fichier JavaScript global : `main.js`
- une image de fond de stade
- un style moderne de type glassmorphism
- une sidebar pour naviguer entre les pages
- une meilleure mise en page des formulaires et tableaux
### Résultat
L’interface est devenue :
- plus cohérente,
- plus moderne,
- plus agréable à utiliser,
- plus professionnelle pour une démonstration.
---
## 9. Organisation du dépôt GitHub
Le projet a également été organisé dans le dépôt GitHub de façon plus professionnelle.
Le code a été placé dans :
- `code/ClubManager/ClubManager`
La documentation a été placée dans :
- `documentation`
Cette organisation permet de :
- séparer le code de la documentation,
- rendre le dépôt plus propre,
- faciliter la lecture pour le professeur.
---
## 10. Difficultés rencontrées
Pendant le développement, plusieurs difficultés ont été rencontrées.
### Difficultés techniques
- configuration de la connexion à la base de données,
- gestion des chemins Git et GitHub,
- conflits Git lors des pushes,
- structure incorrecte du dépôt au début,
- placement du projet dans le bon dossier `/code`,
- gestion correcte des dates pour les entraînements,
- affichage correct des notifications dans WebForms.
### Difficultés de conception
- choisir quels patrons utiliser et où les placer,
- éviter d’utiliser les patrons de façon forcée,
- garder un projet simple tout en intégrant plusieurs patrons.
Ces difficultés ont été résolues progressivement, ce qui a permis d’améliorer la structure du projet.
---
## 11. Résultat final
À la fin de ce travail, nous avons obtenu une application qui permet :
- l’authentification des utilisateurs,
- la gestion des joueurs,
- la gestion des entraîneurs,
- la gestion des entraînements,
- une séparation entre le rôle administrateur et entraîneur,
- l’intégration de plusieurs patrons de conception,
- une interface plus professionnelle.
Le projet répond donc à la fois :
- aux besoins fonctionnels du sujet,
- et aux objectifs pédagogiques liés aux patrons de conception.
---
## 12. Conclusion
Le projet **FCB ClubManager** nous a permis de mettre en pratique plusieurs notions importantes vues dans le cours, à la fois sur le plan technique et architectural.
Nous avons pu :
- développer une application web fonctionnelle,
- structurer le code avec plusieurs patrons de conception,
- relier l’interface, la logique métier et la base de données,
- améliorer l’apparence de l’application,
- mieux comprendre l’intérêt réel des patrons dans un projet concret.
Ce projet nous a aussi aidés à travailler la logique de développement progressive, la résolution de problèmes et l’organisation d’un dépôt GitHub de manière plus professionnelle.
---
## 13. Améliorations possibles
Même si le projet est déjà fonctionnel, plusieurs améliorations peuvent encore être ajoutées dans le futur :
- enrichir davantage le dashboard entraîneur,
- ajouter une vraie affectation joueurs ↔ entraîneurs,
- ajouter une affectation joueurs ↔ entraînements,
- améliorer les notifications,
- ajouter d’autres patrons comme Factory, Adapter ou Decorator,
- améliorer encore la sécurité des mots de passe,
- nettoyer certains fichiers inutiles du dépôt.
---
## 14. Répartition générale des éléments réalisés
### Partie interface
- Login
- dashboards
- gestion joueurs
- gestion entraîneurs
- gestion entraînements
- design global
### Partie base de données
- utilisateurs
- joueurs
- entraîneurs
- entraînements
### Partie architecture
- Singleton
- Facade
- Command
- State
- Observer
### Partie dépôt
- organisation dans `/code`
- documentation séparée
- mise à jour sur GitHub
---
