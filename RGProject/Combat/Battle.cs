using FantasyRPG.Characters;
using FantasyRPG.Controller;
using FantasyRPG.UI;
using RGProject.Characters.Enemies;
using RGProject.Characters.Heroes;
using Spectre.Console;

namespace FantasyRPG.Combat;

public interface IBattle : IDisposable
{
    ICharacter Hero { get; }
    ICharacter Enemy { get; }
    ICharacter InTurn { get; set; }
    void Initiate();
    ICharacter Turn(); // Advance to next turn
    void Defeat();
}
public class Battle : IBattle
{
    public Battle(ICharacter hero, ICharacter enemy)
    {
        Hero = hero;
        Enemy = enemy;
    }
    public ICharacter Hero { get; }
    public ICharacter Enemy { get; }
    public Player Player { get; }
    public ICharacter InTurn { get; set; }
    public void Initiate()
    {
        InTurn = Hero;
        Player.State = State.Fighting;
    }

    Random rnd = new Random();
    public bool ChanceSuccessful(double chance)
    {
        int randomNumber = rnd.Next(101);
        return randomNumber < (int)chance;
    }

    public ICharacter Turn()
    {
        InTurn = Hero;
        var menu = new Menu();
        double dmg = 0;
        double defDmg = 0;
        double def = 0;

        int countW = 0;
        int countL = 0;

        for (int i = 0; i < 100; i++)
        {
            if (ChanceSuccessful(Hero.Stun))
            {
                countW++;
            }
            else
            {
                countL++;
            }
        }

        Console.WriteLine("Stun: " + countW + " Lose: " + countL);

        countW = 0;
        countL = 0;

        for (int i = 0; i < 100; i++)
        {
            if (ChanceSuccessful(Hero.Dodge))
            {
                countW++;
            }
            else
            {
                countL++;
            }
        }

        Console.WriteLine("Dodge: " + countW + " Lose: "+countL);

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
                def = Hero.DEF + (25 * (Hero.DEF / 100));
            }
            else if (move == "Use item")
            {
                menu.ShowItemMenu();
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
                double losthp = Hero.Health/100 * 5;
                Hero.Health -= losthp;
                AnsiConsole.Write(new Markup($"You chose run and lost [red1]{losthp}hp[/] during the escape!"));
            }

            if (ChanceSuccessful(Enemy.Dodge))
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
                if (ChanceSuccessful(Hero.Stun))
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
            if (ChanceSuccessful(Hero.Dodge))
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
                if (ChanceSuccessful(Enemy.Stun))
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
