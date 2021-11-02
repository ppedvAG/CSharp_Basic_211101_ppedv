using System;
using System.Linq;

namespace Array_Bedingungen
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] zahlen = { 2, 4, 78, -123, -8, 0, 11111 };

            Console.WriteLine(zahlen[2]);

            zahlen[2] = 1234;

            Console.WriteLine(zahlen[2]);

            Console.WriteLine(zahlen.Contains(-123));
            Console.WriteLine(zahlen.Contains(555));

            Console.WriteLine(zahlen.Length);





            int a = 23;
            int b = 23;

            if (a < b)
            {
                Console.WriteLine("A ist kleiner als B");
            }
            else if (a > b)
            {
                Console.WriteLine("A ist größer als B");
            }
            else
                Console.WriteLine("A ist gleich B");


            string name1 = "Hans";
            string name2 = "Hans";

            if (name1.Equals(name2))
            {
                Console.WriteLine("Gleich");
            }

            Console.WriteLine(name1[2]);



        }
    }
}
