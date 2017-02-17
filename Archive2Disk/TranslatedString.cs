using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive2Disk
{
    class TranslatedString
    {
        Dictionary<string, string> values;
        string defaultLang;

        public TranslatedString()
        {
            values = new Dictionary<string, string>();
            defaultLang = "EN";
        }

        public TranslatedString(string lang, string value)
        {
            values = new Dictionary<string, string>();
            addOrUpdateTranslation(lang, value);
            defaultLang = "EN";
        }

        public TranslatedString(string lang, string value, bool setAsDefaultLang)
        {
            values = new Dictionary<string, string>();
            addOrUpdateTranslation(lang, value);
            if (setAsDefaultLang)
                this.defaultLang = lang;
        }

        public void addOrUpdateTranslation(string lang, string value)
        {
            values[lang] = value;
        }

        public string getTranslation(string lang)
        {
            if (values.ContainsKey(lang)) return values[lang];
            return values[defaultLang];
        }
    }
}
