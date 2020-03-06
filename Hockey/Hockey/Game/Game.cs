using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Game
{
    internal static int momentum;
    internal static Team offence;
    internal static Team defence;
    internal static bool sideA;
    internal static Rink location;
    internal static Rink low = new Low();
    internal static Rink high = new High();
    internal static Rink neutral = new Neutral();
    internal static Player goalScorer;
    internal static Player assist1;
    internal static Player assist2;
    internal static Player dPlayer;
    internal static AIOffence oAI = new AIOffence();
    internal static AIDefence dAI = new AIDefence();
    internal static Game game = new Game();

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
        ChangeFLines(a, a.Line1);
        ChangeFLines(b, b.Line1);
        ChangeDLines(a, a.DLine1);
        ChangeDLines(b, b.DLine1);
        Faceoff(true);
        while (period < 4)
        {
            while (time < 200)
            {
                if ((a.oAI == oAI && sideA) || (b.oAI == oAI && sideA == false)) Result(oAI.Decision(true, location), dAI.Decision(false, location));
                else Result(oAI.Decision(false, location), dAI.Decision(true, location));
                time++;
            }            
            period++;
        }
        GameRecap();
    }

    private static void Result(int[] a, int[] b)
    {
        Console.Clear();
        low.OneTimer(goalScorer.Team.CurrentFLine, dPlayer.Team.Goalies[0]);
        //if (a[1] >= b[1])
        //{
        //    if (a[0] == 1) location.WristShot(goalScorer, dPlayer.Team.Goalies[0]);
        //    if (a[0] == 2) location.OneTimer(goalScorer.Team.CurrentFLine, dPlayer.Team.Goalies[0]);
        //    if (a[0] == 3) location.Slapshot(goalScorer, dPlayer.Team.Goalies[0]);
        //    if (a[0] == 4) location.Pass(goalScorer.Team.CurrentFLine, dPlayer.Team.Goalies[0]);
        //    if (a[0] == 5) location.Carry(goalScorer);  
        //}
        //else
        //{
        //    if (b[0] == 1) location.BlockShot();
        //    if (b[0] == 2) location.Check();
        //    if (b[0] == 3) location.InterceptPass();
        //    if (b[0] == 4) location.PokeCheck();
        //    if (b[0] == 5) location.Positioning();
        //}
        Console.ReadLine();
    }

    private static void ChangeFLines(Team x, Player[] line)
    {
        x.CurrentFLine = line;
    }

    private static void ChangeDLines(Team x, Player[] line)
    {
        x.CurrentDLine = line;
    }

    internal static void Faceoff(bool center)
    {
        int faceoffRoll = Utilities.RandomInt(1, 101);
        int awin = 50 + game.a.CurrentFLine[1].OffAware - game.b.CurrentFLine[1].OffAware;
        if (faceoffRoll <= awin)
        {
            AHasPuck();
            goalScorer = game.a.CurrentFLine[1];
            dPlayer = game.b.CurrentDLine[1];
            sideA = false;
        }
        else
        {
            BHasPuck();
            sideA = true;
            goalScorer = game.b.CurrentFLine[1];
            dPlayer = game.a.CurrentDLine[1];
        }
        if (center)
        {
            location = neutral;
        } 
            
    }

    internal static void Warmup()
    {
        
    }

    public static void AHasPuck()
    {
        offence = game.a;
        defence = game.b;
        oAI = game.a.oAI;
        dAI = game.b.dAI;         
    }

    public static void BHasPuck()
    {
        offence = game.b;
        defence = game.a;
        oAI = game.b.oAI;
        dAI = game.a.dAI;        
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
    internal static void PuckChange()
    {
        offence = (offence == game.a) ? game.b : game.a;
        defence = (defence == game.a) ? game.b : game.a;
        oAI = (oAI == game.a.oAI) ? game.b.oAI : game.a.oAI;
        dAI = (dAI == game.a.dAI) ? game.b.dAI : game.a.dAI;
        goalScorer = (goalScorer == game.a.CurrentFLine[1])? game.b.CurrentFLine[1]: game.a.CurrentFLine[1];
        dPlayer = (dPlayer == game.a.CurrentDLine[1]) ? game.b.CurrentDLine[1] : game.a.CurrentDLine[1];
    }
}