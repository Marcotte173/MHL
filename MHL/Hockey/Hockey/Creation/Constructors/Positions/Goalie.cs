using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Goalie:Player
{
    static Random rand = new Random();
    public Goalie(int minimum, int maximum, int target, int range)
    : base()
    {
        position = "Goalie";
        int nameRoll = rand.Next(0, CreatePlayers.nameList.Count);
        name = $"{CreatePlayers.nameList[nameRoll]}";
        CreatePlayers.nameList.Remove(CreatePlayers.nameList[nameRoll]);
        do
        {
            glove = rand.Next(minimum , maximum );
            stick = rand.Next(minimum , maximum );
            angles = rand.Next(minimum, maximum );
            agility = rand.Next(minimum , maximum );
            butterfly = rand.Next(minimum, maximum);
        } while (target > Overall + range || target < Overall - range);
        coefficient = (Overall > 90) ? 4 : (Overall > 85) ? 3 : (Overall > 80) ? 2 : 1;
    }
    public override double Overall { get { return ( glove + stick + angles * 2 + agility * 2 + butterfly * 2) / 8; } }
    public override double Price { get { return Overall * (350 + rand.Next(-20,20)) * coefficient; } }
}
