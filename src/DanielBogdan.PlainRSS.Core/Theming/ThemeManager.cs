using DanielBogdan.PlainRSS.Core.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DanielBogdan.PlainRSS.Core.Theming
{
    public class ThemeManager
    {

        private static readonly Logger Logger = new Logger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Load theme from provided folder
        /// </summary>
        /// <param name="themeFolder"></param>
        /// <returns></returns>
        public static IList<Theme> LoadThemes(string themeFolder)
        {
            var themeList = new List<Theme>()
            {
                BuildDefaultTheme()
            };

            if (!Directory.Exists(themeFolder))
                return themeList;

            var themeFiles = Directory.GetFiles(themeFolder, "*.xml");
            foreach (var themeFile in themeFiles)
            {

                try
                {

                    using (var xmlReader = XmlReader.Create(themeFile))
                    {
                        var xmlSerializer = new XmlSerializer(typeof(Theme));
                        var theme = (Theme)xmlSerializer.Deserialize(xmlReader);

                        themeList.Add(theme);
                    }
                }
                catch (Exception exception)
                {
                    Logger.Warn($"{nameof(ThemeManager)} error", exception);
                }
            }


            return themeList;
        }


        /// <summary>
        /// Create default
        /// </summary>
        /// <returns></returns>
        private static Theme BuildDefaultTheme()
        {
            return new Theme()
            {
                Name = "Default",
                RssItemBackColor = "333333",
                RssItemAltBackColor = "3c3c3c",
                RssItemTextColor = "FFFFFF"
            };
        }
    }
}
