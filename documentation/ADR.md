# Architecture Decision Records ADR-<NN> — <application de livraison>
**Statut :** Proposed | Accepted | Rejected | Superseded  
**Date :** <2026-10-8>  
**Décideurs :** <Smarley, Nathanael, Neeraj, Reda>  
**Contexte projet :** <application de livraison
 / module>

---

## 1. Contexte
- **Problème / besoin :** <Rechercher des produits, consulter les prix , leurs description, les reviews des personnes, commander ou ajouter au panier, et suivre la commande >
- **Contraintes :** Langue de coding (c sharp, javascript python ), catelogue d'items, Equipe de support
- **Forces en présence :** <qualité, performance, simplicité, risques>

---

## 2. Décision
> Décrire la décision en 1–3 phrases. 
- Nous choisissons : <Nous avons choisi de créer une application de web commerce en ligne.> 
- Pour : Cette solution permettra aux utilisateur de consulter des produits, de les ajouter au panier et de passer la commande.

---

## 3. Alternatives considérées
### Option A — <Application Web>
- **Avantages :** Accessible  sur un navigateur d'ordinateur ou telephone.
- **Inconvénients :** cetrain fonction sur mobile sont moins accesible

### Option B — <nom>
- **Avantages :** offre une expérience adaptée aux téléphones et peut utiliser certaines fonctions de l’appareil.  
- **Inconvénients :** demande plus de temps à développer et à maintenir

---

## 4. Justification (Pourquoi cette décision ?)
- <raison 1> Une application de web  est accessible pour des appareilles
- <raison 2> Une seule version permet de réduire le temps de maintenance et developpement
- <raison 3> Une application web permet aux utilisateur d'acceder aux catalogues rapidement, sans devoir telecharger

---

## 5. Conséquences
### Positives
- <...>
- Les utilisateurs peuvent accéder au système à partir d’un navigateur
    Amélioration de la communication avec les clients
  Fonctionne sur n'importe quel appareil

### Négatives / Risques
- <...>
- - Une connexion Internet sera nécessaire pour utiliser l’application.
    menaces de cybersécurité


### Impact sur l’architecture / le code
- <modules touchés, patterns concernés, refactoring prévu>
Le système devra inclure au minimum des modules pour le catalogue, le panier, les comptes clients, les commandes, le support client, ainsi que les conditions générales.

--- L'interface sera pensée pour un navigateur, et elle s'affichera correctement sur un ordinateur comme sur un téléphone. C'est ce que la plupart des gens utilisent.

L'application aura une interface utilisateur simple.

  

## 6. Plan d’implémentation (court)
- [ ] Étape 1 : Crée depot dans github
- [ ] Étape 2 : Developper les fonction principale(le catalogue de produits, la recherche, le panier et la création d’une commande simulée).
- [ ] Étape 3 : afficher l'etat de la commande

---

## 7. Validation
- **Comment vérifier que c’est bon ?**
  - <tests / métriques / critères d’acceptation>
  - Vérifier qu'un utilisateur peut consulter un produit, l'ajouter au panier et passer une commande de test.
    Vérifier que l'utilisateur peut consulter l'état de sa commande.
     Confirmer qu'aucun paiement réel n'est déclenché et qu'aucun suivi GPS ne se met en route.

---

## 8. Liens
- UML : <lien/nom de fichier>
- Issue/Tâche : <lien>
- Référence : <doc officiel / cours>
