using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    //Arbeitnehmer erbt mittels des :-Zeichens von der Person-Klasse und übernimmt somit alle Eigenschaften und Methoden von dieser.
    public class Arbeitnehmer : Person
    {
        //Zusätzliche Arbeitnehmer-eigene Eigenschaft
        public string Abteilung { get; set; }

        //Arbeitnehmer-Konstruktor, welcher per BASE-Stichwort den Konstruktor der Personklasse aufruft. Dieser erstellt dann eine Person, gibt diese
        ///an diesen Konstruktor zurück, welcher dann die zusätzlichen Eigenschaften einfügt
        public Arbeitnehmer(string name, int alter, string abteilung) : base(name, alter)
        {
            this.Abteilung = abteilung;
        }

        //Mittels OVERRIDE können Methoden der Mutterklassen, welche mit VIRTUAL markiert sind, überschrieben werden. Bei Aufruf wird die neue Methode ausgeführt.
        //Mittels BASE kann ein Rückbezug zur nächst-höheren Klasse hergestellt werden.
        public sealed override string ToString()
        {
            return base.ToString() + $" und arbeitet in der {this.Abteilung}.";
        }

        //Durch Mutterklasse erzwungene (weil dort abstrakte) Methode
        public override void Essen()
        {
            Console.WriteLine("Kantinenessen");
        }
    }
}
