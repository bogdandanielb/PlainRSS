using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DanielBogdan.PlainRSS.UI
{
    public class UIUtilities
    {
        /// <summary>
        /// Wrap text based on a width in pixels
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxWidthInPixels"></param>
        /// <param name="g"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public static List<string> WrapTextByPixelSize(string text, int maxWidthInPixels, Graphics g, Font font)
        {
            string[] words = text.Split(new string[] { " " }, StringSplitOptions.None);

            var wrappedLines = new List<string>();

            var currentLine = new StringBuilder();
            float currentLineWidth = 0;

            foreach (var word in words)
            {
                var wordSize = g.MeasureString(word, font);

                if (currentLineWidth + wordSize.Width <= maxWidthInPixels)
                {

                    currentLine.Append(word + " ");
                    currentLineWidth += wordSize.Width;
                }
                else
                {
                    wrappedLines.Add(currentLine.ToString());
                    currentLine.Clear();
                    currentLineWidth = 0;
                }
            }

            if (currentLine.Length > 0)
                wrappedLines.Add(currentLine.ToString());

            return wrappedLines;
        }
    }
}
