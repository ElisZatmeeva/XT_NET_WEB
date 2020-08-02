using System;
using System.IO;


namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{

    internal static class MyLogger
    {
        internal static void LogChanges(string message, string pathToLogFiles)
        {
            string path = pathToLogFiles;
            string fileName = string.Format("{0}_{1}_{2}{3}",
                DateTime.Now.Day,
                DateTime.Now.Month,
                DateTime.Now.Year,
                ".log");

            try
            {
                DirectoryInfo dir = new DirectoryInfo(path); 

                if (!dir.Exists) // Проверка на наличие папки.
                    dir.Create();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Не возможно создать директорию: " + ex.Message);
            }

            try
            {
                StreamWriter file = new StreamWriter(path + "/" + fileName, true); //запись в файл
                file.WriteLine(DateTime.Now + " | " + message);
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Создание файла закончилось не успешно: " + ex.Message);
            }
        }

        internal static void ViewLogs(string pathToLogFiles) // просомотр логов
        {
            DirectoryInfo logs = new DirectoryInfo(pathToLogFiles);

            FileInfo[] logFiles = logs.GetFiles("*.log");
            
            if (logFiles.Length == 0)
            {
                Console.WriteLine("Записей в логфайлах нет");
                return;
            }

            foreach (FileInfo log in logFiles)
            {
                Console.WriteLine("Log {0}", log.Name);
                using (StreamReader sr = new StreamReader(pathToLogFiles + "\\" + log.Name))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine("\t" + line);
                    }
                }
            }
        }
    }
}
