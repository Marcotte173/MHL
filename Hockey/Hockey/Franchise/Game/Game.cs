using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Game
{
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

    internal static void Play(Game game)
    {
        game.aScore = Utilities.RandomInt(0, 5);
        game.bScore = Utilities.RandomInt(0, 5);
        game.aShots = game.aScore * Utilities.RandomInt(2, 5);
        game.bShots = game.bScore * Utilities.RandomInt(2, 5);
        for (int i = 0; i < game.aScore; i++)
        {
            game.a.Roster[Utilities.RandomInt(0, 12)].GoalStat++;
        }
        for (int i = 0; i < game.bScore; i++)
        {
            game.b.Roster[Utilities.RandomInt(0, 12)].GoalStat++;
        }
        GameRecap(game);
    }

    private static void GameRecap(Game game)
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

    internal static void Warmup()
    {
        
    }
}