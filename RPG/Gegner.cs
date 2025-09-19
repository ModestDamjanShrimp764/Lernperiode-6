using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Gegner
    {
        internal int Hp;
        internal string Name;

        public int Attack { get; internal set; }
        public int Defense { get; set; }


        internal void TakeDamage(int dmgP)
        {
            throw new NotImplementedException();
        }
    }
}
