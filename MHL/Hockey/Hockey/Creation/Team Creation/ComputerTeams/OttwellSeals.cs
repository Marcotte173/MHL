using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OttwellSeals:Team
{
    public OttwellSeals()
    : base()
    {
        name = "The Ottwell Seals";
        gmName = "Kyle Zigglesworth";
        money = (1400000) * Utilities.difficulty;
        fans = (100) * Utilities.difficulty;
        reputation = (105) * Utilities.difficulty;
    }
    public override void Draft(List<Player> f, List<Player> d, List<Player> g)
    {
        if (Money >= f[f.Count - 1].Price && Money >= d[d.Count - 1].Price && Money >= g[g.Count - 1].Price)
        {
            if (forward < 2) { foreach (Player p in f) { if (Money > p.Price) { Aquire.Hire(p, Team.list[3]); break; } } }
            else if (defence < 2) { foreach (Player p in d) { if (Money > p.Price) { Aquire.Hire(p, Team.list[3]); break; } } }
            else if (goalie < 1) { foreach (Player p in g) { if (Money > p.Price) { Aquire.Hire(p, Team.list[3]); break; } } }
            else if (forward < 10) { foreach (Player p in f) { if (Money > p.Price) { Aquire.Hire(p, Team.list[3]); break; } } }
            else if (defence < 5) { foreach (Player p in d) { if (Money > p.Price) { Aquire.Hire(p, Team.list[3]); break; } } }
            else if (goalie < 2) { foreach (Player p in g) { if (Money > p.Price) { Aquire.Hire(p, Team.list[3]); break; } } }
        }       
        else Aquire.Loaner(Team.list[3]);
    }
}