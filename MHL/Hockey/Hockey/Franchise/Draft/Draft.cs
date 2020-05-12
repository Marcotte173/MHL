using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Draft
{
    internal static int round = 1;
    internal static Player chosen = new Player { };
    static Team p = Team.list[0];
    static List<Player> f = Create.forwardList;
    static List<Player> d = Create.defenceList;
    static List<Player> g = Create.goalieList;

    internal static void Start()
    {
        Console.Clear();
        Console.WriteLine(Colour.SPEAK + "'Excellent. Now let's get you a hockey team.\n");
        Console.WriteLine("Your uncle has agreed to fund your team up to a point.\n\nYou have $1,000,000 to spend right now on your team.");
        Console.WriteLine("Any other money you might need you'll have to raise yourself.\n\nWinning games is a good way to make money'\n" + Colour.RESET);
        Utilities.KeyPress();
        Menu();
    }

    internal static void Menu()
    {
        while (round < 18)
        {
            chosen = null;
            Utilities.SortPrice(f);
            Utilities.SortPrice(d);
            Utilities.SortPrice(g);
            Console.Clear();
            Console.WriteLine($"It is draft round {round}\n");
            //If you can afford a player
            if (p.Money >= f[f.Count - 1].Price && p.Money >= d[d.Count - 1].Price && p.Money >= g[g.Count - 1].Price)
            {
                Utilities.SortOverall(f);
                Utilities.SortOverall(d);
                Utilities.SortOverall(g);
                //Draft a player
                p.Draft(f,d,g,chosen, round);               
            }
            //Otherwise
            else
            {
                //Get a crappy Loaner          
                Console.WriteLine("You have run out of money, you have been assigned a loaner player. This player is not good\n");
                Aquire.Loaner(p);
                Utilities.KeyPress();
            }
        }
        Console.Clear();
        //After round 15, you have a team
        Console.WriteLine("You have a team! It's time to get your schedule and start planning for your games!\nPress any key to review the teams and start the season");
        Console.ReadKey(true);
        Review();
    }

    private static void Review()
    {
        foreach (Team t in Team.list)
        {
            Console.Clear();
            Write.CenterColourText(Colour.NAME, Colour.TEAM, "", t.GMName, " of the ", t.Name, "");
            Console.WriteLine("Players\n");
            Console.WriteLine(String.Format("{0, -6}{1, -35}{2,-20}{3,-20}{4,-20}{5,-21}{6,-19}{7,-21}{8,-20}{9,-20}{10,-10}", "Num", Colour.NAME + "Name ", Colour.OVERALL + "Overall", Colour.PRICE + "Price", Colour.SHOOT + "Shooting", Colour.PASS + "Passing", Colour.SPEED + "Speed", Colour.SECONDARY + "Secondary", Colour.SECONDARY + "OAware", Colour.SECONDARY + "DAware", Colour.POSITION + "Position" + Colour.RESET));
            Console.WriteLine("");
            for (int i = 0; i < t.Roster.Length; i++)
            {
                if (t.Roster[i] != null)
                Console.WriteLine(String.Format("{0, -6}{1, -37}{2,-18}{3,-23}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}{9,-19}{10,-10}", $"[{i + 1}] ", Colour.NAME + $"{t.Roster[i].Name} ", Colour.OVERALL + $"{t.Roster[i].Overall}", Colour.PRICE + $"{t.Roster[i].Price}", Colour.SHOOT + $"{t.Roster[i].Shooting}", Colour.PASS + $"{t.Roster[i].Passing}", Colour.SPEED + $"{t.Roster[i].Speed}", Colour.SECONDARY + $"{(t.Roster[i].Handling + t.Roster[i].Checking + t.Roster[i].Balance + t.Roster[i].Block) / 4} ", Colour.SECONDARY + $"{t.Roster[i].OffAware}", Colour.SECONDARY + $"{t.Roster[i].DefAware}", Colour.POSITION + $"{t.Roster[i].Position}" + Colour.RESET));
            }
            Console.WriteLine("\n");
            Console.WriteLine("Goalies\n");
            Console.WriteLine(String.Format("{0, -6}{1, -35}{2,-20}{3,-20}{4,-20}{5,-21}{6,-19}{7,-21}{8,-30}{9,-20}", "Num", Colour.NAME + "Name ", Colour.OVERALL + "Overall", Colour.PRICE + "Price", Colour.SHOOT + "Glove", Colour.PASS + "Stick", Colour.SPEED + "Angles", Colour.SECONDARY + "Agility", Colour.SECONDARY + "Butterfly", Colour.POSITION + "Position" + Colour.RESET));
            for (int i = 0; i < t.GoalieRoster.Length; i++)
            {
                if (t.GoalieRoster[i] != null)
                    Console.WriteLine(String.Format("{0, -6}{1, -37}{2,-18}{3,-23}{4,-20}{5,-20}{6,-20}{7,-20}{8,-30}{9,-19}", $"[{i + 1}] ", Colour.NAME + $"{t.GoalieRoster[i].Name} ", Colour.OVERALL + $"{t.GoalieRoster[i].Overall}", Colour.PRICE + $"{t.GoalieRoster[i].Price}", Colour.SHOOT + $"{t.GoalieRoster[i].Glove}", Colour.PASS + $"{t.GoalieRoster[i].Stick}", Colour.SPEED + $"{t.GoalieRoster[i].Angles}", Colour.SECONDARY + $"{t.GoalieRoster[i].Agility} ", Colour.SECONDARY + $"{t.GoalieRoster[i].Butterfly}", Colour.POSITION + $"{t.GoalieRoster[i].Position}" + Colour.RESET));
            }
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Utilities.KeyPress();
        }          
        Season.Start();
    }

    internal static void ComputerDraft()
    {
        for (int i = 1; i < Team.list.Count; i++)
        {
            Team.list[i].Draft(f,d,g);
        }
        round++;
    }
}