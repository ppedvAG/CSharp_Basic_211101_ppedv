using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{
    public delegate int MeinDelegate (int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            MeinDelegate delegateVariable;

            delegateVariable = Addiere;

            int erg = delegateVariable(45, 12);

            Console.WriteLine(erg);

            delegateVariable = Subtrahiere;
            Console.WriteLine(delegateVariable(45,12));

            delegateVariable += Addiere;
            delegateVariable += Addiere;
            delegateVariable += Addiere;
            delegateVariable += Addiere;

            Console.WriteLine(delegateVariable(45, 12));

            foreach (var item in delegateVariable.GetInvocationList())
            {
                Console.WriteLine(item.Method);
            }

            delegateVariable -= Addiere;

            delegateVariable = null;

            Func<int, int, int> meinFunc = Addiere;

            FühreAus(meinFunc);

            FühreAus(Addiere);

            List<string> Städteliste = new List<string>() { "München", "Berlin", "Hamburg", "Köln" };

            string gefundeneStadt;

            gefundeneStadt = Städteliste.Find(SucheStadtMitB);

            gefundeneStadt = Städteliste.Find
                (
                    delegate (string stadt)
                    {
                        return stadt.StartsWith('B');
                    }
                );

            gefundeneStadt = Städteliste.Find((string stadt) => { return stadt.StartsWith('B'); });

            gefundeneStadt = Städteliste.Find(stadt => stadt.StartsWith('B'));

            Städteliste = Städteliste.OrderBy(stadt => stadt[0]).ToList();
            foreach (var item in Städteliste)
            {
                Console.WriteLine(item);
            }

        }

        public static bool SucheStadtMitB(string stadt)
        {
            return stadt.StartsWith('B');
        }

        public static void FühreAus(Func<int, int, int> mehrLogik)
        {
            mehrLogik(45, 78);
        }

        public static int Addiere(int a, int b)
        {
            Console.WriteLine("Addiere");
            return a + b;
        }

        public static int Subtrahiere(int a, int b)
        {
            Console.WriteLine("Subtrahiere");
            return a - b;
        }
    }
}
