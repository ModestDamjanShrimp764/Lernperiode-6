using RPG;
using System;

class Program
{
    static void Main()
    {
        // === Klassen-Auswahl ===
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

        // === Waffe ===
        Waffe w1 = new Waffe();
        w1.Name = "RPG";
        w1.MinDamage = 20;
        w1.MaxDamage = 30;
        Console.WriteLine("Waffe: " + w1.Name + ", MinDamage: " + w1.MinDamage + ", MaxDamage: " + w1.MaxDamage);

        // === Kampf 1 ===
        Gegner e1 = new Gegner();
        e1.Name = "Peter";
        e1.Hp = 30;
        e1.Attack = 10;

        int runde = 1;
        int totalDamage = 0;

        Console.WriteLine("=== Kampf 1: " + e1.Name + " ===");

        while (p1.Hp > 0 && e1.Hp > 0)
        {
            Console.WriteLine("Runde " + runde);
            Console.WriteLine("HP: Du " + p1.Hp + " | " + e1.Name + " " + e1.Hp);

            int dmgP = p1.Attack + w1.RollDamage();
            e1.TakeDamage(dmgP);
            totalDamage += dmgP;
            Console.WriteLine("Du machst " + dmgP + " Schaden. Gegner HP: " + e1.Hp);

            if (e1.Hp <= 0) break;

            int dmgE = e1.Attack;
            p1.TakeDamage(dmgE);
            Console.WriteLine(e1.Name + " macht " + dmgE + " Schaden. Deine HP: " + p1.Hp);

            runde++;
        }

        if (p1.Hp > 0)
        {
            Console.WriteLine("=== KAMPF GEWONNEN ===");
            Console.WriteLine("Runden: " + runde);
            Console.WriteLine("Gesamtschaden: " + totalDamage);
            Console.WriteLine("Verbleibende HP: " + p1.Hp);
            Console.WriteLine("======================");

            // === Kampf 2 ===
            Gegner e2 = new Gegner();
            e2.Name = "Hans";
            e2.Hp = 40;
            e2.Attack = 8;

            runde = 1;
            totalDamage = 0;
            Console.WriteLine("=== Kampf 2: " + e2.Name + " ===");

            while (p1.Hp > 0 && e2.Hp > 0)
            {
                Console.WriteLine("Runde " + runde);
                Console.WriteLine("HP: Du " + p1.Hp + " | " + e2.Name + " " + e2.Hp);

                int dmgP = p1.Attack + w1.RollDamage();
                e2.TakeDamage(dmgP);
                totalDamage += dmgP;
                Console.WriteLine("Du machst " + dmgP + " Schaden. Gegner HP: " + e2.Hp);

                if (e2.Hp <= 0) break;

                int dmgE = e2.Attack;
                p1.TakeDamage(dmgE);
                Console.WriteLine(e2.Name + " macht " + dmgE + " Schaden. Deine HP: " + p1.Hp);

                runde++;
            }

            if (p1.Hp > 0)
            {
                Console.WriteLine("=== KAMPF GEWONNEN ===");
                Console.WriteLine("Runden: " + runde);
                Console.WriteLine("Gesamtschaden: " + totalDamage);
                Console.WriteLine("Verbleibende HP: " + p1.Hp);
                Console.WriteLine("======================");
                Console.WriteLine("=== Dungeon komplett geschafft! ===");
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




