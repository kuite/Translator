using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;

namespace Translator.Model
{
    public class TranslationService
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
            var temp = "//dl[@data-translation='" + i + "']";
            var node = doc.DocumentNode.SelectSingleNode(temp).SelectSingleNode("//div[@class='target']");
            if (node == null)
                return "-";
            return node.SelectSingleNode("//div[@class='target']").InnerText.Replace("f\n", "").Replace("m\n", "").Replace("mpl\n", "").Replace("nt\n", "").Replace("\n", "").Replace(" ", "");
        }
    }
}
