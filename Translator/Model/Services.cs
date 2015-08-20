using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace Translator.Model
{
    public class Services
    {
        public static IEnumerable<string> Translate(string word)
        {
            var list = new List<string>();
            var htmlWeb = new HtmlWeb();
            var doc = htmlWeb.Load("http://en.pons.com/translate?q=" + word + "&l=enpl&in=&lf=en");

            var oneText = GetText(doc, 0);
            var twoText = GetText(doc, 1);
            var threeText = GetText(doc, 2);

            list.Add(oneText);
            list.Add(twoText);
            list.Add(threeText);
            return list;
        }

        private static string GetText(HtmlDocument doc, int i)
        {
            var node = doc.DocumentNode.SelectSingleNode("//dl[@data-translation='" + i + "']");
            if (node == null)
                return "-";
            var textNode = node.ChildNodes.Where(x => x.Name == "dd").ElementAt(0);

            const RegexOptions options = RegexOptions.None;
            var regex = new Regex(" {2,}", options);
            var text = textNode.SelectSingleNode(".//div[@class='target']").InnerText;
            text = regex.Replace(text, @" ");

            return text.Replace("f\n", "").
                Replace(" f ", " ").Replace("m\n", "").Replace("mpl\n", "").Replace("nt\n", "").
                Replace("\n", "").Replace("\n\n", "").Replace("  ", "").Replace(" nt ", " ").Replace(" m ", " ");
        }
    }
}
