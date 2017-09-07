using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DanielBogdan.PlainRSS.Core
{
    public class Utilities
    {

        /// <summary>
        /// Truncate text using a maximum size and add ellipsis
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maximumSize"></param>
        /// <returns></returns>
        public static string TruncateText(string text, int maximumSize)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text), @"Text should not be empty");

            if (maximumSize <= 0)
                throw new ArgumentNullException(nameof(maximumSize), @"MaximumSize should be greater than 0");


            if (maximumSize >= text.Length)
                return text;


            return text.Substring(0, maximumSize) + "...";
        }

        /// <summary>
        /// Clean string by url decoding, html decoding and removing html tags 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string CleanString(string text)
        {

            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text), @"Text should not be empty");

            text = HttpUtility.UrlDecode(text);
            text = HttpUtility.HtmlDecode(text);
            text = HtmlUtils.StripTags(text);

            text = text.Replace("\r", "");
            text = text.Replace("\n", "");

            return text;
        }

        /// <summary>
        /// Wrap text by number of characters per line
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxCharsPerLine"></param>
        /// <returns></returns>
        public static IList<string> WrapTextByCharacterNo(string text, int maxCharsPerLine)
        {

            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text), @"Text should not be empty");

            if (maxCharsPerLine <= 0)
                throw new ArgumentNullException(nameof(maxCharsPerLine), @"MaxCharsPerLine should be greater than 0");


            var wrappedLines = new List<string>();
            var index = 0;

            do
            {
                wrappedLines.Add(text.Substring(index, (maxCharsPerLine + index > text.Length ? text.Length - index : maxCharsPerLine)));
                index += maxCharsPerLine;
            }
            while (index < text.Length);

            return wrappedLines;
        }


        /// <summary>
        /// Wrap text by number of characters per line but keep complete words
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxCharsPerLine"></param>
        /// <returns></returns>
        public static List<string> WrapTextByCharacterNoFull(string text, int maxCharsPerLine)
        {


            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text), @"Text should not be empty");

            if (maxCharsPerLine <= 0)
                throw new ArgumentNullException(nameof(maxCharsPerLine), @"MaxCharsPerLine should be greater than 0");


            string[] words = text.Split(new string[] { " " }, StringSplitOptions.None);

            var wrappedLines = new List<string>();

            var currentLine = new StringBuilder();
            float currentLineWidth = 0;

            foreach (var word in words)
            {


                if (currentLineWidth + word.Length <= maxCharsPerLine)
                {

                    currentLine.Append(word + " ");
                    currentLineWidth += word.Length;
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
