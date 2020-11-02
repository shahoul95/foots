using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using foots.Models;
using MySqlX.XDevAPI.Relational;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace foots.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Profile : Controller
    {

        public IActionResult Index()
        {

            return View("Profile");
        }

        [HttpGet("information")]
        public ActionResult GetProfile()
        {
            //je verifie les variables de session si il sont vide
            if (HttpContext.Session.GetString("nom") != null && HttpContext.Session.GetString("prenom") != null && HttpContext.Session.GetString("equipe") != null && HttpContext.Session.GetString("poste") != null)
            {
                var nom = HttpContext.Session.GetString("nom");
                var prenom = HttpContext.Session.GetString("prenom");
                var equipe = HttpContext.Session.GetString("equipe");
                var poste = HttpContext.Session.GetString("poste");
                return Json(new { nom, prenom, equipe, poste });

            }
            else
            {
                //si les variables de session sont null je renvoie un null 
                var a = 0;
                return Json(new { a });

            }

        }

        [HttpGet("getmessage")]
        public ActionResult GetMessage()
        {
            //je verifie la variables de session "id" si il est vide ou non
            if (HttpContext.Session.GetInt32("id") != null)
            {

                // On teste pour voir si nos variables ont bien été enregistrées
                var ids = HttpContext.Session.GetInt32("id");
                var context = new djibsonContext();
                //je recupere les messages qui appartient à l'utilisatuer connecté grâce à son id
                var message = from messages in context.MessageRecu
                              from membres in context.Membre
                              where messages.Expediteur == ids && membres.IdMembres == messages.Expediteur && messages.Heure <= DateTime.Now
                              select new { membres.IdMembres, membres.Prenom, messages.Expediteur, messages.Destinataire, messages.Message, messages.Heure };
                // je retourne les donnée de a requete
                return Json(message);


            }
            else
            {
                return Json(0);
            }

        }

        [HttpGet("getamis")]
        public ActionResult GetAmis()
        {
            //je verifie la variables de session "id" si il est vide ou non
            if (HttpContext.Session.GetInt32("id") != null)
            {

                var ids = HttpContext.Session.GetInt32("id");
                var context = new djibsonContext();
                //je recupere les messages qui appartient à l'utilisateur connecter grâce à son id
                var amis = from friend in context.Amis
                           from member in context.Membre
                           where friend.IdMembre == ids && friend.IdAmis == member.IdMembres
                           select new { friend.IdAmis, member.Prenom, friend.IdMembre };


                return Json(amis);


            }
            else
            {
                return Json(0);
            }

        }

        [HttpPost("message")]
        public ActionResult Message(string nom, string message)
        {
            var context = new djibsonContext();
            try
            {
                //je teste si les variable de session et les parametre de variable sont non null , donc je rentre dans le if.
                if (nom != null && message != null && HttpContext.Session.GetString("nom") != null && HttpContext.Session.GetString("prenom") != null)
                {
                    var noms = HttpContext.Session.GetString("prenom");
                    var prenom = HttpContext.Session.GetString("nom");
                    var complet = noms + " " + prenom;
                    var name = nom;
                    var messages = message;
                    var time = DateTime.Today;
                    //la variable prenoms qui permet de recuperer l'id  du destinateur grâce à son nom qui vient du parametre 
                    var prenoms = from member in context.Membre where member.Prenom == name select new { member.IdMembres };
                    //ici je recupere la donnée de la requete l'id du destinateur 
                    var idmembre = prenoms.DefaultIfEmpty().Single().IdMembres;
                    //ici j'insere les messages avec le constructeur surchargée
                    var a = new MessageRecu(complet, idmembre, messages, time, null, 1);
                    context.MessageRecu.Add(a);
                    context.SaveChangesAsync();
                    return Json("ok");
                }

                else
                {
                    return Json(0);
                }

            }
            catch (Exception e)
            {
                context.DisposeAsync();
                return Json(e);
            }

        }

        [HttpGet("getvue")]
        public ActionResult Getvue()
        {

            if (HttpContext.Session.GetString("id") != null)
            {

                // On teste pour voir si nos variables ont bien été enregistrées
                var id = HttpContext.Session.GetInt32("id");

                var context = new djibsonContext();
                var vue = from vues in context.MessageRecu
                          from member in context.Membre
                          where vues.Expediteur == id && member.IdMembres == vues.Expediteur && vues.NonVue == 1
                          select vues.NonVue;
                var count = vue.Count();
                return Json(count);


            }
            else
            {
                return Json(false);
            }

        }

        [HttpGet("getnonvue")]
        public ActionResult Getnonvue()
        {

            if (HttpContext.Session.GetString("id") != null)
            {

                // On teste pour voir si nos variables ont bien été enregistrées
                var id = HttpContext.Session.GetInt32("id");

                var context = new djibsonContext();
                var query = from ord in context.MessageRecu
                            where ord.Expediteur == id
                            select ord;

                foreach(var i in query)
                {
                    i.NonVue = 0;

                }
                try
                {
                    context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Provide for exceptions.
                }
                finally
                {
                    context.DisposeAsync();
                }
                return Json(true);
            }
            else
            {
                return Json(false);
            }

        }
    }
}
