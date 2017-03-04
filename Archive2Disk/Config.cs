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
using System.Text;
using System.Threading.Tasks;

namespace Archive2Disk
{
    class Config
    {
        private Dictionary<string, string> foldersBonding;
        private Dictionary<string, string> options;
        private static Config instance = null;
        private string filenameFolders;
        private string filenameOptions;

        private Config()
        {
            foldersBonding = new Dictionary<string, string>();
            options = new Dictionary<string, string>();
            loadFoldersBindingFile();
            loadOptionsFile();
        }

        public static Config getInstance()
        {
            if (instance == null) instance = new Config();
            return instance;
        }

        public void updateFoldersBinding(Dictionary<string, string> newBinding)
        {
            foldersBonding = newBinding;
            saveBinding();
        }

        public void addOrUpdateOption(string key, string val)
        {
            if(options.ContainsKey(key))
            {
                options[key] = val;
            }
            else
            {
                options.Add(key, val);
            }
        }

        private void saveBinding()
        {
            int i = 0;
            string[] newlines = new string[foldersBonding.Count];
            foreach (string key in foldersBonding.Keys)
            {
                newlines[i] = key + ";" + foldersBonding[key];
                i++;
            }
            File.WriteAllLines(filenameFolders, newlines);
        }

        public void saveOptions()
        {
            int i = 0;
            string[] newlines = new string[options.Count];
            foreach (string key in options.Keys)
            {
                newlines[i] = key + ";" + options[key];
                i++;
            }
            File.WriteAllLines(filenameOptions, newlines);
        }

        private void loadFoldersBindingFile()
        {
            filenameFolders = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Archive2Disk", "outlookArchiveToDiskFoldersBinding.csv");
            if (File.Exists(filenameFolders))
            {
                var lines = File.ReadAllLines(filenameFolders);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    foldersBonding.Add(parts[0], parts[1]);
                }
            }
            else
            {
                // création du répertoire
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Archive2Disk"));
            }
        }

        private void loadOptionsFile()
        {
            filenameOptions = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Archive2Disk", "outlookArchiveToDiskOptions.csv");
            if (File.Exists(filenameOptions))
            {
                var lines = File.ReadAllLines(filenameOptions);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    options.Add(parts[0], parts[1]);
                }
            }
            else
            {
                // création du répertoire
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Archive2Disk"));
            }
        }

        public Dictionary<string, string> getFoldersBinding()
        {
            return foldersBonding;
        }

        public string getOption(string key)
        {
            if (options.ContainsKey(key)) return options[key];
            return "";
        }

        public Dictionary<string, string> getOptions()
        {
            return options;
        }
    }
}
