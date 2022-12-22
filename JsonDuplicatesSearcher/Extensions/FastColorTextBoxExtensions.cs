using FastColoredTextBoxNS;
using JsonDuplicatesSearcher.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonDuplicatesSearcher.Extensions
{
    public static class FastColorTextBoxExtensions
    {
        public static string BuildString(this TextSource textSource)
        {
            var stringBuilder = new StringBuilder();
            IList<string> lines = textSource.GetLines();
            for (int i = 0; i < lines.Count; i++)
            {
                string str = lines[i];
                stringBuilder.AppendLine(str);
            }

            return stringBuilder.ToString();
        }

        public static Line CreateLine(this TextSource textSource, string lineStr)
        {
            Line line = textSource.CreateLine();
            line.AddRange(lineStr.Select(c => new FastColoredTextBoxNS.Char(c)));

            return line;
        }

        public static void AddJsonElements(this TextSource textSource, JsonElement[] jsonElements)
        {
            int lineIndex = textSource.Count;
            for (int i = 0; i < jsonElements.Length; i++)
            {
                JsonElement element = jsonElements[i];

                string[] lines = element.Json.Split('\n');
                for (int j = 0; j < lines.Length; j++)
                {
                    string lineStr = lines[j];
                    Line line = textSource.CreateLine(lineStr);
                    textSource.InsertLine(lineIndex++, line);
                }
            }
        }
    }
}
