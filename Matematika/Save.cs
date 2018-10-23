using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matematika
{
    class Save
    {
        private int iD { get; set; }
        private int level { get; set; }
        private int score { get; set; }

        private Priklad priklad;

        public Save(int ID, int level, int score, Priklad priklad)
        {
            this.iD = ID;
            this.level = level;
            this.score = score;
            this.priklad = priklad;
        }
    }
}
