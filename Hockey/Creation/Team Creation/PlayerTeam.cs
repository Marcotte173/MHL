using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerTeam:Team
{
    public PlayerTeam()
    : base()
    {
        money = 1000000;
        fans = 100;
        reputation = 100;
    }
    public override void Draft(List<Player> f, List<Player> d, List<Player> g, Player chosen, int round)
    {
        Console.WriteLine($"\nYou currently have {forward}/10 forwards, {defence}/5 defencemen, and {goalie}/2 goalies.\n\nYou have ${money} available\n");
        Console.WriteLine("What would you like to view? \n\n[1]Available players\n[2]Current team");
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "1") Available(f, d, g, chosen);
        else if (choice == "x") money = 0;
        else if (choice == "2") Current(f, d, g, chosen);
        global::Draft.Menu();
    }

    internal void Current(List<Player> f, List<Player> d, List<Player> g, Player chosen)
    {
        Console.Clear();
        Console.WriteLine("Who would you like to take a look at?\n\n[1]Players\n[2]Goalies\n");
        string choice = Utilities.Choice();
        if (choice == "1") chosen = DraftDisplay.Players(roster.ToList());
        else if (choice == "2") chosen = DraftDisplay.Players(goalieRoster.ToList());
        if (chosen != null) Player.ExaminePlayer(chosen);
    }

    public void Available(List<Player> f, List<Player> d, List<Player> g, Player chosen)
    {
        Console.Clear();
        Console.WriteLine("Who would you like to take a look at?\n\n[1]Forwards\n[2]Defence\n[3]Goalies\n");
        string choice = Utilities.Choice();
        if (choice == "1")
        {
            if (forward >= 10)
            {
                Console.Clear();
                Console.WriteLine("You don't have any more room on the team for forwards!");
                Utilities.KeyPress();
                global::Draft.Menu();
            }
            chosen = DraftDisplay.Players(f);
        }
        else if (choice == "2")
        {
            if (defence >= 5)
            {
                Console.Clear();
                Console.WriteLine("You don't have any more room on the team for defencman!");
                Utilities.KeyPress();
                global::Draft.Menu();
            }
            chosen = DraftDisplay.Players(d);
        }
        else if (choice == "3")
        {
            if (goalie >= 2)
            {
                Console.Clear();
                Console.WriteLine("You don't have any more room on the team for goalies!");
                Utilities.KeyPress();
                global::Draft.Menu();
            }
            chosen = DraftDisplay.Players(g);
        }
        else global::Draft.Menu();
        if (chosen == null) global::Draft.Menu();
        Console.Clear();
        Console.WriteLine(Colour.NAME + $"{chosen.Name}\t" + Colour.OVERALL + $"{chosen.Overall}\t" + Colour.PRICE + $"{chosen.Price}" + Colour.RESET);
        Console.WriteLine("\n[1]Examine\n[2]Hire");
        Console.WriteLine($"\nYou have ${Money}");
        string choice1 = Utilities.Choice();
        if (choice1 == "1") Player.ExaminePlayer(chosen);
        else if (choice1 == "2")
        {
            Console.Clear();
            if (Utilities.CheckMoney(chosen.Price, Team.list[0])) Aquire.Hire(chosen, Team.list[0]);
            else 
            {
                Console.WriteLine("\n\nYou cannot afford this player\n\n");
                Utilities.KeyPress();                
            }
        }
        else global::Draft.Menu();
    }
}