using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklarierung von Person-Variablen und Instanziierung von neuen Personenobjekten per Konstruktor
            Person neuePerson = new Person("Anna", 23);
            Person neuePerson2 = new Person("Hannes", 45);

            //Lesezugriff auf Property per Getter
            Console.WriteLine(neuePerson.Vorname);

            //Schreibzugriff auf Property per Setter
            neuePerson.Vorname = "Otto";

            Console.WriteLine(neuePerson.Vorname);

            Console.WriteLine(neuePerson.Alter);

            //Aufruf einer klasseneigenen Funktion
            neuePerson.Altern();
            neuePerson.Altern();
            neuePerson.Altern();
            neuePerson.Altern();

            Console.WriteLine(neuePerson.Alter);
        }
    }
}
