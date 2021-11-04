using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Modul 06: OOP
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
            #endregion

            #region Modul 07: Statische Member

            //Aufruf eines statischen Members der Person-Klasse
            Console.WriteLine(Person.ZeigeAnzahlPersonen());

            #endregion

            #region Modul 08: Vererbung

            //Instanziierung eines Objekts der abgeleiteten Klasse
            Arbeitnehmer an = new Arbeitnehmer("Anna", 45, "Operations");
            //Aufruf von Properties und Methoden, welche aus der Mutterklasse stammen
            Console.WriteLine(an.Alter);
            an.Altern();
            Console.WriteLine(an.Alter);

            //Ausgabe der (überschriebenen) ToString()-Methode
            Console.WriteLine(an); 

            #endregion
        }
    }
}
