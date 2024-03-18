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
    public int Turns { get; set; }
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

    public double CalcDamage(double dmgMultiplier = 1.0, double stunMultiplier = 1.0)
    {
        double dmg = 0;
        double defDmg = 0;

        if (ChanceSuccessful(Enemy.Dodge))
        {
            // Dodge was successful
            InTurn = Enemy;
            AnsiConsole.Console.Write(new Markup("The enemy [blue1]dodged[/] the attack!"));
        }
        else
        {
            // Dodge was not successful
            if (bloodthirsty)
            {
                if (ChanceSuccessful(Hero.Crit))
                {
                    dmg = Enemy.Health * 0.80;
                    Enemy.Health -= dmg;
                    Hero.TempStun = Hero.Stun;
                    Hero.Stun += 20;
                    bloodthirsty = false;
                    if (ChanceSuccessful(Hero.Combo))
                    {
                        if (ChanceSuccessful(Hero.Stun))
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy!"));
                            InTurn = Enemy;
                        }
                        AnsiConsole.Write(new Markup("\nYou achieved a [gold1]combo[/] and you strike again!"));
                        Console.ReadKey();
                        CalcDamage(dmgMultiplier, stunMultiplier);
                    }
                    else
                    {
                        if (ChanceSuccessful(Hero.Stun))
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy!"));
                            InTurn = Enemy;
                        }
                    }

                }
                else
                {
                    defDmg = Hero.Damage*dmgMultiplier / 100;
                    dmg = Hero.Damage*dmgMultiplier - (defDmg * Enemy.DEF);
                    Enemy.Health -= dmg;
                    if (ChanceSuccessful(Hero.Combo))
                    {
                        if (ChanceSuccessful(Hero.Stun))
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy!"));
                            InTurn = Enemy;
                        }
                        AnsiConsole.Write(new Markup("\nYou achieved a [gold1]combo[/] and you strike again!"));
                        Console.ReadKey();
                        CalcDamage(dmgMultiplier, stunMultiplier);
                    }
                    else
                    {
                        if (ChanceSuccessful(Hero.Stun))
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy!"));
                            InTurn = Enemy;
                        }
                    }
                }
            }
            else
            {
                if (ChanceSuccessful(Hero.Crit))
                {
                    defDmg = Hero.Damage*dmgMultiplier / 100;
                    dmg = Hero.Damage*dmgMultiplier*2 - (defDmg * Enemy.DEF);
                    Enemy.Health -= dmg;
                    Hero.TempStun = Hero.Stun;
                    Hero.Stun += 20;
                    if (ChanceSuccessful(Hero.Stun))
                    {
                        AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                        InTurn = Hero;
                    }
                    else
                    {
                        AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy!"));
                        InTurn = Enemy;
                    }

                }
                else
                {
                    defDmg = Hero.Damage*dmgMultiplier / 100;
                    dmg = Hero.Damage*dmgMultiplier - (defDmg * Enemy.DEF);
                    Enemy.Health -= dmg;
                    if (ChanceSuccessful(Hero.Stun))
                    {
                        AnsiConsole.Write(new Markup($"You dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                        InTurn = Hero;
                    }
                    else
                    {
                        AnsiConsole.Write(new Markup($"You dealt [green3]{dmg}dmg[/] to the enemy!"));
                        InTurn = Enemy;
                    }
                }
            }
        }

        return dmg;
    }

    public bool bloodthirsty = true;
    public ICharacter Turn()
    {
        InTurn = Hero;
        var menu = new Menu(this); // wtf
        double def = 0;

        if (InTurn == Hero)
        {
            AnsiConsole.Write(new Markup("It's your turn!"));
            string move = menu.ShowBattleMenu();

            if (move == "Attack")
            {
                switch (Hero.Type)
                {
                    case CharacterType.Assassin:
                        AssassinAttacks a = menu.ShowAssassinAttacks();
                        switch (a)
                        {
                            case AssassinAttacks.DaggerStrike:
                                CalcDamage();
                                break;
                            case AssassinAttacks.PoisonDagger:
                                CalcDamage(0.4);
                                break;
                            case AssassinAttacks.ShadowStrike:
                                CalcDamage();
                                Hero.TempDodge = Hero.Dodge;
                                Hero.Dodge = 75;
                                break;
                        }
                        break;
                    case CharacterType.Elf:
                        ElfAttacks b = menu.ShowElfAttacks();
                        switch (b)
                        {
                            case ElfAttacks.ArrowShot:
                                CalcDamage();
                                break;
                            case ElfAttacks.ArrowRain:
                                CalcDamage(1.6);
                                break;
                            case ElfAttacks.ShockingArrow:
                                CalcDamage(0.6, 5);
                                break;
                        }
                        break;
                    case CharacterType.Hero:
                        HeroAttacks c = menu.ShowHeroAttacks();
                        switch (c)
                        {
                            case HeroAttacks.HeroicStrike:
                                CalcDamage();
                                break;
                            case HeroAttacks.Crown:
                                Hero.TempCrit = Hero.Crit;
                                Hero.Crit += 25;
                                CalcDamage(0.3);
                                Hero.TempDEF = Hero.DEF;
                                Hero.DEF += 25;
                                Hero.Crit = Hero.TempCrit;
                                break;
                            case HeroAttacks.GettingACape:
                                CalcDamage();
                                Hero.TempDmg = Hero.Damage;
                                Hero.TempDEF = Hero.DEF;
                                Hero.Damage += 20;
                                Hero.DEF += 10;
                                break;
                        }
                        break;
                    case CharacterType.Hunter:
                        HunterAttacks d = menu.ShowHunterAttacks();
                        switch (d)
                        {
                            case HunterAttacks.BlastShot:
                                CalcDamage();
                                break;
                            case HunterAttacks.Bloodthirsty:
                                Enemy.Health *= 0.8;
                                Hero.Damage *= 0.855;
                                bloodthirsty = true;
                                AnsiConsole.Write(new Markup("You used [red1]Bloodthirsty[/] and dealt 20% of the enemy's health and increased your stun by 10%"));
                                break;
                            case HunterAttacks.Explorer:
                                CalcDamage();
                                break;
                        }
                        break;
                    case CharacterType.Mage:
                        MageAttacks e = menu.ShowMageAttacks();
                        switch (e)
                        {
                            case MageAttacks.Fireball:
                                CalcDamage();
                                break;
                            case MageAttacks.IceShard:
                                CalcDamage();
                                break;
                            case MageAttacks.Thunderbolt:
                                CalcDamage();
                                break;
                        }
                        break;
                    case CharacterType.Ninja:
                        NinjaAttacks f = menu.ShowNinjaAttacks();
                        if (f != NinjaAttacks.None)
                        {
                            switch (f)
                            {
                                case NinjaAttacks.SharperDagger:
                                    CalcDamage();
                                    break;
                                case NinjaAttacks.SmokeBomb:
                                    CalcDamage();
                                    break;
                                case NinjaAttacks.SpinningBlades:
                                    CalcDamage();
                                    break;
                            }
                        }
                        break;
                    case CharacterType.Paladin:
                        PaladinAttacks g = menu.ShowPaladinAttacks();
                        switch (g)
                        {
                            case PaladinAttacks.HolyStrike:
                                CalcDamage();
                                break;
                            case PaladinAttacks.HolyShield:
                                CalcDamage();
                                break;
                            case PaladinAttacks.HolyLight:
                                CalcDamage();
                                break;
                        }
                        break;
                    case CharacterType.Warrior:
                        WarriorAttacks h = menu.ShowWarriorAttacks();
                        switch (h)
                        {
                            case WarriorAttacks.Slash:
                                CalcDamage();
                                break;
                            case WarriorAttacks.ShieldBash:
                                CalcDamage();
                                break;
                            case WarriorAttacks.WarCry:
                                CalcDamage();
                                break;
                        }
                        break;
                }
            }
            else if(move == "Defend" )
            {
                def = Hero.DEF + (25 * (Hero.DEF / 100));
            }
            else if (move == "Use Item")
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
            else if(move == "Run")
            {
                double losthp = Hero.Health/100 * 10;
                Hero.Health -= losthp;
                AnsiConsole.Write(new Markup($"You chose run and lost [red1]{losthp}hp[/] during the escape!"));
            }
            else
            {
                AnsiConsole.Write(new Markup("404 Choice not found!"));
                Console.ReadKey();
                Turn();
            }
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
                double defDmg = Enemy.Damage / 100;
                double dmg = Enemy.Damage - (defDmg * Hero.DEF);
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
