using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Standings
{
    public static List<Team> list = new List<Team> { };
    internal static void Display()
    {
        Utilities.SortPoints(list);
        Team a = list[0];
        Team b = list[1];
        Team c = list[2];
        Team d = list[3];
        Team e = list[4];
        Team f = list[5];        
        Console.Clear();
        Console.WriteLine(string.Format("{0,-15}{1,-15}{2,-10}{3,-10}{4,-10}{5,-10}","", "Team", "Win", "Loss", "OT Loss", "Points\n"));
        Console.WriteLine(string.Format("{0,-51}{1,-10}{2,-12}{3,-10}{4,-10}", Colour.TEAM + a.Name + Colour.RESET, a.Win, a.Loss, a.OTLoss, a.Win * 2 + a.OTLoss));
        Console.WriteLine(string.Format("{0,-51}{1,-10}{2,-12}{3,-10}{4,-10}", Colour.TEAM + b.Name + Colour.RESET, b.Win, b.Loss, b.OTLoss, b.Win * 2 + b.OTLoss));
        Console.WriteLine(string.Format("{0,-51}{1,-10}{2,-12}{3,-10}{4,-10}", Colour.TEAM + c.Name + Colour.RESET, c.Win, c.Loss, c.OTLoss, c.Win * 2 + c.OTLoss));
        Console.WriteLine(string.Format("{0,-51}{1,-10}{2,-12}{3,-10}{4,-10}", Colour.TEAM + d.Name + Colour.RESET, d.Win, d.Loss, d.OTLoss, d.Win * 2 + d.OTLoss));
        Console.WriteLine(string.Format("{0,-51}{1,-10}{2,-12}{3,-10}{4,-10}", Colour.TEAM + e.Name + Colour.RESET, e.Win, e.Loss, e.OTLoss, e.Win * 2 + e.OTLoss));
        Console.WriteLine(string.Format("{0,-51}{1,-10}{2,-12}{3,-10}{4,-10}", Colour.TEAM + f.Name + Colour.RESET, f.Win, f.Loss, f.OTLoss, f.Win * 2 + f.OTLoss));
        Console.WriteLine("");
        Utilities.KeyPress();
    }
}