using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Modul 06: OOP
            ////Deklarierung von Person-Variablen und Instanziierung von neuen Personenobjekten per Konstruktor
            //Person neuePerson = new Person("Anna", 23);
            //Person neuePerson2 = new Person("Hannes", 45);

            ////Lesezugriff auf Property per Getter
            //Console.WriteLine(neuePerson.Vorname);

            ////Schreibzugriff auf Property per Setter
            //neuePerson.Vorname = "Otto";

            //Console.WriteLine(neuePerson.Vorname);

            //Console.WriteLine(neuePerson.Alter);

            ////Aufruf einer klasseneigenen Funktion
            //neuePerson.Altern();
            //neuePerson.Altern();
            //neuePerson.Altern();
            //neuePerson.Altern();

            //Console.WriteLine(neuePerson.Alter);
            #endregion

            #region Modul 07: Statische Member

            ////Aufruf eines statischen Members der Person-Klasse
            //Console.WriteLine(Person.ZeigeAnzahlPersonen());

            #endregion

            #region Modul 08: Vererbung

            ////Instanziierung eines Objekts der abgeleiteten Klasse
            //Arbeitnehmer an = new Arbeitnehmer("Anna", 45, "Operations");
            ////Aufruf von Properties und Methoden, welche aus der Mutterklasse stammen
            //Console.WriteLine(an.Alter);
            //an.Altern();
            //Console.WriteLine(an.Alter);

            ////Ausgabe der (überschriebenen) ToString()-Methode
            //Console.WriteLine(an);

            #endregion

            #region Modul 09: Polymorphismus

            ////Deklaration einer Bsp-Variablen
            //Person person;
            ////Instanziierung eines abgeleiteten Objekts
            //Arbeitnehmer an = new Arbeitnehmer("Hanna", 35, "Finanzen");

            ////Zuweisung des abgeleiteten Objekts zu Variable der Mutterklasse
            //person = (Person)an;

            ////Tests des Laufzeittyps (des beinhalteten Objekts)
            //if (person.GetType() == typeof(Arbeitnehmer))
            //    Console.WriteLine("Person hat Arbeit");

            //if (person is Arbeitnehmer)
            //    Console.WriteLine("Person hat Arbeit");

            ////überschriebene Methoden werden trotzdem ausgeführt
            //Console.WriteLine(person.ToString());

            //if (person is Arbeitnehmer)
            //{
            //    //Rückcast des abgeleiteten Objekts aus Mutterklassevariablen in abgeleitete Variable
            //    Arbeitnehmer an2 = (Arbeitnehmer)person;
            //} 

            #endregion


            #region Modul 10: Interfaces

            //Instanziierung eines Beispiel-Objekts
            Arbeitnehmer an = new Arbeitnehmer("Hanna", 35, "Finanzen");
            //Betrachtung des Objekts als Objekt des Interfaces
            ILohn lohnerhaltendesObjekt = an;
            //Zugriff auf Interface-Methode
            lohnerhaltendesObjekt.Auszahlung();
            //Übergabe an Methode, welche ein Objekt des Interfaces erwartet
            Gehaltserhöhung(lohnerhaltendesObjekt);
            //Übergabe benötigt keinen Cast aus implementierender Klasse
            Gehaltserhöhung(an);

            //Aufrzf der Clone()-Funktion des IClonable-Interfaces
            Arbeitnehmer kopierterAn = (Arbeitnehmer)an.Clone(); 
            #endregion

        }

        #region Modul 10: Interfaces

        //Bsp-Methode, welche ein Objekt vom Typ des Interfaces verlangt
        public static void Gehaltserhöhung(ILohn lohn)
        {
            lohn.Gehalt += 100;

            //Prüfun des Objekts auf Laufzeittyp
            if (lohn is Arbeitnehmer)
            {
                //Cast
                Arbeitnehmer an = (Arbeitnehmer)lohn;
                an.Essen();
            }
        } 

        #endregion
    }
}
