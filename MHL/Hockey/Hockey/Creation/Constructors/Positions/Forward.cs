using System;
using System.Collections.Generic;
public class Forward:Player
{
    static Random rand = new Random();
    public Forward(int minimum, int maximum, int target, int range)
    : base()
    {
        int nameRoll = rand.Next(0, CreatePlayers.nameList.Count);
        name = $"{CreatePlayers.nameList[nameRoll]}";
        CreatePlayers.nameList.Remove(CreatePlayers.nameList[nameRoll]); position = "Forward";
        do
        {
            shooting = rand.Next(minimum, maximum);
            passing =  rand.Next(minimum, maximum);
            speed =    rand.Next(minimum, maximum);
            offAware = rand.Next(minimum, maximum);
            defAware = rand.Next(minimum - 10, maximum - 10);
            handling = rand.Next(minimum, maximum);
            checking = rand.Next(minimum - 5, maximum - 10);
            balance =  rand.Next(minimum, maximum);
            block =    rand.Next(minimum - 5, maximum - 10);
        } while (target > Overall + range || target < Overall - range);
        coefficient = (Overall > 90) ? 5 : (Overall > 85) ? 3 : (Overall > 80) ? 2 : 1;

    }
    public override double Overall { get { return (
                shooting * 5 +
                offAware * 4 +                
                passing  * 3 +
                speed    * 3 +
                handling * 2 +
                defAware * 2 +
                checking * 1 + 
                balance  * 1 +                  
                block    * 1
                ) 
                / 22; } }
    public override double Price { get { return Overall * (400 + rand.Next(-20, 20)) * coefficient; } }
}