using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey
{    
    class Program
    {        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            string[] firstNames = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "/FirstNames.txt");
            string[] lastNames = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "/LastNames.txt");
            for (int i = 0; i < firstNames.Length; i++)
            {
                for (int j = 0; j < lastNames.Length; j++) { Create.nameList.Add($"{firstNames[i]} {lastNames[j]}"); }
            }
            Create.PlayerCreate();
            Colour.SetupConsole();
            StartScreen();        
        }

        private static void StartScreen()
        {
            Console.SetCursorPosition(0, Console.WindowHeight / 2 - 3);
            Write.Menu(Colour.INJURY +"  ____    ____  "+Colour.POSITION + "____  ____  "+Colour.GOAL + "_____      " + Colour.RESET + "");
            Write.Menu(Colour.INJURY +" |_   \\  /   _|"+Colour.POSITION + "|_   ||   _|"+Colour.GOAL + "|_   _|    " + Colour.RESET + "");
            Write.Menu(Colour.INJURY +"   |   \\/   |  "+Colour.POSITION + "  | |__| |  "+Colour.GOAL + "  | |      " + Colour.RESET + "");
            Write.Menu(Colour.INJURY +"   | |\\  /| |  "+Colour.POSITION + "  |  __  |  "+Colour.GOAL + "  | |   _  " + Colour.RESET + "");
            Write.Menu(Colour.INJURY +"  _| |_\\/_| |_ "+Colour.POSITION + " _| |  | |_ "+Colour.GOAL + " _| |__/ | " + Colour.RESET + "");
            Write.Menu(Colour.INJURY + "|_____||_____|"  +Colour.POSITION + "|____||____|"+  Colour.GOAL + "|________|" + Colour.RESET + "");
            Console.SetCursorPosition(0, Console.WindowHeight / 2 + 5);
            Write.CenterText("Version 0.10");
            Console.SetCursorPosition(0, Console.WindowHeight / 2 + 10);
            Write.CenterText("[N]ew Game\t[Q]uit\n");
            string choice = Utilities.Choice();
            if (choice == "n") Game();
            else if (choice == "q") Environment.Exit(0);
            else StartScreen();
        }

        private static void Game()
        {
            Flavor();
            CreateTeam.Start();
            Draft.Start();    
        }       

        private static void Flavor()
        {
            Console.Clear();
            Console.WriteLine("You just received a call from your uncle.\n\nApparently, he won a small defunct hockey team in a poker game");
            Console.WriteLine("He knows you don't have much going on, and offers to let you run the team.\n\nIf you can win the Marcotte cup at the end of the season, the team is yours!\nOtherwise, you go to jail");
            Console.WriteLine("\nSeizing the opportunity, you head downtown to register your team...\n\n");
            Utilities.KeyPress();
        }             
    }
}