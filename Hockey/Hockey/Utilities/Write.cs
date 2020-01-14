using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Write
{
    public static void DotDotDot()
    {
        Thread.Sleep(300);
        Console.Write(".");
        Thread.Sleep(300);
        Console.Write(".");
        Thread.Sleep(300);
        Console.Write(".\n");
        Thread.Sleep(300);
    }

    //Dot dot dot same line
    public static void DotDotDotSL()
    {
        Thread.Sleep(300);
        Console.Write(".");
        Thread.Sleep(300);
        Console.Write(".");
        Thread.Sleep(300);
        Console.Write(".");
        Thread.Sleep(300);
    }
    public static void Menu(string text)
    {
        Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2) + 20) + "}", text));
    }

    public static void CenterText(string text)
    {
        Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
    }

    public static void CenterText(string text, string text2)
    {
        Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 3) + (text.Length / 2)) + "}{1," + ((Console.WindowWidth / 3) + (text2.Length / 2) - (text.Length / 2)) + "}", text, text2));
    }

    public static void CenterText(string text, string text2, string text3)
    {
        Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 4) + (text.Length / 2)) + "}{1," + ((Console.WindowWidth / 4) + (text2.Length / 2) - (text.Length / 2)) + "}" +
            "{2," + ((Console.WindowWidth / 4) + (text3.Length / 2) - (text2.Length / 2)) + "}", text, text2, text3));
    }
    public static void CenterColourText(string colour, string text, string text2, string text3)
    {
        Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + ((text.Length + text2.Length + text3.Length) / 2) + ((colour.Length + Colour.RESET.Length))) + "}", $"{text}{colour}{text2}{Colour.RESET}{text3}"));
    }

    public static void CenterColourText(string colour, string colour2, string text, string text2, string text3, string text4, string text5)
    {
        Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + ((text.Length + text2.Length + text3.Length + text4.Length + text5.Length) / 2) + ((colour.Length + colour2.Length + Colour.RESET.Length * 2))) + "}", text + colour + text2 + Colour.RESET + text3 + colour2 + text4 + Colour.RESET + text5));
    }

    public static void CenterColourText(string colour, string colour2, string colour3, string text, string text2, string text3, string text4, string text5, string text6, string text7)
    {
        Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + ((text.Length + text2.Length + text3.Length + text4.Length + text5.Length + text6.Length + text7.Length) / 2) + ((colour.Length + colour2.Length + colour3.Length + Colour.RESET.Length * 3))) + "}", text + colour + text2 + Colour.RESET + text3 + colour2 + text4 + Colour.RESET + text5 + colour3 + text6 + Colour.RESET + text7));
    }

    public static void CenterColourText(string colour, string colour2, string colour3, string colour4, string text, string text2, string text3, string text4, string text5, string text6, string text7, string text8, string text9)
    {
        Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + ((text.Length + text2.Length + text3.Length + text4.Length + text5.Length + text6.Length + text7.Length + text8.Length + text9.Length) / 2) + ((colour.Length + colour2.Length + colour3.Length + colour4.Length + Colour.RESET.Length * 4))) + "}", text + colour + text2 + Colour.RESET + text3 + colour2 + text4 + Colour.RESET + text5 + colour3 + text6 + Colour.RESET + text7 + colour4 + text8 + Colour.RESET + text9));
    }
    public static void EmbedColourText(string colour, string text1, string text2, string text3)
    {
        Console.Write(
            $"{text1}"
            + colour + $"{text2}"
            + Colour.RESET + $"{text3}\n");
    }

    public static void EmbedColourText(string colour, string colour2, string text1, string text2, string text3, string text4, string text5)
    {
        Console.Write(
            $"{text1}"
            + colour
            + $"{text2}"
            + Colour.RESET + $"{text3}"
            + colour2 + $"{text4}"
            + Colour.RESET + $"{text5}\n");
    }

    public static void EmbedColourText(string colour, string colour2, string colour3, string text1, string text2, string text3, string text4, string text5, string text6, string text7)
    {
        Console.Write(
            $"{text1}"
            + colour + $"{text2}"
            + Colour.RESET + $"{text3}"
            + colour2 + $"{text4}"
            + Colour.RESET + $"{text5}"
            + colour3 + $"{text6}"
            + Colour.RESET
            + $"{text7}\n");
    }

    public static void EmbedColourText(string colour1, string colour2, string colour3, string colour4, string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8, string text9)
    {
        Console.Write(
            $"{text1}"
            + colour1
            + $"{text2}"
            + Colour.RESET
            + $"{text3}"
            + colour2
            + $"{text4}"
            + Colour.RESET
            + $"{text5}"
            + colour3
            + $"{text6}"
            + Colour.RESET
            + $"{text7}"
            + colour4
            + $"{text8}"
            + Colour.RESET
            + $"{text9}\n");
    }

    public static void EmbedColourText(string colour1, string colour2, string colour3, string colour4, string colour5, string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8, string text9, string text10, string text11)
    {
        Console.Write(
             $"{text1}"
             + colour1
             + $"{text2}"
             + Colour.RESET
             + $"{text3}"
             + colour2
             + $"{text4}"
             + Colour.RESET
             + $"{text5}"
             + colour3
             + $"{text6}"
             + Colour.RESET
             + $"{text7}"
             + colour4
             + $"{text8}"
             + Colour.RESET
             + $"{text9}"
             + colour5
             + $"{text10}"
             + Colour.RESET
             + $"{text11}\n");
    }

    public static void CombatText(string colour, string colour2, string colour3, string text, string text2, string text3)
    {
        Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 4) + (text.Length / 2) + (colour.Length)) + "}{1," + ((Console.WindowWidth / 4) + (text2.Length / 2) - (text.Length / 2) + (colour2.Length)) + "}" +
            "{2," + ((Console.WindowWidth / 4) + (text3.Length / 2) - (text2.Length / 2) + (colour3.Length)) + "}", colour + text, colour2 + text2, colour3 + text3 + Colour.RESET));
    }
}