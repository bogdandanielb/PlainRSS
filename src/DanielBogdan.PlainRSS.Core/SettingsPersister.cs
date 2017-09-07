using DanielBogdan.PlainRSS.Core.DTOs;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DanielBogdan.PlainRSS.Core
{
    public class SettingsPersister
    {
        private const string FileSettingsName = "application.dat";

        /// <summary>
        /// Read application state
        /// </summary>
        /// <param name="inputFolder"></param>
        /// <returns></returns>
        public Settings ReadSettings(string inputFolder)
        {


            if (string.IsNullOrEmpty(inputFolder))
                throw new ArgumentNullException(nameof(inputFolder), @"Input folder should not be null");

            var settingsViewModel = new Settings();

            var xmlWriterSettings = new XmlReaderSettings()
            {

            };

            var inputFile = inputFolder + Path.DirectorySeparatorChar + FileSettingsName;
            if (File.Exists(inputFile))
            {

                using (var xmlReader = XmlReader.Create(inputFile, xmlWriterSettings))
                {
                    var xmlSerializer = new XmlSerializer(typeof(Settings));
                    settingsViewModel = (Settings)xmlSerializer.Deserialize(xmlReader);
                }

            }


            return settingsViewModel;
        }


        /// <summary>
        /// Save application state
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="outputFolder"></param>
        public void SaveSettings(Settings settings, string outputFolder)
        {


            if (settings == null)
                throw new ArgumentNullException(nameof(settings), @"ViewModel should not be null");


            if (string.IsNullOrEmpty(outputFolder))
                throw new ArgumentNullException(nameof(outputFolder), @"Output folder should not be null");


            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);


            var xmlWriterSettings = new XmlWriterSettings()
            {
                NewLineHandling = NewLineHandling.Entitize
            };

            var outputFile = outputFolder + Path.DirectorySeparatorChar + FileSettingsName;

            using (var writer = XmlWriter.Create(outputFile, xmlWriterSettings))
            {
                var xmlSerializer = new XmlSerializer(settings.GetType());
                xmlSerializer.Serialize(writer, settings);

            }


        }


    }
}