using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Game
{
    Team teamA;
    Team teamB;
    Team winner;
    Team loser;
    Team otLoser;
    bool played;
    int aScore;
    int bScore;
    int aShots;
    int bShots;    

    public Game() { }
    public Game(Team a, Team b)
    {
        teamA = a;
        teamB = b;
        played = false;
        aScore = 0;
        bScore = 0;
        aShots = 0;
        bShots = 0;
    }

    public Team A { get { return teamA; } set { teamA = value; } }
    public Team B { get { return teamB; } set { teamB = value; } }
    public Team Winner { get { return winner; } set { winner = value; } }
    public Team Loser { get { return loser; } set { loser = value; } }
    public Team OTLoser { get { return otLoser; } set { otLoser = value; } }
    
    public int AScore { get { return aScore; } set { aScore = value; } }
    public int BScore { get { return bScore; } set { bScore = value; } }
    public int AShots { get { return aShots; } set { aShots = value; } }
    public int BShots { get { return bShots; } set { bShots = value; } }
    public bool Played { get { return played; } set { played = value; } }
}