using System;

namespace DanielBogdan.PlainRSS.Core.Theming
{
    [Serializable]
    public class Theme
    {

        public string Name { get; set; }
        public string RssItemBackColor { get; set; }
        public string RssItemAltBackColor { get; set; }
        public string RssItemTextColor { get; set; }



        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Theme)
            {
                var temp = (Theme)obj;
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