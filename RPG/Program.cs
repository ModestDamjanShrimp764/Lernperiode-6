using System;
using System.Text;
using System.Collections.Generic;
using RPG;

class Program
{
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
    }
      




