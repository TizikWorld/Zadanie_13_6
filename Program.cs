using System.Collections.Generic;
using System.Diagnostics;

namespace Zadanie_13_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Zadanie 13.6.1

            var timer = new Stopwatch();
            
            StreamReader streamReader = new StreamReader("C:\\My\\ReposVS\\Zadanie_13_6\\Text1.txt");

            TimeSpan timeTaken = timer.Elapsed;

            var text = streamReader.ReadToEnd();

            List<char> chars = new List<char>();

            LinkedList<char> list = new LinkedList<char>();


            //List
            timer.Start();

            for (int i = 0; i < text.Length; i++)
            {
                chars.Add(text[i]);
            }
            
            timer.Stop();

            Console.WriteLine($"Время List: {timer.ElapsedMilliseconds}");

            timer.Reset();
            //LinkedList
            timer.Start();

            for (int i = 0; i < text.Length; i++)
            {
                list.AddLast(text[i]);
            }

            timer.Stop();

            Console.WriteLine($"Время LinkedList: {timer.ElapsedMilliseconds}");

            #endregion


            #region Zadanie 13.6.2

            //var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (!keyValuePairs.TryAdd(words[i], 0))
                {
                    int j = 0;
                    j = keyValuePairs[(words[i])] + 1;
                    if (j > 9) //выход из функции если слово встретилось более 10 раз
                    { 
                        Console.WriteLine(words[i]);
                        break;
                    }
                    keyValuePairs[words[i]] = j;
                    keyValuePairs.TryAdd(words[i], j);
                }
            }


            Console.ReadKey();

            #endregion


        }
    }
}
