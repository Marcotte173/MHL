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
        int num = Utilities.RandomInt(0, 3);
        while (Game.goalScorer == line[num])
        {
            num = Utilities.RandomInt(0, 3);
        }
        Player shooter = line[num];
        Game.assist1 = Game.goalScorer;
        Game.goalScorer = shooter;
        Console.WriteLine($"{Game.assist1.Name} passes the puck to {Game.goalScorer.Name}\n He shoots!");
        shooter.Team.Shots++;        
        if ((shooter.Shooting + shooter.OffAware) / 2 + Utilities.RandomInt(0, 15) > goalie.Agility + Utilities.RandomInt(0, 18))
        {
            Console.WriteLine($"HE SCORES!\n{shooter.Name} puts one past the goalie!");
            shooter.GoalStat++;
            Game.assist1.AssistStat++;
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