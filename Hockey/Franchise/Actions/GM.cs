using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GM
{
    static Team t = Team.list[0];
    internal static void Menu()
    {
        Console.Clear();
        Write.CenterColourText(Colour.NAME, Colour.TEAM, "", t.GMName, " of the ", t.Name, "");
        Console.WriteLine("\n\n\n[1]Rosters\n[2]Trade players\n[3]Free agents\n\n\n[0]Return");
        string choice = Utilities.Choice();
        if (choice == "1") Roster.Menu();
        if (choice == "2") 
        {
            int y;
            Console.Clear();
            Write.CenterColourText(Colour.NAME, Colour.TEAM, "", t.GMName, " of the ", t.Name, "");
            Console.WriteLine("\n\n\nWho are you interested in trading with?\n");
            for (int i = 1; i < Team.list.Count; i++)
            {
                Console.WriteLine($"[{i}] {Team.list[i].Name}");
            }
            Console.WriteLine("[0] Return");
            while (!int.TryParse(Console.ReadLine(), out y))
            {
                Console.Clear();
                Write.CenterColourText(Colour.NAME, Colour.TEAM, "", t.GMName, " of the ", t.Name, "");
                Console.WriteLine("\n\n\nWho are you interested in trading with?\n");
                for (int i = 1; i < Team.list.Count; i++)
                {
                    Console.WriteLine($"[{i}] {Team.list[i].Name}");
                }
                Console.WriteLine("[0] Return");
            };
            if (y != 0)
            {
                if (y >0 && y<6) Trade(Team.list[y]);
            }            
        }
            
        if (choice == "3") FreeAgents();
        else if (choice != "0") Menu();
    }

    public static void FreeAgents()
    {
        
    }

    public static void Trade(Team t)
    {
        Console.Clear();
         
    }
}