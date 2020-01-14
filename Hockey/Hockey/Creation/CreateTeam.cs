using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class CreateTeam
{
    internal static void Start()
    {
        //Find GM name, Location, Team name
        Names();
        //Draft Players
        Draft();
    }    

    private static void Names()
    {
        Console.Clear();
        Console.WriteLine("The clerk looks up at you\n");
        Console.WriteLine(Colour.SPEAK + "'Greetings! To register a team I will first need your name'\n" + Colour.NAME);
        string gmName = Console.ReadLine();
        Console.WriteLine(Colour.RESET + $"\n'" + Colour.NAME + $"{gmName}" + Colour.SPEAK+"? Did I get that right?'");
        if (Utilities.Confirm() == false) { NamesAgain(); }
        Console.Clear();
        Console.WriteLine(Colour.SPEAK + "'Alright sir, at what location would you like to register your team?'\n" + Colour.TEAM);
        string location = Console.ReadLine();
        Console.WriteLine(Colour.RESET + $"\n'" + Colour.TEAM + $"{location}" + Colour.SPEAK + "? That's where your team will be located?");
        if (Utilities.Confirm() == false) { NamesAgain(); }
        Console.Clear();
        Console.WriteLine(Colour.SPEAK + "'Wonderful. And what would you like your team name to be?'\n" + Colour.TEAM);
        string name = Console.ReadLine();
        Console.WriteLine(Colour.RESET + $"\n'" + Colour.SPEAK + "Ok, so the " + Colour.TEAM + $"{location} {name}" + Colour.SPEAK + "?'");
        if (Utilities.Confirm() == false) { NamesAgain(); }
        CreatePlayers.playerTeam.GMName = gmName;
        CreatePlayers.playerTeam.Name = $"{location} {name}";
    }

    static void NamesAgain()
    {
        Console.WriteLine(Colour.SPEAK + "\n'Ok, let's try this again'\n" + Colour.RESET);
        Utilities.KeyPress();
        Names();
    }

    private static void Draft()
    {
        
    }

    internal static void DisplayPlayers(List<Player> list)
    {
        Console.Clear();
        if (list == CreatePlayers.goalieList) 
        {
            Console.WriteLine(String.Format("{0, -6}{1, -35}{2,-20}{3,-20}{4,-20}{5,-21}{6,-19}{7,-21}{8,-20}{9,-20}", "Num", Colour.NAME + "Name ", Colour.OVERALL + "Overall", Colour.PRICE + "Price", Colour.SHOOT + "Glove", Colour.PASS + "Stick", Colour.SPEED + "Angles", Colour.SECONDARY + "Agility", Colour.SECONDARY + "Butterfly", Colour.POSITION + "Position" + Colour.RESET));
            Console.WriteLine("");
            for (int i = 0; i<list.Count; i++)
            {
                Console.WriteLine(String.Format("{0, -6}{1, -37}{2,-18}{3,-23}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}{9,-19}", $"[{i + 1}] ", Colour.NAME + $"{list[i].Name} ", Colour.OVERALL + $"{list[i].Overall}", Colour.PRICE + $"{list[i].Price}", Colour.SHOOT + $"{list[i].Glove}", Colour.PASS + $"{list[i].Stick}", Colour.SPEED + $"{list[i].Angles}", Colour.SECONDARY + $"{list[i].Agility} ", Colour.SECONDARY + $"{list[i].Butterfly}", Colour.POSITION + $"{list[i].Position}" + Colour.RESET));
            }
        }
        else 
        {
            Console.WriteLine(String.Format("{0, -6}{1, -35}{2,-20}{3,-20}{4,-20}{5,-21}{6,-19}{7,-21}{8,-20}{9,-20}{10,-10}", "Num", Colour.NAME + "Name ", Colour.OVERALL + "Overall", Colour.PRICE + "Price", Colour.SHOOT + "Shooting", Colour.PASS + "Passing", Colour.SPEED + "Speed", Colour.SECONDARY + "Secondary", Colour.SECONDARY + "OAware", Colour.SECONDARY + "DAware", Colour.POSITION + "Position" + Colour.RESET));
            Console.WriteLine("");
            for (int i = 0; i<list.Count; i++)
            {
                Console.WriteLine(String.Format("{0, -6}{1, -37}{2,-18}{3,-23}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}{9,-19}{10,-10}", $"[{i + 1}] ", Colour.NAME + $"{list[i].Name} ", Colour.OVERALL + $"{list[i].Overall}", Colour.PRICE + $"{list[i].Price}", Colour.SHOOT + $"{list[i].Shooting}", Colour.PASS + $"{list[i].Passing}", Colour.SPEED + $"{list[i].Speed}", Colour.SECONDARY + $"{(list[i].Handling + list[i].Checking + list[i].Balance + list[i].Block) / 4} ", Colour.SECONDARY + $"{list[i].OffAware}", Colour.SECONDARY + $"{list[i].DefAware}", Colour.POSITION + $"{list[i].Position}" + Colour.RESET));
            }
        }         
        Console.WriteLine("\nPlease select a player to hire");
        Console.ReadLine();
    }
}