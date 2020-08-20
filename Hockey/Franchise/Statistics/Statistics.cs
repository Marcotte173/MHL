using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Statistics
{
    internal static List<Player> leaderboardList = new List<Player> { };
    internal static void LeaderBoard()
    {        
        Utilities.SortPoints(leaderboardList);
        Console.Clear();
        Console.WriteLine(String.Format("{0,-20}{1,-25}{2,-18}{3,-12}{4,-15}{5,-15}{6,-0}", "Name", "Team Name", "Games Played", "Goal", "Assist", "Points", "+/-"));
        Console.WriteLine("");
        for (int i = 0; i < 10 && i< leaderboardList.Count; i++)
        {
            if(leaderboardList[i] != null)
            {
                leaderboardList[i].Team = (Team.list[0].Roster.Contains(leaderboardList[i]) ? Team.list[0] : Team.list[1].Roster.Contains(leaderboardList[i]) ? Team.list[1] : Team.list[2].Roster.Contains(leaderboardList[i]) ? Team.list[2] : Team.list[3].Roster.Contains(leaderboardList[i]) ? Team.list[3] : Team.list[4].Roster.Contains(leaderboardList[i]) ? Team.list[4] : Team.list[5]);
                Console.WriteLine(String.Format("{0,-20}{1,-30}{2,-14}{3,-13}{4,-15}{5,-14}{6,-0}", leaderboardList[i].Name, leaderboardList[i].Team.Name, leaderboardList[i].GamesPlayed, leaderboardList[i].GoalStat, leaderboardList[i].AssistStat, leaderboardList[i].PointStat, leaderboardList[i].Plusminus));
            }                
        }
        Console.WriteLine("\n");
        Utilities.KeyPress();       
    }

    internal static void Individual(Player p)
    {
        Console.Clear();
        Write.Line(Colour.NAME, Colour.POSITION, Colour.TEAM,  p.Name, p.Position, Team.list[0].Name);
        Console.WriteLine("\n");
        Console.WriteLine(String.Format("{0,-18}{1,-12}{2,-15}{3,-15}{4,-9}{5,-20}{6,-12}{7,-15}","Games Played", "Goal", "Assist", "Points", "+/-","Penalty Minutes","Hits", "Shots Blocked"));
        Console.WriteLine(String.Format("{0,-5}{1,-14}{2,-13}{3,-15}{4,-14}{5,-15}{6,-15}{7,-15}{8,-15}","", p.GamesPlayed, p.GoalStat, p.AssistStat, p.AssistStat+p.GoalStat, p.Plusminus, p.PenaltyStat,p.HitStat ,p.BlockStat));
        Console.WriteLine("\n\n");
        Utilities.KeyPress();
    }

    internal static void LeaderboardCheck()
    {
        foreach (Team t in Team.list)
        {
            foreach (Player p in t.Roster)
            {
                if (p != null)
                {
                    if (!leaderboardList.Contains(p) && p.PointStat > 0) leaderboardList.Add(p);
                }
            }
        }
    }
}