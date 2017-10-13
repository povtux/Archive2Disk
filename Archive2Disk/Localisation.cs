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
        Dictionary<string, TranslatedString> strings;
        static Localisation instance = new Localisation();
        ResourceManager res_man;

        private Localisation()
        {
            strings = new Dictionary<string, TranslatedString>();

            // LANG: EN
            strings["FORM_ARCHIVE_TO_DISK_TITLE"] = new TranslatedString("en", "Archive2Disk", true);
            strings["LABEL_DESTINATION"] = new TranslatedString("en", "Destination:", true);
            strings["LABEL_LIST_TITLE"] = new TranslatedString("en", "Emails to archive:", true);
            strings["LABEL_NB_MAILS"] = new TranslatedString("en", "Mail count:", true);
            strings["BT_CANCEL"] = new TranslatedString("en", "Cancel", true);
            strings["BT_CLOSE"] = new TranslatedString("en", "Close", true);
            strings["BT_OK"] = new TranslatedString("en", "Ok", true);
            strings["LIST_COLUMN_DATE"] = new TranslatedString("en", "Receive date", true);
            strings["LIST_COLUMN_SUBJECT"] = new TranslatedString("en", "Subjet", true);
            strings["LIST_COLUMN_STATE"] = new TranslatedString("en", "State", true);
            strings["LIST_COLUMN_DESTINATION"] = new TranslatedString("en", "Destination", true);
            strings["CONFIG_FORM_TITLE"] = new TranslatedString("en", "Archive2Disk Config panel", true);
            strings["LABEL_CONFIG_FOLDER_LIST"] = new TranslatedString("en", "Folders", true);
            strings["CONFIG_COLUMN_FOLDER_OUTLOOK"] = new TranslatedString("en", "Outlook", true);
            strings["CONFIG_COLUMN_FOLDER_DISK"] = new TranslatedString("en", "Disk", true);
            strings["LABEL_TREATED_MAILS"] = new TranslatedString("en", "Archived mails:", true);
            strings["ARCHIVED_CATEGORY"] = new TranslatedString("en", "Archived", true);
            strings["PATH_TOO_LONG"] = new TranslatedString("en", "Path too long", true);
            strings["FULL_PATH_TOO_LONG"] = new TranslatedString("en", "Absolute file path too long", true);
            strings["FILE_ALREADY_EXISTS"] = new TranslatedString("en", "File already exists", true);
            strings["ALREADY_CATEGORISED_AS_ARCHIVED"] = new TranslatedString("en", "Alread categorised as archived", true);
            strings["CB_EXPLODE_ATTACHMENTS"] = new TranslatedString("en", "Explode attachments in a separate folder", true);
            strings["CB_TRUNCATE_PATH_TOO_LONG"] = new TranslatedString("en", "Automatically tuncate long path", true);
            strings["CB_ASK_PATH_TOO_LONG"] = new TranslatedString("en", "Ask for a shorter filename when long path is detected", true);
            strings["TAB_FOLDERS"] = new TranslatedString("en", "Folders", true);
            strings["TAB_PARAMS"] = new TranslatedString("en", "Options", true);
            strings["QUESTION_FULL_PATH_TOO_LONG"] = new TranslatedString("en", "Please, provide a shorter path", true);
            

            // LANG: FR
            strings["FORM_ARCHIVE_TO_DISK_TITLE"].addOrUpdateTranslation("fr", "Archiver sur disque");
            strings["LABEL_DESTINATION"].addOrUpdateTranslation("fr", "Destination:");
            strings["LABEL_LIST_TITLE"].addOrUpdateTranslation("fr", "Emails à traiter:");
            strings["LABEL_NB_MAILS"].addOrUpdateTranslation("fr", "Nb mails:");
            strings["BT_CANCEL"].addOrUpdateTranslation("fr", "Annuler");
            strings["BT_CLOSE"].addOrUpdateTranslation("fr", "Fermer");
            strings["BT_OK"].addOrUpdateTranslation("fr", "Ok");
            strings["LIST_COLUMN_DATE"].addOrUpdateTranslation("fr", "Date de réception");
            strings["LIST_COLUMN_SUBJECT"].addOrUpdateTranslation("fr", "Sujet");
            strings["LIST_COLUMN_STATE"].addOrUpdateTranslation("fr", "Etat");
            strings["LIST_COLUMN_DESTINATION"].addOrUpdateTranslation("fr", "Destination");
            strings["CONFIG_FORM_TITLE"].addOrUpdateTranslation("fr", "Configuration Archive2Disk");
            strings["LABEL_CONFIG_FOLDER_LIST"].addOrUpdateTranslation("fr", "Répertoires");
            strings["CONFIG_COLUMN_FOLDER_OUTLOOK"].addOrUpdateTranslation("fr", "Outlook");
            strings["CONFIG_COLUMN_FOLDER_DISK"].addOrUpdateTranslation("fr", "Stockage externe");
            strings["LABEL_TREATED_MAILS"].addOrUpdateTranslation("fr", "Mails archivés");
            strings["ARCHIVED_CATEGORY"].addOrUpdateTranslation("fr", "Archivé");
            strings["PATH_TOO_LONG"].addOrUpdateTranslation("fr", "Nom de répertoire trop long");
            strings["FULL_PATH_TOO_LONG"].addOrUpdateTranslation("fr", "Chemin de fichier trop long");
            strings["FILE_ALREADY_EXISTS"].addOrUpdateTranslation("fr", "Le fichier existe déjà");
            strings["ALREADY_CATEGORISED_AS_ARCHIVED"].addOrUpdateTranslation("fr", "Déjà catégorisé archivé");
            strings["CB_EXPLODE_ATTACHMENTS"].addOrUpdateTranslation("fr", "Extraire les attachements dans un dossier séparé");
            strings["CB_TRUNCATE_PATH_TOO_LONG"].addOrUpdateTranslation("fr", "Tronquer le chemins trop long automatiquement");
            strings["CB_ASK_PATH_TOO_LONG"].addOrUpdateTranslation("fr", "Demander un nom de fichier plus court lors de la détection de chemins trop long");
            strings["TAB_FOLDERS"].addOrUpdateTranslation("fr", "Dossiers");
            strings["TAB_PARAMS"].addOrUpdateTranslation("fr", "Options");
            strings["QUESTION_FULL_PATH_TOO_LONG"].addOrUpdateTranslation("fr", "Merci de proposer un chemin plus court");


            // LANG: DE
            strings["FORM_ARCHIVE_TO_DISK_TITLE"].addOrUpdateTranslation("de", "Disk Archiver");
            strings["LABEL_DESTINATION"].addOrUpdateTranslation("de", "Ziel:");
            strings["LABEL_LIST_TITLE"].addOrUpdateTranslation("de", "E-Mails zu beschäftigen:");
            strings["LABEL_NB_MAILS"].addOrUpdateTranslation("de", "Anzahl der E-Mails:");
            strings["BT_CANCEL"].addOrUpdateTranslation("de", "Abbrechen");
            strings["BT_CLOSE"].addOrUpdateTranslation("de", "Schließen");
            strings["BT_OK"].addOrUpdateTranslation("de", "Ok");
            strings["LIST_COLUMN_DATE"].addOrUpdateTranslation("de", "Empfangsdatum");
            strings["LIST_COLUMN_SUBJECT"].addOrUpdateTranslation("de", "Thema");
            strings["LIST_COLUMN_STATE"].addOrUpdateTranslation("de", "Zustand");
        }

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
            //if (strings.ContainsKey(id)) return strings[id].getTranslation(lang);
            //return null;
        }
    }
}
