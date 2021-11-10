using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dateien
{
    class Person
    {
        public int Alter { get; set; }
        public string Name { get; set; }
    }

    class Arbeitnehmer : Person
    {
        public string Abteilung { get; set; }
    }
}
