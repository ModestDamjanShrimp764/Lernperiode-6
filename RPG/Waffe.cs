using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Waffe
    {
        public string Name { get; internal set; }
        public int MaxDamage { get; internal set; }
        public int MinDamage { get; internal set; }
        public int RollDamage()
        {
            Random rnd = new Random();
            return rnd.Next(MinDamage, MaxDamage + 1);
        }
    }
}
        

     