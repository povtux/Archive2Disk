using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Archive2Disk
{
    public partial class ArchiverForm : Form
    {
        public delegate void updateItem(string id, string etat);
        public updateItem updateItemDelegate;

        public delegate void endArchive();
        public endArchive endArchiveDelegate;

        public delegate void addLIne(Outlook.MailItem mailitem, string destination, string etat);
        public addLIne addLIneDelegate;

        public Outlook.Application olApplication;
        public List<Outlook.MailItem> selection;

        protected Dictionary<string, ListViewGroup> groups = new Dictionary<string, ListViewGroup>();
        public CultureInfo culture;


        protected void activate(ThisAddIn addin)
        {
            updateItemDelegate = new updateItem(updateEtat);
            endArchiveDelegate = new endArchive(terminate);
            addLIneDelegate = new addLIne(addLIneToList);

            this.olApplication = addin.getApplication();
            int lcid = this.olApplication.LanguageSettings.get_LanguageID(Microsoft.Office.Core.MsoAppLanguageID.msoLanguageIDUI);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lcid);
            culture = Thread.CurrentThread.CurrentUICulture;
        }

        public virtual void updateEtat(string id, string etat) { }
        public virtual void terminate() { }
        public virtual void addLIneToList(Outlook.MailItem mailitem, string destination, string etat) { }
    }
}
