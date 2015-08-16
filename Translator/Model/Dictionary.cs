using System.Collections.Generic;

namespace Translator.Model
{
    public class Dictionary
    {
        private string _unknown;
        private string _translatedOne;
        private string _translatedTwo;
        private string _translatedThree;

        public string Unknown
        {
            get { return _unknown; }
            set { _unknown = value; }
        }

        public string TranslatedOne
        {
            get { return _translatedOne; }
            set { _translatedOne = value; }
        }

        public string TranslatedTwo
        {
            get { return _translatedTwo; }
            set { _translatedTwo = value; }
        }

        public string TranslatedThree
        {
            get { return _translatedThree; }
            set { _translatedThree = value; }
        }

        //TODO
        public void TranslateUnknown()
        {
            TranslatedOne = "roman";
            TranslatedTwo = "zdzisio";
            TranslatedThree = "bodzio";
        }
    }
}
