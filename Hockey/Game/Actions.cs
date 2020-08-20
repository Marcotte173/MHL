using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class Actions
{
    internal static void Pass(Player p, Team offence)
    {
        List<Player> available = new List<Player> { };
        Player receive;
        if (offence == Play.a)
        {
            foreach (Player player in Play.aOnIce) if (player != Play.carrier[0]) available.Add(player);
            int roll = Utilities.RandomInt(0, available.Count);
            receive = available[roll];
        }
        else
        {
            foreach (Player player in Play.aOnIce) if (player != Play.carrier[0]) available.Add(player);
            int roll = Utilities.RandomInt(0, available.Count);
            receive = available[roll];
        }
        Play.playByPlay.Add(p.Name + " passes to " + receive.Name);
        Play.Display();
        Play.GivePuck(receive);
        if (Utilities.RandomInt(0, 100) < 40)
        {
            if (Play.IsOffenceLow(receive.Team)) Play.playByPlay.Add(receive.Name + " moves the puck, looking for a better shot ");
            else  if (Play.IsOffenceHigh(receive.Team)) Play.playByPlay.Add(receive.Name + " advances the puck further into the opponent's zone ");
            else if (Play.IsNeutral()) Play.playByPlay.Add(receive.Name + " advances the puck into the neutral zone ");
            else if (Play.IsDefenceHigh(receive.Team)) Play.playByPlay.Add(receive.Name + " advances the puck ");
            else if (Play.IsDefenceLow(receive.Team )) Play.playByPlay.Add(receive.Name + " advances the puck ");
            Advance();
        }
        Play.Display();
    }
    internal static void SlapShot(Player p, Team offence)
    {
        if (offence == Play.a) Play.gameAShot++;
        else Play.gameBShot++;
        Play.playByPlay.Add(p.Name + " winds up for a slapshot!");
        Play.Display();
        Thread.Sleep(300);
        if ((p.Shooting + p.OffAware) / 2 + Utilities.RandomInt(0, 15) > Play.defence.StartingGoalie.Angles + Utilities.RandomInt(0, 18))
        {
            Play.playByPlay.Add($"HE SCORES!\n{p.Name} puts one past the goalie!");
            p.GoalStat++;
            p.Team.Score++;
            if (offence == Play.a) Play.gameAGoal++;
            else Play.gameBGoal++;
        }
        else
        {
            Play.playByPlay.Add($"BIG SAVE!\n{Play.defence.StartingGoalie.Name} comes up with a big save to keep his team out of trouble");
            Play.Display();
            Thread.Sleep(300);            
            Play.FaceOff();
            Play.PlayGame();
        }
        Play.Display();
    }
    internal static void WristShot(Player p, Team offence)
    {
        p.Team.Shots++;
        Advance();
        Play.playByPlay.Add(p.Name + " takes a quick wristshot!");
        Play.Display();
        Thread.Sleep(300);
        if ((p.Shooting + p.OffAware) / 2 + Utilities.RandomInt(0, 15) > (Play.defence.StartingGoalie.Stick + Play.defence.StartingGoalie.Glove)/2 + Utilities.RandomInt(0, 18))
        {
            Play.playByPlay.Add($"HE SCORES!\n{p.Name} puts one past the goalie!");
            p.GoalStat++;
            p.Team.Score++;
            if (offence == Play.a) Play.gameAGoal++;
            else Play.gameBGoal++;
        }
        else
        {
            Play.playByPlay.Add($"BIG SAVE!\n{Play.defence.StartingGoalie.Name} comes up with a big save to keep his team out of trouble");
            Play.Display();
            Thread.Sleep(300);
            Play.FaceOff();
            Play.PlayGame();
        }
        Play.Display();
    }
    internal static void OneTimer(Player p, Team offence)
    {
        offence.Shots++;
        List<Player> available = new List<Player> { };
        Player receive;
        foreach (Player player in offence.CurrentFLine) 
            if (player != Play.carrier[0]) available.Add(player);
        int roll = Utilities.RandomInt(0, available.Count);
        receive = available[roll];
        Play.playByPlay.Add(p.Name + " passes to " + receive.Name);
        Play.GivePuck(receive);
        Play.playByPlay.Add(receive.Name + " shoots immediately! ");
        Play.Display();
        Thread.Sleep(300);
        if ((receive.Shooting + receive.OffAware) / 2 + Utilities.RandomInt(0, 15) > Play.defence.StartingGoalie.Agility + Utilities.RandomInt(0, 18))
        {
            Play.playByPlay.Add($"HE SCORES!\n{receive.Name} puts one past the goalie!");
            receive.GoalStat++;
            if (offence == Play.a) Play.gameAGoal++;
            else Play.gameBGoal++;
            if (Play.carrier.Count > 1)
            {
                Play.playByPlay.Add($"{Play.carrier[1].Name} gets the assist!");
                Play.carrier[1].AssistStat++;
            }
            if (Play.carrier.Count > 2)
            {
                Play.playByPlay.Add($"{Play.carrier[2].Name} gets the assist!");
                Play.carrier[2].AssistStat++;
            }
            receive.Team.Score++;
        }
        else
        {
            Play.playByPlay.Add($"BIG SAVE!\n{Play.defence.StartingGoalie.Name} comes up with a big save to keep his team out of trouble");
            Play.Display();
            Thread.Sleep(300);
            Play.FaceOff();
            Play.PlayGame();
        }
    }
    internal static void Carry(Player p)
    {
        if (Play.IsOffenceLow(p.Team)) Play.playByPlay.Add(p.Name + " moves the puck, looking for a better shot ");
        else if (Play.IsOffenceHigh(p.Team)) Play.playByPlay.Add(p.Name + " advances the puck further into the opponent's zone ");
        else if (Play.IsNeutral()) Play.playByPlay.Add(p.Name + " advances the puck into the neutral zone ");
        else if (Play.IsDefenceHigh(p.Team)) Play.playByPlay.Add(p.Name + " advances the puck ");
        else if (Play.IsDefenceLow(p.Team)) Play.playByPlay.Add(p.Name + " advances the puck ");
        Advance();
        Play.Display();
    }
    internal static void BlockShot(Player p)
    {
        Play.playByPlay.Add(p.Name + " gets in front of the puck. The puck is loose!");
        Play.LoosePuck();
        Play.Display();
    }
    internal static void Intercept(Player p)
    {
        Play.playByPlay.Add(p.Name + " intercepts the pass!");
        Play.GivePuck(p);
        Play.Display();
    }
    internal static void Check(Player p)
    {
        Play.playByPlay.Add(p.Name + " checks " + Play.carrier[0].Name +" off the puck");
        Play.LoosePuck();
        Play.Display();
    }
    internal static void PokeCheck(Player p)
    {
        Play.playByPlay.Add(p.Name + " uses his stick to poke the puck away from " + Play.carrier[0].Name);
        Play.LoosePuck();
        Play.Display();
    }
    internal static void Position(Player p)
    {
        Play.momentum = -2;
        Play.playByPlay.Add(p.Name + " uses positioning to prevent " + Play.carrier[0].Name + " from moving forward");
        Play.Display();
    }
    internal static void Retrieve(Player p)
    {
        Play.playByPlay.Add(p.Name + " retrieves the puck");
        Play.GivePuck(p);
        Play.Display();
    }

    public static void Advance()
    {
        if (Play.offence == Play.a)
        {
            if (Play.IsALow()) Play.AHigh();
            else if (Play.IsAHigh()) Play.Neutral();
            else if (Play.IsNeutral()) Play.BHigh();
            else if (Play.IsBHigh()) Play.BLow();
            else Play.BLow();
        }
        else
        {
            if (Play.IsBLow()) Play.BHigh();
            else if (Play.IsBHigh()) Play.Neutral();
            else if (Play.IsNeutral()) Play.AHigh();
            else if (Play.IsAHigh()) Play.ALow();
            else Play.ALow();
        }
    }

    public static void Regress()
    {
        if (Play.offence == Play.b)
        {
            if (Play.IsALow()) Play.AHigh();
            else if (Play.IsAHigh()) Play.Neutral();
            else if (Play.IsNeutral()) Play.BHigh();
            else if (Play.IsBHigh()) Play.BLow();
            else Play.BLow();
        }
        else
        {
            if (Play.IsBLow()) Play.BHigh();
            else if (Play.IsBHigh()) Play.Neutral();
            else if (Play.IsNeutral()) Play.AHigh();
            else if (Play.IsAHigh()) Play.ALow();
            else Play.ALow();
        }
    }    
}