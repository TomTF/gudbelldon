using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gudbelldon.Data.Model;
using Gudbelldon.Facebook;

namespace Gudbelldon.Models
{
    public class HomeModel
    {
        public IEnumerable<Photo> Images { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<KnittingNight> KnittingDates { get; set; }
    }
}
