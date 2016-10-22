using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gudbelldon.Facebook;

namespace Gudbelldon.Models
{
    public class HomeModel
    {
        public IEnumerable<Photo> Images { get; set; }
        public IEnumerable<EventModel> Events { get; set; }
    }
}
