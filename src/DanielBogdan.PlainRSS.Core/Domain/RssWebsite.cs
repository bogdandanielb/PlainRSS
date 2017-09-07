using System;
using System.Xml.Serialization;

namespace DanielBogdan.PlainRSS.Core.Domain
{
    [Serializable]
    public class RssWebsite
    {
        private bool enabled = true;

        private bool firstUpdate = true;

        private DateTime lastUpdate = DateTime.MinValue;

        private string link = "";
        private string name = "";


        public RssWebsite()
        {
        }


        public RssWebsite(string name, string link)
        {
            Name = name;
            Link = link;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(Name), @"Cannot be empty");


                name = value;
            }
        }

        public string Link
        {
            get => link;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(Link), @"Cannot be empty");


                if (!Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute))
                    throw new ArgumentNullException(nameof(Link), @"Invalid format");

                link = value;
            }
        }

        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        [XmlIgnore]
        public bool FirstUpdate
        {
            get => firstUpdate;
            set => firstUpdate = value;
        }

        [XmlIgnore]
        public DateTime LastUpdate
        {
            get => lastUpdate;
            set => lastUpdate = value;
        }


        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is RssWebsite)
            {
                var temp = obj as RssWebsite;
                if (temp.Link == Link)
                    return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Link.GetHashCode();
        }
    }
}