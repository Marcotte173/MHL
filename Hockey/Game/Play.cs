using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

public enum Rink {ALOW, AHIGH, NEUTRAL, BHIGH, BLOW };
public class Play
{
    public static Team a;
    public static Team b;
    public static Player defenceman;
    public static Player carrier;
    public static Player aCenter;
    public static Player aRightWing;
    public static Player aLeftWing;
    public static Player aRightDefence;
    public static Player aLeftDefence;
    public static Player bCenter;
    public static Player bRightWing;
    public static Player bLeftWing;
    public static Player bRightDefence;
    public static Player bLeftDefence;
    public static Rink location;
    public static Team offence;
    public static Team defence;
    public static int momentum = 0;
    public static int x;
    public static int y;

    /// <summary>
    /// Game itself
    /// </summary>
    /// <param name="game"></param>
    public static void Start(Game game)
    {
        game.Played = true;
        int period = 1;
        int time = 0;
        a = game.A;
        b = game.B;
        ChangeFLinesA(a.Line1);
        ChangeFLinesB(b.Line1);
        ChangeDLinesA(a.Line1);
        ChangeDLinesB(b.Line1);
        LoosePuck();
        FaceOff();
        while (period < 4)
        {
            while (time < 200)
            {
                if (offence == a) WhoGoes(OffenceDecide(a), DefenceDecide(b));
                else WhoGoes(OffenceDecide(b), DefenceDecide(a));
                time++;
            }
            period++;
        }
        if (a.Score != b.Score) GameRecap();
        else
        {
            TieBreak();
            GameRecap();
        }
    }

    //////
    //AI
    //////

    private static int OffenceDecide(Team offence)
    {
        if ((location == Rink.ALOW && offence == b) || (location == Rink.BLOW && offence == a))
        {
            int choice = Utilities.RandomInt(1, 8);
            //wristshot
            if (choice == 1 || choice == 2)
            {
                x = carrier.Shooting;
                offence.teamOffence = TeamOffence.WristShot;
            }
            //onetimer                                 
            if (choice == 3)
            {
                x = (carrier.Passing + carrier.OffAware * 2) / 3;
                offence.teamOffence = TeamOffence.OneTimer;
            }
            //carry                                    
            if (choice == 4 || choice == 5)
            {
                x = (carrier.Speed * 3 + carrier.Handling * 2) / 5;
                offence.teamOffence = TeamOffence.Carry;
            }
            //pass
            else
            {
                x = carrier.Passing;
                offence.teamOffence = TeamOffence.Pass;
            }
        }
        if ((location == Rink.AHIGH && offence == b) || (location == Rink.BHIGH && offence == a))
        {
            if (carrier.Position == "Forward")
            {
                int choice = Utilities.RandomInt(1, 6);
                //carry
                if (choice == 1 || choice == 2)
                {
                    x = (carrier.Speed * 3 + carrier.Handling * 2) / 5;
                    offence.teamOffence = TeamOffence.Carry;
                }
                //pass
                else
                {
                    x = carrier.Passing;
                    offence.teamOffence = TeamOffence.Pass;
                }
            }
            if (carrier.Position == "Defence")
            {
                int choice = Utilities.RandomInt(1, 6);
                //wristshot
                if (choice == 1 || choice == 2)
                {
                    x = carrier.Shooting;
                    offence.teamOffence = TeamOffence.WristShot;
                }
                //slapshot
                else if (choice == 3 || choice == 4)
                {
                    x = carrier.Shooting;
                    offence.teamOffence = TeamOffence.SlapShot;
                }
                //pass
                else
                {
                    x = carrier.Passing;
                    offence.teamOffence = TeamOffence.Pass;
                }
            }
        }
        else
        {
            int choice = Utilities.RandomInt(1, 6);
            //carry
            if (choice == 1 || choice == 2)
            {
                x = (carrier.Speed * 3 + carrier.Handling * 2) / 5;
                offence.teamOffence = TeamOffence.Carry;
            }
            //pass 
            else
            {
                x = carrier.Passing;
                offence.teamOffence = TeamOffence.Pass;
            }
        }
        return x;
    }

    private static int DefenceDecide(Team defence)
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
        if ((location == Rink.ALOW && defence == a) || (location == Rink.BLOW && defence == b))
        {
            int choice = Utilities.RandomInt(1, 10);
            //PokeCheck
            if (choice == 1)
            {
                x = defenceman.DefAware;
                defence.teamDefence = TeamDefence.PokeCheck;
            }
            //Check
            if (choice == 2)
            {
                x = (defenceman.DefAware + defenceman.Checking) / 2;
                defence.teamDefence = TeamDefence.Check;
            }
            //InterceptPass
            if (choice == 3 || choice == 4)
            {
                x = defenceman.DefAware;
                defence.teamDefence = TeamDefence.InterceptPass;
            }
            //Block Shot
            if (choice == 5 || choice == 6 || choice == 7)
            {
                x = defenceman.DefAware;
                defence.teamDefence = TeamDefence.BlockShot;
            }
            //Positioning
            else
            {
                x = defenceman.DefAware;
                defence.teamDefence = TeamDefence.Positioning;
            }
        }
        if ((location == Rink.AHIGH && defence == a) || (location == Rink.BHIGH && defence == b))
        {
            int choice = Utilities.RandomInt(1, 10);
            //PokeCheck
            if (choice == 1 || choice == 2)
            {
                x = defenceman.DefAware;
                defence.teamDefence = TeamDefence.PokeCheck;
            }
            //Check
            if (choice == 3)
            {
                x = (defenceman.DefAware + defenceman.Checking) / 2;
                defence.teamDefence = TeamDefence.Check;
            }
            //InterceptPass
            if (choice == 4 || choice == 5)
            {
                x = defenceman.DefAware;
                defence.teamDefence = TeamDefence.InterceptPass;
            }
            //Block Shot
            if (choice == 6 || choice == 7)
            {
                x = defenceman.DefAware;
                defence.teamDefence = TeamDefence.BlockShot;
            }
            //Positioning
            else
            {
                x = defenceman.DefAware;
                defence.teamDefence = TeamDefence.Positioning;
            }
        }
        //if (location == Rink.NEUTRAL)
        else
        {
            int choice = Utilities.RandomInt(1, 9);
            //PokeCheck
            if (choice == 1 || choice == 2)
            {
                x = defenceman.DefAware;
                defence.teamDefence = TeamDefence.PokeCheck;
            }
            //Check
            if (choice == 3 || choice == 4 || choice == 5)
            {
                x = (defenceman.DefAware + defenceman.Checking) / 2;
                defence.teamDefence = TeamDefence.Check;
            }
            //InterceptPass
            if (choice == 6)
            {
                x = defenceman.DefAware;
                defence.teamDefence = TeamDefence.InterceptPass;
            }
            //Positioning
            else
            {
                x = defenceman.DefAware;
                defence.teamDefence = TeamDefence.Positioning;
            }
        }
        return y;
    }

    private static void WhoGoes(int oSkill, int dSkill)
    {
        //Percentage chance to see who exerts will
        bool offenceWinsRoll = false;
        int roll = Utilities.RandomInt(1, 101);
        roll -= oSkill;
        roll += dSkill;
        roll += momentum;
        //Modifiers based on what each side selected
        if (offence.teamOffence == TeamOffence.SlapShot || offence.teamOffence == TeamOffence.WristShot)
        {
            if (defence.teamDefence == TeamDefence.BlockShot) roll += 5;
            else if (defence.teamDefence == TeamDefence.Check) roll -= 2;
            else if (defence.teamDefence == TeamDefence.InterceptPass) roll -= 15;
        }
        else if (offence.teamOffence == TeamOffence.OneTimer)
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
            else if (defence.teamDefence == TeamDefence.PokeCheck) roll += 4;
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
            if (offence.teamOffence == TeamOffence.WristShot) Actions.WristShot();
            else if (offence.teamOffence == TeamOffence.SlapShot) Actions.SlapShot();
            else if (offence.teamOffence == TeamOffence.OneTimer) Actions.OneTimer();
            else if (offence.teamOffence == TeamOffence.Carry) Actions.Carry();
            else if (offence.teamOffence == TeamOffence.Pass) Actions.Pass();
        }
        else
        {
            if (defence.teamDefence == TeamDefence.BlockShot) Actions.BlockShot();
            else if (defence.teamDefence == TeamDefence.Check) Actions.Check();
            else if (defence.teamDefence == TeamDefence.InterceptPass) Actions.Intercept();
            else if (defence.teamDefence == TeamDefence.PokeCheck) Actions.PokeCheck();
            else if (defence.teamDefence == TeamDefence.Positioning) Actions.Position();
        }
    }

    /// <summary>
    /// After Game
    /// </summary>

    private static void TieBreak()
    {

    }

    private static void GameRecap()
    {

    }


    /// <summary>
    /// Utility - Line changes, faceoffs, etc. Getting people on ice and pucks on their sticks
    /// </summary>
    /// 
    private static void FaceOff()
    {
        int faceoffRoll = Utilities.RandomInt(1, 101);
        int awin = 50 + a.CurrentFLine[1].OffAware - b.CurrentFLine[1].OffAware;
        if (faceoffRoll <= awin) GivePuck(aCenter);
        else bCenter.HasPuck = true; GivePuck(bCenter);
    }

    private static void ChangeFLinesA(Player[] line)
    {
        a.CurrentFLine = line;
        aRightWing = line[0];
        aCenter = line[1];
        aLeftWing = line[2];
    }
    private static void ChangeFLinesB(Player[] line)
    {
        b.CurrentFLine = line;
        bRightWing = line[0];
        bCenter = line[1];
        bLeftWing = line[2];
    }

    private static void ChangeDLinesA(Player[] line)
    {
        a.CurrentDLine = line;
        aRightDefence = line[0];
        aLeftDefence = line[1];
    }
    private static void ChangeDLinesB(Player[] line)
    {
        b.CurrentDLine = line;
        bRightDefence = line[0];
        bLeftDefence = line[1];
    }

    private static void GivePuck(Player p)
    {
        LoosePuck();
        p.HasPuck = true;
        offence = (a.Roster.Contains(p)) ? a : b;
        defence = (a.Roster.Contains(p)) ? b : a;
        carrier = p;
    }

    private static void LoosePuck()
    {
        foreach (Player p in a.Roster) p.HasPuck = false;
        foreach (Player p in b.Roster) p.HasPuck = false;
        offence = null;
        carrier = null;
    }

    /// <summary>
    /// Location checks and functions
    /// </summary>

    internal void ALow() => location = Rink.ALOW;
    internal void AHigh() => location = Rink.AHIGH;
    internal void Neutral() => location = Rink.NEUTRAL;
    internal void BHigh() => location = Rink.BHIGH;
    internal void BLow() => location = Rink.BLOW;
    internal bool IsALow() => location == Rink.ALOW;
    internal bool IsAHigh() => location == Rink.AHIGH;
    internal bool IsNeutral() => location == Rink.NEUTRAL;
    internal bool IsBHigh() => location == Rink.BHIGH;
    internal bool IsBLow() => location == Rink.BLOW;

    //////
    ///Pre game warmup
    //////


    internal static void Warmup()
    {

    }
}