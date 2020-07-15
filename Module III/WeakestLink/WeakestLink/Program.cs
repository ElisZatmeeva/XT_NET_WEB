using System;
using System.Collections.Generic;
using System.Threading;

namespace WeakestLink
{
    class Program
    {
        enum TypeList
        {
            AlekseiGushchin = 1,
            IvanYufin,
            KirillSinitsin,
            SergeiBerezin,
            ElizavetaDubrovskaia,
            AlekseiErmolov,
            IvanMartyshin,
            MaksimZaveniagin,
            DaniilVolkov,
            KirillGusev,
            NikitaBodnar,
            IgorDemin,
            MaksimBiserov,
            SviatoslavTatarintsev,
            ViktorDenisov,
            IgorBriukov,
            VladislavSerbin,
            VsevolodAverin,
            DmitriySurovyagin,
            EvgeniiIsachenko,
            MirraRikhter,
            DanilTiurin,
            AlekseiVoronkov,
            IliaUstimov,
            SvetlanaSiakina,
            BogdanMosenz,
            DmitriiGrigorev,
            SofiyaVoloshina,
            KirillKlimov,
            AlekseiRomanov,
            IuliiaPiratinskaia,
            VladislavMakaev,
            AlekseiMarinin,
            AlekseiAnisimov,
            EkaterinaRadchenko,
            AngelinaKhvostova,
            KonstantinMelnikov,
            IlyaIsaev,
            RomanBudko,
            AndreySemichev,
            AleksandrKuzin,
            NinaZubkova,
            DariaSokolova
        }
        protected static int number;
        protected static int count;
        protected static bool res = true;
        protected static int j = 1;

        static void Main(string[] args)
        {
            try
            {
                do
                {
                    Console.WriteLine("Введите количество людей от 1 до 43, стоящих в кругу");
                    number = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите N - порядковый номер, который будет выбывать.");
                    count = int.Parse(Console.ReadLine());
                } while (count >= number || number < 1 || number > 43 || count <= 0);


                TypeList[] typeList = (TypeList[])Enum.GetValues(typeof(TypeList));
                List<TypeList> listPeople = new List<TypeList>();

                Console.WriteLine("Сгенерирован круг людей. Начинаем вычеркивать каждого {0}.", count);
                for (int i = 0; i < number; i++)
                {
                    listPeople.Add(typeList[i]);
                    Console.WriteLine(listPeople.Count + "." + listPeople[i]);
                }

                while (listPeople.Count > count)
                {
                    var lastArr = new TypeList[number - 1];

                    if (listPeople.Count != count)
                    {
                        Console.WriteLine("Раунд {0}. Вычеркнут человек {1}.", j, listPeople[count] - 1);
                        listPeople.RemoveRange(count - 1, 1);

                        Console.WriteLine("Людей осталось {0}", listPeople.Count);
                        j++;                       
                    }

                    listPeople.CopyTo(count - 1, lastArr, 0, listPeople.Count - count + 1);

                    listPeople.CopyTo(0, lastArr, listPeople.Count - count + 1, listPeople.Count - (listPeople.Count - count + 1));

                    listPeople = new List<TypeList>();

                    foreach (TypeList item in lastArr)
                    {
                        if (item != 0)
                        {
                            listPeople.Add(item);
                            Console.WriteLine(listPeople.Count + "." + item);
                        }

                    }

                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Введите целое числовое значение");
            }

            catch (Exception e)
            {
                Console.WriteLine("Значение не корректно.");
            }

            Console.WriteLine("Игра окончена.");
            Console.ReadLine();
        }

    }
}
