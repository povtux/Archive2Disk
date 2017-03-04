//------------------------------------------------------------------------------
// This file is part of Archive2Disk.
//
// Archive2Disk is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Archive2Disk is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Archive2Disk.  If not, see <http://www.gnu.org/licenses/>.
//------------------------------------------------------------------------------

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
