using System;
using System.Collections.Generic;
public class Team
{
    List<Player> roster;
    List<Player> injured;
    int win;
    int loss;
    int otLoss;
    int money;
    string name;
    int fans;
    int reputation;
    int forward;
    int defence;
    int goalie;
    string gmName;

    public Team() 
    {
        win = 0;
        loss = 0;
        otLoss = 0;
        money = 150000;
        name = "";
        fans = 100;
        reputation = 100;
        forward = 0;
        defence = 0;
        goalie = 0;
        gmName = "";
    }

    public string GMName { get { return gmName; } set { gmName = value; } }
    public string Name { get { return name; } set { name = value; } }
    public int Win { get { return win; } set { win = value; } }
    public int Loss { get { return loss; } set { loss = value; } }
    public int OTLoss { get { return otLoss; } set { otLoss = value; } }
    public int Money { get { return money; } set { money = value; } }
    public int Fans { get { return fans; } set { fans = value; } }
    public int Reputation { get { return reputation; } set { reputation = value; } }
    public int Forward { get { return forward; } set { forward = value; } }
    public int Defence { get { return defence; } set { defence = value; } }
    public int Goalie { get { return goalie; } set { goalie = value; } }
}