using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Check
{
    internal static Game Game()
    {
        foreach (Day d in Schedule.days)
        {
            if (d.TheDay == Time.Day && d.TheWeek == Time.Week && d.TheMonth == Time.Month)
                return d.TheGame;
        }
        return null;
    }

    internal static bool GameToday()
    {
        return (Game() != null);
    }

    internal static bool MyGame(Game game)
    {
        return (game.A == Team.list[0] || game.B == Team.list[0]);
    }    

    internal static bool Weekend() { return (Time.Day == 4); }

    internal static void Event(Game game)
    {
        if (Time.Day == 4 && Time.Week == 3 && Time.Month == 3)
        {
            Season.season = false;
        }
        else if (Weekend()) Console.WriteLine("It is the weekend. This is a perfect time to practice\nAnd to have some fun.");
        else if (game != null)
        {
            Console.WriteLine("Game Today");
            Console.SetCursorPosition(0, 5);
            Console.WriteLine(Colour.TEAM + game.A.Name + Colour.RESET + " vs " + Colour.TEAM + game.B.Name + Colour.RESET);
            if (game.Played)
            {
                Console.SetCursorPosition(8, 7);
                Console.WriteLine(Colour.GOAL + game.AScore + Colour.RESET);
                Console.SetCursorPosition(33, 7);
                Console.WriteLine(Colour.GOAL + game.BScore + Colour.RESET);
            }            
            else
            {
                Console.SetCursorPosition(0 , 10);
                if (Check.MyGame(game)) Console.WriteLine("Your team plays today. Make sure to warm up. Maybe consider getting your team a little edge.");
                else Console.WriteLine("Your team doesn't play today, but it's still worth your while to pay attention.\nYou can use this chance to scout other players and maybe tip the balances in someone's favor.");
            }                     
        }
    }
}