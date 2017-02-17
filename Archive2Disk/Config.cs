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
        private static Config instance = null;
        private string filename;

        private Config()
        {
            foldersBonding = new Dictionary<string, string>();
            loadFoldersBindingFile();
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

        private void saveBinding()
        {
            int i = 0;
            string[] newlines = new string[foldersBonding.Count];
            foreach (string key in foldersBonding.Keys)
            {
                newlines[i] = key + ";" + foldersBonding[key];
                i++;
            }
            File.WriteAllLines(filename, newlines);
        }

        private void loadFoldersBindingFile()
        {
            filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Archive2Disk", "outlookArchiveToDiskFoldersBinding.csv");
            if (File.Exists(filename))
            {
                var lines = File.ReadAllLines(@filename);
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

        public Dictionary<string, string> getFoldersBinding()
        {
            return foldersBonding;
        }
    }
}
