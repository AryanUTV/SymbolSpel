namespace SymbolSpel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sätt rätt symbol i rätt hink");
            Console.WriteLine("Tryck på piltangenterna för att flytta symbolen");
            Console.WriteLine("Tryck Enter för att börja spelet");
            Console.ReadLine();

            Random rnd = new Random();

            // Bestämmer om spelet ska fortsättas
            bool spela = true;

            while (spela)
            {
                // Nollställer rundor och poäng när nytt spel börjas
                int runda = 0;
                int rätt = 0;

                while (runda < 5)
                {
                    // Slumpar tal mellan 0 och 3
                    int symbol = rnd.Next(0, 4);

                    string symbolText;

                    // Vilken symbol faller ner
                    if (symbol == 0)
                    {
                        symbolText = "X";
                    }
                    else if (symbol == 1)
                    {
                        symbolText = "O";
                    }
                    else if (symbol == 2)
                    {
                        symbolText = "T";
                    }
                    else
                    {
                        symbolText = "H";
                    }

                    // x är för höger/vänster och y är för upp/ner
                    int x = 5;
                    int y = 0;

                    // Symbolen ska falla till det når hinkarnas rad
                    while (y < 21)
                    {
                        Console.Clear();

                        // Kollar om en tangent har tryckts
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo key = Console.ReadKey(true);

                            // Flytta symbolen till vänster
                            if (key.Key == ConsoleKey.LeftArrow && x >= 2)
                                x -= 2;

                            // Flytta symbolen till höger
                            if (key.Key == ConsoleKey.RightArrow && x <= 33)
                                x += 2;
                        }

                        // Symbolen placeras på rätt plats på skärmen
                        Console.SetCursorPosition(x, y);
                        Console.Write(symbolText);

                        Console.SetCursorPosition(0, 20);
                        Console.Write("[  X  ]   [  O  ]   [  T  ]   [  H  ]");

                        // Symbolen tar ett steg ner
                        y++;

                        // Hur många millisekynder symbolen faller ner
                        Thread.Sleep(300);
                    }

                    // Kollar vart symbolen hamnade
                    if (symbolText == "X" && x >= 1 && x <= 5)
                    {
                        rätt++;
                    }
                    else if (symbolText == "O" && x >= 11 && x <= 15)
                    {
                        rätt++;
                    }
                    else if (symbolText == "T" && x >= 21 && x <= 25)
                    {
                        rätt++;
                    }
                    else if (symbolText == "H" && x >= 31 && x <= 35)
                    {
                        rätt++;
                    }

                    // Till nästa runda
                    runda++;

                    // 1 sekund paus tills nästa runda
                    Thread.Sleep(1000);
                }

                // Resultatet efter alla 5 rundor
                Console.Clear();

                Console.WriteLine("==============================");
                Console.WriteLine("         SPELET ÄR SLUT");
                Console.WriteLine("==============================");
                Console.WriteLine();
                Console.WriteLine($"        Du fick {rätt}/5 rätt!");
                Console.WriteLine();
                Console.WriteLine("        Tryck C för att spela igen");
                Console.WriteLine("        Tryck på något annat för att avsluta");
                Console.WriteLine("==============================");

                // Läser vad man har tryckt
                string svar = Console.ReadLine();

                // Om inte C har valts så avslutas spelet
                if (svar.ToUpper() != "C")
                {
                    spela = false;
                }
            }
        }
    }
}
