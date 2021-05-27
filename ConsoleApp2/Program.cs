using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringVal1 = "car";
            string stringVal2 = "race";

            Console.Write(string.Format( "Anagram check ( {0} : {1} ) -> ", stringVal1, stringVal2));
            Console.WriteLine(CheckAnagramStrStr(stringVal1, stringVal2).ToString().ToLower());

            stringVal1 = "nod";
            stringVal2 = "done";

            Console.Write(string.Format("Anagram check ( {0} : {1} ) -> ", stringVal1, stringVal2));
            Console.WriteLine(CheckAnagramStrStr(stringVal1, stringVal2).ToString().ToLower());

            stringVal1 = "bag";
            stringVal2 = "grab";

            Console.Write(string.Format("Anagram check ( {0} : {1} ) -> ", stringVal1, stringVal2));
            Console.WriteLine(CheckAnagramStrStr(stringVal1, stringVal2).ToString().ToLower());

            Console.ReadLine();
        }

        public static Boolean CheckAnagramStrStr(string fristString, string secondString)
        {
            Boolean result = false;
            
            char[] firstCharArray = fristString.ToCharArray();

            Dictionary<string, string> permuatationList = new Dictionary<string, string>();

            GetPer(firstCharArray, permuatationList);

            foreach (KeyValuePair<string, string> permutableItem in permuatationList)
            {
                if (secondString.Contains(permutableItem.Key))
                {
                    result = true;
                }
            }

            return result;
        }

        //The below string permutable function is copied from : https://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer
        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }

        public static void GetPer(char[] list, Dictionary<string, string> permuatationList)
        {
            int x = list.Length - 1;
            GetPer(list, 0, x, permuatationList);
        }

        private static void GetPer(char[] list, int k, int m, Dictionary<string, string> permuatationList)
        {
            if (k == m)
            {
                var permuationString = String.Join("", list);

                if (permuatationList.ContainsKey(permuationString) == false)
                {
                    permuatationList.Add(permuationString, permuationString);
                }                
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m, permuatationList);
                    Swap(ref list[k], ref list[i]);
                }
        }
    }
}
