using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Gudbelldon.Data.Model;
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
                Events = new List<Event> {
                    //new EventModel("Content/Images/Events/20161003.png", "Franz. Handschuhe", "Teil 1", "Etwas Strickerfahrung erlaubt :) Wir stricken zwar kraus rechts, aber mit dünner Wolle und ebenso dünnen Nadeln (etwa Stärke 2,5 – 3: können mitgebracht werden!). Am ersten Abend stricken wir den Oberteil des Handschuhs, dann wird es eine kleine Hausübung geben bis zum zweiten Abend, an dem wir dann den Daumenkeil in Angriff nehmen. Eventuell kommt zum Zusammenhäkeln der Teile ein dritter Abend zustande. Kursbeitrag: € 5,-/Abend (etwa 3h) + Material", new DateTime(2016,10,3), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                    //new EventModel("Content/Images/Events/20161010.png", "Franz. Handschuhe", "Teil 2", "Etwas Strickerfahrung erlaubt :) Wir stricken zwar kraus rechts, aber mit dünner Wolle und ebenso dünnen Nadeln (etwa Stärke 2,5 – 3: können mitgebracht werden!). Am ersten Abend stricken wir den Oberteil des Handschuhs, dann wird es eine kleine Hausübung geben bis zum zweiten Abend, an dem wir dann den Daumenkeil in Angriff nehmen. Eventuell kommt zum Zusammenhäkeln der Teile ein dritter Abend zustande. Kursbeitrag: € 5,-/Abend (etwa 3h) + Material", new DateTime(2016,10,10), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                    //new EventModel(null, "Spinn`di aus", "Spinnen für Anfänger und Fortgeschrittene", "Wir entlassen niemand ohne Faden :). Kursbeitrag: € 55,- All Inclusive (auch Spinnrad).(nach Absprache kann auch das eigene Spinnrad mitgenommen werden!)", new DateTime(2016,10,22), new TimeSpan(14,0,0), new TimeSpan(17,0,0)),
                    //new EventModel("Content/Images/Events/20161024.png", "Filzpatschen Strickfilzen", null, "Es besteht im November an den Montag Vormittagen auch die Möglichkeit, zum Strickfilzen ins Gudbelldon zu kommen. Kursbeitrag: € 5,-/Abend (ca. 3h) + Material (vorhandene Nadeln Stärke 7 oder 8 können mitgenommen werden)", new DateTime(2016,10,24), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                    //new EventModel(null, "Schlüsselanhänger häckeln / Amigurumi", null, "Kleine Schlüsselanhänger Häkeln – Häkeltiere. Kursbeitrag: € 5,-/Abend. Bitte Wollreste mitnehmen, da für diese Tierchen oft nur kleine Mengen benötigt werden", new DateTime(2016,10,28), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                    //new EventModel(null, "1. Sockennachmittag", "Fragen zur Socke von A - Z", "Du willst deinen ersten eigenen Socken stricken oder hast eine spezifische Frage mitten in der Ferse? Hier bist du richtig und bekommst hoffentlich auf alles eine Antwort und eine Tasse Kaffee :). Beitrag pro Nachmittag: € 5,-", new DateTime(2016,11,4), new TimeSpan(15,0,0), null),
                    //new EventModel(null, "Entrelac/Stricken im Flechtmuster", "Teil 1", null, new DateTime(2016,11,7), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                    //new EventModel(null, "2. Sockennachmittag", "Fragen zur Socke von A - Z", "Du willst deinen ersten eigenen Socken stricken oder hast eine spezifische Frage mitten in der Ferse? Hier bist du richtig und bekommst hoffentlich auf alles eine Antwort und eine Tasse Kaffee :). Beitrag pro Nachmittag: € 5,-", new DateTime(2016,11,11), new TimeSpan(15,0,0), null),
                    //new EventModel(null, "Entrelac/Stricken im Flechtmuster", "Teil 2", null, new DateTime(2016,11,14), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                    //new EventModel(null, "3. Sockennachmittag", "Fragen zur Socke von A - Z", "Du willst deinen ersten eigenen Socken stricken oder hast eine spezifische Frage mitten in der Ferse? Hier bist du richtig und bekommst hoffentlich auf alles eine Antwort und eine Tasse Kaffee :). Beitrag pro Nachmittag: € 5,-", new DateTime(2016,11,18), new TimeSpan(15,0,0), null),
                    //new EventModel("Content/Images/Events/20161122.png", "Strickerisch für Anfänger", null, null, new DateTime(2016,11,22), new TimeSpan(18,30,0), new TimeSpan(21,0,0)),
                    //new Event(null, "Glücksbringer häkeln/Amigurumi", null, null, new DateTime(2016,12,29), new TimeSpan(8,30,0), new TimeSpan(11,30,0)),
                    //new Event("Content/Images/Events/filzpatschen.jpg", "Filzpatschenkurs!", null, null, new DateTime(2016,12,5), new TimeSpan(18,30,0), null),
                    //new Event("Content/Images/Events/haube.jpg", "Strick deine Haube!", null, null, new DateTime(2016,12,12), new TimeSpan(18,30,0), null),
                    //new Event("Content/Images/Events/Child.jpg", "Mama-Kinder-Kurs", "Armstricken mit Alpaka-Merino-Wolle", null, new DateTime(2017,1,3), new TimeSpan(9,0,0), new TimeSpan(11,0,0)),
                    new Event(null, "Französische Handschuhe stricken", "Teil 1", null, new DateTime(2017,1,16), new TimeSpan(18,30,0), null),
                    new Event(null, "Französische Handschuhe stricken", "Teil 2", null, new DateTime(2017,1,23), new TimeSpan(18,30,0), null),
                    new Event(null, "Französische Handschuhe stricken", "Teil 3", null, new DateTime(2017,1,30), new TimeSpan(18,30,0), null),
                    new Event(null, "Französische Handschuhe stricken", "Teil 4", null, new DateTime(2017,2,6), new TimeSpan(18,30,0), null),
                    new Event(null, "Sockennachmittag", "Fragen zur Socke von A - Z", "Jeweils ab 15 Uhr werden alle Fragen zum Thema Sockenstricken beantwortet und es kann in gemütlicher Runde gestrickt werden! Kursbeitrag: € 5,-", new DateTime(2017,01,27), new TimeSpan(15,0,0), null),
                    new Event(null, "Sockennachmittag", "Fragen zur Socke von A - Z", "Jeweils ab 15 Uhr werden alle Fragen zum Thema Sockenstricken beantwortet und es kann in gemütlicher Runde gestrickt werden! Kursbeitrag: € 5,-", new DateTime(2017,02,03), new TimeSpan(15,0,0), null),
                    new Event(null, "Sockennachmittag", "Fragen zur Socke von A - Z", "Jeweils ab 15 Uhr werden alle Fragen zum Thema Sockenstricken beantwortet und es kann in gemütlicher Runde gestrickt werden! Kursbeitrag: € 5,-", new DateTime(2017,02,10), new TimeSpan(15,0,0), null),
                    new Event(null, "Schlüsselanhänger häckeln", null, "Häckel dir deinen Schlüsselanhänger. Kursbeitrag € 5,-", new DateTime(2017,02,13), new TimeSpan(18,30,0), null),
                    new Event(null, "Filz dir deine Häkeltasche", null, " Kursbeitrag € 5,-", new DateTime(2017,03,6), new TimeSpan(18,30,0), null),
                    new Event(null, "Filzhasen", null, " Kursbeitrag € 5,-", new DateTime(2017,03,13), new TimeSpan(18,30,0), null),
                    new Event(null, "Filzkörbe", null, " Kursbeitrag € 5,-", new DateTime(2017,03,20), new TimeSpan(18,30,0), null),
                    new Event(null, "Hühner stricken", null, " Kursbeitrag € 5,-", new DateTime(2017,03,27), new TimeSpan(18,30,0), null),
                    new Event(null, "Fühlingsdeko häkeln", null, " Kursbeitrag € 5,-", new DateTime(2017,4,3), new TimeSpan(18,30,0), null),
                    new Event(null, "Spinnkurs", "mit Tina Stegfellner", "Kurs mit Material, Leihspinnrad und Anleitung € 60,-", new DateTime(2017,3,4), new TimeSpan(13,30,0), null)
                }.Where(e => e.Date > DateTime.Now.AddDays(-1)).OrderBy(e => e.Date),
                KnittingDates = new List<KnittingNight> {
                    new KnittingNight(new DateTime(2016,11,21)),
                    new KnittingNight(new DateTime(2016,11,28)),
                    new KnittingNight(new DateTime(2016,12,13)),
                    new KnittingNight(new DateTime(2017,1,10)),
                    new KnittingNight(new DateTime(2017,1,17), "grade", "#eea159", "Freistädter Brauhaus "),
                    new KnittingNight(new DateTime(2017,1,24)),
                    new KnittingNight(new DateTime(2017,1,31)),
                    new KnittingNight(new DateTime(2017,2,7)),
                    new KnittingNight(new DateTime(2017,2,15), "grade", "#eea159", "Cafe Konditorei Poissl"),
                    new KnittingNight(new DateTime(2017,2,28)),

                    new KnittingNight(new DateTime(2017,3,8)),
                    new KnittingNight(new DateTime(2017,3,14), "grade", "#eea159", null),
                    new KnittingNight(new DateTime(2017,3,21)),
                    new KnittingNight(new DateTime(2017,3,28)),
                    new KnittingNight(new DateTime(2017,4,4)),
                    new KnittingNight(new DateTime(2017,4,19), "grade", "#eea159", null),
                    new KnittingNight(new DateTime(2017,4,25)),
                    new KnittingNight(new DateTime(2017,5,2)),
                    new KnittingNight(new DateTime(2017,5,9)),
                    new KnittingNight(new DateTime(2017,5,16)),
                    new KnittingNight(new DateTime(2017,5,23), "grade", "#eea159", null),
                    new KnittingNight(new DateTime(2017,5,30)),
                    new KnittingNight(new DateTime(2017,6,6)),
                    new KnittingNight(new DateTime(2017,6,14), "grade", "#eea159", null),
                    new KnittingNight(new DateTime(2017,6,20)),
                    new KnittingNight(new DateTime(2017,7,4)),
                    new KnittingNight(new DateTime(2017,7,11), "grade", "#eea159", null),
                    new KnittingNight(new DateTime(2017,8,21), "grade", "#eea159", null),
                    new KnittingNight(new DateTime(2017,8,29)),
                    new KnittingNight(new DateTime(2017,9,5)),
                    new KnittingNight(new DateTime(2017,9,19)),
                    new KnittingNight(new DateTime(2017,9,26), "grade", "#eea159", null),
                    new KnittingNight(new DateTime(2017,10,3)),
                    new KnittingNight(new DateTime(2017,10,10)),
                    new KnittingNight(new DateTime(2017,10,17), "grade", "#eea159", null),
                    new KnittingNight(new DateTime(2017,10,24)),
                    new KnittingNight(new DateTime(2017,11,7)),
                    new KnittingNight(new DateTime(2017,11,14), "grade", "#eea159", null),
                    new KnittingNight(new DateTime(2017,11,21)),
                    new KnittingNight(new DateTime(2017,11,28)),
                    new KnittingNight(new DateTime(2017,12,5)),
                    new KnittingNight(new DateTime(2017,12,12), "grade", "#eea159", null),
                }.Where(e => e.Date > DateTime.Now.AddDays(-1)).OrderBy(d => d.Date)
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