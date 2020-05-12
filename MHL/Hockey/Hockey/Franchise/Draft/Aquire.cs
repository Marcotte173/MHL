using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Aquire
{
    static List<Player> f  = Create.forwardList;
    static List<Player> d  = Create.defenceList;
    static List<Player> g  = Create.goalieList;
    static List<Player> lf = Create.loanerForwardList;
    static List<Player> ld = Create.loanerDefenceList;
    static List<Player> lg = Create.loanerGoalieList;
    static Team p = Team.list[0];
    internal static void Hire(Player chosen, Team t)
    {
        if (t == p)
        {
            Console.WriteLine($"Hire {chosen.Name}?");
            if (Utilities.Confirm() == false) Draft.Menu();
        }        
        if (chosen.Position == "Goalie")
        {
            t.GoalieRoster[NextNull(t.GoalieRoster)] = chosen;
            chosen.Team = t;
            t.Goalie++;
            g.Remove(chosen);
        }
        else if (chosen.Position == "Forward")
        {
            t.Roster[NextNull(t.Roster)] = chosen;
            chosen.Team = t;
            t.Forward++;
            f.Remove(chosen);
        }
        else if (chosen.Position == "Defence")
        {
            t.Roster[NextNull(t.Roster)] = chosen;
            chosen.Team = t;
            t.Defence++;
            d.Remove(chosen);
        }
        t.Money -= chosen.Price;
        if (t == p)
        {
            Console.Clear();
            Console.WriteLine($"{chosen.Name} has been added to your team");
            Draft.ComputerDraft();
            Utilities.KeyPress();
        }        
    }    

    internal static void Loaner(Team t)
    {
        if (t.Forward < 10)
        {
            if (t == p) Console.WriteLine(Colour.NAME + lf[0].Name + Colour.RESET + " has joined your team\n");
            t.Roster[NextNull(t.Roster)] = lf[0];
            t.Forward++;
            lf.Remove(lf[0]);
        }
        else if (t.Defence < 5)
        {
            if (t == p) Console.WriteLine(Colour.NAME + ld[0].Name + Colour.RESET + " has joined your team\n");
            t.Roster[NextNull(t.Roster)] = ld[0];
            t.Defence++;
            ld.Remove(ld[0]);
        }
        else if (t.Goalie < 2)
        {
            if (t == p) Console.WriteLine(Colour.NAME + lg[0].Name + Colour.RESET + " has joined your team\n");
            t.GoalieRoster[NextNull(t.GoalieRoster)] = lg[0];
            t.Goalie++;
            lg.Remove(lg[0]);
        }
        if(t == p) Draft.ComputerDraft();
    }

    static int NextNull(Player[] r)
    {
        for (int i = 0; i < r.Length; i++)
        {
            if (r[i] == null) return i;
        }
        return 0;
    }
}