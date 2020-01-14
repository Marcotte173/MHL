using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DraftDisplay
{
    static Player chosen = Draft.chosen;
    internal static Player Players(List<Player> list)
    {
        Console.Clear();
        if (list == Create.goalieList) return GoalieList(list);
        else return PlayerList(list);        
    }

    private static Player GoalieList(List<Player> list)
    {
        Console.WriteLine(String.Format("{0, -6}{1, -35}{2,-20}{3,-20}{4,-20}{5,-21}{6,-19}{7,-21}{8,-20}{9,-20}", "Num", Colour.NAME + "Name ", Colour.OVERALL + "Overall", Colour.PRICE + "Price", Colour.SHOOT + "Glove", Colour.PASS + "Stick", Colour.SPEED + "Angles", Colour.SECONDARY + "Agility", Colour.SECONDARY + "Butterfly", Colour.POSITION + "Position" + Colour.RESET));
        Console.WriteLine("");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(String.Format("{0, -6}{1, -37}{2,-18}{3,-23}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}{9,-19}", $"[{i + 1}] ", Colour.NAME + $"{list[i].Name} ", Colour.OVERALL + $"{list[i].Overall}", Colour.PRICE + $"{list[i].Price}", Colour.SHOOT + $"{list[i].Glove}", Colour.PASS + $"{list[i].Stick}", Colour.SPEED + $"{list[i].Angles}", Colour.SECONDARY + $"{list[i].Agility} ", Colour.SECONDARY + $"{list[i].Butterfly}", Colour.POSITION + $"{list[i].Position}" + Colour.RESET));
        }
        Console.WriteLine("\nSelect a player or press enter to continue");
        string choice = Console.ReadLine();
        if (int.TryParse(choice, out int intchoice))
        {
            if (intchoice > 0 && intchoice <= list.Count) return list[intchoice - 1];
            else return null;
        }
        else return null;
    }
    private static Player GoalieList(Player[] list)
    {
        Console.WriteLine(String.Format("{0, -6}{1, -35}{2,-20}{3,-20}{4,-20}{5,-21}{6,-19}{7,-21}{8,-20}{9,-20}", "Num", Colour.NAME + "Name ", Colour.OVERALL + "Overall", Colour.PRICE + "Price", Colour.SHOOT + "Glove", Colour.PASS + "Stick", Colour.SPEED + "Angles", Colour.SECONDARY + "Agility", Colour.SECONDARY + "Butterfly", Colour.POSITION + "Position" + Colour.RESET));
        Console.WriteLine("");
        for (int i = 0; i < list.Length; i++)
        {
            Console.WriteLine(String.Format("{0, -6}{1, -37}{2,-18}{3,-23}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}{9,-19}", $"[{i + 1}] ", Colour.NAME + $"{list[i].Name} ", Colour.OVERALL + $"{list[i].Overall}", Colour.PRICE + $"{list[i].Price}", Colour.SHOOT + $"{list[i].Glove}", Colour.PASS + $"{list[i].Stick}", Colour.SPEED + $"{list[i].Angles}", Colour.SECONDARY + $"{list[i].Agility} ", Colour.SECONDARY + $"{list[i].Butterfly}", Colour.POSITION + $"{list[i].Position}" + Colour.RESET));
        }
        Console.WriteLine("\nSelect a player or press enter to continue");
        string choice = Console.ReadLine();
        if (int.TryParse(choice, out int intchoice))
        {
            if (intchoice > 0 && intchoice <= list.Length) return list[intchoice - 1];
            else return null;
        }
        else return null;
    }

    private static Player PlayerList(List<Player> list)
    {
        int counter = list.Count;
        int upCount = 0;
        int iteration = 1;
        Console.WriteLine(String.Format("{0, -6}{1, -35}{2,-20}{3,-20}{4,-20}{5,-21}{6,-19}{7,-21}{8,-20}{9,-20}{10,-10}", "Num", Colour.NAME + "Name ", Colour.OVERALL + "Overall", Colour.PRICE + "Price", Colour.SHOOT + "Shooting", Colour.PASS + "Passing", Colour.SPEED + "Speed", Colour.SECONDARY + "Secondary", Colour.SECONDARY + "OAware", Colour.SECONDARY + "DAware", Colour.POSITION + "Position" + Colour.RESET));
        Console.WriteLine("");
        while (counter > 0)
        {
            if (counter < 20)
            {
                for (int i = upCount; i < list.Count; i++)
                {
                    if (list[i] != null)
                    {
                        Console.WriteLine(String.Format("{0, -6}{1, -37}{2,-18}{3,-23}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}{9,-19}{10,-10}", $"[{i + 1}] ", Colour.NAME + $"{list[i].Name} ", Colour.OVERALL + $"{list[i].Overall}", Colour.PRICE + $"{list[i].Price}", Colour.SHOOT + $"{list[i].Shooting}", Colour.PASS + $"{list[i].Passing}", Colour.SPEED + $"{list[i].Speed}", Colour.SECONDARY + $"{(list[i].Handling + list[i].Checking + list[i].Balance + list[i].Block) / 4} ", Colour.SECONDARY + $"{list[i].OffAware}", Colour.SECONDARY + $"{list[i].DefAware}", Colour.POSITION + $"{list[i].Position}" + Colour.RESET));
                        counter--;
                        upCount++;
                    }                    
                }
            }
            else
            {
                for (int i = upCount; i < 20 * iteration; i++)
                {
                    if (list[i] != null)
                    {
                        Console.WriteLine(String.Format("{0, -6}{1, -37}{2,-18}{3,-23}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}{9,-19}{10,-10}", $"[{i + 1}] ", Colour.NAME + $"{list[i].Name} ", Colour.OVERALL + $"{list[i].Overall}", Colour.PRICE + $"{list[i].Price}", Colour.SHOOT + $"{list[i].Shooting}", Colour.PASS + $"{list[i].Passing}", Colour.SPEED + $"{list[i].Speed}", Colour.SECONDARY + $"{(list[i].Handling + list[i].Checking + list[i].Balance + list[i].Block) / 4} ", Colour.SECONDARY + $"{list[i].OffAware}", Colour.SECONDARY + $"{list[i].DefAware}", Colour.POSITION + $"{list[i].Position}" + Colour.RESET));
                        counter--;
                        upCount++;
                    }                        
                }
                iteration++;
            }
            Console.WriteLine("\nSelect a player or press enter to continue");
            string choice = Console.ReadLine();
            if (int.TryParse(choice, out int intchoice))
            {
                if (intchoice > 0 && intchoice <= list.Count) return list[intchoice - 1];
                else return null;
            }
            else return null;
        }
        return null;
    }
    private static Player PlayerList(Player[] list)
    {
        int counter = list.Length;
        int upCount = 0;
        int iteration = 1;
        Console.WriteLine(String.Format("{0, -6}{1, -35}{2,-20}{3,-20}{4,-20}{5,-21}{6,-19}{7,-21}{8,-20}{9,-20}{10,-10}", "Num", Colour.NAME + "Name ", Colour.OVERALL + "Overall", Colour.PRICE + "Price", Colour.SHOOT + "Shooting", Colour.PASS + "Passing", Colour.SPEED + "Speed", Colour.SECONDARY + "Secondary", Colour.SECONDARY + "OAware", Colour.SECONDARY + "DAware", Colour.POSITION + "Position" + Colour.RESET));
        Console.WriteLine("");
        while (counter > 0)
        {
            if (counter < 20)
            {
                for (int i = upCount; i < list.Length; i++)
                {
                    Console.WriteLine(String.Format("{0, -6}{1, -37}{2,-18}{3,-23}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}{9,-19}{10,-10}", $"[{i + 1}] ", Colour.NAME + $"{list[i].Name} ", Colour.OVERALL + $"{list[i].Overall}", Colour.PRICE + $"{list[i].Price}", Colour.SHOOT + $"{list[i].Shooting}", Colour.PASS + $"{list[i].Passing}", Colour.SPEED + $"{list[i].Speed}", Colour.SECONDARY + $"{(list[i].Handling + list[i].Checking + list[i].Balance + list[i].Block) / 4} ", Colour.SECONDARY + $"{list[i].OffAware}", Colour.SECONDARY + $"{list[i].DefAware}", Colour.POSITION + $"{list[i].Position}" + Colour.RESET));
                    counter--;
                    upCount++;
                }
            }
            else
            {
                for (int i = upCount; i < 20 * iteration; i++)
                {
                    Console.WriteLine(String.Format("{0, -6}{1, -37}{2,-18}{3,-23}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}{9,-19}{10,-10}", $"[{i + 1}] ", Colour.NAME + $"{list[i].Name} ", Colour.OVERALL + $"{list[i].Overall}", Colour.PRICE + $"{list[i].Price}", Colour.SHOOT + $"{list[i].Shooting}", Colour.PASS + $"{list[i].Passing}", Colour.SPEED + $"{list[i].Speed}", Colour.SECONDARY + $"{(list[i].Handling + list[i].Checking + list[i].Balance + list[i].Block) / 4} ", Colour.SECONDARY + $"{list[i].OffAware}", Colour.SECONDARY + $"{list[i].DefAware}", Colour.POSITION + $"{list[i].Position}" + Colour.RESET));
                    counter--;
                    upCount++;
                }
                iteration++;
            }
            Console.WriteLine("\nSelect a player or press enter to continue");
            string choice = Console.ReadLine();
            if (int.TryParse(choice, out int intchoice))
            {
                if (intchoice > 0 && intchoice <= list.Length) return list[intchoice - 1];
                else return null;
            }
            else return null;
        }
        return null;
    }
}