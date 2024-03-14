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

        int count = 0;

        if (InTurn == Hero)
        {
            for (int i = 0; i < 100; i++)
            {
                int rndchance = rnd.Next(100);
                if (rndchance < EnemyDodgeChance)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            defDmg = Hero.Damage / 100;
            dmg = Hero.Damage - (defDmg * Enemy.DEF);
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
