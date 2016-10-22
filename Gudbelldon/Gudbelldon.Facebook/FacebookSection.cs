using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gudbelldon.Facebook
{
    public class FacebookSection : ConfigurationSection
    {
        [ConfigurationProperty("Albums", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(FacebookAlbumCollection),
               AddItemName = "add",
               ClearItemsName = "clear",
               RemoveItemName = "remove")]
        public FacebookAlbumCollection Albums {
            get
            {
                return (FacebookAlbumCollection)base["Albums"];
            }
        }

        [ConfigurationProperty("accessToken", IsRequired = true, IsKey = false)]
        public string AccessToken { get { return (string)base["accessToken"]; } }
    }

    public class FacebookAlbumCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FacebookAlbumElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FacebookAlbumElement)element).Name;
        }
    }

    public class FacebookAlbumElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return (String)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }
    }
    
}
