using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Archive2Disk
{
    public partial class FormMassArchiveToDisk : ArchiverForm
    {
        private Archiver archiver;

        public FormMassArchiveToDisk(ThisAddIn addin) : base(addin)
        {
            InitializeComponent();
            updateLabelsWithLang(culture);
            this.archiver = new Archiver("", this);

            this.bt_close.Enabled = false;
            this.bt_cancel.Enabled = true;
        }

        public void showDlg()
        {
            Thread t = new Thread(archiver.massArchive);
            t.Start();

            this.ShowDialog();
        }

        protected void updateLabelsWithLang(CultureInfo info)
        {
            Localisation loc = Localisation.getInstance();
            this.Text = loc.getString(info.TwoLetterISOLanguageName, this.Text);
            this.label1.Text = loc.getString(info.TwoLetterISOLanguageName, this.label1.Text);
            this.ch_date.Text = loc.getString(info.TwoLetterISOLanguageName, this.ch_date.Text);
            this.ch_subject.Text = loc.getString(info.TwoLetterISOLanguageName, this.ch_subject.Text);
            this.ch_state.Text = loc.getString(info.TwoLetterISOLanguageName, this.ch_state.Text);
            this.ch_destination.Text = loc.getString(info.TwoLetterISOLanguageName, this.ch_destination.Text);
            this.bt_close.Text = loc.getString(info.TwoLetterISOLanguageName, this.bt_close.Text);
            this.bt_cancel.Text = loc.getString(info.TwoLetterISOLanguageName, this.bt_cancel.Text);
        }

/*        override public void updateEtat(string id, string etat)
        {
            if (!groups.ContainsKey(etat))
            {
                ListViewGroup lvg = new ListViewGroup(etat);
                groups.Add(etat, lvg);
                listView1.Groups.Add(lvg);
            }
            try
            {
                var items = listView1.Items.Find(id, false);
                if (items.Length > 0)
                {
                    items[0].SubItems[2].Text = etat;
                    items[0].Group = groups[etat];
                }
            }
            catch (Exception) { }
        }*/

        override public void addLIneToList(Outlook.MailItem mailitem, string destination, string etat)
        {
            if (!groups.ContainsKey(etat))
            {
                ListViewGroup lvg = new ListViewGroup(etat);
                groups.Add(etat, lvg);
                listView1.Groups.Add(lvg);
            }

            var item = new ListViewItem(new string[] {
                            String.Format("{0:yyyy-MM-dd HH:mm:ss}", mailitem.ReceivedTime),
                            mailitem.Subject,
                            destination,
                            etat
                        });
            item.Name = mailitem.EntryID;
            item.Group = groups[etat];
            listView1.Items.Add(item);
        }

        override public void terminate()
        {
            this.bt_close.Enabled = true;
            this.bt_cancel.Enabled = false;
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            archiver.askToStop();
        }
    }
}
