using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matematika
{
    class Priklad
    {
        private int cislo1 { get; set; }
        private int cislo2 { get; set; }
        private Znaminko znaminko { get; set; }

        public Priklad(int cislo1, int cislo2, Znaminko znaminko)
        {
            this.cislo1 = cislo1;
            this.cislo2 = cislo2;
            this.znaminko = znaminko;
        }
    }
}
