using System;
using System.Runtime.Serialization;

namespace Gudbelldon.Facebook.FacebookTypes
{
    [DataContract]
    public class FacebookData
    {
        [DataMember(Name = "created_time")]
        public DateTime CreatedTime { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}