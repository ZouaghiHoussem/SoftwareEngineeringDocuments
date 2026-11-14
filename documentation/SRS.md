# Cahier des charges (SRS léger) — <Nom du projet>
**Équipe :** <Smarley, Nathanael, Neeraj, Reda, Hassan>  
**Date :** <2026 10 10>  
**Version :** <v0.1 / v2.0>

---

## 1. Contexte & objectif
- **Contexte :** Le projet : un prototype de boutique en ligne. Le client parcourt les produits, lit les avis, passe commande, puis suit l'état de sa commande.
- **Objectif principal :** Une application qui rassemble les étapes principales d'un achat en ligne, depuis la recherche d'un produit jusqu'au suivi de la commande.
- **Parties prenantes :** <utilisateurs, client, admin, etc.>

---

## 2. Portée (Scope)
Client: parcourt le catalogue, commande, puis suit l'avancement de ses commandes.
Vendeur: met ses produits en ligne et regarde les commandes qui le concernent.
Livreur: voit les livraisons qu'on lui a confiées et en met à jour l'état.
Administrateur: gère les comptes utilisateurs, surveille le catalogue et les commandes.
Équipe de développement: analyse les besoins, conçoit le prototype et le réalise dans le cadre du cours.
### 2.1 Inclus (IN)
IN-1 : Parcourir le catalogue et y chercher un produit.
IN-2 : Consulter le prix, la description et les avis d'un produit.
IN-3 : Mettre des produits au panier, puis changer les quantités.
IN-4: Valider une commande en indiquant une adresse de livraison.
IN-5: Retrouver ses commandes passées et suivre leur état.
IN-6: Côté vendeur : gérer les produits et consulter les commandes.
IN-7 : Côté livreur : faire avancer l'état d'une livraison.
IN-8: Simuler la confirmation d'un paiement, pour la démo.
IN-9:Ajouter de argent dans le solde du compte dans l'application
IN-10:Signaler un probleme
IN-11:Bannir un utilisateur 

### 2.2 Exclu (OUT)
OUT-1 : Effectuer un paiement réel ou stocker des données bancaires.
OUT-2 : Suivre un livreur en temps réel sur une carte.
OUT-3 : Piloter une livraison qui a vraiment lieu, ou s'engager sur des délais.
OUT-4 : Refabriquer tout ce que fait Amazon : recommandations poussées, abonnements, etc.

---

## 3. Acteurs / profils utilisateurs
- **Acteur A :** Client : parcourt les produits, les met au panier, passe commande et suit l'état de celle-ci. Pour commander, il lui faut un compte.
- **Acteur B :** Veudeur:ajoute ou modifie ses produits, et consulte les commandes qui le concernent.
- Acteur C, Livreur: retrouve les livraisons qui lui ont été attribuées et met à jour leur avancement.
- Acteur D, Administrateur: a la main sur les utilisateurs, les produits et les commandes.

---

## 4. Exigences fonctionnelles (FR)
FR-1 : Le client peut créer un compte et se connecter.
FR-2 : Le système affiche un catalogue de produits.
FR-3 : Le client peut rechercher un produit par critere.
FR-4 : Le client peut consulter les avis liés à un produit.
FR-5 : Le client peut ajouter un produit au panier, puis modifier ou retirer la quantité.
FR-6 : Le sous-total du panier est calculé et affiché avant la commande.
FR-7 : Le client confirme sa commande en fournissant une adresse de livraison.
FR-8 : Une confirmation de commande s'affiche, avec un paiement simulé : aucune transaction réelle n'est effectuée.
FR-9 : Le client peut consulter l'historique de ses commandes et leur état.
FR-10 : Le vendeur peut ajouter, modifier ou retirer ses produits du catalogue.
FR-11 :L'administrateur peut mettre en garde ou banir un client
FR-12:L'administrateur peut voir la liste total des produit vendu.
FR13:L'administrateur peut repondre au different signalement de la boutique
FR14:L'administrateur peut modifier les permissions
FR15: Le client peut signaler un vendeur
FR16: Le client peur donner son avis sur un produit

## 5. Exigences non fonctionnelles (NFR)
> Performance / sécurité / disponibilité / UX / maintenabilité…
- **NFR-1 (Performance) :**Dans un environnement de démonstration, les pages principales (catalogue, panier) doivent s'afficher en moins de 2 secondes.
- **NFR-2 (Sécurité) :**Les fonctions sensibles ne sont accessibles qu'après authentification, avec des contrôles adaptés au rôle de l'utilisateur.
- **NFR-3 (UX) :** L'interface doit rester simple et claire, pour qu'un utilisateur parcoure les produits et passe commande sans rencontrer de blocage.
- **NFR-4 (Qualité) :** L'application fonctionne sur les principaux navigateurs, aussi bien sur écran d'ordinateur que sur téléphone.
- **NFR-5 (Disponibilite) :** L'application annule lajout un article dans le pznier quil est indisponible
- NFR-6(UX) L'application affiche pour chaque produit son nom, prix,disponibilite et la description
---

## 6. Contraintes
- **C-1 (Technologie) :** Le langage et le framework seront ceux que l'équipe du cours autorise ou retient. Le choix reste à confirmer.
- **C-2 (Plateforme) :**Le prototype prendra la forme d'une application Web, accessible depuis un navigateur.
- **C-3 (Délai) :**  Le projet doit être réalisé et remis avant la date fixée par le cours.
- **C-4 (Outils) :** L'équipe utilisera Git pour conserver le code et suivre les changements.

---

## 7. Données & règles métier (si applicable)
- **Entités principales :**Le modèle de données comprend sept entités : Utilisateur, Produit, Panier, Article du panier, Commande, Article de commande, Avis et Livraison.
- **Règles métier :** La quantité d'un article est au minimum de un.
Le total d'une commande se calcule à partir des prix et des quantités des produits commandés.
Un client ne peut consulter que ses propres commandes.
Un livreur ne peut mettre à jour que les livraisons qui lui sont attribuées.
Un avis est toujours rattaché à un produit et à un utilisateur.
Les commandes et les livraisons servent de données de démonstration : leur état ne correspond pas à une livraison réelle.

---

## 8. Hypothèses & dépendances
### 8.1 Hypothèses
- H-1 :  utilisateurs ont un compte
- H-2 : Les utilisateurs disposent d'un accès à Internet et d'un navigateur.

### 8.2 Dépendances
- D-1 : : Le dépôt Git de l'équipe sera nécessaire pour partager et versionner le code.
- D-2 : Les données de démonstration et la méthode de stockage seront choisies par l'équipe.
    
---

## 9. Product Backlog

## 9.1 Critères d’acceptation globaux (Definition of Done – mini)
- [ ] Fonctionnalités livrées et testées
- [ ] Tests unitaires présents
- [ ] Gestion d’erreurs minimale
- [ ] Documentation à jour (UML + ADR si requis)
Product Backlog

## 9.2 User Stories
- [ ]En tant que client, je veux creer un compte, afin de regrouper lensemble de mes achats et produits favoris.
- [ ]En tant que client , je peux cherecher un produit, afin de lajouter dans mon panier achat.
- [ ]En tant que client , je peux consulter les avis d'un produit, afin d'avoir une idee et des recommandations avant l'achat.
- [ ]En tant que vendeur, je peux ajouter un produit à vendre,afin de me faire de l'argent.
- [ ]En tant que vendeur, je peux ajouter un produit à vendre,afin de faire un place chez moi.
- [ ]En tant que vendeur, je peux modifier les description de mon produit, afin de faire une mise à jour.
- [ ] En tant que administrateur, je peux mettre banir un vendeur, afin de le punir pour mauvais comportement
- [ ] En tant que administrateur, je peux repondre au signalement, afin de verifier les different problemes rencontrés par les utilisateur
  


