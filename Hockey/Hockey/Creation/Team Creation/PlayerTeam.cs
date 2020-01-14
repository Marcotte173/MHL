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
        Console.WriteLine("Would you like to view [A]vailable players or your [C]urrent team?");
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "a") Available(f, d, g, chosen);
        else if (choice == "x") money = 0;
        else if (choice == "c") Current(f, d, g, chosen);
        global::Draft.Menu();
    }

    internal void Current(List<Player> f, List<Player> d, List<Player> g, Player chosen)
    {
        Console.Clear();
        Console.WriteLine("Would you like to take a look at [P]layers or [G]oalies?\n");
        string choice = Utilities.Choice();
        if (choice == "p") chosen = DraftDisplay.Players(roster.ToList());
        else if (choice == "g") chosen = DraftDisplay.Players(goalieRoster.ToList());
        if (chosen != null) Player.ExaminePlayer(chosen);
    }

    private void Available(List<Player> f, List<Player> d, List<Player> g, Player chosen)
    {
        Console.Clear();
        Console.WriteLine("Would you like to take a look at [F]orwards, [D]efencemen or [G]oalies?\n");
        string choice = Utilities.Choice();
        if (choice == "f")
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
        else if (choice == "d")
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
        else if (choice == "g")
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
        Console.WriteLine("\nWould you like to [E]xamine or [H]ire this player?");
        Console.WriteLine($"\nYou have ${Money}");
        string choice1 = Utilities.Choice();
        if (choice1 == "e") Player.ExaminePlayer(chosen);
        else if (choice1 == "h")
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