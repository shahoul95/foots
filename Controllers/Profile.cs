using System;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;

using foots.Models;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace foots.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Profile : Controller
    {
  
        public IActionResult Index()
        {

            return View("Profile");
        }

        [HttpGet("GetProfile")]
        public ActionResult GetProfile()
        {
            //je verifie les variables de session si il sont vide
            if (HttpContext.Session.GetString("nom") != null && HttpContext.Session.GetString("prenom") != null && HttpContext.Session.GetString("equipe") != null && HttpContext.Session.GetString("poste") != null)
            {
                var nom = HttpContext.Session.GetString("nom");
                var prenom = HttpContext.Session.GetString("prenom");
                var equipe = HttpContext.Session.GetString("equipe");
                var poste = HttpContext.Session.GetString("poste");
                try
                {
                    return Json(new { nom, prenom, equipe, poste });
                }
                catch (Exception e)
                {
                    return Json(e);
                }

            }
            else
            {
                var a = 0;
                return Json(a);
            }


        }

        [HttpGet("GetMessage")]
        public async Task<JsonResult> GetMessage()
        {
            //je verifie la variables de session "id" si il est vide ou non
            var context = new djibsonContext();
            if (HttpContext.Session.GetInt32("id") != null)
            {

                var ids = HttpContext.Session.GetInt32("id");

                //je recupere les messages qui appartient à l'utilisatuer connecté grâce à son id
                var message = Task.Run(() => from messages in context.MessageRecu
                                             from membres in context.Membre
                                             where messages.Expediteur == ids && membres.IdMembres == messages.Expediteur && messages.Heure <= DateTime.Now
                                             select new { membres.IdMembres, membres.Prenom, messages.Expediteur, messages.Destinataire, messages.Message, messages.Heure });
                try
                {

                    message.Wait();
                    var messages = await message;
                    return Json(messages);
                }
                catch (Exception e)
                {

                    if (context != null)
                    {
                        await context.DisposeAsync();
                    }
                    return Json(e);
                }

            }
            else
            {


                return Json(false);
            }
        }

        [HttpGet("GetAmis")]
        public async Task<JsonResult> GetAmis()
        {
            //je verifie la variables de session "id" si il est vide ou non
            var context = new djibsonContext();


            if (HttpContext.Session.GetInt32("id") != null)
            {
                var ids = HttpContext.Session.GetInt32("id");

                //je recupere les messages qui appartient à l'utilisateur connecter grâce à son id


                var amise = Task.Run(() => from friend in context.Amis
                                           from member in context.Membre
                                           where friend.IdMembre == ids && friend.IdAmis == member.IdMembres
                                           select new { friend.IdAmis, member.Prenom, friend.IdMembre });

                 
                
                try
                {


                    amise.Wait();

                    var amis = await amise;

                    return Json(amis);

                }
                catch (Exception e)
                {
                    if (context != null)
                    {
                        await context.DisposeAsync();
                    }
                    return Json(e);

                }


            }
            else
            {
                if (context != null)
                {
                    await context.DisposeAsync();
                }
                return Json(false);
            }
        }
        [HttpPost("message")]
        public async Task<ActionResult> Message([FromBody] MessageRecu message)
        {
            var context = new djibsonContext();
            try
            {
                //je teste si les variable de session et les parametre de variable sont non null , donc je rentre dans le if.
                if (message.ExpediteurNavigation.Nom != null && message.Message != null && HttpContext.Session.GetString("nom") != null && HttpContext.Session.GetString("prenom") != null)
                {
                    var noms = HttpContext.Session.GetString("prenom");
                    var prenom = HttpContext.Session.GetString("nom");
                    var complet = noms + " " + prenom;
                    var name = message.ExpediteurNavigation.Nom;
                    var messages = message.Message;
                    var time = DateTime.Today;
                    //la variable prenoms qui permet de recuperer l'id  du destinateur grâce à son nom qui vient du parametre 
                    var prenoms = Task.Run(() => from member in context.Membre where member.Prenom == name select new { member.IdMembres });
                    //ici je recupere la donnée de la requete l'id du destinateur
                    prenoms.Wait();
                    var idmembre = await prenoms;
                    var idmembres = idmembre.DefaultIfEmpty().Single().IdMembres;
                    //ici j'insere les messages avec le constructeur surchargée
                    var a = new MessageRecu(complet, idmembres, messages, time, null, 1);
                    context.MessageRecu.Add(a);
                    await context.SaveChangesAsync();

                    return Json("ok");
                }

                else
                {
                    return Json(0);
                }

            }
            catch (Exception e)
            {

                return Json(e);
            }
            finally
            {
                if (context != null)
                {
                    await context.DisposeAsync();
                }
            }


        }

        [HttpGet("Getvue")]
        public async Task<ActionResult> Getvue()
        {

            if (HttpContext.Session.GetInt32("id") != null)
            {

                // On teste pour voir si nos variables ont bien été enregistrées
                var id = HttpContext.Session.GetInt32("id");

                var context = new djibsonContext();
                var vue = Task.Run(() => from vues in context.MessageRecu
                                         from member in context.Membre
                                         where vues.Expediteur == id && member.IdMembres == vues.Expediteur && vues.NonVue == 1
                                         select vues.NonVue);
                          
                var count = await vue;
                var counts = count.Count();
                try
                {
                    vue.Wait();
                    return Json(counts);
                }
                catch (Exception e)
                {
                    return Json(e);
                }
                finally
                {
                    if (context != null)
                    {
                        await context.DisposeAsync();
                    }
                }

            }
            else
            {
                return Json(false);
            }


        }

        [HttpPut("Getnonvue")]
        public async Task<ActionResult> Getnonvue()
        {

            if (HttpContext.Session.GetString("id") != null)
            {

                // On teste pour voir si nos variables ont bien été enregistrées
                var id = HttpContext.Session.GetInt32("id");

                var context = new djibsonContext();
                var query = from ord in context.MessageRecu
                            where ord.Expediteur == id
                            select ord;

                foreach (var i in query)
                {
                    i.NonVue = 0;

                }
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    // Provide for exceptions.
                }
                finally
                {
                    if (context != null)
                    {
                        await context.DisposeAsync();
                    }

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
