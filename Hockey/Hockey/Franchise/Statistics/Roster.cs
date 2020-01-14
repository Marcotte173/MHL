using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Roster
{
    public static Player[] list = new Player[19]
    {
        null,
        Team.list[0].Line1[0], Team.list[0].Line1[1], Team.list[0].Line1[2],
        Team.list[0].Line2[0], Team.list[0].Line2[1], Team.list[0].Line2[2],
        Team.list[0].Line3[0], Team.list[0].Line3[1], Team.list[0].Line3[2],
        Team.list[0].DLine1[0], Team.list[0].DLine1[1],
        Team.list[0].DLine2[0], Team.list[0].DLine2[1],
        Team.list[0].Bench[0],
        Team.list[0].Bench[1],
        Team.list[0].Bench[2],
        Team.list[0].Bench[3],
        Team.list[0].Bench[4]
    };
    internal static void Menu()
    {
        Player chosen = null;
        Console.Clear();
        Console.WriteLine("Would you like to look at [P]layers or [G]oalies?");
        string choice = Utilities.Choice();
        if (choice == "p") chosen = DraftDisplay.Players(Team.list[0].Roster.ToList());
        else if (choice == "g") chosen = DraftDisplay.Players(Team.list[0].GoalieRoster.ToList());
        if (chosen != null)
        {
            Coach.Name(chosen, 50, 20);
            Coach.String("What would you like to see?", 50, 22);
            Coach.String("[A]ttributes\t\t[S]tats", 50, 24);
            string choice1 = Utilities.Choice();
            if (choice1 == "s") Statistics.Individual(chosen);
            else if (choice1 == "a") Player.ExaminePlayer(chosen);
        }
    }
}