using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Spieler
    {
        public object Name { get; internal set; }
        public int Attack { get; internal set; }
        public int Hp { get; internal set; }
        public int Defense { get; set; }
        public int Level { get; internal set; }

        internal void TakeDamage(int dmgE)
        {
            Hp -= dmgE;
            if (Hp < 0)
                Hp = 0;
        }
    }
}
