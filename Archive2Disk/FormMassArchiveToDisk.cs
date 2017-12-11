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
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Archive2Disk
{
    public partial class FormMassArchiveToDisk : ArchiverForm
    {
        private Archiver archiver;
        private Thread t;

        public FormMassArchiveToDisk(ThisAddIn addin)
        {
            Activate(addin);
            InitializeComponent();
            UpdateLabelsWithLang(culture);

            this.archiver = new Archiver("", this);

            this.bt_close.Enabled = false;
            this.bt_cancel.Enabled = true;
        }

        public void ShowDlg()
        {
            if (MessageBox.Show(
                Localisation.getInstance().getString(culture.TwoLetterISOLanguageName, "MESSAGE_ARE_YOU_SURE"),
                Localisation.getInstance().getString(culture.TwoLetterISOLanguageName, "FORM_ARCHIVE_TO_DISK_TITLE"),
                MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            t = new Thread(archiver.MassArchive);
            t.Start();

            this.ShowDialog();
        }

        protected void UpdateLabelsWithLang(CultureInfo info)
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

        override public void AddLIneToList(Outlook.MailItem mailitem, string destination, string etat)
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
                        })
            {
                Name = mailitem.EntryID,
                Group = groups[etat]
            };
            listView1.Items.Add(item);
        }

        override public void Terminate()
        {
            this.bt_close.Enabled = true;
            this.bt_cancel.Enabled = false;
        }

        private void Bt_close_Click(object sender, EventArgs e)
        {
            archiver.AskToStop();
            t.Abort();
            this.Hide();
        }

        private void Bt_cancel_Click(object sender, EventArgs e)
        {
            archiver.AskToStop();
            t.Abort();
            this.Terminate();
        }
    }
}
