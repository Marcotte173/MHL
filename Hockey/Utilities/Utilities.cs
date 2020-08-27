using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Utilities
{
    static Random rand = new Random();
    internal static double difficulty = 1;
    internal static void KeyPress()
    {
        Write.Line(0,28,"Press any key to continue");
        Console.ReadKey(true);
    }    

    internal static void SortOverall(List<Player> list)
    {
        Player temp;
        for (int j = 0; j <= list.Count - 2; j++)
        {
            for (int i = 0; i <= list.Count - 2; i++)
            {
                if (list[i].Overall < list[i + 1].Overall)
                {
                    temp = list[i + 1];
                    list[i + 1] = list[i];
                    list[i] = temp;
                }
            }
        }
    }

    internal static void SortPrice(List<Player> list)
    {
        Player temp;
        for (int j = 0; j <= list.Count - 2; j++)
        {
            for (int i = 0; i <= list.Count - 2; i++)
            {
                if (list[i].Price < list[i + 1].Price)
                {
                    temp = list[i + 1];
                    list[i + 1] = list[i];
                    list[i] = temp;
                }
            }
        }
    }

    internal static void SortPoints(List<Team> list)
    {
        Team temp;
        for (int j = 0; j <= list.Count - 2; j++)
        {
            for (int i = 0; i <= list.Count - 2; i++)
            {
                if ((list[i].Win*2 + list[i].OTLoss) < (list[i+1].Win * 2 + list[i+1].OTLoss))
                {
                    temp = list[i + 1];
                    list[i + 1] = list[i];
                    list[i] = temp;
                }
            }
        }
    }

    internal static void SortPoints(List<Player> list)
    {
        Player temp = null;
        for (int j = 0; j <= list.Count - 2; j++)
        {
            for (int i = 0; i <= list.Count - 2; i++)
            {
                if ((list[i].PointStat) < (list[i + 1].PointStat))
                {
                    temp = list[i + 1];
                    list[i + 1] = list[i];
                    list[i] = temp;
                }
            }
        }
    }

    internal static bool Confirm()
    {
        Console.WriteLine(Colour.RESET + "\n[1]Yes\n[2]No");
        string confirm = Console.ReadKey(true).KeyChar.ToString().ToLower();
        return (confirm == "1") ? true : false;
    }

    internal static bool CheckMoney(double price, Team t)
    {
        return (t.Money > price);
    }

    internal static string Choice()
    {
        return Console.ReadKey(true).KeyChar.ToString().ToLower();
    }

    internal static int RandomInt(int min, int max)
    {
        return rand.Next(min, max);
    }

    internal static int Integer()
    {
        int sellChoice;
        while (!int.TryParse(Console.ReadLine(), out sellChoice))
        {
           
        };
        return sellChoice;
    }
}