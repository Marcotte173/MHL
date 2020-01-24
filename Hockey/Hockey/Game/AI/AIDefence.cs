using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AIDefence : AI
{
    public AIDefence()
    : base()
    {
        line = new Player[2];
    }

    internal int[] Decision(Rink location, Team t)
    {
        int[] x = new int[2];
        Game.dPlayer = Game.defence.CurrentDLine[0];
        foreach(Player p in Game.defence.CurrentDLine) 
        {
            if (p != null)
                if (p.DefAware > Game.dPlayer.DefAware) Game.dPlayer = p;
        }
        foreach (Player p in Game.defence.CurrentFLine)
        {
            if (p != null)
                if (p.DefAware > Game.dPlayer.DefAware) Game.dPlayer = p;
        }
        Player d = Game.dPlayer;
        if (location == Game.low && t.attack)
        {
            int choice = Utilities.RandomInt(1, 8);
            //PokeCheck
            if (choice == 1 || choice == 2) x = new int[] { 4, d.DefAware };
            //Check
            if (choice == 3 || choice == 4) x = new int[] { 2, (d.DefAware + d.Checking)/2 };
            //InterceptPass
            if (choice == 5) x = new int[] { 3, d.DefAware };
            //Positioning
            else x = new int[] { 5, d.DefAware }; 
        }
        if (location == Game.high && t.attack)
        {
            int choice = Utilities.RandomInt(1, 8);
            //PokeCheck
            if (choice == 1 || choice == 2) x = new int[] { 4, d.DefAware };
            //Check
            if (choice == 3 || choice == 4) x = new int[] { 2, (d.DefAware + d.Checking) / 2 };
            //InterceptPass
            if (choice == 5) x = new int[] { 3, d.DefAware };
            //Positioning
            else x = new int[] { 5, d.DefAware };
        }
        if (location == Game.neutral && t.attack)
        {
            int choice = Utilities.RandomInt(1, 9);
            //PokeCheck
            if (choice == 1 || choice == 2) x = new int[] { 4, d.DefAware };
            //Check
            if (choice == 3 || choice == 4 || choice == 5) x = new int[] { 2, (d.DefAware + d.Checking) / 2 };
            //InterceptPass
            if (choice == 6) x = new int[] { 3, d.DefAware };
            //Positioning
            else x = new int[] { 5, d.DefAware };
        }
        if (location == Game.neutral && t.attack == false)
        {
            int choice = Utilities.RandomInt(1, 9);
            //PokeCheck
            if (choice == 1 || choice == 2) x = new int[] { 4, d.DefAware };
            //Check
            if (choice == 3 || choice == 4 || choice == 5) x = new int[] { 2, (d.DefAware + d.Checking) / 2 };
            //InterceptPass
            if (choice == 6) x = new int[] { 3, d.DefAware };
            //Positioning
            else x = new int[] { 5, d.DefAware };
        }
        if (location == Game.high && t.attack == false)
        {
            int choice = Utilities.RandomInt(1, 10);
            //PokeCheck
            if (choice == 1 || choice == 2) x = new int[] { 4, d.DefAware };
            //Check
            if (choice == 3 ) x = new int[] { 2, (d.DefAware + d.Checking) / 2 };
            //InterceptPass
            if (choice == 4 || choice == 5) x = new int[] { 3, d.DefAware };
            //Block Shot
            if (choice == 6 || choice == 7) x = new int[] { 1, d.DefAware };
            //Positioning
            else x = new int[] { 5, d.DefAware };
        }
        if (location == Game.low && t.attack == false)
        {
            int choice = Utilities.RandomInt(1, 10);
            //PokeCheck
            if (choice == 1 ) x = new int[] { 4, d.DefAware };
            //Check
            if (choice == 2) x = new int[] { 2, (d.DefAware + d.Checking) / 2 };
            //InterceptPass
            if (choice == 3 || choice == 4) x = new int[] { 3, d.DefAware };
            //Block Shot
            if (choice == 5 || choice == 6 || choice == 7) x = new int[] { 1, d.DefAware };
            //Positioning
            else x = new int[] { 5, d.DefAware };
        }
        return x;
    }
}