namespace ProjektHängaGubbe
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] ordlista =
            {
                "Vispgrädde", "Ukulele", "Innebandyspelare",
                "Flaggstång", "Yxa", "Havsfiske", "Prisma", "Landsbygd",
                "Generositet", "Lyckosam", "Perrong", "Samarbeta", "Välartad"
            };
            string[] betydelse =
            {
                "Uppvispad grädde",
                "Ett fyrsträngat instrument med ursprung i Portugal",
                "En person som spelar sporten innebandy",
                "En mast man hissar upp en flagga på",
                "Verktyg för att hugga ved",
                "Fiske till havs",
                "Ett transparent optiskt element som bryter ljuset vid plana ytor",
                "Geografiskt område med lantlig bebyggelse",
                "En personlig egenskap där man vill dela med sig av det man har",
                "Att man ofta, eller för stunden har tur",
                "Den upphöjda yta som passagerare väntar på eller stiger på/av ett spårfordon",
                "Att arbeta tillsamans mot ett gemensamt mål",
                "Att någon är väluppfostrad, skötsam, eller lovande"
            };

            // huvudloopen för spelet. Spelet kommer att fortsätta att köras tills användaren -
            // väljer att avsluta det.
            while (true)
            {
                // slumpas ett hemligt ord från ordlista
                Random Rand = new Random();
                int SlumpaOrd = Rand.Next(0, ordlista.Length);
                string hemligtOrd = ordlista[SlumpaOrd].ToUpper(); // hemliga ordet är i initieras variabler för att hantera gissningar.                                                             // stora bokstäver oavsett hur det finns i ordlista
                string GissOrd = new string('-', hemligtOrd.Length);// en sträng som innehåller streck av de delar av det hemliga ordet
                int GissKvar = 6;  // GissKvar håller koll på antalet gissningar som användaren har kvar
                string Bokstäv = ""; // Bokstäv håller koll på de bokstäver som användaren redan har gissat.
                                                             
                Console.WriteLine("Hänga Gubbe!");

                //loop körs så längre spelaren har gissningar kvar och det hemliga ordet inte har
                while (GissKvar > 0 && GissOrd != hemligtOrd)
                {
                    Console.WriteLine($"\nSökt ord: {GissOrd}"); 
                    Console.WriteLine($"använda bokstäver: {Bokstäv} ");
                    Console.WriteLine("{0} gissningar kvar", GissKvar);
                    Console.Write("Gissa en bokstav: ");
                    char giss = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                    // om bokstäv finns i det hemliga ordet, ändra gissord med rätt bokstäv
                    if (Bokstäv.Contains(giss))
                    {
                       continue;

                    }
                    Bokstäv += giss;

                    // om den gissade bokstav finns i hemligrord
                    if (hemligtOrd.Contains(giss))
                    {
                      
                        for (int i = 0; i < hemligtOrd.Length; i++)
                        {
                            if (hemligtOrd[i] == giss)
                            {
                                // tar bort 1 tecken på position i och sätter in den rätt bokstäv på samma position 
                                GissOrd = GissOrd.Remove(i, 1).Insert(i, giss.ToString());

                            }
                        }

                        if (GissOrd == hemligtOrd)
                        {
                            Console.WriteLine("\nDu vann!");
                            Console.WriteLine($"Ordet var {hemligtOrd} ({betydelse[SlumpaOrd]})");
                            break;

                        }
                    }
                    // annars minskas antalet gissningar.
                    else
                    {
                        GissKvar--;

                    }
                    // om anvädaren har använt alla 6 gånger gissningar
                    if (GissKvar == 0)
                    {
                        Console.WriteLine($"\n ordet var:{hemligtOrd} ( {betydelse[SlumpaOrd]})");
                    }

                }

                // frågar spelaren om han vill spela igen: om "y" rensa console och börja spela igen annas avsluta programmet.
                Console.WriteLine($"Vill du spela igen? (y/n): ");
                string svar = Console.ReadLine();
                if (svar == "y")
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    break;
                }





            }


        }




    }



}


