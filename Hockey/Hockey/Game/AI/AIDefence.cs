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

    internal int[] Decision(Rink location)
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
        if (location == Game.la)
        {

        }
        if (location == Game.ha)
        {

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