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

    internal int[] Decision(bool opponentZone, Rink location)
    {
        Player o = Game.goalScorer; 
        int[] x = new int[2];      
        if (location == Game.low && opponentZone)
        {
            int choice = Utilities.RandomInt(1, 8);
            //wristshot
            if (choice == 1 || choice == 2)             x = new int[] { 1, o.Shooting };
            //onetimer                                 
            if (choice == 3)                            x = new int[] { 3, (o.Passing + o.OffAware * 2) / 3 };
            //carry                                    
            if (choice == 4 || choice == 5)             x = new int[] { 4, (o.Speed * 3 + o.Handling * 2) / 5 };
            //pass
            else                                        x = new int[] { 5, o.Passing };

        }
        if (location == Game.high && opponentZone)
        {
            if (o.Position == "Forward")
            {
                int choice = Utilities.RandomInt(1, 6);
                //carry
                if (choice == 1 || choice == 2)         x = new int[] { 4, (o.Speed*3 + o.Handling*2)/5 };
                //pass
                else                                    x = new int[] { 5, o.Passing };
            }
            if (o.Position == "Defence")
            {
                int choice = Utilities.RandomInt(1, 6);
                //wristshot
                if (choice == 1 || choice == 2)         x = new int[] { 1, o.Shooting };
                //slapshot
                else  if (choice == 3 || choice ==4)    x = new int[] { 2, o.Shooting };
                //pass
                else                                    x = new int[] { 5, o.Passing };
            }
        }
        else
        {
            int choice = Utilities.RandomInt(1, 6);
            //carry
            if (choice == 1 || choice == 2)             x = new int[] { 4, (o.Speed * 3 + o.Handling * 2) / 5  };
            //pass 
            else                                        x = new int[] { 5, o.Passing };
        }
        return x;
    }
}