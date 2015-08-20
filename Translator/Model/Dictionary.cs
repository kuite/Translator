using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Translator.Model
{
    public class Dictionary
    {
        private List<Word> _words;

        private const string SourcePath = @"C:\Users\kuite\Desktop\angielski\words.json";

        public List<Word> Words
        {
            get { return _words; }
        }

        public Dictionary()
        {
            _words = new List<Word>();
            if (!File.Exists(SourcePath)) Save();
        }

        public void AddToDictionary(Word word)
        {
            _words = JsonConvert.DeserializeObject<List<Word>>(File.ReadAllText(SourcePath));
            _words.Add(word);
            Save();
        }

        private void Save()
        {
            var json = JsonConvert.SerializeObject(_words, Formatting.Indented);
            File.WriteAllText(SourcePath, json);
        }
    }
}
