using System;
using System.Collections.Generic;
using System.IO;

namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{
    class Program
    {
        static void Main(string[] args)
        {

            // Параметры по умолчанию
            var pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); // узнаёт путь до рабочего стола
            Console.WriteLine(pathDesktop);

            string pathToDirectory = $@"{ pathDesktop }\test\samples"; // папки будут расположены на рабочем столе
            Console.WriteLine(pathToDirectory);

            DirectoryInfo directoryInfo = new DirectoryInfo(pathToDirectory); 
            if (!directoryInfo.Exists)
                directoryInfo.Create();

            string pathToArchive = $@"{ pathDesktop }\test\myArchive";
            Console.WriteLine(pathToArchive);

            DirectoryInfo archive = new DirectoryInfo(pathToArchive); 
            if (!archive.Exists)
                archive.Create();

            string pathToLogFiles = $@"{ pathDesktop }\test\myLogs";
            Console.WriteLine(pathToLogFiles);

            DirectoryInfo logDirectory = new DirectoryInfo(pathToLogFiles);
            if (!logDirectory.Exists)
                logDirectory.Create();


            int saveFrequency = 5; // частота сохранения каталога


            bool res = false;

            while (!res)
            {
                Console.WriteLine("Выберите режим работы: \n" +
                "\t 'w' - Режим просмотра (изменения будут сохранятся) \n" +
                "\t 'r' - Режим восстановления \n" +
                "\t 's' - Просмотров log файлов\n" +
                "\t 'c' - Очистить архив и log файлы\n" +
                "\t 'e' - exit");

                string answer = Console.ReadLine().ToLower().Trim();

                switch (answer)
                {
                    case "w": // Режим просмотра

                        try
                        {
                            // Режим просмотра в одном из каталогов 
                            MyFileListener w = new MyFileListener(
                            pathToDirectory,
                            pathToArchive,
                            pathToLogFiles,
                            saveFrequency);

                            Console.WriteLine("Вы в режиме наблюдения. Изменения логируются.");

                            res = true;
                            Console.WriteLine("Для выхода из режима просмотра нажмите'q'");
                            while (Console.Read() != 'q') ;
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }

                    case "r": // Режим отката (восстановления)

                        try
                        {
                            Dictionary<string, string> d = MyFileRestorer.GetAvailableArchives(pathToArchive);

                            if (d.Count == 0)
                            {
                                Console.WriteLine("У Вас нет сохранённых архивов.");
                                res = true;
                                continue;
                            }

                            Console.WriteLine("Режим отката запущен.");

                            Console.WriteLine("Перечень архивов для восстановления:");

                            foreach (string arch in d.Keys)
                            {
                                Console.WriteLine("\t s{0}: {1}", arch, MyFileRestorer.ParseArchiveName(d[arch]));
                            }

                            Console.WriteLine("Выберите номер ахива: ");
                            string num = Console.ReadLine().Trim();

                            if (!d.ContainsKey(num))
                            {
                                Console.WriteLine("Введите целое число.");
                                continue;
                            }

                            MyFileRestorer.UnzipArchiveWithReplace(d[num], pathToDirectory, pathToArchive, pathToLogFiles);

                            Console.WriteLine("Нажмите 'yes', что бы продолжить:");
                            string key = Console.ReadLine().ToLower().Trim();

                            if (key == "yes" || key == "y")
                            {
                                continue;
                            }
                            else
                            {
                                res = true;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }

                    case "s":
                        MyLogger.ViewLogs(pathToLogFiles);

                        Console.WriteLine("Для продолжения нажмите 'yes'");
                        string keyFromLogger = Console.ReadLine().ToLower().Trim();

                        if (keyFromLogger == "yes" || keyFromLogger == "y")
                        {
                            continue;
                        }
                        else
                        {
                            res = true;
                            break;
                        }

                    case "c":
                        try
                        {
                            Directory.Delete(pathToArchive, true);
                            Directory.Delete(pathToLogFiles, true);
                            Console.WriteLine("Удалены папки: {0}, {1}", pathToArchive, pathToLogFiles);
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }

                    case "e":
                        res = true;
                        break;

                    default:
                        Console.WriteLine("Не верный ввод");
                        continue;
                }
            }

            Console.WriteLine("Для выхода нажмите любую клавишу.");
            Console.ReadKey();
        }
    }
}
