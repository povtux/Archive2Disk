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
using System.Globalization;
using System.Resources;

namespace Archive2Disk
{
    class Localisation
    {
        static Localisation instance = new Localisation();
        ResourceManager res_man;

        private Localisation() {}

        public static Localisation getInstance()
        {
            return instance;
        }

        public string getString(string lg, string id)
        {
            if (res_man == null)
                res_man = new ResourceManager("Archive2Disk.Ressources.lang", typeof(ArchiverForm).Assembly);
            CultureInfo ci = CultureInfo.CreateSpecificCulture(lg);
            return res_man.GetString(id, ci);
        }
    }
}
