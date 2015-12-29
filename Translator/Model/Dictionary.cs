using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Translator.Model
{
    public class Dictionary
    {
        private List<Word> _words;

        private string _sourcePath = AppDomain.CurrentDomain.BaseDirectory + "words.json";

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
        }

        private void CreateJson()
        {
            File.Create(_sourcePath);
        }

        public void AddToDictionary(Word word)
        {
            if (!File.Exists(_sourcePath))
                CreateJson();

            _words = JsonConvert.DeserializeObject<List<Word>>(File.ReadAllText(_sourcePath)) ?? new List<Word>();
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
