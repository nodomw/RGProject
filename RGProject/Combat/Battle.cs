using FantasyRPG.Characters;
using FantasyRPG.Controller;
using RGProject.Characters.Enemies;
using RGProject.Characters.Heroes;
using Spectre.Console;

namespace FantasyRPG.Combat;

public interface IBattle : IDisposable
{
    Character Hero { get; }
    Character Enemy { get; }
    Character InTurn { get; set; }
    void Initiate();
    Character Turn(); // Advance to next turn
    void Defeat();
}
public class Battle : IBattle // cant really work on this until there is concrete information on how shit should work
{
    public Battle(Character hero, Character enemy)
    {
        Hero = hero;
        Enemy = enemy;
    }
    public Character Hero { get; }
    public Character Enemy { get; }
    public Player Player { get; }
    public Character InTurn { get; set; }
    public void Initiate()
    {
        InTurn = Hero;
        Player.State = State.Fighting;
    }

    private Battle b = new(new Hunter("joni"), new Vampire("gino"));

    public Character Turn()
    {
        Random rnd = new Random();
        double HeroDodgeChance = Hero.Dodge;
        double HeroStunChance = Hero.Stun;
        double EnemyDodgeChance = Enemy.Dodge;
        double EnemyStunChance = Enemy.Stun;
        double dmg = 0;
        double defDmg = 0;

        int countW = 0;
        int countL = 0;

        if (InTurn == Hero)
        {
            for (int i = 0; i < 100; i++)
            {
                int rndchance = rnd.Next(100);
                if (rndchance < EnemyDodgeChance)
                {
                    countW++;
                }
                else
                {
                    countL++;
                }
            }

            if (countW >= countL)
            {
                InTurn = Enemy;
            }
            else
            {
                defDmg = Hero.Damage / 100;
                dmg = Hero.Damage - (defDmg * Enemy.DEF);
            }

            countW = 0;
            countL = 0;

            for (int i = 0; i < 100; i++)
            {
                int rndchance = rnd.Next(100);
                if (rndchance < HeroStunChance)
                {
                    countW++;
                    //InTurn = Hero;
                }
                else
                {
                    countL++;
                    //InTurn = Enemy;
                }
            }

            if (countW >= countL)
            {
                InTurn = Hero;
            }
            else
            {
                InTurn = Hero;
            }

        }
        else
        {
            dmg = Enemy.Damage - Hero.DEF;
        }

        return InTurn == Hero ? Enemy : Hero;
    }
    public void Defeat() { }
    public void Dispose() => GC.SuppressFinalize(this);
}
