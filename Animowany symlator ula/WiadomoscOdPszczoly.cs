using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animowany_symlator_ula
{
    /// <summary>
    /// Delegat do funkcji zwrotnej pszczoły, która zwraca ID pszczoły oraz komunkat co w tej chwili robi
    /// </summary>
    public delegate void WiadomoscOdPszczoly(int id, string info);
}
