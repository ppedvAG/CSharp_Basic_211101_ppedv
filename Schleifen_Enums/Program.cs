using System;

namespace Schleifen_Enums
{
    enum Wochentag { Montag = 1, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag}

    class Program
    {
        static void Main(string[] args)
        {
            #region Schleifen
            int a = 0;
            int b = 10;

            while (a < b)
            {
                Console.WriteLine("A ist kleiner B");
                a++;

                if (a == 5)
                    break;
            }
            Console.WriteLine("Schleifenende");

            a = -45;
            do
            {
                Console.WriteLine(a);
                a--;

                continue;

            } while (a > 0);


            for (int i = 0; i < 10; i += 2)
            {
                Console.WriteLine(i);

                i++;
            }

            int[] zahlen = { 2, 3, 5, 4 };
            for (int i = 0; i < zahlen.Length; i++)
            {
                Console.WriteLine(zahlen[i]);
            }

            foreach (int item in zahlen)
            {
                Console.WriteLine(item);
            }
            #endregion

            Wochentag heutigerTag = Wochentag.Dienstag;
            Console.WriteLine($"Heute ist also {heutigerTag}.");

            Console.WriteLine("Welcher Wochentag ist dein Lieblingstag?");
            for (int i = 1; i < 8; i++)
            {
                Console.WriteLine($"{i}: {(Wochentag)i}");
            }
            heutigerTag = (Wochentag)int.Parse(Console.ReadLine());
            Console.WriteLine($"Dein Lieblingstag ist also {heutigerTag}.");

            heutigerTag = (Wochentag)Enum.Parse(typeof(Wochentag), "Freitag");
            Console.WriteLine($"Dein Lieblingstag ist also {heutigerTag}.");

            switch (heutigerTag)
            {
                case Wochentag.Montag:
                    Console.WriteLine("Wochenstart");
                    break;
                case Wochentag.Dienstag:
                case Wochentag.Mittwoch:
                case Wochentag.Donnerstag:
                    Console.WriteLine("Normaler Wochentag");
                    break;
                case Wochentag.Freitag:
                case Wochentag.Samstag:
                case Wochentag.Sonntag:
                    Console.WriteLine("Wochenende");
                    break;
                default:
                    Console.WriteLine("Fehlerhafte Eingabe");
                    break;
            }

            int f = -45;
            switch (f)
            {
                case 5:
                    Console.WriteLine("a ist 5");
                    break;
                case int g when g < 0:
                    Console.WriteLine("a < 0");
                    break;
                default:
                    break;
            }

        }
    }
}
