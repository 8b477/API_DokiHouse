﻿using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Tools_DokiHouse.Filters.JwtIdentifiantFilter
{

    /// <summary>
    /// Filtre d'action pour extraire l'identifiant de l'utilisateur à partir du jeton JWT.
    /// Stocke ensuite cet identifiant dans les objets HttpContext.Items pour le rendre accessible aux actions ultérieures de la même requête si nécessaire.
    /// </summary>
    public class JwtUserIdentifiantFilter : IActionFilter
    {

        /// <summary>
        /// Cette méthode est exécutée avant l'exécution de l'action.
        /// Elle extrait l'identifiant de l'utilisateur du jeton JWT et le stocke dans HttpContext.Items.
        /// </summary>
        /// <param name="context">Le contexte d'exécution de l'action.</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Extrait l'identifiant de l'utilisateur du jeton JWT
            string? identifiant = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            // Extrait le rôle de l'utilisateur du jeton JWT
            string? role = context.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;


            // Extrait le nom de l'utilisateur du jeton JWT
            string? name = context.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

            // Stocke l'identifiant et le rôle dans l'objet context.HttpContext.Items pour les rendre accessibles aux actions ultérieures dans la même requête si nécessaire.
            context.HttpContext.Items["id"] = identifiant;
            context.HttpContext.Items["role"] = role;
            context.HttpContext.Items["name"] = name;
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Peut contenir du code supplémentaire à exécuter après l'exécution de l'action.
        }

    }
}
