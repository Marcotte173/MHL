using System;
using System.Collections.Generic;
using System.Linq;
internal class Season
{
    internal static bool season = true;
    internal static void Start()
    {
        Console.Clear();
        GenerateLines();
        Schedule.Generate();
        Schedule.Display();
        Menu();
        Playoffs.Start();
    }

    private static void GenerateLines()
    {
        for (int i = 0; i < Team.list.Count; i++)
        {
            List<Player> forward = new List<Player> { };
            List<Player> defence = new List<Player> { };
            for (int z = 0; z < 15; z++)
            {
                if (Team.list[0].Roster[z].Position == "Forward") forward.Add(Team.list[0].Roster[z]);
                else if (Team.list[0].Roster[z].Position == "Defence") defence.Add(Team.list[0].Roster[z]);
            }
            Utilities.SortOverall(forward);
            for (int j = 0; j < 3; j++)
            {
                Team.list[i].Line1[j] = forward[0];
                forward.RemoveAt(0);
            }
            for (int k = 0; k < 3; k++)
            {
                Team.list[i].Line2[k] = forward[0];
                forward.RemoveAt(0);
            }
            for (int n = 0; n < 3; n++)
            {
                Team.list[i].Line3[n] = forward[0];
                forward.RemoveAt(0);
            }
            Utilities.SortOverall(defence);
            for (int l = 0; l < 2; l++)
            {
                Team.list[i].DLine1[l] = defence[0];
                defence.RemoveAt(0);
            }
            for (int m = 0; m < 2; m++)
            {
                Team.list[i].DLine2[m] = defence[0];
                defence.RemoveAt(0);
            }
            Team.list[i].Bench[0] = forward[0];
            Team.list[i].Bench[1] = defence[0];
            Team.list[i].StartingGoalie = Team.list[i].GoalieRoster[0];
            Team.list[i].StartingGoalie = Team.list[i].GoalieRoster[1];
        }
    }

    internal static void Menu()
    {
        while (season)
        {
            Game game = Check.Game();
            Console.Clear();
            Time.Display();
            Check.Event(game);
            Console.SetCursorPosition(0, Console.WindowHeight - 8);
            Console.WriteLine("[G]m actions\t\t[C]oach actions");
            Console.WriteLine("\n[R]osters\t\t[S]tandings\t\t[L]eaderboard");
            Console.WriteLine("\n\n\n[N]ext day");
            string choice = Utilities.Choice();
            if (Check.GameToday())
            {
                if (choice == "t" && game.Played == false) Game.Play(game);
                else if (choice == "i") Interference.GameDay(Check.MyGame(game));
                else if (Check.MyGame(game) && (choice == "w")) Game.Warmup();
            }
            if (choice == "n")
            {
                if (game == null || game.Played) Time.PassTime(1);
                else
                {
                    Console.Clear();
                    Console.WriteLine("There is a game that must be played before moving on");
                    Utilities.KeyPress();
                }
            }
            else if (choice == "g") GM.Menu();
            else if (choice == "c") Coach.Menu();
            else if (choice == "r") Roster.Menu();
            else if (choice == "s") Standings.Display();
            else if (choice == "l") Statistics.LeaderBoard();
        }
        Console.Clear();
        Console.WriteLine("Cool Beans");
        Utilities.KeyPress();
    }
}