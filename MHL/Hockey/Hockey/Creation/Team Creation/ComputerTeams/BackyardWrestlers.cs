using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BackyardWrestlers : Team
{
    public BackyardWrestlers()
    : base()
    {
        name = "The Backyard Wrestlers";
        gmName = "Brad Oats";
        money = (1400000) * Utilities.difficulty;
        fans = (135) * Utilities.difficulty;
        reputation = (120) * Utilities.difficulty;
    }
    public override void Draft(List<Player> f, List<Player> d, List<Player> g)
    {
        if (Money >= f[f.Count - 1].Price && Money >= d[d.Count - 1].Price && Money >= g[g.Count - 1].Price)
        {
            if (forward < 10)
            {
                foreach (Player p in f)
                {
                    if (Money > p.Price)
                    {
                        Aquire.Hire(p, Team.list[2]);
                        break;
                    }
                }
            }
            else if (defence < 5)
            {
                foreach (Player p in d)
                {
                    if (Money > p.Price)
                    {
                        Aquire.Hire(p, Team.list[2]);
                        break;
                    }
                }
            }
            else if (goalie < 2)
            {
                foreach (Player p in g)
                {
                    if (Money > p.Price)
                    {
                        Aquire.Hire(p, Team.list[2]);
                        break;
                    }
                }
            }
        }
        else Aquire.Loaner(Team.list[2]);
    }
}