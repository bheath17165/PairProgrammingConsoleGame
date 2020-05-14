using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;
using System.Runtime.Remoting.Messaging;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace Eleven_Fifty_Fighter
{
    public class ProgramUI
    {
        int counter = 0;
        int playerHealth = 40;
        Random random = new Random();
        public int RandomNumber()
        {
            Thread.Sleep(5);
            return random.Next(0, 6);
        }
        public void Run()
        {
            var welcome = new SoundPlayer();
            welcome.SoundLocation = @"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Welcome.wav";


            Console.Clear();
            string titleScreen = System.IO.File.ReadAllText(@"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\TitleScreen.txt");
            Console.WriteLine(titleScreen);
            welcome.PlaySync();
            Console.ReadKey();
            SelectionScreen();

        }
        public void SelectionScreen()
        {
            var round1 = new SoundPlayer();
            round1.SoundLocation = @"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Round1.wav";
            var round2 = new SoundPlayer();
            round2.SoundLocation = @"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Round2.wav";
            var round3 = new SoundPlayer();
            round3.SoundLocation = @"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Round3.wav";
            var round4 = new SoundPlayer();
            round4.SoundLocation = @"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Round4.wav";
            var round5 = new SoundPlayer();
            round5.SoundLocation = @"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Round5.wav";
            var win = new SoundPlayer();
            win.SoundLocation = @"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Win.wav";
            var lose = new SoundPlayer();
            lose.SoundLocation = @"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Lose.wav";

            string alecImg = System.IO.File.ReadAllText(@"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Alec.txt");
            string philipImg = System.IO.File.ReadAllText(@"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Philip.txt");
            string caseyImg = System.IO.File.ReadAllText(@"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Casey.txt");
            string adamImg = System.IO.File.ReadAllText(@"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Adam.txt");
            string andrewImg = System.IO.File.ReadAllText(@"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Andrew.txt");

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                "You must defeat all 5 instructors to receive your Gold Badge.\n" +
                "\n1. Alec" +
                "\n2. Philip" +
                "\n3. Casey" +
                "\n4. Adam" +
                "\n5. Andrew");
            Console.Write("\nChoose Your Opponent: ");

            string input = Console.ReadLine();
            if (input == "1" || input == "Alec" || input == "alec")
            {
                Console.WriteLine(alecImg);
                round1.PlaySync();
                Game();
            }
            else if (input == "2" || input == "Philip" || input == "philip")
            {
                Console.WriteLine(philipImg);
                round2.PlaySync();
                Game();
            }
            else if (input == "3" || input == "Casey" || input == "casey")
            {
                Console.WriteLine(caseyImg);
                round3.PlaySync();
                Game();
            }
            else if (input == "4" || input == "Adam" || input == "adam")
            {
                Console.WriteLine(adamImg);
                round4.PlaySync();
                Game();
            }
            else if (input == "5" || input == "Andrew" || input == "andrew")
            {
                Console.WriteLine(andrewImg);
                round5.PlaySync();
                Game();
            }
            else
            {
                Console.WriteLine("You did not enter a valid selection. You Lose!");
                lose.PlaySync();
                Console.ReadKey();
            }
        }
        public void Game()
        {
            int fighterHealth = 10;

            var punch = new SoundPlayer();
            punch.SoundLocation = @"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Realistic_Punch.wav";
            var perfectDodge = new SoundPlayer();
            perfectDodge.SoundLocation = @"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Perfect.wav";
            var knockOut = new SoundPlayer();
            knockOut.SoundLocation = @"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\KO.wav";
            var win = new SoundPlayer();
            win.SoundLocation = @"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Win.wav";
            var lose = new SoundPlayer();
            lose.SoundLocation = @"C:\Users\halo4\source\repos\PairProgrammingConsoleGame\Eleven Fifty Fighter\Lose.wav";

            while (playerHealth > 0 && counter < 5)
            {
                Console.Clear();
                Console.WriteLine(
                    "Prepare for battle!\n\n" +
                    "1) Fight\n\n" +
                    "2) Run (Running takes away 10 HP, you coward...)");
                Console.Write("\r\nChoose Your Attack: ");
                string userValue = Console.ReadLine();
                if (userValue == "1" || userValue == "Fight" || userValue == "fight")
                {

                    while (fighterHealth > 0 && playerHealth > 0)
                    {
                        Console.WriteLine("Press 'Enter' to Attack");
                        Console.Clear();
                        int playerAttack = RandomNumber();
                        int fighterAttack = RandomNumber();
                        fighterHealth -= playerAttack;
                        punch.PlaySync();
                        Console.WriteLine("You asked Instructor a question!");
                        if (playerAttack == 0)
                        {
                            Console.WriteLine("The Instructor asked if you googled it!");
                            perfectDodge.PlaySync();
                        }
                        Console.WriteLine("Attack strength: " + playerAttack);
                        if (fighterHealth >= 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (fighterHealth > 3 && fighterHealth < 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.WriteLine("Instructor HP: " + fighterHealth);
                        Console.ForegroundColor = ConsoleColor.White;
                        if (fighterHealth <= 0)
                        {
                            Console.WriteLine("Knock Out!\nPress 'Enter' to continue.");
                            knockOut.PlaySync();
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine("Press 'Enter' for next move.");
                        Console.ReadLine();
                        playerHealth -= fighterAttack;
                        punch.PlaySync();
                        Console.WriteLine("Instructor explained a new concept to you!");
                        if (fighterAttack == 0)
                        {
                            Console.WriteLine("Internet Connection Unstable!");
                            perfectDodge.PlaySync();
                        }
                        Console.WriteLine("Attack strength: " + fighterAttack);
                        if (playerHealth >= 20)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (playerHealth > 10 && playerHealth < 20)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.WriteLine("Your HP: " + playerHealth);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press 'Enter' for next move.");
                        Console.ReadLine();
                    }
                    counter++;
                    fighterHealth = 10;
                    if (counter == 5 && playerHealth < 1)
                    {
                        Console.WriteLine("\nYou won... but at what cost...");
                        win.PlaySync();
                        Console.ReadKey();
                    }
                    else if (counter == 5)
                    {
                        Console.WriteLine("\nYou received your Gold Badge!");
                        win.PlaySync();
                        Console.ReadKey();
                    }
                    else if (playerHealth < 1)
                    {
                        Console.WriteLine("\nYou lost! Apply again in the fall.");
                        lose.PlaySync();
                        Console.ReadKey();
                    }
                    else
                    {
                        SelectionScreen();
                    }
                }
                else if (userValue == "2" || userValue == "Run" || userValue == "run")
                {
                    // playerHealth = playerHealth - 10;
                    playerHealth -= 10;
                    counter++;
                    if (counter == 5 && playerHealth < 1)
                    {
                        Console.WriteLine("\nYou won... but at what cost...");
                        win.PlaySync();
                        Console.ReadKey();
                    }
                    else if (counter == 5)
                    {
                        Console.WriteLine("\nYou received your Gold Badge!");
                        win.PlaySync();
                        Console.ReadKey();
                    }
                    else if (playerHealth < 1)
                    {
                        Console.WriteLine("\nYou lost! Apply again in the fall.");
                        lose.PlaySync();
                        Console.ReadKey();
                    }
                    else
                    {
                        SelectionScreen();
                    }
                }
                else
                {
                    Console.WriteLine("\nThat's not an official EFF move!\n\nPress 'Enter' to try again.");
                    Console.ReadLine();
                }
            }
        }
    }
}
