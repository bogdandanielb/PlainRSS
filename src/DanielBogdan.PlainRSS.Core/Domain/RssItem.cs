using System;

namespace DanielBogdan.PlainRSS.Core.Domain
{
    public class RssItem
    {
        private RssCategory category;
        private RssWebsite website;

        public RssItem(RssCategory category, RssWebsite website)
        {
            Category = category;
            Website = website;
        }


        public RssItem()
        {
        }

        public string Guid { get; set; }

        public DateTime PubDate { get; set; } = DateTime.MinValue;

        public string Author { get; set; } = "no-author";

        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; } = "";

        public RssCategory Category
        {
            get => category;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Category), @"Cannot be empty");

                category = value;
            }
        }

        public RssWebsite Website
        {
            get => website;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Website), @"Cannot be empty");

                website = value;
            }
        }

        public override string ToString()
        {
            return
                $"{PubDate:[hh:mm:ss]} [{Category.Name}:{Website.Name}] {Utilities.TruncateText(Title, 100)}:{Utilities.TruncateText(Description, 200)}";
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is RssItem)
            {
                //since Guid is not required we have to identify them by title
                var rssItem = obj as RssItem;
                if (rssItem.Title == Title)
                    return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}