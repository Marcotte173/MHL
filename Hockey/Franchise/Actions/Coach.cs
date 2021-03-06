﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Coach
{    
   internal static void Menu()
    {              
        int x;
        Display();
        String("Choose a player", 80, 20);
        String("[0] to return", 80, 21);
        Console.SetCursorPosition(86, 27);
        while (!int.TryParse(Console.ReadLine(), out x))
        {
            Display();
            String("Choose a player", 80, 20);
            String("[0] to return", 80, 21);
            Console.SetCursorPosition(86, 27);
        };
        if (x != 0)
        {
            ExamineOrSwap(x);            
        }        
    }

    public static void ExamineOrSwap(int x)
    {
        Player chosen = null;
        chosen = (x > 0 && x < 21) ? Roster.list[x] : null;
        Display();
        Name(chosen, 80, 20);
        if (chosen != null) String("[2]Examine", 80, 23);
        String("[1]Swap", 80, 22);
        string choice = Utilities.Choice();
        if (chosen != null) if (choice == "2") Examine(x, chosen);
        if (choice == "1") Swap(x, chosen);   
        Menu();
    }

    public static void Swap(int x, Player chosen)
    {
        int y;
        Display();
        Name(chosen, 80, 20);
        String("Please select a player to swap", 80, 22);
        String("[0] to return", 80, 23);
        Console.SetCursorPosition(86, 27);
        while (!int.TryParse(Console.ReadLine(), out y))
        {
            Display();
            Name(chosen, 80, 20);
            String("Please select a player to swap", 80, 22);
            String("[0] to return", 80, 21);
            Console.SetCursorPosition(88, 27);
        };
        if (y != 0)
        {            
            Player swap = (y > 0 && y < 21) ? Roster.list[y] : null;
            Name(swap, 80, 25);
            if (chosen != swap)
            {
                Roster.list[x] = swap;
                Roster.list[y] = chosen;
                NewLines();
            }
            String("Press any key to continue", 80, 27);
            Console.ReadKey();

        }
    }

    internal static void NewLines()
    {
        Team.list[0].Roster[0] = Team.list[0].Line1[0]   = Roster.list[1];
        Team.list[0].Roster[1] = Team.list[0].Line1[1]   = Roster.list[2];
        Team.list[0].Roster[2] = Team.list[0].Line1[2]   = Roster.list[3];
        Team.list[0].Roster[3] = Team.list[0].Line2[0]   = Roster.list[4];
        Team.list[0].Roster[4] = Team.list[0].Line2[1]   = Roster.list[5];
        Team.list[0].Roster[5] = Team.list[0].Line2[2]   = Roster.list[6];
        Team.list[0].Roster[6] = Team.list[0].Line2[0]   = Roster.list[7];
        Team.list[0].Roster[7] = Team.list[0].Line2[1]   = Roster.list[8];
        Team.list[0].Roster[8] = Team.list[0].Line2[2]   = Roster.list[9];
        Team.list[0].Roster[9] = Team.list[0].DLine1[0]  = Roster.list[10];
        Team.list[0].Roster[10] = Team.list[0].DLine1[1] = Roster.list[11];
        Team.list[0].Roster[11] = Team.list[0].DLine2[0] = Roster.list[12];
        Team.list[0].Roster[12] = Team.list[0].DLine2[1] = Roster.list[13];
        Team.list[0].Roster[13] = Team.list[0].Bench[0]  = Roster.list[14];
        Team.list[0].Roster[14] = Team.list[0].Bench[1]  = Roster.list[15];
        Team.list[0].Roster[15] = Team.list[0].Bench[2]  = Roster.list[16];
        Team.list[0].Roster[16] = Team.list[0].Bench[3]  = Roster.list[17];
        Team.list[0].Roster[17] = Team.list[0].Bench[4]  = Roster.list[18];
        Team.list[0].GoalieRoster[0] = Roster.list[19];
        Team.list[0].GoalieRoster[1] = Roster.list[20];

    }

    public static void Examine(int x, Player chosen)
    {
        Display();
        Name(Roster.list[x], 80, 20);
        String("[1]Attributes", 80, 22);
        String("[2]Stats", 80, 23);
        string choice1 = Utilities.Choice();
        if (choice1 == "2") Statistics.Individual(chosen);
        else if (choice1 == "1") Player.ExaminePlayer(chosen);
    }

    internal static void Name( Player p, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        if (p != null) 
        {
            if (p.Position == "Forward") Console.Write(Colour.GOAL + p.Name + Colour.RESET);
            else if (p.Position == "Defence") Console.Write(Colour.FIGHT + p.Name + Colour.RESET);
            else Console.Write(Colour.PRICE + p.Name + Colour.RESET);
            Console.SetCursorPosition(x + 25, y);
            Console.Write(Colour.SECONDARY + p.Overall + Colour.RESET);
        }
        else Console.Write($"None");
    }

    internal static void Name(int num, Player p, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write($"[{num}] ");
        if (p != null)
        {
            if (p.Position == "Forward") Console.Write(Colour.GOAL + p.Name + Colour.RESET);
            else if (p.Position == "Defence") Console.Write(Colour.FIGHT + p.Name + Colour.RESET);
            else Console.Write(Colour.PRICE + p.Name + Colour.RESET);
            Console.SetCursorPosition(x + 25, y);
            Console.Write(Colour.SECONDARY + p.Overall + Colour.RESET);
        }
        else Console.Write($"None");
    }

    internal static void String(string s, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(s);
    }

    internal static void String(string s, string c, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(c + s + Colour.RESET);
    }

    internal static void String(string s, int x, int y, bool overall)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(s);
        Console.SetCursorPosition(x + 23, y);
        Console.Write(Colour.OVERALL + "Overall" + Colour.RESET);
    }

    internal static void String(string s, string c, int x, int y, bool overall)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(c + s + Colour.RESET);
        Console.SetCursorPosition(x + 23, y);
        Console.Write(Colour.OVERALL + "Overall" + Colour.RESET);
    }

    public static void Display()
    {
        Console.Clear();
        Write.CenterColourText(Colour.NAME, Colour.TEAM, "", Team.list[0].GMName, " of the ", Team.list[0].Name, "");
        String("Left Wing", Colour.POSITION, 11, 3, true);
        String("Center", Colour.POSITION, 48, 3, true);
        String("Right Wing", Colour.POSITION, 82, 3, true);
        String("Line 1", Colour.SECONDARY, 0, 5);
        Name(1, Roster.list[1], 11, 5);
        Name(2, Roster.list[2], 48, 5);
        Name(3, Roster.list[3], 82, 5);
        String("Line 2", Colour.SECONDARY, 0, 6);
        Name(4, Roster.list[4], 11, 6);
        Name(5, Roster.list[5], 48, 6);
        Name(6, Roster.list[6], 82, 6);
        String("Line 3", Colour.SECONDARY, 0, 7);
        Name(7, Roster.list[7], 11, 7);
        Name(8, Roster.list[8], 48, 7);
        Name(9, Roster.list[9], 82, 7);
        String("Left Defence", Colour.POSITION, 25, 11, true);
        String("Right Defence", Colour.POSITION, 60, 11, true);
        String("First Pair", Colour.SECONDARY, 0, 13);
        Name(10, Roster.list[10], 25, 13);
        Name(11, Roster.list[11], 60, 13);
        String("Second Pair", Colour.SECONDARY, 0, 14);
        Name(12, Roster.list[12], 25, 14);
        Name(13, Roster.list[13], 60, 14);
        String("Goalies", Colour.POSITION,40,20,true);
        Name(19, Roster.list[19], 40, 22);
        Name(20, Roster.list[20], 40, 23);
        String("Bench", Colour.POSITION, 0, 20, true);
        for (int i = 0; i < 5; i++)
        {
            Name(14 + i, Roster.list[14+i], 0, 22 + i); 
        }
    }  
}