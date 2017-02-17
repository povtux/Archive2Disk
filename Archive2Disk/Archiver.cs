using System;
using System.IO;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Archive2Disk
{
    class Archiver
    {
        private string dir;
        private ArchiverForm parent;
        private bool shouldStop = false;

        public Archiver(string dir, ArchiverForm parent)
        {
            this.dir = dir;
            this.parent = parent;
        }

        public void archive()
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
                msg = archiveItem(item);
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
            }

            parent.Invoke(parent.endArchiveDelegate);
        }

        public void massArchive()
        {
            string msg;
            var customCat = Localisation.getInstance().getString(
                parent.culture.TwoLetterISOLanguageName,
                "ARCHIVED_CATEGORY"
                );
            var binding = Config.getInstance().getFoldersBinding();
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
                        if(item is Outlook.MailItem)
                        {
                            var mailitem = (Outlook.MailItem)item;

                            // if no category or not categorised as achived, archive and continue
                            if(mailitem.Categories == null || 
                                mailitem.Categories.Trim().Equals("") ||
                                !mailitem.Categories.Contains(customCat))
                            {
                                // archive items
                                msg = archiveItem(mailitem, binding[key]);
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

        public void askToStop()
        {
            shouldStop = true;
        }

        public string archiveItem(Outlook.MailItem item)
        {
            return archiveItem(item, this.dir);
        }

        public string archiveItem(Outlook.MailItem item, string dir)
        {
            string archived = "erreur";
            string filename = Path.Combine(dir, String.Format("{0:yyyy-MM-dd_HHmmss}", item.ReceivedTime) + "-" + cleanFileName(item.Subject) + ".msg");

            // si on fleurte avec les limites, on ne sauve pas
            if (filename.Length > 250) return Localisation.getInstance().getString(
                parent.culture.TwoLetterISOLanguageName,
                "PATH_TOO_LONG"
                );

            // si fichier déjà existant, on ne sauve pas
            if (File.Exists(filename)) return Localisation.getInstance().getString(
                parent.culture.TwoLetterISOLanguageName,
                "FILE_ALREADY_EXISTS"
                );

            // on tente de sauver
            try
            {
                item.SaveAs(filename, Outlook.OlSaveAsType.olMSGUnicode);
                archived = "Ok";
            }
            catch (Exception e)
            {
                archived = e.Message;
            }

            return archived;
        }

        private string cleanFileName(string origin)
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
