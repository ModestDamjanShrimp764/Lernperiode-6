using RPG;
using System;
using System.Collections.Generic; // wichtig für List<Gegner>

class Program
{
    static void Main()
    {
        // === Spieler-Klasse auswählen ===
        Console.WriteLine("=== Wähle deine Klasse ===");
        Console.WriteLine("1) Krieger");
        Console.WriteLine("2) Naruto");
        Console.Write("Deine Wahl: ");
        string auswahl = Console.ReadLine();

        Spieler p1 = new Spieler();

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

        // === Waffen-Auswahl ===
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

        // === Gegnerliste erstellen ===
        List<Gegner> gegnerListe = new List<Gegner>
        {
            new Gegner { Name = "Peter", Hp = 30, Attack = 10 },
            new Gegner { Name = "Hans", Hp = 40, Attack = 8 },
            new Gegner { Name = "Ork", Hp = 50, Attack = 12 }
        };

        // === Nacheinander gegen alle Gegner kämpfen ===
        foreach (Gegner g in gegnerListe)
        {
            Kampf(p1, g, w1);

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

    // === Kampf-Methode ===
    static void Kampf(Spieler p1, Gegner g1, Waffe w1)
    {
        int runde = 1;
        int totalDamage = 0;

        Console.WriteLine("=== Kampf: " + g1.Name + " ===");

        while (p1.Hp > 0 && g1.Hp > 0)
        {
            Console.WriteLine("Runde " + runde);
            Console.WriteLine("HP: Du " + p1.Hp + " | " + g1.Name + " " + g1.Hp);

            int dmgP = p1.Attack + w1.RollDamage();
            g1.TakeDamage(dmgP);
            totalDamage += dmgP;
            Console.WriteLine("Du machst " + dmgP + " Schaden. Gegner HP: " + g1.Hp);

            if (g1.Hp <= 0) break;

            int dmgE = g1.Attack;
            p1.TakeDamage(dmgE);
            Console.WriteLine(g1.Name + " macht " + dmgE + " Schaden. Deine HP: " + p1.Hp);

            runde++;
        }

        if (p1.Hp > 0)
        {
            Console.WriteLine("=== KAMPF GEWONNEN ===");
            Console.WriteLine("Runden: " + runde);
            Console.WriteLine("Gesamtschaden: " + totalDamage);
            Console.WriteLine("Verbleibende HP: " + p1.Hp);
            Console.WriteLine("======================");
        }
        else
        {
            Console.WriteLine("=== KAMPF VERLOREN ===");
            Console.WriteLine("Runden: " + runde);
            Console.WriteLine("Gesamtschaden: " + totalDamage);
            Console.WriteLine("Deine HP ist 0");
            Console.WriteLine("======================");
        }
    }
}


