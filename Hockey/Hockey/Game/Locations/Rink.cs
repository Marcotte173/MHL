using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

public class Rink
{
    public Rink()
    {

    }
    public virtual void OneTimer(Player[] line, Player goalie)
    {
        for (int i = 0; i < line.Length; i++)
        {
            if (Game.goalScorer == line[i]) line[i] = null;
        }
        Player shooter = null;
        while (shooter == null)
        {
            if (line[Utilities.RandomInt(0, 3)] != null) shooter = line[Utilities.RandomInt(0, 3)];

        }
        if (Game.assist1 != null) Game.assist2 = Game.assist1;
        Game.assist1 = Game.goalScorer;
        Game.goalScorer = shooter;
        Console.WriteLine($"{Game.assist1} passes the puck to {Game.goalScorer}\n He shoots!");
        shooter.Team.Shots++;        
        if ((shooter.Shooting + shooter.OffAware) / 2 + Utilities.RandomInt(0, 15) > goalie.Agility + Utilities.RandomInt(0, 18))
        {
            Console.WriteLine($"HE SCORES!\n{shooter.Name} puts one past the goalie!");
            shooter.GoalStat++;
            if (Game.assist1 != null) Game.assist1.AssistStat++;
            if (Game.assist2 != null) Game.assist2.AssistStat++;
            shooter.Team.Score++;
        }
        else
        {
            Console.WriteLine($"BIG SAVE!\n{goalie.Name} comes up with a big save to keep his team out of trouble");
            Thread.Sleep(300);
            Game.Faceoff(false);  
        }
    }

    public virtual void WristShot(Player shooter, Player goalie)
    {

    }

    public virtual void Slapshot(Player shooter, Player goalie)
    {

    }

    public virtual void Pass(Player[] line, Player goalie)
    {

    }

    public virtual void Carry(Player carrier)
    {

    }
    public virtual void BlockShot()
    {

    }
    public virtual void PokeCheck()
    {

    }
    public virtual void Check()
    {

    }

    public virtual void InterceptPass()
    {

    }
    public virtual void Positioning()
    {

    }
}