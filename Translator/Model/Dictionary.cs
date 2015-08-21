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

        private string _sourcePath = @"C:\Users\kuite\Desktop\angielski\words.json";

        public List<Word> Words
        {
            get { return _words; }
        }

        public string SourcePath {
            get { return _sourcePath; }
            set { _sourcePath = value; }
        }

        public Dictionary()
        {
            _words = new List<Word>();
            if (!File.Exists(_sourcePath))
                Save();

            if (_words == null)
                _words = new List<Word>();
        }

        public void AddToDictionary(Word word)
        {
            if (!File.Exists(_sourcePath))
                Save();
            _words = JsonConvert.DeserializeObject<List<Word>>(File.ReadAllText(_sourcePath));
            _words.Add(word);
            Save();
        }

        private void Save()
        {
            var json = JsonConvert.SerializeObject(_words, Formatting.Indented);
            File.WriteAllText(_sourcePath, json);
        }

        public void CreatePdf()
        {
            Services.CreatePdf(_words, _sourcePath);
        }
    }
}
