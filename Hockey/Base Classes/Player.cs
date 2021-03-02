using System;


public class Player
{
    protected string name;
    protected int gamesPlayed;
    protected int plusminus;
    protected int speed;
    protected int handling;
    protected int passing;
    protected int shooting;
    protected int checking;
    protected int balance;
    protected int offAware;
    protected int defAware;
    protected int block;
    protected double coefficient;
    protected double price;
    protected string position;
    protected int glove;
    protected int stick;
    protected int angles;
    protected int agility;
    protected int butterfly;
    protected int overall;
    public int[] shotStat =          new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 };
    public int[] goalStat =          new int[] {0,0,0,0,0,0,0,0,0,0,0,0};
    public int[] assistStat =        new int[] {0,0,0,0,0,0,0,0,0,0,0,0};
    public int[] pointStat =         new int[] {0,0,0,0,0,0,0,0,0,0,0,0};
    public int[] checkStat =         new int[] {0,0,0,0,0,0,0,0,0,0,0,0};
    public int[] penaltyStat =       new int[] {0,0,0,0,0,0,0,0,0,0,0,0};
    public int[] blockStat =         new int[] {0,0,0,0,0,0,0,0,0,0,0,0};
    public int[] hitStat =           new int[] {0,0,0,0,0,0,0,0,0,0,0,0};
    public int[] saveStat =          new int[] {0,0,0,0,0,0,0,0,0,0,0,0};
    public int[] allowGoalStat =     new int[] {0,0,0,0,0,0,0,0,0,0,0,0};
    protected Team team = new Team();
    protected double savePercentStat;
    protected bool hasPuck;

    public Player() { }

    public int TotalGoal { get { return goalStat[1] + goalStat[2] + goalStat[3] + goalStat[4] + goalStat[5] + goalStat[6] + goalStat[7] + goalStat[8] + goalStat[9] + goalStat[10] + goalStat[11]; } }
    public int TotalAssist { get { return assistStat[1] + assistStat[2] + assistStat[3] + assistStat[4] + assistStat[5] + assistStat[6] + assistStat[7] + assistStat[8] + assistStat[9] + assistStat[10] + assistStat[11]; } }
    public int TotalPoint { get { return pointStat[1] + pointStat[2] + pointStat[3] + pointStat[4] + pointStat[5] + pointStat[6] + pointStat[7] + pointStat[8] + pointStat[9] + pointStat[10] + pointStat[11]; } }
    public int TotalCheck { get { return checkStat[1] + checkStat[2] + checkStat[3] + checkStat[4] + checkStat[5] + checkStat[6] + checkStat[7] + checkStat[8] + checkStat[9] + checkStat[10] + checkStat[11]; } }
    public int TotalPenalty { get { return penaltyStat[1] + penaltyStat[2] + penaltyStat[3] + penaltyStat[4] + penaltyStat[5] + penaltyStat[6] + penaltyStat[7] + penaltyStat[8] + penaltyStat[9] + penaltyStat[10] + penaltyStat[11]; } }
    public int TotalBlock { get { return blockStat[1] + blockStat[2] + blockStat[3] + blockStat[4] + blockStat[5] + blockStat[6] + blockStat[7] + blockStat[8] + blockStat[9] + blockStat[10] + blockStat[11]; } }
    public int TotalHit { get { return hitStat[1] + hitStat[2] + hitStat[3] + hitStat[4] + hitStat[5] + hitStat[6] + hitStat[7] + hitStat[8] + hitStat[9] + hitStat[10] + hitStat[11]; } }
    public int TotaTotalSavelGoal { get { return saveStat[1] + saveStat[2] + saveStat[3] + saveStat[4] + saveStat[5] + saveStat[6] + saveStat[7] + saveStat[8] + saveStat[9] + saveStat[10] + saveStat[11]; } }
    public int TotalAllowGoal { get { return allowGoalStat[1] + allowGoalStat[2] + allowGoalStat[3] + allowGoalStat[4] + allowGoalStat[5] + allowGoalStat[6] + allowGoalStat[7] + allowGoalStat[8] + allowGoalStat[9] + allowGoalStat[10] + allowGoalStat[11]; } }

    public bool HasPuck { get { return hasPuck; } set { hasPuck = value; } }
    public int GamesPlayed { get { return gamesPlayed; } set { gamesPlayed = value; } }
    public int Plusminus { get { return plusminus; } set { plusminus = value; } }
    public double SavePercentStat { get { return savePercentStat; } set { savePercentStat = value; } }
    public virtual double Overall { get { return 0; } }
    public virtual double Price { get { return 0; } }
    public string Name { get { return name; } }
    public int Speed { get { return speed; } }
    public int Handling { get { return handling; } }
    public int Passing { get { return passing; } }
    public int Shooting { get { return shooting; } }
    public int Checking { get { return checking; } }
    public int Balance { get { return balance; } }
    public int Block { get { return block; } }
    public int OffAware { get { return offAware; } }
    public int DefAware { get { return defAware; } }
    public string Position { get { return position; } }
    public int Glove { get { return glove; } }
    public int Stick { get { return stick; } }
    public int Angles { get { return angles; } }
    public int Agility { get { return agility; } }
    public int Butterfly { get { return butterfly; } }
    public Team Team { get { return team; } set { team = value; } }

    internal static void ExaminePlayer(Player p)
    {
        Console.Clear();
        if (p.position != "Goalie")
        {
            Write.CenterText("      ___");
            Write.CenterText("       / OO\\ ");
            Write.CenterText("       \\ & / ");
            Write.CenterText("        ---  ");
            Write.CenterText("       /===\\ ");
            Write.CenterText("      /|   | ");
            Write.CenterText("     / |___| ");
            Write.CenterText("    /   | |   ");
            Write.CenterText("___/   _| |_  ");
            Write.CenterText("");
            Write.CenterColourText(Colour.NAME, Colour.NAME, "", "Name", ":", $"{p.Name}", "\n");
            Write.CenterColourText(Colour.OVERALL, Colour.OVERALL, "", "Overall", ":", $"{p.Overall}", "\n");
            Write.CenterColourText(Colour.SECONDARY, Colour.SECONDARY, "", "Offensive Awareness", ":", $"{p.OffAware}", "");
            Write.CenterColourText(Colour.SECONDARY, Colour.SECONDARY, "", "Defensive Awareness", ":", $"{p.DefAware}", "\n");
            Write.CenterColourText(Colour.SHOOT, Colour.SHOOT, "", "Shooting", ":", $"{p.Shooting}", "");
            Write.CenterColourText(Colour.PASS, Colour.PASS, "", "Passing", ":", $"{p.Passing}", "");
            Write.CenterColourText(Colour.SPEED, Colour.SPEED, "", "Speed", ":", $"{p.Speed}", "\n");
            Write.CenterColourText(Colour.SECONDARY, Colour.SECONDARY, "", "Handling", ":", $"{p.Handling}", "");
            Write.CenterColourText(Colour.SECONDARY, Colour.SECONDARY, "", "Checking", ":", $"{p.Checking}", "");
            Write.CenterColourText(Colour.SECONDARY, Colour.SECONDARY, "", "Balance", ":", $"{p.Balance}", "");
            Write.CenterColourText(Colour.SECONDARY, Colour.SECONDARY, "", "Shot Blocking", ":", $"{p.Block}", "\n");
            Write.CenterColourText(Colour.PRICE, Colour.PRICE, "", "Value", ":", $"{p.Price}", "\n");
        }
        else
        {
            Write.CenterText("  ___");
            Write.CenterText("      / OO\\    ");
            Write.CenterText("      \\ & /    ");
            Write.CenterText("        ---      ");
            Write.CenterText("    __ /===\\ __  ");
            Write.CenterText("    /  /|   |\\  \\  ");
            Write.CenterText("   /__/ |___| \\__\\ ");
            Write.CenterText("    /  | | |      ");
            Write.CenterText("___/  _|_|_|_     ");
            Write.CenterText("");
            Write.CenterColourText(Colour.NAME, Colour.NAME, "", "Name", ":", $"{p.Name}", "\n");
            Write.CenterColourText(Colour.OVERALL, Colour.OVERALL, "", "Overall", ":", $"{p.Overall}", "\n");
            Write.CenterColourText(Colour.SHOOT, Colour.SHOOT, "", "Glove", ":", $"{p.Glove}", "");
            Write.CenterColourText(Colour.PASS, Colour.PASS, "", "Stick", ":", $"{p.Stick}", "\n");
            Write.CenterColourText(Colour.SPEED, Colour.SPEED, "", "Angles", ":", $"{p.Angles}", "");
            Write.CenterColourText(Colour.SECONDARY, Colour.SECONDARY, "", "Agility", ":", $"{p.Agility}", "");
            Write.CenterColourText(Colour.SECONDARY, Colour.SECONDARY, "", "Butterfly", ":", $"{p.Butterfly}", "\n");
            Write.CenterColourText(Colour.PRICE, Colour.PRICE, "", "Value", ":", $"{p.Price}", "\n");
        }        
        if (Create.defenceList.Contains(p) || Create.goalieList.Contains(p) || Create.forwardList.Contains(p))
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 5);
            if (Utilities.CheckMoney(p.Price, Team.list[0])) Aquire.Hire(p, Team.list[0]);
        }
        else Utilities.KeyPress();
    }
}