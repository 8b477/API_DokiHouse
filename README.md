# Sommaire

### [1. Bref présentation du projet.](#zero) <br>
### [2. Comment l'utiliser ?](#one)  
### [3. Mockup si vous avez la flemme de remplir les datas.](#two)
### [4. Résulat attendu après suivis un schéma d'insertion basique.](#trois)
### [5. A savoir, spécifisité dans le projet.](#four)
### [6. Vidéo explicative sur comment publié la base de donnée.](#five)
### [7. Todo, liste de tâches en cours (évolutif).](#six)


# <a name="zero"> API_DokiHouse </a> 

Création d'une API sur la gestion d'un Bonsaï :  

- Création d'un profil perso (User).
- Espace gestion Bonsaï, ajout, suivis, notification.



But à terme de l'api et du front  

- Mise en relation des utilisateurs autour d'une même passion.
- Possibilité pour l'utilisateur de publier des posts ou de commenter.


# <a name="one"> Utilisation </a>

- Création d'un nouveau User
- Entrée son mail et mot de passe dans le endpoint Log
=> Récupération d'un token personnalisé qui contient (id, role)
- Insérer le token reçu au dessus a droite dans SwaggerUI 'Authorize'

- Création d'un Bonsai
- Création d'une Catégorie, une note, un style

Attention les endpoints sont protégés il n'y a que la création d'un User et le endpoint Log qui sont en public, une fois log et avoir inséré son token dans l'endroit approprié les autres endpoints sont ouverts.

## <a name="two"> Mockup </a>

**USER Create**
```json
{
  "name": "jhon",
  "email": "jhon@example.com",
  "passwd": "Test1234*",
  "passwdConfirm": "Test1234*"
}
```
Log
```json
{
  "email": "jhon@example.com",
  "passwd": "Test1234*"
}
```

**BONSAI Create**
```json
{
  "name": "Bonzi",
  "description": "Un arbre plein de vie"
}
```


**CATEGORY Create**
```json
{
  "shohin": false,
  "mame": true,
  "chokkan": false,
  "moyogi": false,
  "shakan": true,
  "kengai": true,
  "hanKengai": false,
  "ikadabuki": false,
  "neagari": false,
  "literati": false,
  "yoseUe": false,
  "ishitsuki": false,
  "kabudachi": false,
  "kokufu": false,
  "yamadori": false,
  "perso": "Super caté !"
}
```

**STYLE Create**
```json
{
  "bunjin": false,
  "bankan": true,
  "korabuki": false,
  "ishituki": false,
  "perso": ""
}
```


**NOTE Create**
```json
 {
  "title": "Titre de ma note",
  "description": "Tache visible sur le dessous des feuilles"
}
```

## <a name="trois"> Résulat </a>

*Attendu via =>*   
   `https://localhost:7043/api/Bonsai/GetOwnBonsai`
```json
[
  {
    "id": 1,
    "name": "Bonzi",
    "description": "Un arbre plein de vie",
    "idUser": 1
  }
]
```


*Attendu via =>*  
  `https://localhost:7043/api/ADokiHouse`

```json
[
  {
    "user": {
      "userId": 1,
      "userName": "jhon",
      "role": "Visitor",
      "idPictureProfil": null
    },
    "bonsai": {
      "bonsaiId": 1,
      "bonsaiName": "Bonzi",
      "bonsaiDescription": "Un arbre plein de vie",
      "bonsaiUserId": 1
    },
    "category": {
      "categoryId": 1,
      "shohin": false,
      "mame": true,
      "chokkan": false,
      "moyogi": false,
      "shakan": true,
      "kengai": true,
      "hanKengai": false,
      "ikadabuki": false,
      "neagari": false,
      "literati": false,
      "yoseUe": false,
      "ishitsuki": false,
      "kabudachi": false,
      "kokufu": false,
      "yamadori": false,
      "categoryPerso": "Super caté !"
    },
    "style": {
      "styleId": 1,
      "bunjin": false,
      "bankan": true,
      "korabuki": false,
      "ishituki": false,
      "stylePerso": ""
    },
    "note": {
      "noteId": 1,
      "title": "Titre de ma note",
      "noteDescription": "Tache visible sur le dessous des feuilles",
      "createAt": "2024-01-04T17:27:21.107"
    }
  }
]
```

# <a name="four"> A savoir </a>

Le projet a un endpoint qui se nomme ADokiHouse, il récupère toutes les données en base de données et build un objet via leurs relations de clé étrangère:

Il récupère un User
Puis la liste des Bonsai possédé par le User
Enfin la table Catégorie, Style, Note liée au à la table Bonsai

Résultat : 

Les User qui n'ont pas de Bonsai, Style, Catégorie, Note ceux-ci seront affiché comme champ avec une valeur 'null', j'ai décidé de ne pas développer d'avantage les propriétés de l'objet si celui-ci est évalué à 'null'.


--------------------
# <a name="five"> Comment publier la DB et changer la connection string ? </a>

https://github.com/8b477/API_DokiHouse/assets/92020766/f642e210-170a-44f4-b525-f7205a491193


---------------

# <a name="six"> TODO </a>

- Fix les endpoints Picture.
- Mettre en place un système d'envoie de mail si l'utilisateur à perdu son mot de passe.
- Ajouter les tables Blog, Comments, Notification.
- Mettre en place un système de notification Sms/Mail.
