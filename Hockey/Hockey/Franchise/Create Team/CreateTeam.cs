using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class CreateTeam
{    
    internal static void Start()
    {
        for (int i = 0; i < Team.list.Count; i++)
        {
            Standings.list.Add(Team.list[i]);
        }
        GMName();
        string location = Location();
        string name = TeamName(location);
        Team.list[0].Name = (location == "" && name == "")?"The Edmonton Puppins":$"The {location} {name}";
    }

    private static void GMName()
    {
        Console.Clear();
        Console.WriteLine("The clerk looks up at you\n");
        Console.WriteLine(Colour.SPEAK + "'Greetings! To register a team I will first need your name'\n" + Colour.NAME);
        string gmName = Console.ReadLine();
        Team.list[0].GMName = gmName;
        Console.WriteLine(Colour.RESET + $"\n'" + Colour.NAME + $"{gmName}" + Colour.SPEAK + "? Did I get that right?'");
        if (Utilities.Confirm() == false) { GMName(); }        
    }

    private static string Location()
    {
        Console.Clear();
        Console.WriteLine(Colour.SPEAK + "'Alright sir, at what location would you like to register your team?'\n" + Colour.TEAM);
        string location = Console.ReadLine();
        Console.WriteLine(Colour.RESET + $"\n'" + Colour.TEAM + $"{location}" + Colour.SPEAK + "? That's where your team will be located?");
        if (Utilities.Confirm() == false) { Location(); }
        return location;
    }

    private static string TeamName(string location)
    {
        Console.Clear();
        Console.WriteLine(Colour.SPEAK + "'Wonderful. And what would you like your team name to be?'\n" + Colour.TEAM);
        string name = Console.ReadLine();
        Console.WriteLine(Colour.RESET + $"\n'" + Colour.SPEAK + "Ok, so you are "+ Colour.NAME + $"{Team.list[0].GMName}" + Colour.SPEAK + ", the general manager of the " + Colour.TEAM + $"{location} {name}" + Colour.SPEAK + "?'");
        if (Utilities.Confirm() == false) { Start(); }
        return name;
    } 
}