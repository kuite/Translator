using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator.Model
{
    public class TranslationService
    {
        public static IEnumerable<string> Translate(string word)
        {
            var list = new List<string>();
            //todo: get web content of google translate then extract 3 matches and return as list
            return list;
        } 
    }
}
