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
using System.IO;
using System.Threading;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Archive2Disk
{
    class Archiver
    {
        private string dir;
        private ArchiverForm parent;
        private bool shouldStop = false;
        private bool extractAttachments = false;
        private bool truncatePathTooLong = false;
        private bool askPathTooLong = false;

        public Archiver(string dir, ArchiverForm parent)
        {
            this.dir = dir;
            this.parent = parent;
        }

        public void EnableExtractAttachments()
        {
            this.extractAttachments = true;
        }

        public void EnableTruncatePathTooLong()
        {
            this.truncatePathTooLong = true;
        }

        public void EnableAskPathTooLong()
        {
            this.askPathTooLong = true;
        }

        public void Archive()
        {
            var customCat = Localisation.getInstance().getString(
                parent.culture.TwoLetterISOLanguageName,
                "ARCHIVED_CATEGORY"
                );
            string msg;
            int cpt = 0;

            foreach (var item in parent.selection)
            {
                if (shouldStop)
                {
                    parent.Invoke(parent.endArchiveDelegate);
                    return;
                }
                msg = ArchiveItem(item);
                if (msg.Equals("Ok"))
                {
                    if (item.Categories == null || item.Categories.Trim().Equals("")) // no current categories assigned
                        item.Categories = customCat;
                    else if (!item.Categories.Contains(customCat)) // insert as first assigned category
                        item.Categories = string.Format("{0}, {1}", customCat, item.Categories);

                    item.Save();
                }

                parent.Invoke(parent.updateItemDelegate, new object[] { item.EntryID, msg });
                cpt++;
                Thread.Sleep(10);
            }

            parent.Invoke(parent.endArchiveDelegate);
        }

        public void MassArchive()
        {
            if (Config.GetInstance().GetOption("EXPLODE_ATTACHMENTS").Equals("TRUE")) EnableExtractAttachments();
            if (Config.GetInstance().GetOption("TRUNCATE_PATH_TOO_LONG").Equals("TRUE")) EnableTruncatePathTooLong();
            if (Config.GetInstance().GetOption("ASK_PATH_TOO_LONG").Equals("TRUE")) EnableAskPathTooLong();

            string msg;
            var customCat = Localisation.getInstance().getString(
                parent.culture.TwoLetterISOLanguageName,
                "ARCHIVED_CATEGORY"
                );
            var binding = Config.GetInstance().GetFoldersBinding();
            Outlook.Folder root = parent.olApplication.Session.DefaultStore.GetRootFolder() as Outlook.Folder;
            foreach (string key in binding.Keys)
            {
                // get the mapi folder from ID
                Outlook.Folder folder = EnumerateFolders(root, key);
                if(folder.EntryID == key)
                {
                    // iterate mails in folder
                    foreach(var item in folder.Items)
                    {
                        if (item is Outlook.MailItem mailitem)
                        {

                            // if no category or not categorised as achived, archive and continue
                            if (mailitem.Categories == null ||
                                mailitem.Categories.Trim().Equals("") ||
                                !mailitem.Categories.Contains(customCat))
                            {
                                // archive items
                                msg = ArchiveItem(mailitem, binding[key], null);
                                // update categories if needed
                                if (msg.Equals("Ok"))
                                {
                                    if (mailitem.Categories == null || mailitem.Categories.Trim().Equals("")) // no current categories assigned
                                        mailitem.Categories = customCat;
                                    else if (!mailitem.Categories.Contains(customCat)) // insert as first assigned category
                                        mailitem.Categories = string.Format("{0}, {1}", customCat, mailitem.Categories);

                                    mailitem.Save();
                                }
                                // add line to form
                                parent.Invoke(parent.addLIneDelegate, new object[] {
                                    mailitem, binding[key],msg
                                });
                            }
                            else // already categorised
                            {
                                parent.Invoke(parent.addLIneDelegate, new object[] {
                                mailitem,
                                "",
                                Localisation.getInstance().getString(
                                    parent.culture.TwoLetterISOLanguageName,
                                    "ALREADY_CATEGORISED_AS_ARCHIVED")
                                });
                            }
                        }
                    }
                }
            }
            parent.Invoke(parent.endArchiveDelegate);
        }

        private Outlook.Folder EnumerateFolders(Outlook.Folder folder, string id)
        {
            if (folder.EntryID == id) return folder;

            Outlook.Folders childFolders = folder.Folders;
            if (childFolders.Count > 0)
            {
                foreach (Outlook.Folder childFolder in childFolders)
                {
                    if (childFolder.DefaultItemType == Outlook.OlItemType.olMailItem)
                    {
                        // Call EnumerateFolders using childFolder.
                        var f = EnumerateFolders(childFolder, id);
                        if (f != null && f.EntryID == id) return f;
                    }
                }
            }
            return null;
        }

        public void AskToStop()
        {
            shouldStop = true;
        }

        public string ArchiveItem(Outlook.MailItem item)
        {
            return ArchiveItem(item, this.dir, null);
        }

        public string ArchiveItem(Outlook.MailItem item, string dir, string newname)
        {
            string archived = "erreur";
            string shortFilename = String.Format("{0:yyyy-MM-dd_HHmmss}", item.ReceivedTime) + "-";
            if(Config.GetInstance().GetOption("ADD_CATEGORIES_IN_FILENAME") == "TRUE")
            {
                if(item.Categories != null)
                    shortFilename += item.Categories.Replace(';', '-') + "-";
            }
            if (newname != null)
                shortFilename += CleanFileName(newname);
            else
                shortFilename += CleanFileName(item.Subject);
            string filename = Path.Combine(dir, shortFilename + ".msg");

            // si extraction dans dossier séparé, on redéfini le filename
            if(extractAttachments)
            {
                dir = Path.Combine(dir, shortFilename);
                filename = Path.Combine(dir, shortFilename + ".msg");
            }

            // si on fleurte avec les limites, on ne sauve pas
            if (dir.Length > 230)
            {
                return Localisation.getInstance().getString(
                    parent.culture.TwoLetterISOLanguageName,
                    "PATH_TOO_LONG"
                    );
            }

            // si on fleurte avec les limites, on ne sauve pas
            if (filename.Length > 250)
            {
                if(truncatePathTooLong)
                    filename = filename.Substring(0, 250) + ".msg";
                else if(askPathTooLong)
                {
                    do
                    {
                        string error = Localisation.getInstance().getString(
                                parent.culture.TwoLetterISOLanguageName,
                                "FULL_PATH_TOO_LONG"
                           );

                        shortFilename = SingleQuestionForm.Ask(
                            Localisation.getInstance().getString(
                                parent.culture.TwoLetterISOLanguageName,
                                "QUESTION_FULL_PATH_TOO_LONG"
                           ),
                            shortFilename,
                            null, 
                            null,
                            error);

                        filename = Path.Combine(dir, shortFilename + ".msg");
                    } while (filename.Length > 254 || File.Exists(filename));
                }
                else
                    return Localisation.getInstance().getString(
                                parent.culture.TwoLetterISOLanguageName,
                                "FULL_PATH_TOO_LONG"
                           );
            }

            // si fichier déjà existant, on ne sauve pas
            if (File.Exists(filename)) return Localisation.getInstance().getString(
                parent.culture.TwoLetterISOLanguageName,
                "FILE_ALREADY_EXISTS"
                );

            // si extraction des attachements, on est OK sur longueur et not exists, on tente de créer le répertoire
            if(extractAttachments)
            {
                Directory.CreateDirectory(dir);
            }

            // on tente de sauver
            try
            {
                item.SaveAs(filename, Outlook.OlSaveAsType.olMSGUnicode);

                // si extration des attachements, on extract
                if(extractAttachments)
                {
                    foreach(Outlook.Attachment att in item.Attachments)
                    {
                        att.SaveAsFile(Path.Combine(dir, att.FileName));
                    }
                }
                archived = "Ok";
            }
            catch (Exception e)
            {
                archived = e.Message;
            }

            return archived;
        }

        private string CleanFileName(string origin)
        {
            if (origin == null || origin.Equals("")) return "(sans sujet)";
            return origin.Replace('"', '_')
                .Replace('[', '_')
                .Replace(':', '_')
                .Replace('/', '_')
                .Replace('*', '_')
                .Replace('?', '_')
                .Replace('|', '_')
                .Replace('<', '_')
                .Replace('>', '_')
                .Replace(']', '_')
                .Replace(';', '_')
                .Replace('+', '_')
                .Replace('\r', '_')
                .Replace('\n', '_')
                .Replace('\'', '_')
                .Replace('°', '_')
                .Replace(',', '_')
                .Replace('\t', ' ')
                .Replace('\b', ' ')
                .Trim();
        }
    }
}
