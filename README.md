# 📄 DokiHouse - Guide de Démarrage Rapide

Bienvenue dans le guide de démarrage rapide de l'API DokiHouse.   
Ce guide vous aidera à comprendre et à utiliser les fonctionnalités offertes par DokiHouse.
<br><br><br>

## Sommaire

### - [Présentation.](#one) <br>
### - [Objectifs.](#two) <br>
### - [Guide de démarrage.](#three) <br>
### - [Authentification.](#four) <br>
### - [Besoin d'aide.](#five) 
### - [Vidéo publication DB.](#six)
<br>

## Mockup
### - [User.](#seven) <br>
### - [Bonsai.](#eight) <br>
### - [Blog.](#nine) <br>
<br>

## Contrainte des différentes tables
### - [User](#seven2)<br>
### - [Bonsai](#eight2)<br>
### - [Category](#category)<br>
### - [Style](#style)<br>
### - [Note](#note)<br>
### - [PictureBonsai](#picturebonsai)<br>
### - [PictureUser](#pictureuser)<br>
### - [Post](#post)<br>
### - [Comments](#comments)<br>

<br><br>

## 🔖 Comment utiliser ce guide
Si vous voulez des détails plus précis sur les différents endpoints disponibles, je vous invite à cliquer sur le lien qui suit :

➡️ [Doc_Postman](https://documenter.getpostman.com/view/23325187/2s9YynkPkN)   

<br><br>
## <a name="one"> Présentation de l'API DokiHouse </a>

L'API DokiHouse offre un ensemble de fonctionnalités pour créer un réseau autour de la passion des Bonsaïs et de la gestion d'un blog. Elle permet de gérer des profils d'utilisateurs, d'ajouter et de suivre des Bonsaïs, de recevoir des notifications, de créer des posts et de commenter.

<br><br>
### <a name="two"> Objectifs de l'API </a>

L'API DokiHouse vise à mettre en relation les utilisateurs partageant une même passion pour les Bonsaïs. Les principales fonctionnalités incluent la possibilité de créer un profil personnel, de gérer des Bonsaïs avec des fonctionnalités telles que l'ajout et le suivi, de recevoir des notifications pertinentes, de créer des posts et de commenter.

<br><br>
## <a name="three"> Guide de Démarrage </a>

### **IMPORTANT:** 👀  
L'API n'est pas en ligne, il vous faudra donc télécharger le projet depuis :   
➡️ [GitHub](https://github.com/8b477/API_DokiHouse). <br><br>
Ensuite, il vous suffira de démarrer le projet dans un IDE, je vous conseille :   
➡️ [Visual Studio](https://visualstudio.microsoft.com/fr/). <br><br>
Enfin, il vous faudra publier la base de données, il y a une vidéo explicative de moins de 1 min en bas de cette page.  

<br><br>
## <a name="four"> **AUTHENTIFICATION:**  </a>

L'API DokiHouse utilise une authentification par Bearer token, directement gérée via l'API au moment de la connexion.


<br><br>
##  <a name="five"> **BESOIN D'AIDE?** </a> 

Si vous avez des questions, vous pouvez me contacter via :<br>
➡️ [LinkedIn](https://www.linkedin.com/in/jonathan-buchet).


<br><br>

# <a name="six"> Comment publier la DB et changer la connection string ? </a>

https://github.com/8b477/API_DokiHouse/assets/92020766/d948a66a-4bd7-4867-a007-4c97d58b1d62


<br><br>

# Mockup
<br>

----------------------------

## <a name="seven"> User </a>

```json
{
  "name": "jhon",
  "email": "jhon@example.com",
  "passwd": "Test1234*",
  "passwdConfirm": "Test1234*"
}
```

-----------------------------

### <a name="seven2"> Contrainte User </a>
Le **name** ne peut contenir plus de 50 caractères et ne peut pas être null.  
Le **passwd** doit contenir 8 caractère minimum, une majuscule, une minuscule, un caractère spécial et un chiffre et ne peut pas être null.  
L'adresse **mail** ne peut pas être déjà éxistante en base de donnée (UNIQUE) et ne peut pas être null.  
Le **passwdConfirm** doit être exactement identique à passwd et ne peut pas être null.  

----------------------------

## <a name="eight"> Bonsai </a>
```json
{
  "name": "bonzi",
  "description": "Super description"
}
```

### <a name="eight2"> Contrainte Bonsai </a>

Le **name** est de maximum 50 caratères et ne peut pas être null.   
Le **description** peut être null.   
Le Bonsai ne peut être créer que si un Utilisateur est enregistrer en base de données.


### <a name="category"> Category </a>
```json
{
  "shohin": false,
  "mame": true,
  "chokkan": false,
  "moyogi": false,
  "shakan": false,
  "kengai": true,
  "hanKengai": true,
  "ikadabuki": true,
  "neagari": false,
  "literati": false,
  "yoseUe": false,
  "ishitsuki": false,
  "kabudachi": false,
  "kokufu": false,
  "yamadori": false,
  "perso": "ninja"
}
```
### Contrainte catégorie

Le champ **perso** ne peut pas contenir plus de 150 caractères et peut être null.
Une catégorie est directement lié un a Bonsaï donc impossible de créer une catégorie sans avoir de Bonsaï préalablement créer.

### <a name="style"> Style </a>
```json
{
  "bunjin": true,
  "bankan": false,
  "korabuki": false,
  "ishituki": true,
  "perso": "cool"
}
```
### Contrainte Style

Le champ **perso** ne peut pas contenir plus de 150 caractères et peut être null.
Un style est directement lié un a Bonsaï donc impossible de créer un style sans avoir de Bonsaï préalablement créer.

### <a name="note"> Note </a>
```json
{
  "title": "Important",
  "description": "blabla description"
}
```
### Contrainte Note
Le champ **title** ne peut pas contenir plus de 100 caractères et ne peut pas être null.
Une note est directement lié un a Bonsaï donc impossible de créer une note sans avoir de Bonsaï préalablement créer.

-------------------------

### <a name="picturebonsai"> PictureBonsai </a>
N'accepte que les formats suivant : ".jpg", ".jpeg", ".png" <br>
Les images sont directement sauvegardées sur le serveur. <br>
Les utilisateurs ont un dossier unique pour chacun d'entre eux avec leurs différentes images stocker aussi sous un nom unique.


### <a name="pictureuser"> PictureUser </a>  
Les images de profil d'un utilisateur sont générées automatiquement à l'inscription de celui-ci via le front,
via le service de DICEBEAR pour en savoir en plus à leur sujet voici leur site officiel : <br>
➡️ https://www.dicebear.com <br>
Je ne stocke que l'url qui fait référence à l'image produite via l'API de DiceBear.

--------------------

## <a name="nine"> Partie Blog </a>

### <a name="post"> Post </a>
```json
{
  "title": "La main verte",
  "description": "Super longue description",
  "content": "Et un contenu encore plus long"
}
```
### Contrainte Post
Le champ **title** ne peut pas contenir plus de 50 caractères  et ne peut pas être null.
Le champ **description** ne peut pas contenir plus de 200 caractères  et ne peut pas être null.


### <a name="comments"> Comments </a>
```json
{
  "content": "J'adore ton post 🥰"
}
```
### Contrainte Comments
Le **content** ne peut pas être null.
Un commentaire cible un post donc le commentaire ne peut exister si il n'est pas lié à un post.
