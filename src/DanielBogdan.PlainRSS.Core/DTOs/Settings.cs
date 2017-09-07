using DanielBogdan.PlainRSS.Core.Domain;
using System;
using System.ComponentModel;

namespace DanielBogdan.PlainRSS.Core.DTOs
{
    [Serializable]
    public class Settings
    {
        public int MaxHistoryItems { get; set; } = 50;

        public int Delay { get; set; } = 3;

        public double Opacity { get; set; } = 0.7;

        public bool AlwaysOnTop { get; set; } = false;

        public BindingList<RssCategory> RssCategories { get; set; } = new BindingList<RssCategory>();

        public bool IgnoreEnabled { get; set; } = false;
        public string IgnoredItems { get; set; }
    }
}