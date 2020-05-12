using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Schedule
{
    static List<Game> list = new List<Game> 
    { 
        new Game(Team.list[0],Team.list[1]),
        new Game(Team.list[0],Team.list[2]),
        new Game(Team.list[0],Team.list[3]),
        new Game(Team.list[0],Team.list[4]),
        new Game(Team.list[0],Team.list[5]),
        new Game(Team.list[0],Team.list[1]),
        new Game(Team.list[0],Team.list[2]),
        new Game(Team.list[0],Team.list[3]),
        new Game(Team.list[0],Team.list[4]),
        new Game(Team.list[0],Team.list[5])
    };

    static List<Game> list1 = new List<Game>
    {
        new Game(Team.list[1],Team.list[2]),
        new Game(Team.list[1],Team.list[3]),
        new Game(Team.list[1],Team.list[4]),
        new Game(Team.list[1],Team.list[5]),
        new Game(Team.list[2],Team.list[3]),
        new Game(Team.list[2],Team.list[4]),
        new Game(Team.list[2],Team.list[5]),
        new Game(Team.list[3],Team.list[4]),
        new Game(Team.list[3],Team.list[5]),
        new Game(Team.list[4],Team.list[5]),
        new Game(Team.list[1],Team.list[2]),
        new Game(Team.list[1],Team.list[3]),
        new Game(Team.list[1],Team.list[4]),
        new Game(Team.list[1],Team.list[5]),
        new Game(Team.list[2],Team.list[3]),
        new Game(Team.list[2],Team.list[4]),
        new Game(Team.list[2],Team.list[5]),
        new Game(Team.list[3],Team.list[4]),
        new Game(Team.list[3],Team.list[5]),
        new Game(Team.list[4],Team.list[5])
    };

    internal static List<Day> days = new List<Day> 
    {   
        new Day(1,2,1, null),
        new Day(2,2,1, null),
        new Day(3,2,1, null),
        new Day(1,3,1, null),
        new Day(2,3,1, null),
        new Day(3,3,1, null),
        new Day(1,4,1, null),
        new Day(2,4,1, null),
        new Day(3,4,1, null),
        new Day(1,1,2, null),
        new Day(2,1,2, null),
        new Day(3,1,2, null),
        new Day(1,2,2, null),
        new Day(2,2,2, null),
        new Day(3,2,2, null),

        new Day(1,3,2, null),
        new Day(2,3,2, null),
        new Day(3,3,2, null),
        new Day(1,4,2, null),
        new Day(2,4,2, null),
        new Day(3,4,2, null),
        new Day(1,1,3, null),
        new Day(2,1,3, null),
        new Day(3,1,3, null),
        new Day(1,2,3, null),
        new Day(2,2,3, null),
        new Day(3,2,3, null),
        new Day(1,3,3, null),
        new Day(2,3,3, null),
        new Day(3,3,3, null),
    };

    internal static void Generate()
    {
        for (int i = 0; i < days.Count; i+=3)
        {
            int choice = Utilities.RandomInt(0, list.Count);
            days[i + Utilities.RandomInt(0, 3)].TheGame = list[choice];
            list.RemoveAt(choice);
        }
        for (int i = 0; i < days.Count; i++)
        {
            if (days[i].TheGame == null)
            {
                int choice = Utilities.RandomInt(0, list1.Count);
                days[i].TheGame = list1[choice];
                list1.RemoveAt(choice);
            }
        }
    }

    internal static void Display()
    {
        Console.WriteLine("MHL Schedule\n\n");
        int counter=0;
        foreach (Day d in Schedule.days)
        {
            if (counter == 15)
            {
                Utilities.KeyPress();
                Console.Clear();
                Console.WriteLine("MHL Schedule\n\n");
            } 
            Console.WriteLine(string.Format("{0,-100}{1,-50}", Colour.PASS + $"{Time.Days[d.TheDay]}" + Colour.RESET + ", " + Colour.PASS + $"{Time.Weeks[d.TheWeek]}" + Colour.RESET + " week of " + Colour.PASS + $"{Time.Months[d.TheMonth]}" + Colour.RESET + ". ", Colour.TEAM + $"{d.TheGame.A.Name} " + Colour.RESET + "vs " + Colour.TEAM + $"{d.TheGame.B.Name}" + Colour.RESET));
            if (d.TheDay == 3) Console.WriteLine("");
            counter++;
        }
        Utilities.KeyPress();
    }
}