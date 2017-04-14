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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Archive2Disk
{
    public partial class FormArchiveToDisk : ArchiverForm
    {
        private Archiver archiver;

        private string[] lines; // lignes du fichier de destinations précédentes
        private string filename; // path complet du fichier.


        public FormArchiveToDisk(ThisAddIn addin)
        {
            activate(addin);
            InitializeComponent();
            updateLabelsWithLang(culture);
            addLastPathsToCombo();
            selection = new List<Microsoft.Office.Interop.Outlook.MailItem>();
        }

        protected void updateLabelsWithLang(CultureInfo info)
        {
            Localisation loc = Localisation.getInstance();
            this.Text = loc.getString(info.TwoLetterISOLanguageName, this.Text);
            this.label1.Text = loc.getString(info.TwoLetterISOLanguageName, this.label1.Text);
            this.ch_date.Text = loc.getString(info.TwoLetterISOLanguageName, this.ch_date.Text);
            this.ch_subject.Text = loc.getString(info.TwoLetterISOLanguageName, this.ch_subject.Text);
            this.ch_etat.Text = loc.getString(info.TwoLetterISOLanguageName, this.ch_etat.Text);
            this.label2.Text = loc.getString(info.TwoLetterISOLanguageName, this.label2.Text);
            this.bt_ok.Text = loc.getString(info.TwoLetterISOLanguageName, this.bt_ok.Text);
            this.bt_close.Text = loc.getString(info.TwoLetterISOLanguageName, this.bt_close.Text);
            this.label3.Text = loc.getString(info.TwoLetterISOLanguageName, this.label3.Text);
            this.bt_cancel.Text = loc.getString(info.TwoLetterISOLanguageName, this.bt_cancel.Text);
            this.cb_explode_attachements.Text = loc.getString(info.TwoLetterISOLanguageName, this.cb_explode_attachements.Text);
        }

        private void addLastPathsToCombo()
        {
            filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Archive2Disk", "outlookArchiveToDiskLastFolders.txt");
            if (File.Exists(filename))
            {
                lines = File.ReadAllLines(@filename);

                var dataSource = new List<ComboItem>();

                dataSource.Add(new ComboItem() { Value = "", Id = "line0" });
                int i = 1;
                foreach (var line in lines)
                {
                    dataSource.Add(new ComboItem() { Value = line, Id = "line" + i });
                    i++;
                }

                //Setup data binding
                this.tb_destination.DataSource = dataSource;
                this.tb_destination.DisplayMember = "Value";
                this.tb_destination.ValueMember = "Id";

            }
            else
            {
                // création du répertoire
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Archive2Disk"));
                lines = new string[1];
            }
        }

        public void showDlg()
        {
            this.ShowDialog();
        }

        public void fillMailList()
        {
            if (olApplication.ActiveExplorer().Selection.Count > 0)
            {
                Outlook.Selection mySelection = olApplication.ActiveExplorer().Selection;
                Outlook.MailItem mailitem = null;

                foreach (Object obj in mySelection)
                {
                    if (obj is Outlook.MailItem)
                    {
                        mailitem = (Outlook.MailItem)obj;
                        selection.Add(mailitem);
                        var item = new ListViewItem(new string[] {
                            String.Format("{0:yyyy-MM-dd HH:mm:ss}", mailitem.ReceivedTime),
                            mailitem.Subject,
                            "-"
                        });
                        item.Name = mailitem.EntryID;
                        listView1.Items.Add(item);
                        this.l_mailsInSelection.Text = selection.Count.ToString();
                    }
                }
            }
        }

        override public void updateEtat(string id, string etat)
        {
            if(!groups.ContainsKey(etat))
            {
                ListViewGroup lvg = new ListViewGroup(etat);
                groups.Add(etat, lvg);
                listView1.Groups.Add(lvg);
            }
            try
            {
                var items = listView1.Items.Find(id, false);
                if(items.Length>0)
                {
                    items[0].SubItems[2].Text = etat;
                    items[0].Group = groups[etat];
                }
            }
            catch (Exception) { }
        }

        override public void terminate()
        {
            this.bt_close.Enabled = true;
            this.bt_cancel.Enabled = false;
        }

        private void bt_destination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fold = new FolderBrowserDialog();
            if (this.tb_destination.Text != "" && Directory.Exists(this.tb_destination.Text))
                fold.SelectedPath = this.tb_destination.Text;
            DialogResult dr = fold.ShowDialog();
            if (dr.Equals(DialogResult.OK))
            {
                this.tb_destination.Text = fold.SelectedPath;
                this.bt_ok.Enabled = true;
            }
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            this.bt_ok.Enabled = false;
            this.bt_close.Enabled = false;
            this.bt_cancel.Enabled = true;

            // réécriture du fichier de destinations précedentes
            if (!lines.Contains(tb_destination.Text))
            {
                string[] newlines = new string[lines.Length + 1];
                newlines[0] = tb_destination.Text;
                Array.ConstrainedCopy(lines, 0, newlines, 1, lines.Length);
                File.WriteAllLines(filename, newlines);
            }

            archiver = new Archiver(this.tb_destination.Text, this);
            if (this.cb_explode_attachements.Checked)
                archiver.enableExtractAttachments();
            if (Config.getInstance().getOption("TRUNCATE_PATH_TOO_LONG").Equals("TRUE")) archiver.enableTruncatePathTooLong();
            Thread t = new Thread(archiver.archive);
            t.Start();
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            archiver.askToStop();
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tb_destination_TextChanged(object sender, EventArgs e)
        {
            if (this.tb_destination.Text != ""
                && this.tb_destination.Text.Length >= 3
                && Directory.Exists(this.tb_destination.Text))
                this.bt_ok.Enabled = true;
            else
                this.bt_ok.Enabled = false;
        }

        private void tb_destination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tb_destination.Text != ""
                && this.tb_destination.Text.Length >= 3
                && Directory.Exists(this.tb_destination.Text))
                this.bt_ok.Enabled = true;
            else
                this.bt_ok.Enabled = false;
        }
    }
}
