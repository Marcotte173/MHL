using System;
using System.Collections.Generic;
public class Defence:Player
{
    static Random rand = new Random();
    public Defence(int minimum, int maximum, int target, int range)
    : base()
    {
        position = "Defence";
        int nameRoll = rand.Next(0, CreatePlayers.nameList.Count);
        name = $"{CreatePlayers.nameList[nameRoll]}";
        CreatePlayers.nameList.Remove(CreatePlayers.nameList[nameRoll]);
        do
        {
            shooting = rand.Next(minimum - 2, maximum - 3);
            passing =  rand.Next(minimum - 2, maximum - 3);
            speed =    rand.Next(minimum - 2, maximum - 3);
            offAware = rand.Next(minimum - 3, maximum - 10);
            defAware = rand.Next(minimum + 5, maximum);
            handling = rand.Next(minimum - 2, maximum - 5);
            checking = rand.Next(minimum + 5, maximum);
            balance =  rand.Next(minimum, maximum);
            block =    rand.Next(minimum + 5, maximum);
        } while (target > Overall + range || target < Overall - range);
        coefficient = (Overall > 90) ? 5 : (Overall > 85) ? 3 : (Overall > 80) ? 2 : 1;
    }
    public override double Overall { get { return 
                (
                defAware  * 5 +
                checking  * 3 +
                block     * 3 +
                shooting  * 3 +
                speed     * 2 +                
                passing   * 2 +
                offAware  * 2 +
                handling  * 1 +
                balance   * 1 
                ) 
                / 22; } }
    public override double Price { get { return Overall * (375 + rand.Next(-20, 20)) * coefficient; } }
}