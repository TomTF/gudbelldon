using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gudbelldon.Data.Model
{
    public class KnittingNight
    {
        private string v;

        public int KnittingNightId { get; set; }
        public DateTime Date { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public string Location { get; set; }
        public string SeperatorText { get; set; }

        public KnittingNight()
        {

        }

        public KnittingNight(DateTime date)
        {
            this.Date = date;
        }

        public KnittingNight(DateTime date, string icon, string color, string location)
        {
            this.Date = date;
            this.Icon = icon;
            this.Color = color;
            this.Location = location;
        }

        public KnittingNight(DateTime date, string seperatorText)
        {
            this.Date = date;
            this.SeperatorText = seperatorText;
        }
    }
}
