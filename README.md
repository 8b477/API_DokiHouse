# API_DokiHouse  

Création d'une API sur la gestion d'un Bonsaï :  

- Création d'un profil perso (User).
- Espace gestion Bonsaï, ajout, suivis, notification.


But à terme de l'api et du front 
- Mise en relation des utilisateurs autour d'une même passion.
- Possibilité pour l'utilisateur de publier des posts ou de commenter.


# Utilisation

- Création d'un nouveau User
- Entrée son mail et mot de passe dans le endpoint Log
=> Récupération d'un token personnalisé qui contient (id, role)
- Insérer le token reçu au dessus a droite dans SwaggerUI 'Authorize'

- Création d'un Bonsai
- Création d'une Catégorie, une note, un style

Attention les endpoints sont protégés il n'y a que la création d'un User et le endpoint Log qui sont en public, une fois log et avoir inséré son token dans l'endroit approprié les autres endpoints sont ouverts.

