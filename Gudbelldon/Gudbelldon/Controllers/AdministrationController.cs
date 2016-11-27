using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Gudbelldon.Data;
using Gudbelldon.Data.Model;
using Gudbelldon.Models;

namespace Gudbelldon.Controllers
{
    public class AdministrationController : Controller
    {
        public async Task<ActionResult> Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login");
            }


            using (var context = new GudbelldonContext())
            {
                var model = new HomeModel
                {
                    Events = new List<Event> {
                        new Event("Content/Images/Events/20160926.png", "Strickerisch für Anfänger", null,
                        "Für all jene, die schon immer \"losnadeln\" wollten, aber nicht wussten  WIE? In diesem Kurs geht es ganz simpel ums Anschlagen, glatt und verkehrt stricken und zu guter Letzt wieder ums Abketten. Am Ende nähen wir unser \"Musterfleckerl\" mit ein paar Stichen händisch zusammen und schwuppdiwupp: der Gästepatschen ist fertig und kann noch umhäkelt werden. Kursbeitrag: € 5,-/Abend (ca. 3h) + Material", new DateTime(2016,9,26), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                        new Event(null, "Glücksbringer häkeln/Amigurumi", null, null, new DateTime(2016,12,29), new TimeSpan(8,30,0), new TimeSpan(11,30,0)),
                        new Event("Content/Images/Events/haube.jpg", "Strick deine Haube!", null, null, new DateTime(2016,12,12), new TimeSpan(18,30,0), null),
                        new Event("Content/Images/Events/Child.jpg", "Mama-Kinder-Kurs", "Armstricken mit Alpaka-Merino-Wolle", null, new DateTime(2016,12,12), new TimeSpan(18,30,0), null),
                    }.Where(e => e.Date > DateTime.Now.AddDays(-1)).OrderBy(e => e.Date),
                    KnittingDates = (await context.KnittingNights.OrderBy(k => k.Date).ToListAsync())
                };

                return View(model);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var context = new GudbelldonContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                if (user == null)
                {
                    this.ModelState.AddModelError("loginfailed", "Falscher Benutzername oder Passwort!");
                    return View(model);
                }

                Session["User"] = user;
            }

            return this.RedirectToActionPermanent("Index");
        }

        [HttpPost]
        public async Task<ActionResult> CreateKnittingDate(DateTime date)
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login");
            }

            using (var context = new GudbelldonContext())
            {
                context.KnittingNights.Add(new KnittingNight(date));
                await context.SaveChangesAsync();
            }

            return RedirectToActionPermanent("Index");
        }


    }
}