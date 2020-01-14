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
        Console.Clear();
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
        game.winner = (game.aScore > game.bScore) ? game.a : (game.aScore > game.bScore) ? game.b : (Utilities.RandomInt(0, 2) == 0) ? game.a : game.b;
        if (game.winner == game.a) game.a.Win++;
        else if (game.winner == game.b) game.b.Win++;
        if (game.aScore == game.bScore && game.winner == game.a)
        {
            game.b.OTLoss++;
            game.otLoser = game.b;
            game.aScore++;
        }
        else if (game.aScore == game.bScore && game.winner == game.b)
        {
            game.a.OTLoss++;
            game.otLoser = game.a;
            game.bScore++;
        }
        if (game.winner != game.a && game.otLoser != game.a)
        {
            game.a.Loss++;
            game.loser = game.a;
        }

        if (game.winner != game.b && game.otLoser != game.b)
        {
            game.b.Loss++;
            game.loser = game.b;
        }
        Console.WriteLine(string.Format("{0,-30}{1,-10}", game.a.Name, game.b.Name));
        Console.WriteLine(string.Format("{0,-30}{1,-10}", game.aScore, game.bScore));
        game.played = true;
        foreach (Player p in game.a.Roster) if (p != null) p.GamesPlayed++;
        foreach (Player p in game.b.Roster) if (p != null) p.GamesPlayed++;
        Console.WriteLine("");
        Utilities.KeyPress();
    }

    internal static void Warmup()
    {
        
    }
}