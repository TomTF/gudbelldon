using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gudbelldon.Facebook.FacebookTypes
{
    [DataContract]
    public class FacebookReponse
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "data")]
        public IEnumerable<FacebookData> Data { get; set; }

        [DataMember(Name = "images")]
        public IEnumerable<FacebookImage> Images { get; set; }
    }
}
