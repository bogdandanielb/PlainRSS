using System;
using System.ComponentModel;

namespace DanielBogdan.PlainRSS.Core.Domain
{
    [Serializable]
    public class RssCategory
    {
        private string name;
        private string color = "#FFFFFF";

        public RssCategory(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public RssCategory()
        {
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

        public string Color
        {
            get { return color; }
            set { color = value; }
        }



        public BindingList<RssWebsite> RssWebsites { get; set; }


        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is RssCategory)
            {
                var temp = (RssCategory)obj;
                if (temp.Name == Name)
                    return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}