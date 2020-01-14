using System;
using System.Collections.Generic;
public class Team
{
    public static List<Team> list = new List<Team> { new PlayerTeam(),  new AfternoonDelight(), new BackyardWrestlers(), new OttwellSeals(), new StocktonSlaps(), new TurkeySandwiches() };
    protected Player[] line1 = new  Player[3] ;
    protected Player[] line2 = new  Player[3] ;
    protected Player[] line3 = new  Player[3] ;
    protected Player[] dLine1 = new Player[2] ;
    protected Player[] dLine2 = new Player[2] ;
    protected Player[] bench = new  Player[5] ;
    protected Player[] roster = new Player[18] ;
    protected Player[] goalieRoster = new Player[2];
    protected List<Player> injured = new List<Player> { };
    protected Player startingGoalie;
    protected Player backupGoalie;

    protected int win;
    protected int loss;
    protected int otLoss;
    protected double money;
    protected string name;
    protected double fans;
    protected double reputation;
    protected int forward;
    protected int defence;
    protected int goalie;
    protected string gmName;
    protected int score;
    protected int shots;


    public Team() 
    {
        win = 0;
        loss = 0;
        otLoss = 0;        
        forward = 0;
        defence = 0;
        goalie = 0;           
    }

    public string GMName { get { return gmName; } set { gmName = value; } }
    public string Name { get { return name; } set { name = value; } }
    public int Win { get { return win; } set { win = value; } }
    public int Loss { get { return loss; } set { loss = value; } }
    public int OTLoss { get { return otLoss; } set { otLoss = value; } }
    public double Money { get { return money; } set { money = value; } }
    public double Fans { get { return fans; } set { fans = value; } }
    public double Reputation { get { return reputation; } set { reputation = value; } }
    public int Forward { get { return forward; } set { forward = value; } }
    public int Defence { get { return defence; } set { defence = value; } }
    public int Goalie { get { return goalie; } set { goalie = value; } }
    public Player[] Line1 { get { return line1; } set { line1 = value; } }
    public Player[] Line2 { get { return line2; } set { line2 = value; } }
    public Player[] Line3 { get { return line3; } set { line3 = value; } }
    public Player[] DLine1 { get { return dLine1; } set { dLine1 = value; } }
    public Player[] DLine2 { get { return dLine2; } set { dLine2 = value; } }
    public Player[] Bench { get { return bench; } set { bench = value; } }
    public Player[] Roster { get { return roster; } set { roster = value; } }
    public Player[] GoalieRoster { get { return goalieRoster; } set { goalieRoster = value; } }
    public List<Player> Injured { get { return injured; } set { injured = value; } }
    public Player StartingGoalie { get { return startingGoalie; } set { startingGoalie = value; } }
    public Player BackupGoalie { get { return backupGoalie; } set { backupGoalie = value; } }
    public int Score { get { return score; } set { score = value; } }
    public int Shots { get { return shots; } set { shots = value; } }
    public virtual void Draft(List<Player>f, List<Player>d, List<Player>g) { }
    public virtual void Draft(List<Player> f, List<Player> d, List<Player> g, Player chosen, int round) { }
}