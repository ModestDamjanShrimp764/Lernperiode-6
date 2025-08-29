using RPG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Text;

class Program
{
    private static object player;
    private static int runde;
    private static object dmgE;
    private static object enemy;

    static void Main()
    {
      
        Spieler p1 = new Spieler();
        p1.Name = "Joshua";
        p1.Hp = 100;
        p1.Attack = 10;

        Console.WriteLine($"Spieler: {p1.Name}, HP: {p1.Hp}, Angriff: {p1.Attack}");

        p1.TakeDamage(10);
        Console.WriteLine($"{p1.Name} hat gerade {p1.Hp} HP");

        Waffe w1 = new Waffe();
        w1.Name = "RPG";
        w1.MinDamage = 20;
        w1.MaxDamage = 30;

        Console.WriteLine($"Waffe: {w1.Name}, MinDamage: {w1.MinDamage}, MaxDamage: {w1.MaxDamage}");

        w1.RollDamage(25);

        runde = 1
while player.Hp > 0 && enemy.Hp > 0:
  dmgP = player.Attack + weapon.RollDamage()
  enemy.TakeDamage(dmgP)
  print($"R{runde}: Du machst {dmgP} | Enemy HP {enemy.Hp}")
  if enemy.Hp == 0{: }


  dmgE = enemy.Attack
  player.TakeDamage(dmgE)
  print($"R{runde}: Gegner macht {dmgE} | Deine HP {player.Hp}")

  runde++
print(player.Hp > 0 ? "Gewonnen!" : "Verloren!")

        Console.WriteLine($"Runde {runde} —");
        Console.WriteLine($"HP: Du {p1.Hp} | {enemy.name} {enemy.Hp}");
        Console.WriteLine($"{enemy.Name} trifft für {dmgE}. Deine HP: {p1.Hp}");
        string result = p1.Hp > 0 ? "GEWONNEN" : "VERLOREN";
        Console.WriteLine($"{result}! In {runde} Runden.");








    }
    private static void print(string v)
    {
        throw new NotImplementedException();
    }
}






