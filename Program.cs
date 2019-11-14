using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WizkidsRocksTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //Check operation form String is Palindrome
            try
            {
                Console.WriteLine("Enter Palindrome string ");
                string palindrome = Console.ReadLine();
                bool pa = IsPalindrome(palindrome);
                Console.WriteLine("IsPalindrome  : " + pa);

                Console.ReadKey();


                Console.ForegroundColor = ConsoleColor.Cyan;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }


            try
            {
                Console.WriteLine(" Foobar operation  ");

                Console.ResetColor();
                Foobar_operation();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }


            try
            {
                validEmailReplaceWithGivenText();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            try
            {
                WordDisctonory();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }





        }


        public static bool IsPalindrome(string palodrom)
        {
            return palodrom.ToLower().SequenceEqual(palodrom.ToLower().Reverse());
        }

        public static void Foobar_operation()
        {
            int Maxcounter = 10;
            for (int index = 0; index < Maxcounter; index++)
            {

                if (index % 3 == 0 && index % 5 == 0)
                    Console.WriteLine("Foo");

                var getResult = (index % 3 == 0 && index % 5 == 0) ? "FooBar"
                               : (index % 3 == 0) ? "Foo"
                               : (index % 5 == 0) ? "Bar"
                               : "";


                Console.WriteLine(" Indexer is " + index + " = " + getResult);
            }
        }

        public static void validEmailReplaceWithGivenText()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Find and Replace email address form String  with Below String ");
            Console.ForegroundColor = ConsoleColor.White;
            string content = "Christian has the email address christain+123@gmail.com Ch,john  has email address john.cave-brown@gmail.com " +
                "john  adress Kiran123@oxforf.co.uk" +
                " twitter handle is @kira.cavebrown";
            Console.WriteLine("Orignal String : " + content);




            Console.ResetColor();
            Console.WriteLine("Enter text which replace in Content");

            string alternateWordForReplace = Console.ReadLine();



            //email pattern with replacment...

            String pattern = @"(\S*)@\S*\.\S*([a-z]|[A-Z]|[0-9])";
            String result = Regex.Replace(content, pattern, alternateWordForReplace);


            Console.WriteLine("Content Modify With " + alternateWordForReplace);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Modify Content  : " + result);
            Console.ResetColor();

        }


        public static void WordDisctonory()
        {

            string[] SuggestionList = new string[] { "cating", "carton", "cabin" };
            string Word = "cat";
            int maxDiff = GetDamerauLevenshteinDistance(Word, SuggestionList[0]);



            Console.WriteLine("=============");
            Console.WriteLine("Search Word : " + Word);
            Console.WriteLine("Autosuggestion Word Use For DamerauLevenshteinDistance is " + Word);

            Console.WriteLine("DamerauLevenshteinDistance :" + maxDiff);
            //Total combination with A-z google..
            List<string> WordwithAtozCombination = GenerateLetterCombinations(maxDiff, Word);


            Console.WriteLine("Combination With A-Z , With SearchWord  : " + WordwithAtozCombination.Count);


            //var res = WordwithAtozCombination.ToArray();

            //Console.WriteLine(String.Join(",", res));

            Console.ReadKey();
        }


        //Google....

        public static int GetDamerauLevenshteinDistance(string source, string target)
        {
            var bounds = new { Height = source.Length + 1, Width = target.Length + 1 };

            int[,] matrix = new int[bounds.Height, bounds.Width];

            for (int height = 0; height < bounds.Height; height++) { matrix[height, 0] = height; };
            for (int width = 0; width < bounds.Width; width++) { matrix[0, width] = width; };

            for (int height = 1; height < bounds.Height; height++)
            {
                for (int width = 1; width < bounds.Width; width++)
                {
                    int cost = (source[height - 1] == target[width - 1]) ? 0 : 1;
                    int insertion = matrix[height, width - 1] + 1;
                    int deletion = matrix[height - 1, width] + 1;
                    int substitution = matrix[height - 1, width - 1] + cost;

                    int distance = Math.Min(insertion, Math.Min(deletion, substitution));

                    if (height > 1 && width > 1 && source[height - 1] == target[width - 2] && source[height - 2] == target[width - 1])
                    {
                        distance = Math.Min(distance, matrix[height - 2, width - 2] + cost);
                    }

                    matrix[height, width] = distance;
                }
            }

            return matrix[bounds.Height - 1, bounds.Width - 1];
        }

        //google..
        public static List<string> GenerateLetterCombinations(int num_letters, string Word)
        {



            List<string> values = new List<string>();

            // Build one-letter combinations.

            char[] p = Word.ToCharArray();
            foreach (char str in p)
            {
                values.Add(str.ToString());
            }

            // Add onto the combinations.
            for (int i = 1; i < num_letters; i++)
            {
                // Make combinations containing i + 1 letters.
                List<string> new_values = new List<string>();
                foreach (string str in values)
                {
                    // Add all possible letters to this string.
                    for (char ch = 'a'; ch <= 'z'; ch++)
                    {
                        new_values.Add(str + ch);
                    }
                }

                // Replace the old values with the new ones.
                values = new_values;
            }

            return values;
        }


    }



}
