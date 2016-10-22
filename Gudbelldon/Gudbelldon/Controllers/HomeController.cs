using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Gudbelldon.Facebook;
using Gudbelldon.Models;

namespace Gudbelldon.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var photoProvider = new PhotoProvider();
            var model = new HomeModel
            {
                Images = await photoProvider.GetPhotoLinks(),
                Events = new List<EventModel> {
                    new EventModel("Content/Images/Events/20160926.png", "Strickerisch für Anfänger", null, 
                    "Für all jene, die schon immer \"losnadeln\" wollten, aber nicht wussten  WIE? In diesem Kurs geht es ganz simpel ums Anschlagen, glatt und verkehrt stricken und zu guter Letzt wieder ums Abketten. Am Ende nähen wir unser \"Musterfleckerl\" mit ein paar Stichen händisch zusammen und schwuppdiwupp: der Gästepatschen ist fertig und kann noch umhäkelt werden. Kursbeitrag: € 5,-/Abend (ca. 3h) + Material", new DateTime(2016,9,26), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),

                    new EventModel("Content/Images/Events/20161003.png", "Franz. Handschuhe", "Teil 1", "Etwas Strickerfahrung erlaubt :) Wir stricken zwar kraus rechts, aber mit dünner Wolle und ebenso dünnen Nadeln (etwa Stärke 2,5 – 3: können mitgebracht werden!). Am ersten Abend stricken wir den Oberteil des Handschuhs, dann wird es eine kleine Hausübung geben bis zum zweiten Abend, an dem wir dann den Daumenkeil in Angriff nehmen. Eventuell kommt zum Zusammenhäkeln der Teile ein dritter Abend zustande. Kursbeitrag: € 5,-/Abend (etwa 3h) + Material", new DateTime(2016,10,3), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                    new EventModel("Content/Images/Events/20161010.png", "Franz. Handschuhe", "Teil 2", "Etwas Strickerfahrung erlaubt :) Wir stricken zwar kraus rechts, aber mit dünner Wolle und ebenso dünnen Nadeln (etwa Stärke 2,5 – 3: können mitgebracht werden!). Am ersten Abend stricken wir den Oberteil des Handschuhs, dann wird es eine kleine Hausübung geben bis zum zweiten Abend, an dem wir dann den Daumenkeil in Angriff nehmen. Eventuell kommt zum Zusammenhäkeln der Teile ein dritter Abend zustande. Kursbeitrag: € 5,-/Abend (etwa 3h) + Material", new DateTime(2016,10,10), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                    new EventModel(null, "Spinn`di aus", "Spinnen für Anfänger und Fortgeschrittene", "Wir entlassen niemand ohne Faden :). Kursbeitrag: € 55,- All Inclusive (auch Spinnrad).(nach Absprache kann auch das eigene Spinnrad mitgenommen werden!)", new DateTime(2016,10,22), new TimeSpan(14,0,0), new TimeSpan(17,0,0)),
                    new EventModel("Content/Images/Events/20161024.png", "Filzpatschen Strickfilzen", null, "Es besteht im November an den Montag Vormittagen auch die Möglichkeit, zum Strickfilzen ins Gudbelldon zu kommen. Kursbeitrag: € 5,-/Abend (ca. 3h) + Material (vorhandene Nadeln Stärke 7 oder 8 können mitgenommen werden)", new DateTime(2016,10,24), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                    new EventModel(null, "Schlüsselanhänger häckeln / Amigurumi", null, "Kleine Schlüsselanhänger Häkeln – Häkeltiere. Kursbeitrag: € 5,-/Abend. Bitte Wollreste mitnehmen, da für diese Tierchen oft nur kleine Mengen benötigt werden", new DateTime(2016,10,28), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                    new EventModel(null, "1. Sockennachmittag", "Fragen zur Socke von A - Z", "Du willst deinen ersten eigenen Socken stricken oder hast eine spezifische Frage mitten in der Ferse? Hier bist du richtig und bekommst hoffentlich auf alles eine Antwort und eine Tasse Kaffee :). Beitrag pro Nachmittag: € 5,-", new DateTime(2016,11,4), new TimeSpan(15,0,0), null),
                    new EventModel(null, "Entrelac/Stricken im Flechtmuster", "Teil 1", null, new DateTime(2016,11,7), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                    new EventModel(null, "2. Sockennachmittag", "Fragen zur Socke von A - Z", "Du willst deinen ersten eigenen Socken stricken oder hast eine spezifische Frage mitten in der Ferse? Hier bist du richtig und bekommst hoffentlich auf alles eine Antwort und eine Tasse Kaffee :). Beitrag pro Nachmittag: € 5,-", new DateTime(2016,11,11), new TimeSpan(15,0,0), null),
                    new EventModel(null, "Entrelac/Stricken im Flechtmuster", "Teil 2", null, new DateTime(2016,11,14), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                    new EventModel(null, "3. Sockennachmittag", "Fragen zur Socke von A - Z", "Du willst deinen ersten eigenen Socken stricken oder hast eine spezifische Frage mitten in der Ferse? Hier bist du richtig und bekommst hoffentlich auf alles eine Antwort und eine Tasse Kaffee :). Beitrag pro Nachmittag: € 5,-", new DateTime(2016,11,18), new TimeSpan(15,0,0), null),
                    new EventModel("Content/Images/Events/20161122.png", "Strickerisch für Anfänger", null, null, new DateTime(2016,11,22), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                    new EventModel(null, "Glücksbringer häkeln/Amigurumi", null, null, new DateTime(2016,12,29), new TimeSpan(8,30,0), new TimeSpan(11,30,0)),
                }.Where(e => e.Date > DateTime.Now.AddDays(-1))
            };
            return View(model);
        }

        public ActionResult ContactMe(ContactModel model)
        {
            var gudbelldonAddress = new MailAddress("contact@gudbelldon.at", string.Format("{0} ({1})", model.FirstName, model.EMail));
            MailMessage mail = new MailMessage();
            mail.From = gudbelldonAddress;
            mail.Sender = gudbelldonAddress;
            mail.To.Add("office@gudbelldon.at");
            mail.Subject = model.Subject;
            mail.Body = this.GetBody(model);
            mail.ReplyToList.Add(gudbelldonAddress);
            mail.IsBodyHtml = false;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            using (SmtpClient client = new SmtpClient("mail.gudbelldon.at", 8889))
            {
                try
                {
                    client.Credentials = new System.Net.NetworkCredential("contact@gudbelldon.at", "wOLL3#Klein");
                    client.EnableSsl = false;
                    client.Send(mail);
                }
                catch
                {
                    Console.WriteLine("Exception while sending email!");
                }
            }

            return this.Json(null);
        }

        private string GetBody(ContactModel model)
        {
            return string.Format("{0} ({1}) schreibt: \n\n {2}", model.FirstName, model.EMail, model.Text);
        }
    }
}