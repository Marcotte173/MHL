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

    internal int[] Decision(Rink location)
    {
        Player o = Game.carrier; 
        int[] x = new int[2];
        int y = Utilities.RandomInt(0, 12);
        if (location == Game.la)
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
        if (location == Game.ha)
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
        if (location == Game.na)
        {
            int choice = Utilities.RandomInt(1, 8);
            //carry
            if (choice == 1 || choice == 2) x = new int[] { 5, (o.Speed * 3 + o.Handling * 2) / 5 + y };
            //pass
            else if (choice == 3 || choice == 4 ) x = new int[] { 4, o.Passing + y };
            //slapshot
            else x = new int[] { 4, o.Passing + y };
        }
        if (location == Game.nd)
        {
            int choice = Utilities.RandomInt(1, 6);
            //carry
            if (choice == 1 || choice == 2) x = new int[] { 5, (o.Speed * 3 + o.Handling * 2) / 5 + y };
            //pass
            else x = new int[] { 4, o.Passing + y };
        }
        if (location == Game.hd)
        {
            int choice = Utilities.RandomInt(1, 6);
            //carry
            if (choice == 1 || choice == 2) x = new int[] { 5, (o.Speed * 3 + o.Handling * 2) / 5 + y };
            //pass
            else x = new int[] { 4, o.Passing + y };
        }
        if (location == Game.ld)
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