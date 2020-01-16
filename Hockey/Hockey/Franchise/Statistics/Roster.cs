using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Roster
{
    public static Player[] list = new Player[21]
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
        Team.list[0].Bench[4],
        Team.list[0].Goalies[0],
        Team.list[0].Goalies[1]
    };
    internal static void Menu()
    {
        Player chosen = null;
        Console.Clear();
        Console.WriteLine("Who would you like to take a look at?\n\n[1]Players\n[2]Goalies\n");
        string choice = Utilities.Choice();
        if (choice == "1") chosen = DraftDisplay.Players(Team.list[0].Roster.ToList());
        else if (choice == "2") chosen = DraftDisplay.Players(Team.list[0].GoalieRoster.ToList());
        if (chosen != null)
        {
            Coach.Name(chosen, 50, 20);
            Coach.String("[1]Attributes", 50, 22);
            Coach.String("[2]Stats", 50, 23);
            Coach.String("[3]Release", 50, 24);
            string choice1 = Utilities.Choice();
            if (choice1 == "2") Statistics.Individual(chosen);
            else if (choice1 == "1") Player.ExaminePlayer(chosen);
            else if (choice1 == "3")
            {
                Console.Clear();
                Console.WriteLine($"Release {chosen.Name}?");
                if (Utilities.Confirm())
                {
                    Console.WriteLine($"\n{chosen.Name} has been released from the organization");
                    for (int i = 0; i < list.Length; i++)
                    {
                        if (list[i] == chosen) list[i] = null;
                        Coach.NewLines();
                    }
                }
            }

        }
    }
}