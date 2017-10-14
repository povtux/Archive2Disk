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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Globalization;

// TODO:  suivez ces étapes pour activer l'élément (XML) Ruban :

// 1. Copiez le bloc de code suivant dans la classe ThisAddin, ThisWorkbook ou ThisDocument.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon1();
//  }

// 2. Créez des méthodes de rappel dans la région "Rappels du ruban" de cette classe pour gérer les actions des utilisateurs
//    comme les clics sur un bouton. Remarque : si vous avez exporté ce ruban à partir du Concepteur de ruban,
//    vous devrez déplacer votre code des gestionnaires d'événements vers les méthodes de rappel et modifiez le code pour qu'il fonctionne avec
//    le modèle de programmation d'extensibilité du ruban (RibbonX).

// 3. Assignez les attributs aux balises de contrôle dans le fichier XML du ruban pour identifier les méthodes de rappel appropriées dans votre code.  

// Pour plus d'informations, consultez la documentation XML du ruban dans l'aide de Visual Studio Tools pour Office.


namespace Archive2Disk
{
    [ComVisible(true)]
    public class Ribbon1 : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private ThisAddIn addin;
        private FormArchiveToDisk f;
        private CultureInfo culture;

        public Ribbon1(ThisAddIn outlookApplication, CultureInfo culture)
        {
            addin = outlookApplication;
            this.culture = culture;
        }


        #region Membres IRibbonExtensibility

        public string GetCustomUI(string ribbonID)
        {
            if(culture.TwoLetterISOLanguageName.Equals("fr"))
                return GetResourceText("Archive2Disk.Ribbonfr.xml");
            if (culture.TwoLetterISOLanguageName.Equals("de"))
                return GetResourceText("Archive2Disk.Ribbonde.xml");
            return GetResourceText("Archive2Disk.Ribbonen.xml");
        }

        #endregion

        #region Rappels du ruban
        //Créez des méthodes de rappel ici. Pour plus d'informations sur l'ajout de méthodes de rappel, consultez http://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        public void OnMyButtonClick(Office.IRibbonControl control)
        {
            f = new FormArchiveToDisk(addin);
            f.Shown += F_Shown;
            Thread t = new Thread(f.ShowDlg);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        public void OnBtInfoClick(Office.IRibbonControl control)
        {
            var formAbout = new AboutBox1(); //AboutForm();
            formAbout.ShowDialog();
        }

        public void OnBtConfigClick(Office.IRibbonControl control)
        {
            var configForm = new ConfigForm(addin);
            configForm.ShowDialog();
        }

        public void OnBtHelpClick(Office.IRibbonControl control)
        {
            System.Diagnostics.Process.Start("https://github.com/povtux/Archive2Disk/raw/master/manuel%20Archive2Disk.pdf");
        }

        public void OnBtMassArchiveClick(Office.IRibbonControl control)
        {
            var massForm = new FormMassArchiveToDisk(addin);
            massForm.ShowDlg();
        }

        public void OnBtArchiveRenameClick(Office.IRibbonControl control)
        {
            var renForm = new FormArchiveRename(addin);
            renForm.ShowDlg();
        }

        private void F_Shown(object sender, EventArgs e)
        {
            f.FillMailList();
        }

        #endregion

        public Bitmap GetImage(Office.IRibbonControl control)
        {
            switch (control.Id)
            {
                case "MyContextMenuMailItem":
                case "MyContextMenuMultipleItems":
                case "BtArchive":
                case "Archive2DiskBtArchiveRenameClick":
                case "BtMassArchive":
                    {
                        Assembly myAssembly = Assembly.GetExecutingAssembly();
                        Stream myStream = myAssembly.GetManifestResourceStream("Archive2Disk.icon_archive.png");
                        return new Bitmap(myStream);
                    }
                case "BtConfig":
                    {
                        Assembly myAssembly = Assembly.GetExecutingAssembly();
                        Stream myStream = myAssembly.GetManifestResourceStream("Archive2Disk.Config-Tools.png");
                        return new Bitmap(myStream);
                    }
                case "BtInfo":
                    {
                        Assembly myAssembly = Assembly.GetExecutingAssembly();
                        Stream myStream = myAssembly.GetManifestResourceStream("Archive2Disk.info.png");
                        return new Bitmap(myStream);
                    }
                case "BtHelp":
                    {
                        Assembly myAssembly = Assembly.GetExecutingAssembly();
                        Stream myStream = myAssembly.GetManifestResourceStream("Archive2Disk.help.png");
                        return new Bitmap(myStream);
                    }
            }
            return null;
        }

        #region Programmes d'assistance

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
