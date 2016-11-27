using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gudbelldon.Data.Model
{
    public class KnittingNight
    {
        public int KnittingNightId { get; set; }
        public DateTime Date { get; set; }

        public KnittingNight()
        {

        }

        public KnittingNight(DateTime date)
        {
            this.Date = date;
        }
    }
}
