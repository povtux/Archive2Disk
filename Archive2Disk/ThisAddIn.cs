using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Globalization;
using System.Threading;

namespace Archive2Disk
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            AddACategory();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Remarque : Outlook ne déclenche plus cet événement. Si du code
            //    doit s'exécuter à la fermeture d'Outlook, voir http://go.microsoft.com/fwlink/?LinkId=506785
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            Outlook.Application app = this.GetHostItem<Outlook.Application>(typeof(Outlook.Application), "Application");
            int lcid = app.LanguageSettings.get_LanguageID(Office.MsoAppLanguageID.msoLanguageIDUI);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lcid);
            return new Ribbon1(this, Thread.CurrentThread.CurrentUICulture);
        }

        public Outlook.Application getApplication()
        {
            return this.Application;
        }

        private void AddACategory()
        {
            Outlook.Categories categories =
                Application.Session.Categories;
            if (!CategoryExists("Archivé"))
            {
                Outlook.Category category = categories.Add("Archivé",
                    Outlook.OlCategoryColor.olCategoryColorGreen);
            }
        }

        private bool CategoryExists(string categoryName)
        {
            try
            {
                Outlook.Category category =
                    Application.Session.Categories[categoryName];
                if (category != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
        #region Code généré par VSTO

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
