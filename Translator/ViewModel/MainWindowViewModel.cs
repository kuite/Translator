using System.Windows.Input;
using Translator.Model;

namespace Translator.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public string Message { get; set; }

        public ICommand TranslateButton { get; set; }

        public ICommand AddToListButton { get; set; }

        public ICommand GeneratePdfButton { get; set; }

        private Word _word = new Word();
        private Dictionary _dictionary = new Dictionary();

        public MainWindowViewModel()
        {
            TranslateButton = new RelayCommand(Translate);
            AddToListButton = new RelayCommand(AddToList);
            GeneratePdfButton = new RelayCommand(GeneratePdf);
        }

        public Dictionary Dictionary
        {
            get { return _dictionary;}
            set
            {
                _dictionary = value;
                RaisePropertyChangedEvent("Dictionary");
            }
        }

        public Word Word
        {
            get { return _word; }
            set
            {
                _word = value;
                RaisePropertyChangedEvent("Word");
            }
        }
        
        private void Translate(object obj)
        {
            _word.TranslateUnknown();
            RaisePropertyChangedEvent("Word");
        }

        private void GeneratePdf(object obj)
        {
            _dictionary.CreatePdf();
        }

        private void AddToList(object obj)
        {
            _dictionary.AddToDictionary(_word);
        }
    }
}
