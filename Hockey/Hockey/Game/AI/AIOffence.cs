using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class AIOffence:AI
{    
    public AIOffence()
    : base()
    {
        line = new Player[3];
    }

    internal int[] Decision(Rink location, Team t)
    {
        Player o = Game.goalScorer; 
        int[] x = new int[2];
        int y = Utilities.RandomInt(0, 12);        
        if (location == Game.low && t.attack)
        {
            int choice = Utilities.RandomInt(1, 8);
            //carry
            if (choice == 1 || choice == 2) x = new int[] { 5, (o.Speed * 3 + o.Handling * 2) / 5 + y};
            //wristshot
            if (choice == 3 || choice == 4) x = new int[] { 1, o.Shooting  + y};
            //onetimer
            if (choice == 5 ) x = new int[] { 2, (o.Passing + o.OffAware*2) / 3 + y };
            //pass
            else x = new int[] { 4, o.Passing + y };
        }
        if (location == Game.high && t.attack)
        {
            if (o.Position == "Forward")
            {
                int choice = Utilities.RandomInt(1, 6);
                //carry
                if (choice == 1 || choice == 2) x = new int[] { 5, (o.Speed*3 + o.Handling*2)/5 + y };
                //pass
                else x = new int[] { 4, o.Passing + y };
            }
            if (o.Position == "Defence")
            {
                int choice = Utilities.RandomInt(1, 6);
                //wristshot
                if (choice == 1 || choice == 2) x = new int[] { 3, o.Shooting + y };
                //slapshot
                else x = new int[] { 4, o.Passing + y };
            }
        }
        if (location == Game.neutral && t.attack)
        {
            int choice = Utilities.RandomInt(1, 8);
            //carry
            if (choice == 1 || choice == 2) x = new int[] { 5, (o.Speed * 3 + o.Handling * 2) / 5 + y };
            //pass
            else if (choice == 3 || choice == 4 ) x = new int[] { 4, o.Passing + y };
            //slapshot
            else x = new int[] { 4, o.Passing + y };
        }
        if (location == Game.neutral && t.attack == false)
        {
            int choice = Utilities.RandomInt(1, 6);
            //carry
            if (choice == 1 || choice == 2) x = new int[] { 5, (o.Speed * 3 + o.Handling * 2) / 5 + y };
            //pass
            else x = new int[] { 4, o.Passing + y };
        }
        if (location == Game.high && t.attack == false)
        {
            int choice = Utilities.RandomInt(1, 6);
            //carry
            if (choice == 1 || choice == 2) x = new int[] { 5, (o.Speed * 3 + o.Handling * 2) / 5 + y };
            //pass
            else x = new int[] { 4, o.Passing + y };
        }
        if (location == Game.low && t.attack == false)
        {
            int choice = Utilities.RandomInt(1, 6);
            //carry
            if (choice == 1 || choice == 2) x = new int[] { 5, (o.Speed * 3 + o.Handling * 2) / 5 + y };
            //pass
            else x = new int[] { 4, o.Passing + y };
        }
        return x;
    }
}