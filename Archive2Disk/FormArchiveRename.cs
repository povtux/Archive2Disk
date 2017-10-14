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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archive2Disk
{
    public partial class FormArchiveRename : ArchiverForm
    {
        private Archiver archiver;

        private string[] lines; // lignes du fichier de destinations précédentes
        private string filename; // path complet du fichier.
        private Microsoft.Office.Interop.Outlook.MailItem mailitem = null;

        public FormArchiveRename(ThisAddIn addin)
        {
            Activate(addin);

            if (addin.GetApplication().ActiveExplorer().Selection.Count > 0)
            {
                Microsoft.Office.Interop.Outlook.Selection mySelection = addin.GetApplication().ActiveExplorer().Selection;
                

                foreach (Object obj in mySelection)
                {
                    if (obj is Microsoft.Office.Interop.Outlook.MailItem)
                    {
                        mailitem = (Microsoft.Office.Interop.Outlook.MailItem)obj;
                    }
                }
            }

            InitializeComponent();
            UpdateLabelsWithLang(culture);
            AddLastPathsToCombo();
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

        protected void UpdateLabelsWithLang(CultureInfo info)
        {
            Localisation loc = Localisation.getInstance();
            this.Text = loc.getString(info.TwoLetterISOLanguageName, this.Text);
            this.TB_RENAME.Text = mailitem.Subject;
            this.LABEL_DESTINATION.Text = loc.getString(info.TwoLetterISOLanguageName, this.LABEL_DESTINATION.Text);
            this.LABEL_RENAME.Text = loc.getString(info.TwoLetterISOLanguageName, this.LABEL_RENAME.Text);
            this.bt_ok.Text = loc.getString(info.TwoLetterISOLanguageName, this.bt_ok.Text);
            this.bt_cancel.Text = loc.getString(info.TwoLetterISOLanguageName, this.bt_cancel.Text);
            this.cb_explode_attachements.Text = loc.getString(info.TwoLetterISOLanguageName, this.cb_explode_attachements.Text);
        }

        private void AddLastPathsToCombo()
        {
            filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Archive2Disk", "outlookArchiveToDiskLastFolders.txt");
            if (File.Exists(filename))
            {
                lines = File.ReadAllLines(@filename);

                var dataSource = new List<ComboItem>
                {
                    new ComboItem() { Value = "", Id = "line0" }
                };
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

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            this.Hide();
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
                archiver.EnableExtractAttachments();
            if (Config.GetInstance().GetOption("TRUNCATE_PATH_TOO_LONG").Equals("TRUE")) archiver.EnableTruncatePathTooLong();
            if (Config.GetInstance().GetOption("ASK_PATH_TOO_LONG").Equals("TRUE")) archiver.EnableAskPathTooLong();
            string res = archiver.ArchiveItem(mailitem,
                                    this.tb_destination.Text,
                                    this.TB_RENAME.Text);
            if(res == "Ok")
            {
                var customCat = Localisation.getInstance().getString(
                    culture.TwoLetterISOLanguageName,
                    "ARCHIVED_CATEGORY"
                    );
                if (mailitem.Categories == null || mailitem.Categories.Trim().Equals("")) // no current categories assigned
                    mailitem.Categories = customCat;
                else if (!mailitem.Categories.Contains(customCat)) // insert as first assigned category
                    mailitem.Categories = string.Format("{0}, {1}", customCat, mailitem.Categories);

                mailitem.Save();
            }
            MessageBox.Show(res);
            this.Dispose();
        }

        public void ShowDlg()
        {
            this.ShowDialog();
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
