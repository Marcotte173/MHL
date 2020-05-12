using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Rink {ALOW, AHIGH, NEUTRAL, BHIGH, BLOW };
public enum Offence { None, A, B };
public class Play
{    
    public static Team a;
    public static Team b;
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
    public static Offence offence;
    public static int momentum;

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
                if (offence == Offence.A) WhoGoes(OffenceDecide(a), DefenceDecide(b));
                else WhoGoes(OffenceDecide(b), DefenceDecide(a));
                Result();
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
        int x = 0;
        if ((location == Rink.ALOW  && offence == b )|| (location == Rink.BLOW && offence == a)  )
        {
            int choice = Utilities.RandomInt(1, 8);
            //wristshot
            if (choice == 1 || choice == 2)
            {
                x = carrier.Shooting ;
                offence.teamOffence = TeamOffence.WristShot;
            }
            //onetimer                                 
            if (choice == 3) x = new int[] { 3, (carrier.Passing + carrier.OffAware * 2) / 3 };
            //carry                                    
            if (choice == 4 || choice == 5) x = new int[] { 4, (carrier.Speed * 3 + carrier.Handling * 2) / 5 };
            //pass
            else x = new int[] { 5, carrier.Passing };

        }
        if ((location == Rink.AHIGH && offence == b)|| (location == Rink.BHIGH && offence == a))
        {
            if (carrier.Position == "Forward")
            {
                int choice = Utilities.RandomInt(1, 6);
                //carry
                if (choice == 1 || choice == 2) x = new int[] { 4, (carrier.Speed * 3 + carrier.Handling * 2) / 5 };
                //pass
                else x = new int[] { 5, carrier.Passing };
            }
            if (carrier.Position == "Defence")
            {
                int choice = Utilities.RandomInt(1, 6);
                //wristshot
                if (choice == 1 || choice == 2) x = new int[] { 1, carrier.Shooting };
                //slapshot
                else if (choice == 3 || choice == 4) x = new int[] { 2, carrier.Shooting };
                //pass
                else x = new int[] { 5, carrier.Passing };
            }
        }
        else
        {
            int choice = Utilities.RandomInt(1, 6);
            //carry
            if (choice == 1 || choice == 2) x = new int[] { 4, (carrier.Speed * 3 + carrier.Handling * 2) / 5 };
            //pass 
            else x = new int[] { 5, carrier.Passing };
        }
        return x;
    }

    private static int DefenceDecide(Team defence)
    {
        return 0;
    }

    private static void WhoGoes(int offenceChoice, int defenceChoice)
    {

    }

    private static void Result()
    {
        
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
        if (a.Roster.Contains(p)) offence = Offence.A;
        else offence = Offence.B;
        carrier = p;
    }

    private static void LoosePuck()
    {
        foreach (Player p in a.Roster) p.HasPuck = false;
        foreach (Player p in b.Roster) p.HasPuck = false;
        offence = Offence.None;
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