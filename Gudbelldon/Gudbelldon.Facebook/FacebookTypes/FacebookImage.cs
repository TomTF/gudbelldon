using System.Runtime.Serialization;

namespace Gudbelldon.Facebook.FacebookTypes
{
    [DataContract]
    public class FacebookImage
    {
        [DataMember(Name = "height")]
        public int Height { get; set; }
        [DataMember(Name = "width")]
        public int Width { get; set; }
        [DataMember(Name = "source")]
        public string Source { get; set; }
    }
}