using System;
using System.IO;
using System.IO.Compression;

namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{
    internal static class MyArchiver
    {
        internal static void SaveChanges(string pathToDirectory, string pathToArchive, string pathToLog) //Сохранение изменений в zip
        {
            string startPath = pathToDirectory;
            string logPath = pathToLog;
            Guid g = Guid.NewGuid();

            string archiveName = string.Format("{0}-{1}-{2}_{3}-{4}-{5}_{6}{7}",
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                DateTime.Now.Second,
                DateTime.Now.Day,
                DateTime.Now.Month,
                DateTime.Now.Year,
                g,
                ".zip");

            string zipPath = pathToArchive;

            try
            {
                DirectoryInfo dir = new DirectoryInfo(zipPath);
                if (!dir.Exists)
                    dir.Create();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Создание папки архива не возможно: " + ex.Message);
            }

            try
            {
                ZipFile.CreateFromDirectory(startPath, zipPath + "\\" + archiveName);
                string message = string.Format("Архив создан: {0}", archiveName);
                MyLogger.LogChanges(message, logPath);
               
                Console.WriteLine("Директория была успешно сохранена {0}!", zipPath);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Сжатие файлов не возможно: " + ex.Message);
            }
        }
    }
}
