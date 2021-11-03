using System;

namespace Funktionen
{
    class Program
    {
        static void Main(string[] args)
        {
            double summe = Addiere(3,5);
            Console.WriteLine(summe);

            int erg = BildeSumme(2,4,7,9,5);

            erg = Subtrahiere(10, 5);

            int zahl = 5;
            erg = AddiereUndSubtrahiere(10, zahl, out int diff);
            Console.WriteLine(diff);
            Console.WriteLine(erg);


            string eingabe = Console.ReadLine();

            if(int.TryParse(eingabe, out int result))
            {
                result = result * 5;
            }
        }

        static int Addiere(int a, int b)
        {
            return a + b;
        }

        static double Addiere(double a , double b)
        {
            return a + b;
        }

        static int BildeSumme(params int[] summanden)
        {
            int summe = 0;

            foreach (var item in summanden)
            {
                summe += item;
            }

            return summe;
        }

        static int Subtrahiere(int a, int b, int c = 0)
        {
            return a - b - c;
        }

        static int AddiereUndSubtrahiere(int a, int b, out int differenz)
        {
            b = 78;
            differenz = a - b;
            return a + b;
        }
    }
}
