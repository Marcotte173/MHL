using System;
using System.Collections.Generic;
using System.Linq;
internal class Season
{
    internal static bool season = true;
    internal static int gameWeek = 0;
    internal static void Start()
    {
        Console.Clear();
        GenerateLines();
        Schedule.Generate();
        Schedule.Display();
        Menu();
        Playoffs.Start();
    }

    public static void GenerateLines()
    {
        for (int i = 0; i < Team.list.Count; i++)
        {
            List<Player> forward = new List<Player> { };
            List<Player> defence = new List<Player> { };
            for (int z = 0; z < 15; z++)
            {  
                if (Team.list[i].Roster[z].Position == "Forward") forward.Add(Team.list[i].Roster[z]);
                else if (Team.list[i].Roster[z].Position == "Defence") defence.Add(Team.list[i].Roster[z]);
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
            Utilities.SortOverall(Team.list[i].GoalieRoster.ToList());
            Team.list[i].StartingGoalie = Team.list[i].GoalieRoster[0];
            Team.list[i].BackupGoalie = Team.list[i].GoalieRoster[1];
            Team.list[i].Bench[0] = forward[0];
            Team.list[i].Bench[1] = defence[0];
        }
    }

    internal static void Menu()
    {
        while (season)
        {
            Statistics.LeaderboardCheck();
            Game game = Check.Game();
            Console.Clear();
            Time.Display();
            Check.Event(game);
            Console.SetCursorPosition(0, Console.WindowHeight - 13);
            if (Check.GameToday())
            {
                if (game.Played == false && Check.MyGame(game)) Console.WriteLine("[1]Play your game today");
                else if (game.Played == false && Check.MyGame(game)==false) Console.WriteLine("[1]Watch the game today");
                else Console.WriteLine("[x]There are no games today");
            }                
            else Console.WriteLine("[x]There are no games today");
            if (Check.GameToday()) 
            {
                if (game.Played == false && Check.MyGame(game)) Console.WriteLine("[2]Warm up");
                else Console.WriteLine("[x]Your team is not playing today");
            }
            else Console.WriteLine("[x]Your team is not playing today");
            Console.WriteLine("[x]There are no events today");
            Console.WriteLine("[4]Coach actions");
            Console.WriteLine("[5]Gm actions");
            Console.WriteLine("[6]Standings");
            if (Statistics.leaderboardList.Count > 0) Console.WriteLine("[7]Leaderboard");
            else Console.WriteLine("[x]No one has points yet");
            Console.WriteLine("\n\n[0]Next day");
            string choice = Utilities.Choice();
            if (Check.GameToday())
            {
                if (choice == "1" && game.Played == false) Play.Start(game);
                else if (Check.MyGame(game) && (choice == "2")) Play.Warmup();
            }
            if (choice == "0")
            {
                if (game == null || game.Played) Time.PassTime(1);
                else
                {
                    Console.Clear();
                    Console.WriteLine("There is a game that must be played before moving on");
                    Utilities.KeyPress();
                }
            }
            else if (choice == "4") Coach.Menu(); 
            else if (choice == "5") GM.Menu();
            else if (choice == "6") Standings.Display();
            else if (choice == "7") if (Statistics.leaderboardList.Count >0) Statistics.LeaderBoard();
        }
        Utilities.KeyPress();
    }
}