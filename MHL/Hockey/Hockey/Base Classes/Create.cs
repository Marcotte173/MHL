using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Create
{
    public static List<string> nameList = new List<string> { };

    public static List<Player> forwardList = new List<Player> { };
    public static List<Player> defenceList = new List<Player> { };
    public static List<Player> goalieList = new List<Player> { };
    public static List<Player> loanerForwardList = new List<Player> { };
    public static List<Player> loanerDefenceList = new List<Player> { };
    public static List<Player> loanerGoalieList = new List<Player> { };

    public static Random rand = new Random();
    public static void PlayerCreate()
    {
        Franchise();
        Elite();
        Top();
        Bottom();
        Goalies();    
        Loaner();
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

    private static void Loaner()
    {        
        for (int i = 0; i < 50; i++) { loanerForwardList.Add(new Forward(30, 40, 35, 5)); }
        for (int i = 0; i < 50; i++) { loanerDefenceList.Add(new Defence(30, 40, 35, 5)); }
        for (int i = 0; i < 50; i++) { loanerGoalieList.Add(new Goalie(40, 50, 45, 5)); }
    }
}
