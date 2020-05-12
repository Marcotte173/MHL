using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Credits
{
    internal static void Start()
    {
        Console.Clear();
        Console.WriteLine("Thanks for playing!\nThis is a pretty small game, but I'd like to make it bigger if feedback is good\n\nDesigned and written by Travis Marcotte\n\nPress any key to close this program");
        Console.ReadKey(true);
        Environment.Exit(0);
    }
}