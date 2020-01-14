using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class CreatePlayers
{
    public static Team playerTeam = new Team();
    public static List<string> firstName = new List<string>
    {
        "Al", "Andy",
        "Bill", "Ben",
        "Carl", "Chevy",
        "Dan", "Doug",
        "Edward", "Earl",
        "Frank", "Fitch",
        "Germaine", "George",
        "Henry", "Harvey",
        "Ian", "Irving",
        "John", "Jason",
        "Keith", "Kirby",
        "Lenny", "Leon",
        "Marc", "Mason",
        "Nic", "Nathan",
        "Olliver", "Orson",
        "Pete", "Paul",
        "Quentin", "Qwark",
        "Rudiger", "Randy",
        "Steve", "Stanley",
        "Tom", "Travis"
    };
    public static List<string> lastName = new List<string>
    {
        "Abner", "Abdhul",
        "Benson", "Bobert",
        "Carlson", "Chenson",
        "Dorf", "Dimes",
        "Edwards", "Einstein",
        "Fredricton", "Francis",
        "Gaffer", "Giminey",
        "Hernandez", "Hippo",
        "Invinton", "Igveld",
        "Johnson", "Jameston",
        "Kinton", "Kelvin",

    };  

    public static List<string> nameList = new List<string> { };

    public static List<Team> teamList = new List<Team> {};

    public static List<Player> forwardList = new List<Player> { };
    public static List<Player> defenceList = new List<Player> { };
    public static List<Player> goalieList = new List<Player> { };
    public static Random rand = new Random();
    public static void PlayerCreate()
    {
        Franchise();
        Elite();
        Top();
        Bottom();
        Goalies();        
        Sort(forwardList);
        Sort(defenceList);
        Sort(goalieList);        
    }

    private static void Sort(List<Player> list)
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

    private static void Goalies()
    {
        for (int i = 0; i < 15; i++) goalieList.Add(new Goalie(70, 99, 80, 10));
    }

    public static void Franchise()
    {
        //How many franchise players?
        int total = rand.Next(2, 11);
        int defence = Convert.ToInt32(0.4 * total);
        int forward = total - defence;
        //Generate franchise players
        for (int i = 0; i < forward; i++) forwardList.Add(new Forward(80, 99, 94, 3));
        for (int i = 0; i < defence; i++) defenceList.Add(new Defence(80, 99, 94, 3));
    }

    private static void Elite()
    {
        //How many elite players?
        int total = rand.Next(15 , 20);
        int defence = Convert.ToInt32(0.4 * total);
        int forward = total - defence;
        //Generate elite players
        for (int i = 0; i < forward; i++) { forwardList.Add(new Forward(75, 93, 89, 3)); }
        for (int i = 0; i < defence; i++) { defenceList.Add(new Defence(75, 93, 89, 3)); }
    }

    private static void Top()
    {
        //How many top players?
        int total = rand.Next(27, 34);
        int defence = Convert.ToInt32(0.4 * total);
        int forward = total - defence;
        //Generate top players
        for (int i = 0; i < forward; i++) { forwardList.Add(new Forward(75, 89, 86, 5)); }
        for (int i = 0; i < defence; i++) { defenceList.Add(new Defence(75, 89, 86, 5)); }
    }

    private static void Bottom()
    {
        //How many bottom players?
        int total = 100 - (defenceList.Count + forwardList.Count);
        int defence = Convert.ToInt32(0.4 * total);
        int forward = total - defence;
        //Generate bottom players
        for (int i = 0; i < forward; i++) { forwardList.Add(new Forward(70, 83, 75, 6)); }
        for (int i = 0; i < defence; i++) { defenceList.Add(new Defence(70, 83, 75, 6)); }
    }
}
