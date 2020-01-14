using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Time
{
    static int day = 1;
    static int week = 1;
    static int month = 1;
    static int year = 2020;

    static string[] days = new string[] { "none", "Monday", "Wednesday", "Friday", "The weekend" };
    static string[] weeks = new string[] { "none", "first", "second", "third", "fourth" };
    static string[] months = new string[] { "none", "September", "October", "January", "February" };

    public static void PassTime(int amount)
    {
        day+=amount;
        int addweek = 0;
        int addmonth = 0;
        int addyear = 0;
        while (day > 4)
        {
            day -= 4;
            addweek++;
        }
        week += addweek;
        while (week > 4)
        {
            week -= 4;
            addmonth++;
        }
        month += addmonth;
        while (month > 4)
        {
            month -= 4;
            addyear++;
        }
        year += addyear;
        Check.Event(null);
    }

    internal static void Display()
    {
        Write.EmbedColourText(Colour.PASS, Colour.PASS, Colour.PASS, Colour.PASS, "It is ", $"{Time.days[Time.day]}", ", the ", $"{Time.weeks[Time.week]}", " week of ", $"{Time.months[Time.month]}", ", ", $"{Time.year}", "\n\n");
    }

    static public int Day { get { return day; } set { day = value; } }
    static public int Week { get { return week; } set { week = value; } }
    static public int Month { get { return month; } set { month = value; } }
    static public int Year { get { return year; } set { year = value; } }
    static public String[] Days { get { return days; } set { days = value; } }
    static public String[] Weeks { get { return weeks; } set { weeks = value; } }
    static public String[] Months { get { return months; } set { months = value; } }
}