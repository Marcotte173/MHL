using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Game
{
    static Team offence;
    static Team defence;
    static Rink location;
    internal static Rink ld = new LowB();
    internal static Rink hd = new HighB();
    internal static Rink nd = new NeutralB();
    internal static Rink la = new LowA();
    internal static Rink ha = new HighA();
    internal static Rink na = new NeutralA();
    internal static Player carrier;
    static Player prev1;
    static Player prev2;
    static Player dPlayer;
    static AIOffence o = new AIOffence();
    static AIDefence d = new AIDefence();
    static Game game = new Game();

    Team a;
    Team b;
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
        this.a = a;
        this.b = b;
        played = false;
        aScore = 0;
        bScore = 0;
        aShots = 0;
        bShots = 0;
    }

    public Team A { get { return a; } set { a = value; } }
    public Team B { get { return b; } set { b = value; } }
    public Team Winner { get { return winner; } set { winner = value; } }
    public Team Loser { get { return loser; } set { loser = value; } }
    public Team OTLoser { get { return otLoser; } set { otLoser = value; } }
    
    public int AScore { get { return aScore; } set { aScore = value; } }
    public int BScore { get { return bScore; } set { bScore = value; } }
    public int AShots { get { return aShots; } set { aShots = value; } }
    public int BShots { get { return bShots; } set { bShots = value; } }
    public bool Played { get { return played; } set { played = value; } }

    internal static void Play(Game thisGame)
    {
        game = thisGame;
        Team a = game.a;
        Team b = game.b;
        int period = 1;
        int time = 0;
        ChangeLines(a, a.Line1);
        ChangeLines(b, a.Line1);
        Faceoff(true);
        while (period < 4)
        {
            while (time < 200)
            {
                Result(o.Decision(location), d.Decision(location));
                time++;
            }            
            period++;
        }
        GameRecap();
    }

    private static void Result(int[] o, int[] d)
    {
        if(o[1] >= d[1])
        {
            if (o[0] == 1) location.WristShot();
            if (o[0] == 2) location.OneTimer();
            if (o[0] == 3) location.Slapshot();
            if (o[0] == 4) location.Pass();
            if (o[0] == 5) location.Carry();
        }
        else
        {
            if (d[0] == 1) location.BlockShot();
            if (d[0] == 2) location.Check();
            if (d[0] == 3) location.InterceptPass();
            if (d[0] == 4) location.PokeCheck();
            if (d[0] == 5) location.Positioning();
        }
    }

    private static void ChangeLines(Team x, Player[] line)
    {
        x.CurrentFLine = line;
    }

    private static void Faceoff(bool center)
    {
        int faceoffRoll = Utilities.RandomInt(1, 101);
        int awin = 50 + offence.CurrentFLine[1].OffAware - defence.CurrentFLine[1].OffAware;
        if (faceoffRoll <= awin)
        {
            o = game.a.o;
            d = game.a.d;
            PuckChange(game.a);
            carrier = game.a.CurrentFLine[1];            
        }
        else
        {
            o = game.b.o;
            d = game.b.d;
            PuckChange(game.b);
            dPlayer = game.b.CurrentFLine[1];
            if (location == la) location = ld;
        }
        if (center) location = nd;
    }

    private static void GameRecap()
    {
        Team a = game.a;
        Team b = game.b;
        if (game.aScore == game.bScore)
        {
            int roll = Utilities.RandomInt(0, 2);
            if (roll == 0)
            {
                game.aScore++;
                game.Winner = a;
                game.otLoser = b;
                a.Win++;
                b.OTLoss++;
            }
            else 
            {
                game.bScore++;
                game.Winner = b;
                game.otLoser = a;
                b.Win++;
                a.OTLoss++;
            }
        }
        else
        {
            if (game.aScore > game.bScore)
            {
                game.Winner = a;
                game.loser = b;
                a.Win++;
                b.Loss++;
            }
            else
            {
                game.Winner = b;
                game.loser = a;
                b.Win++;
                a.Loss++;
            }
        }
        game.played = true;
        foreach (Player p in game.a.Roster) if (p != null) p.GamesPlayed++;
        foreach (Player p in game.b.Roster) if (p != null) p.GamesPlayed++;
    }
    static void PuckChange(Team t)
    {
        offence = (game.a == t) ? game.a : game.b;
        defence = (game.a == t) ? game.b : game.a;
    }
}