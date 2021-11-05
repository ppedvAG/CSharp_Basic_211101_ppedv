﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugpark
{
    interface IBeladbar
    {
        Fahrzeug Ladung { get; set; }

        void Belade(Fahrzeug fz);

        Fahrzeug Entlade();
    }
}
