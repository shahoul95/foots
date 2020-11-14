using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using foots.Models;

namespace foots.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Connexion : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("connexion");
        }

        [HttpGet("connexions")]
        public async Task<JsonResult> connexions(string id, string pass)
        {
            var context = new djibsonContext();
            try
            {
                Chilkat.Crypt2 crypt = new Chilkat.Crypt2();
          
                var profile = Task.Run(() =>from profiles in context.Membre
                              where profiles.Login == id
                              select new { profiles.Nom, profiles.Login, profiles.Prenom, profiles.MotPasses, profiles.Poste, profiles.Equipe, profiles.Phone, profiles.IdMembres });
                profile.Wait();
                var profiles = await profile;
                var login =   profiles.DefaultIfEmpty().Single().Login;
                var nom = profiles.DefaultIfEmpty().Single().Nom;
                var poste = profiles.DefaultIfEmpty().Single().Poste;
                var prenom = profiles.DefaultIfEmpty().Single().Prenom;
                var equipe = profiles.DefaultIfEmpty().Single().Equipe;
                var password = profiles.DefaultIfEmpty().Single().MotPasses;
                var phone =   profiles.DefaultIfEmpty().Single().Phone;
                var ids = profiles.DefaultIfEmpty().Single().IdMembres;
                var verification = crypt.BCryptVerify(pass, password);

                if (login == id & verification)
                {

                    Object[] myObjArray = new Object[6] { login, nom, poste, prenom, equipe, phone };
                    var a = new Membre();
                    a.Login = login;
                    a.Nom = nom;
                    a.Poste = poste;
                    a.Prenom = prenom;
                    a.Equipe = equipe;
                    a.Phone = phone;
                    a.IdMembres = ids;

                    HttpContext.Session.SetString("nom", a.getnom());
                    HttpContext.Session.SetString("prenom", a.getprenom());
                    HttpContext.Session.SetString("equipe", a.getequipe());
                    HttpContext.Session.SetString("poste", a.getposte());
                    HttpContext.Session.SetInt32("id", a.getid());
                    Object[] conne = new Object[2] { "Connexion...", 1 };

                    return Json(conne);

                }
                else
                {
                    Object[] envoie = new Object[1] { "Membre non reconnu" };



                    return Json(envoie);
                }

            }
            catch (Exception e)
            {
                return Json(e);
            }
            finally
            {
               await context.DisposeAsync();
            }
        }


    }
}
