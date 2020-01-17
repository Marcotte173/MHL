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
        if(location == Game.la)
        {
            
        }
        if (location == Game.ha)
        {
            if (o.Position == "Forward")
            {

            }
            if (o.Position == "Defence")
            {
                int choice = Utilities.RandomInt(0, 5);
                if (choice == 1 || choice == 2) x = new int[] { 3, o.Shooting };
                else x = new int[] { 4, o.Passing };
            }
        }
        if (location == Game.na)
        {

        }
        if (location == Game.nd)
        {

        }
        if (location == Game.hd)
        {

        }
        if (location == Game.ld)
        {

        }
        return x;
    }
}