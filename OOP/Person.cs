using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    //KLASSEN sind Vorlagen für Objekte. Sie bestimmen Eigenschaften und Funktionen dieser.
    //ABSTRACT definiert eine Klasse als abstrakt. D.h. von dieser Klasse können keine Objekte mer instanziiert werden, sie dient nur noch als Mutterklasse
    public abstract class Person //zur Verwendung vgl. Program.cs
    {
        #region Felder und Eigenschaften
        //FELDER (Membervariablen) sind die Variablen einzelner Objekte, welche die Zustände dieser Objekte definieren
        private string vorname = "Hugo";
        //EIGENSCHAFTEN (Properties) definieren mittels Getter/Setter den Lese-/Schreibzugriff für jeweils ein Feld.
        ///In den Eigenschaften können bestimmte Bedingungen für das Lesen und Schreiben der Felder gesetzt werden, sowie der Zugriff
        ///für Lesen und Schreiben einzeln angepasst werden
        //Snippet: propfull
        public string Vorname
        {
            get { return vorname; }
            set
            {
                //Das Schlüsselwort VALUE beschreibt in einer Set-Methode den übergebenen Wert
                if (value.Length > 0)
                    vorname = value;
            }
        }

        //Wird in einer Eigenschaft keine Spezifizierung angegeben, generiert das Programm das entsprechende Feld unsichtbar im Hintergrund
        //Snippet: prop
        public int Alter { get; set; } = 0;

        #endregion

        #region Konstruktor
        //KONSTRUKTOREN sind spezielle Methoden, welche ein neues Objekt instanziiert und den Anfangszustand festlegt. Sie definieren sich
        ///durch den Namen (derselbe, wie die Klasse) und den nicht vorhandenen Rückgabetyp (nicht mal void)
        public Person(string vorname, int alter)
        {
            this.Vorname = vorname;
            this.Alter = alter;
        }

        //Es können mehrere Konstruktoren definiert werden, welche unterschiedliche Übergabeparameter haben (Überladung). Ein Konstruktor, der keine
        //Übergabeparameter hat, wird als Basiskonstruktor bezeichnet
        public Person()
        {

        }

        #endregion

        #region Methoden

        //MEMBERMETHODEN sind Funktionen, welche jedes Objekt einer Klasse besitzt und speziell dieses Objekt manipuliert
        public void Altern()
        {
            this.Alter++;
        }

        //Mittels OVERRIDE können Methoden der Mutterklassen, welche mit VIRTUAL markiert sind, überschrieben werden. Bei Aufruf wird die neue Methode ausgeführt.
        public override string ToString()
        {
            return $"{this.Vorname} ist {this.Alter} Jahre alt";
        }

        //Abstrakte Mthoden dürfen nur in abstrakten Klassen existieren und definieren nur
        ///eine Signatur. Die erbenden Klassen werden gezwungen eine Implementierung vorzunehmen
        public abstract void Essen();

        #endregion

        #region Statische Member

        //STATISCHE Variablen und Methoden hängen an der Klasse selbst und nicht an instanziierten Objekten. Sie existieren demnach unabhängig von der Anzahl
        ///Objekte genau einmal. Der Aufruf erfolgt über den Klassenbezeichner.
        public static int AnzahlPersonen { get; set; } = 0;

        public static string ZeigeAnzahlPersonen()
        {
            return $"Es gibt {AnzahlPersonen} Personen.";
        }

        #endregion

    }
}
