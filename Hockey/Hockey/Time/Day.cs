using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Day
{
    int day;
    int week;
    int month;
    Game game;

    public Day(int day, int week, int month, Game game)
    {
        this.day = day;
        this.week = week;
        this.month = month;
        this.game = game;
    }

    public int TheDay { get { return day; } set { day = value; } }
    public int TheWeek { get { return week; } set { week = value; } }
    public int TheMonth { get { return month; } set { month = value; } }
    public Game TheGame { get { return game; } set { game = value; } }
}