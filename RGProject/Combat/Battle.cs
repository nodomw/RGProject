using FantasyRPG.Characters;
using FantasyRPG.Controller;
using FantasyRPG.UI;
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

    Random rnd = new Random();
    public bool ChanceSuccessful(double chance)
    {
        int randomNumber = rnd.Next(101); // Generates a random number between 0 and 100 inclusive
        return randomNumber < chance;
    }

    public Character Turn()
    {
        var menu = new Menu();
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
            AnsiConsole.Write(new Markup("It's your turn!"));
            string move = menu.ShowBattleMenu();

            if (move == "Attack")
            {
                switch (Hero.Type)
                {
                    case CharacterType.Hero:
                        menu.ShowHeroAttacks();
                        break;
                    case CharacterType.Warrior:
                        menu.ShowWarriorAttacks();
                        break;
                    case CharacterType.Assassin:
                        menu.ShowAssassinAttacks();
                        break;
                    case CharacterType.Paladin:
                        menu.ShowPaladinAttacks();
                        break;
                    case CharacterType.Hunter:
                        menu.ShowHunterAttacks();
                        break;
                    case CharacterType.Ninja:
                        menu.ShowNinjaAttacks();
                        break;
                    case CharacterType.Elf:
                        menu.ShowElfAttacks();
                        break;
                    case CharacterType.Mage:
                        menu.ShowMageAttacks();
                        break;
                }
            }
            else if(move == "Defend" )
            {

            }
            else if (move == "Use item")
            {

            }
            else if (move == "Information")
            {
                switch (Hero.Type)
                {
                    case CharacterType.Hero:
                        menu.ShowHeroInfo();
                        break;
                    case CharacterType.Warrior:
                        menu.ShowWarriorInfo();
                        break;
                    case CharacterType.Assassin:
                        menu.ShowAssassinInfo();
                        break;
                    case CharacterType.Paladin:
                        menu.ShowPaladinInfo();
                        break;
                    case CharacterType.Hunter:
                        menu.ShowHunterInfo();
                        break;
                    case CharacterType.Ninja:
                        menu.ShowNinjaInfo();
                        break;
                    case CharacterType.Elf:
                        menu.ShowElfInfo();
                        break;
                    case CharacterType.Mage:
                        menu.ShowMageInfo();
                        break;
                }
            }
            else
            {
                AnsiConsole.Write(new Markup("You chose run!"));
            }

            if (ChanceSuccessful(EnemyDodgeChance))
            {
                // Dodge was successful
                InTurn = Enemy;
            }
            else
            {
                // Dodge was not successful
                defDmg = Hero.Damage / 100;
                dmg = Hero.Damage - (defDmg * Enemy.DEF);
                Enemy.Health -= dmg;
                if (ChanceSuccessful(HeroStunChance))
                {
                    // Stun was successful
                    InTurn = Hero;
                }
                else
                {
                    // Stun was not successful
                    InTurn = Enemy;
                }
            }

            countW = 0;
            countL = 0;

        }
        else
        {
            AnsiConsole.Write(new Markup("The enemy attacks!"));
            if (ChanceSuccessful(HeroDodgeChance))
            {
                // Dodge was successful
                InTurn = Hero;
            }
            else
            {
                // Dodge was not successful
                defDmg = Enemy.Damage / 100;
                dmg = Enemy.Damage - (defDmg * Hero.DEF);
                Hero.Health -= dmg;
                if (ChanceSuccessful(EnemyStunChance))
                {
                    // Stun was successful
                    InTurn = Hero;
                }
                else
                {
                    // Stun was not successful
                    InTurn = Enemy;
                }
            }
        }

        return InTurn == Hero ? Enemy : Hero;
    }
    public void Defeat() { }
    public void Dispose() => GC.SuppressFinalize(this);
}
