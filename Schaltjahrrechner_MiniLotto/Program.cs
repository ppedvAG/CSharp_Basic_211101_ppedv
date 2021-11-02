using System;
using System.Linq;

namespace Schaltjahrrechner_MiniLotto
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Aufgabe:  Schaltjahr-Rechner
            Console.WriteLine("Gib das Jahr ein:");
            int eingabe = int.Parse(Console.ReadLine());

            bool istSchaltjahr = false;

            if(eingabe % 4 == 0)
            {
                istSchaltjahr = true;

                if(eingabe % 100 == 0)
                {
                    istSchaltjahr = false;

                    if(eingabe % 400 == 0)
                    {
                        istSchaltjahr = true;
                    }
                }
            }

            Console.WriteLine($"{eingabe} ist Schaltjahr: {istSchaltjahr}");

            string ausgabe = istSchaltjahr ? $"{eingabe} ist ein Schaltjahr." : $"{eingabe} ist kein Schaltjahr.";
            Console.WriteLine(ausgabe + "\n\n\n");


            //2. Aufgabe: Mini-Lotto
            int[] gewinnzahlen = { 3, 16, 45, 79, 99 };

            Console.Write("Bitte gib deinen Tipp ab (Ganzzahl zwischen 0 und 100): ");
            int tipp = int.Parse(Console.ReadLine());

            if(tipp < 0 || tipp > 100)
                Console.WriteLine("Dein Tipp ist außerhalb des Zahlenbereiches.");
            else
            {
                if (gewinnzahlen.Contains(tipp))
                    Console.WriteLine("Glückwunsch!! Du hast eine der fünf Gewinnzahlen getippt.");
                else
                    Console.WriteLine("Leider daneben. Viel Glück beim nächsten Mal.");
            }
        }
    }
}
