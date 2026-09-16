# Vue d’ensemble de la documentation du projet

Ce dépôt contient la documentation principale utilisée pour structurer et guider le projet logiciel tout au long de son cycle de vie.

## Documents inclus

### 1. Cahier des charges (Software Requirements Specification (SRS))
Ce document décrit **ce que le système doit faire**.  
Il définit :
- la portée du projet (fonctionnalités incluses et exclues),
- les exigences fonctionnelles,
- les exigences non fonctionnelles (performance, sécurité, facilité d’utilisation, etc.),
- les contraintes (plateforme, outils, échéances),
- les hypothèses et les dépendances.

La cahier des charges sert de **référence pour comprendre les exigences du système** et constitue la base des décisions de conception et de développement.
Un modèle du cahier des charges existe dans la documentation [cahier des charges SRS](documentation/SRS.md).

---

### 2. Registres des décisions d’architecture (Architecture Decision Record - ADR) 
Ce document consigne **pourquoi les principales décisions architecturales et techniques ont été prises**.

Chaque ADR présente :
- le contexte de la décision,
- la solution retenue,
- les solutions alternatives envisagées,
- les justifications,
- les conséquences et les compromis.

Les entrées ADR assurent **la traçabilité, la cohérence et la clarté** tout au long de l’évolution de l’architecture du système.
Un modèle du Registres des décisions d’architecture existe dans la documentation [Fiche de décision d’architecture ADR](documentation/ADR.md).

---

## Comment ces documents sont utilisés ensemble

- La **cahier des charges** définit *ce que* le système doit être.
- L’**Registre de décision d’architecture** explique *comment et pourquoi* les décisions architecturales sont prises afin de répondre à ces exigences.

Ensemble, ils fournissent un cadre de documentation clair, professionnel et maintenable, conforme aux pratiques modernes du génie logiciel.

## Arborescence de la documentation
- [cahier des charges SRS](documentation/SRS.md)
- [Fiche de décision d’architecture ADR](documentation/ADR.md)

## Tâches des étudiants
- [ ] Compléter le fichier `student_readmefile.md`.
- [ ] Utiliser le fichier modèle `cahier des charges.md` pour créer votre propre cahier des charges.
- [ ] Utiliser le fichier modèle `ADR.md` pour créer vos propres ADR.
- [ ] Ajouter votre code dans le dossier `/code`.
- [ ] Ajouter votre documentation dans le dossier `/documentation`.

## Pour en savoir plus
- [Modèle Architecture Decision Records (ADR) de Joel Parker Henderson](https://github.com/joelparkerhenderson/architecture-decision-record?tab=readme-ov-file)
- [Site Web ADR](https://adr.github.io/)
