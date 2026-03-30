# Cahier des charges (SRS léger) — <Foot Academy App>
**Équipe :** Foot Academy App  
**Date :** 2006-02-14  
**Version :** <v0.1 / v1.0>

---

## 1. Contexte & objectif
Contexte : L’académie de football reçoit actuellement les demandes de manière non structurée (messages, emails), ce qui rend la gestion difficile pour le coach.

Objectif principal : Centraliser les candidatures des joueurs avec leurs informations et vidéos, et permettre au coach de décider rapidement (accepter/refuser).

Parties prenantes :
Joueurs (candidats)
Coach (administrateur)
Académie

---

## 2. Portée (Scope)
### 2.1 Inclus (IN)
IN-1 : Formulaire d’inscription pour les joueurs
IN-2 : Upload de vidéos de football
IN-3 : Stockage des informations en base de données
IN-4 : Interface coach pour consulter les demandes
IN-5 : Acceptation ou refus des candidatures

### 2.2 Exclu (OUT)
OUT-1 : Paiement en ligne
OUT-2 : Gestion de plusieurs coachs
OUT-3 : Application mobile native

---

## 3. Acteurs / profils utilisateurs
Candidat (joueur) :
Envoie ses informations et vidéos
Consulte le statut de sa demande

Coach :
Consulte toutes les candidatures
Visionne les vidéos
Accepte ou refuse les demandes

---

## 4. Exigences fonctionnelles (FR)
FR-1 : Le système doit permettre à un joueur de soumettre une candidature.
FR-2 : Le système doit permettre l’envoi de vidéos.
FR-3 : Le système doit enregistrer les informations dans une base de données.
FR-4 : Le système doit permettre au coach de voir toutes les candidatures.
FR-5 : Le système doit permettre au coach d’accepter ou refuser une demande.
FR-6 : Le système doit afficher le statut de chaque demande.

---

## 5. Exigences non fonctionnelles (NFR)
NFR-1 (Performance) : Temps de réponse < 3 secondes
NFR-2 (Sécurité) : Accès au tableau de bord sécurisé (login coach)
NFR-3 (UX) : Interface simple et rapide (≤ 3 clics pour envoyer une demande)
NFR-4 (Qualité) : Application stable avec gestion d’erreurs de base


---

## 7. Données & règles métier (si applicable)
Entités principales :
User (nom, âge, email, position)
Video (fichier, taille, date)
Demande (statut : en attente / acceptée / refusée)

Règles métier :
Une demande doit contenir au moins une vidéo
Un joueur peut envoyer plusieurs vidéos
Seul le coach peut accepter ou refuser
Le statut initial est “en attente”

---

## 8. Hypothèses & dépendances
### 8.1 Hypothèses
H-1 : Les utilisateurs ont accès à internet
H-2 : Les vidéos sont dans un format standard (MP4)

### 8.2 Dépendances
D-1 : Base de données (MySQL)
D-2 : Serveur web (Apache / XAMPP)
D-3 : Stockage des fichiers vidéo

---

## 9. Critères d’acceptation globaux (Definition of Done – mini)
 Formulaire fonctionnel
 Upload de vidéos fonctionnel
 Données sauvegardées correctement
 Interface coach opérationnelle
 Acceptation/refus fonctionnel
 Gestion d’erreurs minimale
 Documentation complète disponible
