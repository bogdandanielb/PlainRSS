using DanielBogdan.PlainRSS.Core.Domain;
using DanielBogdan.PlainRSS.Core.DTOs;
using DanielBogdan.PlainRSS.Core.Http;
using DanielBogdan.PlainRSS.Core.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;

namespace DanielBogdan.PlainRSS.Core
{
    public class RssListener
    {
        private static readonly Logger Logger = new Logger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public event Action<RssItem> NewRss;


        private Thread thread = null;
        private bool stopped = true;
        private readonly Settings settings;
        private readonly IList<string> userAgents;

        public RssListener(Settings settings, IList<string> userAgents)
        {
            this.settings = settings;
            this.userAgents = userAgents;
        }

        private void Run()
        {
            while (!stopped)
            {
                try
                {
                    foreach (var rssCategory in settings.RssCategories)
                    {
                        foreach (var rssWebsite in rssCategory.RssWebsites)
                        {
                            if (stopped)
                                return;

                            if (!rssWebsite.Enabled)
                                continue;

                            if (settings.Delay > 0)
                                Thread.Sleep(settings.Delay * 1000);

                            var httpClient = new HttpClient(null, null,
                                userAgents[StaticRandom.Next(0, userAgents.Count)], 60000);

                            var html = httpClient.Get(rssWebsite.Link);
                            if (string.IsNullOrEmpty(html))
                                continue;

                            ParseRss(html, rssCategory, rssWebsite);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Warn($"{nameof(RssListener)} error", ex);
                }
            }
        }

        private void ParseRss(string html, RssCategory rssCategory, RssWebsite rssWebsite)
        {

            var doc = new XmlDocument();
            doc.LoadXml(html);


            var nodes = doc.SelectNodes("//item");
            if (nodes == null)
                return;

            for (var i = nodes.Count - 1; i >= 0; i--) //get them in inverse order ( old items first
            {
                var rssItem = new RssItem
                {
                    Category = rssCategory,
                    Website = rssWebsite
                };

                var xmlNode = nodes[i].SelectSingleNode("title");
                if (xmlNode == null)
                    continue;

                rssItem.Title = Utilities.CleanString(xmlNode.InnerText).Trim();

                xmlNode = nodes[i].SelectSingleNode("link");
                if (xmlNode == null)
                    continue;

                rssItem.Link = xmlNode.InnerText;

                xmlNode = nodes[i].SelectSingleNode("description");
                if (xmlNode == null)
                    continue;

                rssItem.Description = Utilities.CleanString(xmlNode.InnerText).Trim();


                xmlNode = nodes[i].SelectSingleNode("pubDate");
                if (xmlNode != null)
                {
                    var text = xmlNode.InnerText;
                    if (Regex.IsMatch(text, "\\s[a-zA-Z]{3}$", RegexOptions.Multiline))
                        text = text.Substring(0, text.Length - 4);

                    DateTime tempDateTime;
                    if (DateTime.TryParse(text, new CultureInfo("en-US", false), DateTimeStyles.None,
                        out tempDateTime))
                    {
                        rssItem.PubDate = tempDateTime;
                    }
                }

                xmlNode = nodes[i].SelectSingleNode("author");
                if (xmlNode != null)
                    rssItem.Author = Utilities.CleanString(xmlNode.InnerText).Trim();


                xmlNode = nodes[i].SelectSingleNode("guid");
                if (xmlNode != null)
                    rssItem.Guid = xmlNode.InnerText;


                Logger.Info($"Retrieved RSS item \"{rssItem.Title}\" pub date {rssItem.PubDate} link {rssItem.Link}");

                if (rssItem.PubDate > rssWebsite.LastUpdate)
                {
                    Logger.Info($"Published RSS item \"{rssItem.Title}\" pub date {rssItem.PubDate} link {rssItem.Link}");

                    rssWebsite.LastUpdate = rssItem.PubDate;
                    OnNewRss(rssItem);
                }
            }

            rssWebsite.FirstUpdate = false;

        }


        protected void OnNewRss(RssItem item)
        {
            if (NewRss != null)
                NewRss(item);
        }


        public void Start()
        {

            Logger.Info($"{nameof(RssListener)} started");

            stopped = false;

            thread = new Thread(new ThreadStart(Run))
            {
                Name = "Listener",
                IsBackground = true
            };

            thread.Start();
        }

        public void Stop()
        {
            Logger.Info($"{nameof(RssListener)} stopped");

            stopped = true;
        }


        public bool IsRunning()
        {
            return !stopped;
        }
    }
}