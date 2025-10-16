using RPG;
using System;
using System.Collections.Generic;

internal class Program
{
    static void Main()
    {
   
        Console.WriteLine("=== Wähle deine Klasse ===");
        Console.WriteLine("1) Vincent");
        Console.WriteLine("2) Joshua");
        Console.Write("Deine Wahl: ");
        string auswahl = Console.ReadLine();

        Spieler p1 = new Spieler();

        p1.Level = 1;

        if (auswahl == "1")
        {
            p1.Name = "Krieger";
            p1.Hp = 120;
            p1.Attack = 8;
        }
        else if (auswahl == "2")
        {
            p1.Name = "Naruto";
            p1.Hp = 80;
            p1.Attack = 15;
        }
        else
        {
            Console.WriteLine("Ungültige Eingabe, Standard: Krieger");
            p1.Name = "Krieger";
            p1.Hp = 120;
            p1.Attack = 8;
        }

        Console.WriteLine("Spieler: " + p1.Name + ", HP: " + p1.Hp + ", Angriff: " + p1.Attack);

        int heiltrank = 3;



        Console.WriteLine("=== Wähle deine Waffe ===");
        Console.WriteLine("1) Schwert (Min 5 / Max 10)");
        Console.WriteLine("2) Axt (Min 2 / Max 15)");
        Console.Write("Deine Wahl: ");
        string wahlWaffe = Console.ReadLine();

        Waffe w1 = new Waffe();

        if (wahlWaffe == "1")
        {
            w1.Name = "Schwert";
            w1.MinDamage = 5;
            w1.MaxDamage = 10;
        }
        else if (wahlWaffe == "2")
        {
            w1.Name = "Axt";
            w1.MinDamage = 2;
            w1.MaxDamage = 15;
        }
        else
        {
            Console.WriteLine("Ungültige Eingabe, Standard: Schwert");
            w1.Name = "Schwert";
            w1.MinDamage = 5;
            w1.MaxDamage = 10;
        }

        Console.WriteLine("Waffe: " + w1.Name + ", MinDamage: " + w1.MinDamage + ", MaxDamage: " + w1.MaxDamage);

        List<Gegner> gegnerListe = new List<Gegner>
{
    new Gegner { Name = "Peter", Hp = 30, Attack = 10, Defense = 1 },
    new Gegner { Name = "Hans", Hp = 40, Attack = 8, Defense = 2 },
    new Gegner { Name = "Ork", Hp = 50, Attack = 12, Defense = 3 },
    new Gegner { Name = "Drache", Hp = 100, Attack = 15, Defense = 5 } 
};


        foreach (Gegner g in gegnerListe)
        {

            bool gewonnen = Kampf(p1, g, w1, ref heiltrank);

            if (gewonnen)
            {
                p1.Level++;
                p1.Hp += 10;
                p1.Attack += 2;


                Console.WriteLine($"=== LEVEL UP! ===");
                Console.WriteLine($"Neues Level: {p1.Level}");
                Console.WriteLine($"HP +10 → {p1.Hp}");
                Console.WriteLine($"Attack +2 → {p1.Attack}");
                Console.WriteLine("======================");
            }

            if (p1.Hp <= 0) 
            {
                Console.WriteLine("Spiel ist vorbei – du bist besiegt!");
                break;
            }
        }

        if (p1.Hp > 0)
        {
            Console.WriteLine("=== Glückwunsch! Du hast alle Gegner besiegt! ===");
        }
    }

   
    static bool Kampf(Spieler p1, Gegner g1, Waffe w1, ref int heiltrank)
    {
        int runde = 1;
        int totalDamage = 0;

        Console.WriteLine("=== Kampf: " + g1.Name + " ===");

        while (p1.Hp > 0 && g1.Hp > 0)
        {
            Console.WriteLine("Runde " + runde);
            Console.WriteLine("HP: Du " + p1.Hp + " | " + g1.Name + " " + g1.Hp);
            Console.WriteLine("Aktion: (1) Angreifen  (2) Heiltrank benutzen");

            string aktion = Console.ReadLine();

            if (aktion == "2")
            {
                if (heiltrank > 0)
                {
                    p1.Hp += 30;
                    heiltrank--;
                    Console.WriteLine($"Du benutzt einen Heiltrank! +30 HP");
                    Console.WriteLine($"Verbleibende Tränke: {heiltrank}");
                }
                else
                {
                    Console.WriteLine("❌ Keine Heiltränke mehr übrig!");
                }
            }

            else
            {

                int dmgP = p1.Attack + w1.RollDamage() - g1.Defense;
                g1.TakeDamage(dmgP);
                if (g1.Hp < 1) dmgP = 1;
                totalDamage += dmgP;
                Console.WriteLine("Du machst " + dmgP + " Schaden. Gegner HP: " + g1.Hp);
            }

            if (g1.Hp <= 0) break;

            int dmgE = g1.Attack;
            if (dmgE < 1) dmgE = 1;
            p1.TakeDamage(dmgE);
            Console.WriteLine(g1.Name + " macht " + dmgE + " Schaden. Deine HP: " + p1.Hp);

            runde++;
        }

        if (p1.Hp > 0)
        {
            Console.WriteLine("=== Kampf gewonnennnnn ===");
            Console.WriteLine("Runden: " + runde);
            Console.WriteLine("Gesamtschaden: " + totalDamage);
            Console.WriteLine("Verbleibende HP: " + p1.Hp);
            Console.WriteLine("======================");
            return true;
        }
        else
        {
            Console.WriteLine("=== Kampf verlorennnnn ===");
            Console.WriteLine("Runden: " + runde);
            Console.WriteLine("Gesamtschaden: " + totalDamage);
            Console.WriteLine("Deine HP ist 0");
            Console.WriteLine("======================");
            return false;
        }
    }
}

