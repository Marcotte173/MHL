using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

public enum Rink {ALOW, AHIGH, NEUTRAL, BHIGH, BLOW };
public class Play
{
    static int keypress;
    public static Game theGame;
    public static Team a;
    public static Team b;
    public static bool tie;
    public static int gameAShot;
    public static int gameBShot;
    public static int gameAGoal;
    public static int gameBGoal;
    public static Player defenceman;
    public static List<Player> carrier = new List<Player> { };
    public static Player aCenter;
    public static Player aRightWing;
    public static Player aLeftWing;
    public static Player aRightDefence;
    public static Player aLeftDefence;
    public static Player aGoalie;
    public static List<Player> aOnIce = new List<Player> { };
    public static List<Player> bOnIce = new List<Player> { };
    public static Player bCenter;
    public static Player bRightWing;
    public static Player bLeftWing;
    public static Player bRightDefence;
    public static Player bLeftDefence;
    public static Player bGoalie;
    public static Rink location;
    public static Team offence;
    public static Team defence;
    public static int momentum;
    public static int period;
    public static int time;
    public static int x;
    public static int y;
    public static bool loosePuck;
    public static List<string> playByPlay = new List<string> { };

    /// <summary>
    /// Game itself
    /// </summary>
    /// <param name="game"></param>
    public static void Start(Game game)
    {
        tie = false;
        theGame = game;
        game.Played = true;
        period = 1;
        time = 0;
        momentum = 0;
        a = game.A;
        b = game.B;
        gameAShot = 0;
        gameBShot = 0;
        game.AScore = gameAGoal = 0;
        game.BScore = gameBGoal = 0;
        aGoalie = a.StartingGoalie;
        bGoalie = b.StartingGoalie;
        ChangeFLinesA(a.Line1);
        ChangeFLinesB(b.Line1);
        ChangeDLinesA(a.DLine1);
        ChangeDLinesB(b.DLine1);
        FaceOff();
        StartPeriod();        
    }
    public static void PlayGame()
    {
        keypress++;
        if (loosePuck) ScrambleForPuck();
        else
        {
            if (offence == a) WhoGoes(OffenceDecide(a), DefenceDecide(b));
            else WhoGoes(OffenceDecide(b), DefenceDecide(a));
        }
        if (keypress > 4)
        {
            Utilities.KeyPress();
            keypress = 0;
            ClearDisplay();
        }
        else Thread.Sleep(400);        
        time++;
        if (time < 10) PlayGame();        
    }

    public static void StartPeriod()
    {
        time = 0;
        keypress = 0;
        EndPeriod();
    }

    public static void EndPeriod()
    {
        PlayGame();
        Console.Clear();
        period++;
        if (period < 4)
        {
            Write.Line("The period is over!");
            Neutral();
            FaceOff();
            StartPeriod();
        }
        else GameRecap();
    }

    private static void ClearDisplay()
    {
        Console.Clear();
        keypress = 0;
        playByPlay.Clear();
    }

    public static void Display()
    {
        Console.Clear();
        RinkDisplay();
        //Display what happened     
        Console.SetCursorPosition(0, 18);
        foreach (string play in playByPlay)
        {
            Write.Line(play);
        }
        Write.Line(0,0,"Period " + period);        
        Write.Line(50, 0, a.Name);
        Write.Line(80, 0, b.Name);
        Write.Line(60, 1, Colour.GOAL + gameAGoal.ToString()+Colour.RESET);
        Write.Line(90, 1, Colour.GOAL + gameBGoal.ToString()+Colour.RESET);
        Write.Line(50, 2, "Shots: " + gameAShot.ToString() + Colour.RESET);
        Write.Line(80, 2, "Shots: " + gameBShot.ToString() + Colour.RESET);
        DisplayName(50, 10, a.CurrentFLine[0]);
        DisplayName(50, 11, a.CurrentFLine[1]);
        DisplayName(50, 12, a.CurrentFLine[2]);
        DisplayName(50, 14, a.CurrentDLine[0]);
        DisplayName(50, 15, a.CurrentDLine[1]);
        DisplayName(80, 10, b.CurrentFLine[0]);
        DisplayName(80, 11, b.CurrentFLine[1]);
        DisplayName(80, 12, b.CurrentFLine[2]);
        DisplayName(80, 14, b.CurrentDLine[0]);
        DisplayName(80, 15, b.CurrentDLine[1]);
    }

    internal static void RinkDisplay()
    {
        int offset = 55;
        Write.Line(offset,3,"  _____________________________");
        Write.Line(offset,4," /                             \\");
        Write.Line(offset,5,"|                               |");
        Write.Line(offset,6,"|                               |");
        Write.Line(offset,7,"|                               |");
        Write.Line(offset, 8," \\_____________________________/");
        Write.Line(2+offset, 6, Colour.INJURY + "E");
        Write.Line(30+offset, 6, Colour.INJURY + "3");
        for (int i = 1; i < 6; i++) Write.Line(10+offset, i+3, Colour.POSITION + "|");
        for (int i = 1; i < 6; i++) Write.Line(22+offset, i+3, Colour.POSITION + "|");
        for (int i = 1; i < 6; i++) Write.Line(16 + offset, i+3, Colour.INJURY + "|");
        for (int i = 1; i < 6; i++) Write.Line(3 + offset,  i+3, Colour.INJURY + "|");
        for (int i = 1; i < 6; i++) Write.Line(29 + offset, i+3, Colour.INJURY + "|");
        int x = (location == Rink.ALOW) ? 5 : (location == Rink.AHIGH) ? 9 : (location == Rink.NEUTRAL) ? 16 : (location == Rink.BHIGH) ? 23 : 27;
        Write.Line(x + offset, 6, "O");
    }

    private static void DisplayName(int x, int y, Player p)
    {
        if (p.HasPuck) Write.Line(x, y, Colour.NAME + p.Name.ToString() + Colour.RESET);
        else Write.Line(x, y, p.Name.ToString());
    }

    public static void ScrambleForPuck()
    {
        List<Player> available = new List<Player> { };
        foreach (Player p in aOnIce) available.Add(p);
        foreach (Player p in bOnIce) available.Add(p);
        Actions.Retrieve(available[Utilities.RandomInt(0, available.Count)]);
    }

    //////
    //AI
    //////

    public static int OffenceDecide(Team offence)
    {
        int choice;
        if ((location == Rink.ALOW && offence == b) || (location == Rink.BLOW && offence == a))
        {
            choice = Utilities.RandomInt(1, 8);
            //wristshot
            if (choice == 1 || choice == 2)
            {
                x = carrier[0].Shooting;
                offence.teamOffence = TeamOffence.WristShot;
            }
            //onetimer                                 
            else if (choice == 3)
            {
                x = (carrier[0].Passing + carrier[0].OffAware * 2) / 3;
                offence.teamOffence = TeamOffence.OneTimer;
            }
            //carry                                    
            else if (choice == 4 || choice == 5)
            {
                x = (carrier[0].Speed * 3 + carrier[0].Handling * 2) / 5;
                offence.teamOffence = TeamOffence.Carry;
            }
            //pass
            else
            {
                x = carrier[0].Passing;
                offence.teamOffence = TeamOffence.Pass;
            }
        }
        else if ((location == Rink.AHIGH && offence == b) || (location == Rink.BHIGH && offence == a))
        {
            if (carrier[0].Position == "Forward")
            {
                choice = Utilities.RandomInt(1, 6);
                //carry
                if (choice == 1 || choice == 2)
                {
                    x = (carrier[0].Speed * 3 + carrier[0].Handling * 2) / 5;
                    offence.teamOffence = TeamOffence.Carry;
                }
                //pass
                else
                {
                    x = carrier[0].Passing;
                    offence.teamOffence = TeamOffence.Pass;
                }
            }
            else if (carrier[0].Position == "Defence")
            {
                choice = Utilities.RandomInt(1, 6);
                //wristshot
                if (choice == 1 || choice == 2)
                {
                    x = carrier[0].Shooting;
                    offence.teamOffence = TeamOffence.WristShot;
                }
                //slapshot
                else if (choice == 3 || choice == 4)
                {
                    x = carrier[0].Shooting;
                    offence.teamOffence = TeamOffence.SlapShot;
                }
                //pass
                else
                {
                    x = carrier[0].Passing;
                    offence.teamOffence = TeamOffence.Pass;
                }
            }
        }
        else
        {
            choice = Utilities.RandomInt(1, 6);
            //carry
            if (choice == 1 || choice == 2 || choice == 3)
            {
                x = (carrier[0].Speed * 3 + carrier[0].Handling * 2) / 5;
                offence.teamOffence = TeamOffence.Carry;
            }
            //pass 
            else
            {
                x = carrier[0].Passing;
                offence.teamOffence = TeamOffence.Pass;
            }
        }
        return x;
    }

    public static int DefenceDecide(Team defence)
    {
        defenceman = defence.CurrentDLine[0];
        foreach (Player p in defence.CurrentDLine)
        {
            if (p != null)
                if (p.DefAware > defenceman.DefAware) defenceman = p;
        }
        foreach (Player p in defence.CurrentFLine)
        {
            if (p != null)
                if (p.DefAware > defenceman.DefAware) defenceman = p;
        }
        int choice;
        if ((location == Rink.ALOW && defence == a) || (location == Rink.BLOW && defence == b))
        {
            choice = Utilities.RandomInt(1, 10);
            Write.Line("I rolled a " + choice);
            //PokeCheck
            if (choice == 1)
            {
                y = defenceman.DefAware;
                defence.teamDefence = TeamDefence.PokeCheck;
            }
            //Check
            else if (choice == 2)
            {
                y = (defenceman.DefAware + defenceman.Checking) / 2;
                defence.teamDefence = TeamDefence.Check;
            }
            //InterceptPass
            else if (choice == 3 || choice == 4)
            {
                y = defenceman.DefAware;
                defence.teamDefence = TeamDefence.InterceptPass;
            }
            //Block Shot
            else if (choice == 5 || choice == 6 || choice == 7)
            {
                y = defenceman.DefAware;
                defence.teamDefence = TeamDefence.BlockShot;
            }
            //Positioning
            else
            {
                y = defenceman.DefAware;
                defence.teamDefence = TeamDefence.Positioning;
            }
        }
        else if ((location == Rink.AHIGH && defence == a) || (location == Rink.BHIGH && defence == b))
        {
            choice = Utilities.RandomInt(1, 10);
            Write.Line("I rolled a " + choice);
            //PokeCheck
            if (choice == 1 || choice == 2)
            {
                y = defenceman.DefAware;
                defence.teamDefence = TeamDefence.PokeCheck;
            }
            //Check
            else if (choice == 3)
            {
                y = (defenceman.DefAware + defenceman.Checking) / 2;
                defence.teamDefence = TeamDefence.Check;
            }
            //InterceptPass
            else if (choice == 4 || choice == 5)
            {
                y = defenceman.DefAware;
                defence.teamDefence = TeamDefence.InterceptPass;
            }
            //Block Shot
            else if (choice == 6 || choice == 7)
            {
                y = defenceman.DefAware;
                defence.teamDefence = TeamDefence.BlockShot;
            }
            //Positioning
            else
            {
                y = defenceman.DefAware;
                defence.teamDefence = TeamDefence.Positioning;
            }
        }
        else
        {
            choice = Utilities.RandomInt(1, 9);
            Write.Line("I rolled a " + choice);
            //PokeCheck
            if (choice == 1 || choice == 2)
            {
                y = defenceman.DefAware;
                defence.teamDefence = TeamDefence.PokeCheck;
            }
            //Check
            else if (choice == 3 || choice == 4 || choice == 5)
            {
                y = (defenceman.DefAware + defenceman.Checking) / 2;
                defence.teamDefence = TeamDefence.Check;
            }
            //InterceptPass
            else if (choice == 6)
            {
                y = defenceman.DefAware;
                defence.teamDefence = TeamDefence.InterceptPass;
            }
            //Positioning
            else
            {
                y = defenceman.DefAware;
                defence.teamDefence = TeamDefence.Positioning;
            }
        }
        return y;
    }

    public static void WhoGoes(int oSkill, int dSkill)
    {
        //Percentage chance to see who exerts will
        bool offenceWinsRoll = false;
        int roll = Utilities.RandomInt(1, 101);
        roll += (dSkill - oSkill)/2;
        roll += momentum;
        //Modifiers based on what each side selected
        if (offence.teamOffence == TeamOffence.SlapShot || offence.teamOffence == TeamOffence.WristShot)
        {
            if (defence.teamDefence == TeamDefence.BlockShot) roll += 5;
            else if (defence.teamDefence == TeamDefence.Check) roll -= 2;
            else if (defence.teamDefence == TeamDefence.InterceptPass) roll -= 15;
        }
        else if (offence.teamOffence == TeamOffence.Pass)
        {
            if (defence.teamDefence == TeamDefence.BlockShot) roll -=  15;
            else if (defence.teamDefence == TeamDefence.Check) roll -= 2;
            else if (defence.teamDefence == TeamDefence.InterceptPass) roll += 7;
            else if (defence.teamDefence == TeamDefence.PokeCheck) roll += 2;
        }
        else if (offence.teamOffence == TeamOffence.OneTimer)
        {
            if (defence.teamDefence == TeamDefence.BlockShot) roll -= 15;
            else if (defence.teamDefence == TeamDefence.Check) roll -= 4;
            else if (defence.teamDefence == TeamDefence.InterceptPass) roll -= 7;
            else if (defence.teamDefence == TeamDefence.PokeCheck) roll -= 5;
            else if (defence.teamDefence == TeamDefence.Positioning) roll += 8;
        }
        else
        {
            if (defence.teamDefence == TeamDefence.BlockShot) roll -= 8;
            else if (defence.teamDefence == TeamDefence.Check) roll -= 2;
            else if (defence.teamDefence == TeamDefence.InterceptPass) roll += 10;
            else if (defence.teamDefence == TeamDefence.PokeCheck) roll += 4;
        }
        if (roll <= 50)
        {
            offenceWinsRoll = true;
            if (roll < 20) momentum -= 3;
        }
        else if (roll > 80) momentum += 3;
        if (offenceWinsRoll)
        {
            if (offence.teamOffence == TeamOffence.WristShot) Actions.WristShot(carrier[0], carrier[0].Team);
            else if (offence.teamOffence == TeamOffence.SlapShot) Actions.SlapShot(carrier[0], carrier[0].Team);
            else if (offence.teamOffence == TeamOffence.OneTimer) Actions.OneTimer(carrier[0],carrier[0].Team);
            else if (offence.teamOffence == TeamOffence.Carry) Actions.Carry(carrier[0]);
            else if (offence.teamOffence == TeamOffence.Pass) Actions.Pass(carrier[0], carrier[0].Team);
        }
        else
        {
            if (defence.teamDefence == TeamDefence.BlockShot) Actions.BlockShot(defenceman);
            else if (defence.teamDefence == TeamDefence.Check) Actions.Check(defenceman);
            else if (defence.teamDefence == TeamDefence.InterceptPass) Actions.Intercept(defenceman);
            else if (defence.teamDefence == TeamDefence.PokeCheck) Actions.PokeCheck(defenceman);
            else if (defence.teamDefence == TeamDefence.Positioning) Actions.Position(defenceman);
        }
    }

    /// <summary>
    /// After Game
    /// </summary>

    public static void TieBreak()
    {
        tie = true;
        Console.Clear();
        int breaker = Utilities.RandomInt(0, 2);
        if (breaker == 0)
        {
            a.score[Season.gameWeek]++;
            Write.Line($"{a.Name} wins the game in overtime!");
        }
        else
        {
            b.score[Season.gameWeek]++;
            Write.Line($"{b.Name} wins the game in overtime!");
        }        
    }

    public static void GameRecap()
    {
        Write.Line("And that's the game!");        
        if (a.score[Season.gameWeek] == b.score[Season.gameWeek]) TieBreak();
        Utilities.KeyPress();
        foreach (Player p in a.Roster) if(p!=null) p.GamesPlayed++;
        foreach (Player p in b.Roster) if (p != null) p.GamesPlayed++;
        foreach (Player p in a.GoalieRoster) if (p != null) p.GamesPlayed++;
        foreach (Player p in b.GoalieRoster) if (p != null) p.GamesPlayed++;
        a.totalScore += a.score[Season.gameWeek];
        a.totalShots += a.shots[Season.gameWeek];
        b.totalScore += b.score[Season.gameWeek];
        b.totalShots += b.shots[Season.gameWeek];
        if (a.score[Season.gameWeek] > b.score[Season.gameWeek]) Win(a,b);
        else Win(b,a);
    }

    private static void Win(Team w,Team l)
    {
        w.GamesPlayed++;
        w.Win++;
        l.GamesPlayed++;
        l.Loss++;
    }


    /// <summary>
    /// Utility - Line changes, faceoffs, etc. Getting people on ice and pucks on their sticks
    /// </summary>
    /// 

    public static void FaceOff()
    {
        Utilities.KeyPress();
        ClearDisplay();
        momentum = 0;
        carrier.Clear();
        playByPlay.Add("The teams line up for the faceoff");
        Display();
        Thread.Sleep(300);
        int faceoffRoll = Utilities.RandomInt(1, 101);
        int awin = 50 + a.CurrentFLine[1].OffAware - b.CurrentFLine[1].OffAware;
        if (faceoffRoll <= awin)
        {
            GivePuck(aCenter);
            playByPlay.Add(aCenter.Name + " wins the draw");
        }
        else
        {
            GivePuck(bCenter);
            playByPlay.Add(bCenter.Name + " wins the draw");
        }
        Display();
    }

    public static void OnIce()
    {
        aOnIce.Clear();
        bOnIce.Clear();
        foreach (Player p in a.CurrentFLine) aOnIce.Add(p);
        foreach (Player p in a.CurrentDLine) aOnIce.Add(p);
        foreach (Player p in b.CurrentFLine) bOnIce.Add(p);
        foreach (Player p in b.CurrentDLine) bOnIce.Add(p);
    }

    public static void ChangeFLinesA(Player[] line)
    {
        a.CurrentFLine = line;
        aRightWing = line[0];
        aCenter = line[1];
        aLeftWing = line[2];
        OnIce();
    }
    public static void ChangeFLinesB(Player[] line)
    {
        b.CurrentFLine = line;
        bRightWing = line[0];
        bCenter = line[1];
        bLeftWing = line[2];
        OnIce();
    }

    public static void ChangeDLinesA(Player[] line)
    {
        a.CurrentDLine = line;
        aRightDefence = line[0];
        aLeftDefence = line[1];
        OnIce();
    }
    public static void ChangeDLinesB(Player[] line)
    {
        b.CurrentDLine = line;
        bRightDefence = line[0];
        bLeftDefence = line[1];
        OnIce();
    }

    public static void GivePuck(Player p)
    {
        if (carrier.Count >0 && carrier[0].Team != p.Team) carrier.Clear();
        foreach (Player player in a.Roster) if (player != null) player.HasPuck = false;
        foreach (Player player in b.Roster) if (player != null) player.HasPuck = false;
        p.HasPuck = true;
        offence = (a.Roster.Contains(p)) ? a : b;
        defence = (a.Roster.Contains(p)) ? b : a;
        carrier.Insert(0, p);
        loosePuck = false;
    }

    public static void LoosePuck()
    {
        momentum = 0;
        foreach (Player p in a.Roster) if (p != null) p.HasPuck = false;
        foreach (Player p in b.Roster) if (p != null) p.HasPuck = false;
        offence = null;
        carrier.Clear();
        loosePuck = true;
    }

    /// <summary>
    /// Location checks and functions
    /// </summary>

    internal static void ALow() => location = Rink.ALOW;
    internal static void AHigh() => location = Rink.AHIGH;
    internal static void Neutral() => location = Rink.NEUTRAL;
    internal static void BHigh() => location = Rink.BHIGH;
    internal static void BLow() => location = Rink.BLOW;
    internal static bool IsALow() => location == Rink.ALOW;
    internal static bool IsAHigh() => location == Rink.AHIGH;
    internal static bool IsNeutral() => location == Rink.NEUTRAL;
    internal static bool IsBHigh() => location == Rink.BHIGH;
    internal static bool IsBLow() => location == Rink.BLOW;
    public static bool IsOffenceHigh(Team offence) => (offence == a && IsBHigh()) || (offence == b && IsAHigh());
    public static bool IsOffenceLow(Team offence) => (offence == a && IsBLow()) || (offence == b && IsALow());
    public static bool IsDefenceHigh(Team offence) => (offence == a && IsAHigh()) || (offence == b && IsBHigh());
    public static bool IsDefenceLow(Team offence) => (offence == a && IsALow()) || (offence == b && IsBLow());

    //////
    ///Pre game warmup
    //////


    internal static void Warmup()
    {

    }
}