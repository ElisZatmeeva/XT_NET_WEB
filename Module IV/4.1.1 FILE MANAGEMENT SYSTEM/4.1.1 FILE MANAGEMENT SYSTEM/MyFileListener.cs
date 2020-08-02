using System;
using System.Globalization;
using System.IO;

namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{
    internal class MyFileListener
    {
        protected FileSystemWatcher watcher = null;
        protected string pathToDirectory;
        protected string pathToArchive;
        protected string pathToLogFiles;
        protected int changeCounter;
        protected readonly int saveFrequency;

        public MyFileListener(string pathToDir, string pathToArch, string pathToLog, int num)
        {
  
            changeCounter = num; // Изменения сохраняются на кождое num событие
            saveFrequency = num;

            watcher = new FileSystemWatcher();


            pathToDirectory = pathToDir;
            pathToArchive = pathToArch;
            pathToLogFiles = pathToLog;
            watcher.Path = pathToDirectory;

            
            watcher.NotifyFilter = NotifyFilters.LastAccess // Отслеживание соответствующих изменений
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;

            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string message = string.Format("Change file: '{0}'", e.FullPath);
            MyLogger.LogChanges(message, pathToLogFiles);
            changeCounter--;
            Console.WriteLine(message);

            if (changeCounter == 0)
            {
                MyArchiver.SaveChanges(pathToDirectory, pathToArchive, pathToLogFiles);
                changeCounter = saveFrequency;
            }
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {

            string message = string.Format("Create file: '{0}'", e.FullPath);
            MyLogger.LogChanges(message, pathToLogFiles);
            changeCounter--;
            Console.WriteLine(message);

            if (changeCounter == 0)
            {
                MyArchiver.SaveChanges(pathToDirectory, pathToArchive, pathToLogFiles);
                changeCounter = saveFrequency;
            }
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            string message = string.Format("Delete file: '{0}'", e.FullPath);
            MyLogger.LogChanges(message, pathToLogFiles);
            changeCounter--;          
            Console.WriteLine(message);


            if (changeCounter == 0)
            {
                MyArchiver.SaveChanges(pathToDirectory, pathToArchive, pathToLogFiles);
                changeCounter = saveFrequency;
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            string message = string.Format("Rename file: from '{0}' to '{1}'", e.OldFullPath, e.FullPath);
            MyLogger.LogChanges(message, pathToLogFiles);
            changeCounter--;
            Console.WriteLine(message);


            if (changeCounter == 0)
            {
                MyArchiver.SaveChanges(pathToDirectory, pathToArchive, pathToLogFiles);
                changeCounter = saveFrequency;
            }
        }
    }
}