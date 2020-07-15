using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis
{
    class TextAnalysis
    {
        protected static int cnt;
        protected static int res;
        protected static int num;
        protected static int n;
        protected static int r;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();
            if (text.Length == 0)
            {
                throw new ArgumentException("Введите данные");
            }
            var allwords = text.Split(new char[] { ' ', '!', '?', '.', ',', ':', ';', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var unique =
               (from word in allwords select word.ToLower()).Distinct().OrderBy(name => name);
            foreach (var word in unique)
            {
                num = (from word2 in allwords
                           select word2).Count();
               
                cnt = (from word2 in allwords where word2.ToLower() == word select word2).Count();
                Console.WriteLine("Ниже приведён список из слов и количества их повторений в тексте.");
                Console.WriteLine(" Word: {0} - {1}", word, cnt);

                if (cnt > 1)
                {
                    r += cnt;
                   
                }

            }
            double l = (double)r/ num;
            //Console.WriteLine("Количество слов в тексте - {0}", num);
            //Console.WriteLine($"Соотношение повторяющихся слов {l}");

            if(l < 0.5)
            {
                Console.WriteLine("Ваше разнообразие текста выско.");
            }

            else if (l > 0.5 && l <=0.6)
            {
                Console.WriteLine("Ваше разнообразие текста на хорошем уровне");
            }

            else if (l > 0.6 && l <= 0.8)
            {
                Console.WriteLine("Вам стоит поработать над разнообразием слов в своём тексте");
            }
            else
            {
                Console.WriteLine("Советую отредактировать текст. Количество однообразных слов очень велико");
            }

                Console.ReadLine();


            /*Console.WriteLine("Введите текст:"); Эта строка
            line = Console.ReadLine();*/ //Эта строка
                                         //  string[] arr =  { "!", "?", ".", ",", ":", ";", "-" };
                                         // string[] words = line.Split(new char[] {' ', '!', '?', '.', ',', ':', ';', '-' }, StringSplitOptions.RemoveEmptyEntries);Эта строка

            /*foreach (string s in words)
            {
                res = words.Aggregate(s,
                    (longest, next) =>
                        next.Length > longest.Length ? next : longest,
                   
                    res => res.ToUpper());

            }
            Console.WriteLine(res);

            foreach (string i in words) // заменить везде words на text
            {
                var result = words.Where(e => e.Contains(i)).Count();
                Console.WriteLine($"{i} содержится в строке {result} раз ");
            }*/

            /* foreach (var s in words) Этот цикл
             {
                 var matchQuery = from word in words
                                  where word.ToLowerInvariant() == s.ToLowerInvariant()
                                  select word;
                 int wordCount = matchQuery.Count();

                 Console.WriteLine("{0} occurrences(s) of the search term \"{1}\" were found.", wordCount, s);
             }*/


            // Count the matches, which executes the query.  


            // Keep console window open in debug mode  



            /*text = line.Replace(line[i], arr[i]);
          */



          /*  var txt = new Analysis[]
            {
                new Analysis(){ TextAnalysis  = text }
            };

            Console.WriteLine(txt);*/


           /* foreach(var i in text)
            {
                var res = txt.FirstOrDefault(e => words.Contains(e));

                Console.WriteLine($"Количество слов {res}");
                Console.ReadLine();
            }*/
            
            //Console.WriteLine();
            // string txte = new string("Bla");
            //  Analysis txt = new Analysis<string>(text);
            //  Analysis txt = new Analysis(text);

        }
    }
     public interface IAnalysis<T>
     {
        string AnalysisText(T text);

     }
    public class Analysis : IAnalysis<string> //IEnumerable<T>
    {

        public string TextAnalysis { get; set; }
        public string WordsAnalisis { get; set; }
        public string AnalysisText(string text) // this???
        {
            if (text == null)
            {
                throw new ArgumentNullException("Введите данные");
            }

           /* for (int i = 0; i < arr.Length; i++)
            {
                TextAnalysis = TextAnalysis.Replace(arr[i], "+");
            }
*/
            return TextAnalysis; // change. this for example
        }
        public void GetWords()
        {

            // var resWords = TextAnalysis.Where(e => e != WordsAnalisis);
           
        }


        /*public char[] AnalysisText(string text) // this???
        {
            if (text == null)
            {
                throw new ArgumentNullException("Введите данные");
            }
            char[] arr = TextAnalysis.ToCharArray(0, TextAnalysis.Length);
            return arr; // change. this for example
        }*/





        /*public class Analysis !!!!!!!!!!!!!!!!!!!
        {
            public string TextAnalysis { get; set; }

        }*/




        /* public Analysis(string text)
         {
             TextAnalysis = text;
         }*/
        /* public string AnalysisText(string text)
         {
             Console.WriteLine(textAnalysis);
             return textAnalysis; // change. this for example
         }*/
    }

}
