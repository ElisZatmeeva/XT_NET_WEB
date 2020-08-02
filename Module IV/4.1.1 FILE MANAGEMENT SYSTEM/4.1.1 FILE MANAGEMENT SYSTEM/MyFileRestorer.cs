using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;

namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{
    internal static class MyFileRestorer
    {
        internal static void UnzipArchiveWithReplace(string archiveName, string directoryName,
            string pathToArchive, string pathToLog)
        {
            string zipPath = pathToArchive + "\\" + archiveName;
            string extractPath = directoryName;
            string logPath = pathToLog;

            try
            {
                Directory.Delete(directoryName, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Удаление директории невозможно " + ex.Message);
                return;
            }

            try
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath); // извлечение сжатой папки
                string message = string.Format("Осуществлён откат к: {0}", archiveName);
                MyLogger.LogChanges(message, logPath);
                Console.WriteLine("Данные восстановлены.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Извлечение безуспешно: " + ex.Message);
            }
        }

        internal static Dictionary<string, string> GetAvailableArchives(string pathToArchive)
        {
            DirectoryInfo archive = new DirectoryInfo(pathToArchive);
            if (!archive.Exists)
                archive.Create();

            FileInfo[] Files = archive.GetFiles("*.zip");

            Dictionary<string, string> listOfArchives = new Dictionary<string, string>();

            int archId = 1;

            foreach (FileInfo file in Files)
            {
                listOfArchives[archId.ToString()] = file.Name;
                archId++;
            }

            return listOfArchives;
        }

        internal static string ParseArchiveName(string name)
        {
            var parseArchiveName = name.Split(new[] { '_', '.' }, StringSplitOptions.RemoveEmptyEntries);

            string[] time = parseArchiveName[0].Split(new[] { '-' });
            string[] date = parseArchiveName[1].Split(new[] { '-' });

            string res = string.Format("Time: {0}h {1}m {2}s, Date: {3}.{4}.{5}, GUID: {6}",
                time[0], time[1], time[2],
                date[0], date[1], date[2],
                parseArchiveName[2]);

            return res;
        }
    }
}
