# Architecture Decision Records ADR-<NN> —
**Statut :** Proposed 
**Date :** 2026-02-14
**Décideurs :**  
**Contexte projet :** Foot Academy App

---

## 1. Contexte
Problème / besoin : Déterminer la meilleure technologie pour développer une application simple permettant aux joueurs d’envoyer leurs candidatures et au coach de les gérer.
Contraintes : Temps limité, projet académique, simplicité de développement, technologies vues en cours.
Forces en présence : Simplicité, rapidité de développement, facilité de déploiement, maintenabilité.

---

## 2. Décision
Nous avons choisi une solution simple et efficace adaptée au contexte académique.
Nous choisissons : une application Web avec PHP, MySQL et JavaScript
Pour : faciliter le développement rapide et l’accès depuis n’importe quel navigateur

---

## 3. Alternatives considérées
Option A — Application mobile (Android)
Avantages :
Expérience utilisateur plus fluide
Utilisation des fonctionnalités mobiles
Inconvénients :
Développement plus long
Plus complexe pour un projet court
Option B — Application Web (PHP + MySQL)
Avantages :
Simple à développer
Accessible sur tous les appareils
Compatible avec les technologies du cours
Inconvénients :
Moins performante qu’une application native
Interface parfois plus basique

---

## 4. Justification (Pourquoi cette décision ?)
Le projet doit être simple et réalisable rapidement
Les technologies sont déjà maîtrisées (PHP, SQL)
L’application doit être accessible facilement sans installation

---

## 5. Conséquences
### Positives
Développement rapide
Facilité de test et de déploiement
Compatible avec plusieurs appareils

### Négatives / Risques
Interface utilisateur limitée
Gestion des fichiers (vidéos) plus complexe côté serveur

### Impact sur l’architecture / le code
Architecture web classique (frontend + backend + base de données)
Utilisation de formulaires HTML et traitement PHP
Stockage des données dans MySQL

---

## 6. Plan d’implémentation (court)
 Étape 1 : Créer la base de données
 Étape 2 : Développer le formulaire de candidature
 Étape 3 : Implémenter le tableau de bord du coach

---

## 7. Validation
- **Comment vérifier que c’est bon ?**
Le formulaire fonctionne correctement
Les données sont enregistrées en base
Le coach peut voir et gérer les demandes

---

## 8. Liens
UML : diagramme_classes.png
Issue/Tâche : backlog_projet.md
Référence : Notes de cours développement web
