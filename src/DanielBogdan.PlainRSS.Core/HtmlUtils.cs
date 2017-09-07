using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;

namespace DanielBogdan.PlainRSS.Core
{
    public class HtmlUtils
    {

        /// <summary>
        /// Decode javascript non html encodings - contained by JSON.Decode
        /// </summary>
        /// <param name="html"></param>
        /// <param name="no"></param>
        /// <returns></returns>
        public static string DecodeEncodedNonAsciiCharacters(string html, int no)
        {
            return Regex.Replace(html, @"\\u(?<Value>[a-zA-Z0-9]{" + no + "})", new MatchEvaluator(DecodeEncoded));
        }

        private static string DecodeEncoded(Match match)
        {
            var val = 0;

            if (int.TryParse(match.Groups["Value"].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out val))
                return ((char)val).ToString();
            else
                return match.Value;

        }

        /// <summary>
        /// Parse html hiddens
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ParseHiddens(string html)
        {
            var values = new Dictionary<string, string>();

            var regex = new Regex("<input[^<>]*?type\\s*?=\\s*?[\"']?hidden[\"']?[^<>]*?>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var reName = new Regex("name\\s*?=\\s*?[\"']?([^<>]*?)[\"'\\s]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var reValue = new Regex("value\\s*?=\\s*?[\"']([^<>]*?)[\"']", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            for (var match = regex.Match(html); match.Success; match = match.NextMatch())
            {
                var mName = reName.Match(match.Value);
                if (!mName.Success)
                {
                    continue;
                }
                var mValue = reValue.Match(match.Value);
                values[HttpUtility.HtmlDecode(mName.Groups[1].Value)] = HttpUtility.HtmlDecode(mValue.Groups[1].Value); //no URL decode allowed here
            }

            return values;
        }

        /// <summary>
        /// Parse html inputs
        /// </summary>
        /// <param name="html"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ParseInputs(string html, string type)
        {
            var values = new Dictionary<string, string>();

            var mainRegex = "<input[^<>]*?>";
            if (!string.IsNullOrEmpty(type.Trim()))
                mainRegex = "<input[^<>]*?type\\s*?=\\s*?[\"']?" + type.Trim() + "[\"']?[^<>]*?>";

            var regex = new Regex(mainRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var reName = new Regex("name\\s*?=\\s*?[\"']?([^<>]*?)[\"'\\s]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var reValue = new Regex("value\\s*?=\\s*?[\"']([^<>]*?)[\"']", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            for (var match = regex.Match(html); match.Success; match = match.NextMatch())
            {
                var mName = reName.Match(match.Value);
                if (!mName.Success)
                {
                    continue;
                }
                var mValue = reValue.Match(match.Value);
                values[HttpUtility.HtmlDecode(mName.Groups[1].Value)] = HttpUtility.HtmlDecode(mValue.Groups[1].Value); //no URL decode allowed here
            }

            return values;
        }




        /// <summary>
        /// Clear all tags from html
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string StripTags(string html)
        {


            var regexTag = new Regex("<[^<>]*?>");
            var matchTag = regexTag.Match(html);
            while (matchTag.Success)
            {
                html = html.Substring(0, matchTag.Index) + html.Substring(matchTag.Index + matchTag.Length);
                matchTag = regexTag.Match(html);
            }

            return html;

        }

        /// <summary>
        /// Decodes html encoding for unicode characters like &#0040;
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string HtmlDecodeSpecialChars(string html)
        {

            var regexTag = new Regex("&#(\\d+?)[\\D$]", RegexOptions.Multiline);
            var matchTag = regexTag.Match(html);
            while (matchTag.Success)
            {
                html = html.Substring(0, matchTag.Index) + (char)(Convert.ToInt32(matchTag.Groups[1].Value)) + html.Substring(matchTag.Index + matchTag.Length - (matchTag.Value.EndsWith(";") ? 0 : 1));
                matchTag = regexTag.Match(html);
            }

            return html;

        }


        public static string DecodeQuotedPrintable(string html)
        {
            var hexRegex = new Regex(@"(\=([0-9A-F][0-9A-F]))", RegexOptions.IgnoreCase);
            var match = hexRegex.Match(html);
            while (match.Success)
            {
                var dec = (char)Convert.ToInt32(match.Groups[2].Value, 16);
                html = html.Substring(0, match.Index) + dec + html.Substring(match.Index + match.Length);
                match = hexRegex.Match(html);
            }
            html = html.Replace("=\r\n", "");
            return html;

        }


    }
}
