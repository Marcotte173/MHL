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
        protected int goalStat;
        protected int assistStat;
        protected int pointStat;
        protected int checkStat;
        protected int penaltyStat;
        protected int blockStat;
        protected int hitStat;
        protected int saveStat;
        protected int allowGoalStat;
        protected Team team = new Team();
        protected double savePercentStat;


        public Player() { }
        public int GoalStat { get { return goalStat; } set { goalStat = value; } }
        public int AssistStat { get { return assistStat; } set { assistStat = value; } }
        public int GamesPlayed { get { return gamesPlayed; } set { gamesPlayed = value; } }
        public int Plusminus { get { return plusminus; } set { plusminus = value; } }
        public int CheckStat { get { return checkStat; } set { checkStat = value; } }
        public int PenaltyStat { get { return penaltyStat; } set { penaltyStat = value; } }
        public int BlockStat { get { return blockStat; } set { blockStat = value; } }
        public int HitStat { get { return hitStat; } set { hitStat = value; } }
        public int PointStat { get { return goalStat + assistStat; }  }
        public int SaveStat { get { return saveStat; } set { saveStat = value; } }
        public int AllowGoalStat { get { return allowGoalStat; } set { allowGoalStat = value; } }
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
            Console.SetCursorPosition(0, Console.WindowHeight - 4);
            if (Utilities.CheckMoney(p.Price, Team.list[0])) Aquire.Hire(p, Team.list[0]);
        }
        else Utilities.KeyPress();
    }
}