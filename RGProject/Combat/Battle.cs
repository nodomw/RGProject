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
    bool Defeat();
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

    public double HeroCalcDamage(double dmgMultiplier = 1.0, double stunMultiplier = 1.0)
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
                    defDmg = Hero.Damage*dmgMultiplier / 100;
                    dmg = Hero.Damage*dmgMultiplier - (defDmg * Enemy.DEF);
                    Enemy.Health -= dmg;
                    Hero.TempStun = Hero.Stun;
                    Hero.Stun += 20;
                    bloodthirsty = false;
                    if (ChanceSuccessful(Hero.Combo))
                    {
                        if (ChanceSuccessful(Hero.Stun))
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            Hero.Stun = Hero.TempStun;
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy!"));
                            Hero.Stun = Hero.TempStun;
                            InTurn = Enemy;
                        }
                        AnsiConsole.Write(new Markup("\nYou achieved a [gold1]combo[/] and you strike again!"));
                        Console.ReadKey();
                        HeroCalcDamage(dmgMultiplier, stunMultiplier);
                    }
                    else
                    {
                        if (ChanceSuccessful(Hero.Stun))
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            Hero.Stun = Hero.TempStun;
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy!"));
                            Hero.Stun = Hero.TempStun;
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
                        HeroCalcDamage(dmgMultiplier, stunMultiplier);
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
                    if (ChanceSuccessful(Hero.Combo))
                    {
                        if (ChanceSuccessful(Hero.Stun))
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            Hero.Stun = Hero.TempStun;
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy!"));
                            Hero.Stun = Hero.TempStun;
                            InTurn = Enemy;
                        }
                        AnsiConsole.Write(new Markup("\nYou achieved a [gold1]combo[/] and you strike again!"));
                        Console.ReadKey();
                        HeroCalcDamage(dmgMultiplier, stunMultiplier);
                    }
                    else
                    {
                        if (ChanceSuccessful(Hero.Stun))
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            Hero.Stun = Hero.TempStun;
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"You hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy!"));
                            Hero.Stun = Hero.TempStun;
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
                        HeroCalcDamage(dmgMultiplier, stunMultiplier);
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
        }

        return dmg;
    }

    public double EnemyCalcDamage(double dmgMultiplier = 1.0, double stunMultiplier = 1.0)
    {
        double dmg = 0;
        double defDmg = 0;

        if (ChanceSuccessful(Hero.Dodge))
        {
            // Dodge was successful
            InTurn = Hero;
            AnsiConsole.Console.Write(new Markup("The enemy [blue1]dodged[/] the attack!"));
        }
        else
        {
            if (ChanceSuccessful(Enemy.Crit))
            {
                defDmg = Enemy.Damage*dmgMultiplier / 100;
                dmg = Enemy.Damage*dmgMultiplier*2 - (defDmg * Hero.DEF);
                Hero.Health -= dmg;
                Enemy.TempStun = Hero.Stun;
                Enemy.Stun += 20;
                if (ChanceSuccessful(Enemy.Combo))
                {
                    if (ChanceSuccessful(Enemy.Stun))
                    {
                        AnsiConsole.Write(new Markup($"Then enemy hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to you and [yellow1]stunned[/] you!"));
                        Enemy.Stun = Enemy.TempStun;
                        InTurn = Enemy;
                    }
                    else
                    {
                        AnsiConsole.Write(new Markup($"The enemy hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to you!"));
                        Enemy.Stun = Enemy.TempStun;
                        InTurn = Hero;
                    }
                    AnsiConsole.Write(new Markup("\nThe enemy achieved a [gold1]combo[/] and he strikes again!"));
                    Console.ReadKey();
                    EnemyCalcDamage(dmgMultiplier, stunMultiplier);
                }
                else
                {
                    if (ChanceSuccessful(Enemy.Stun))
                    {
                        AnsiConsole.Write(new Markup($"Then enemy hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to you and [yellow1]stunned[/] you!"));
                        Enemy.Stun = Enemy.TempStun;
                        InTurn = Enemy;
                    }
                    else
                    {
                        AnsiConsole.Write(new Markup($"The enemy hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to you!"));
                        Enemy.Stun = Enemy.TempStun;
                        InTurn = Hero;
                    }
                }
            }
            else
            {
                defDmg = Enemy.Damage*dmgMultiplier / 100;
                dmg = Enemy.Damage*dmgMultiplier - (defDmg * Hero.DEF);
                Hero.Health -= dmg;
                if (ChanceSuccessful(Enemy.Combo))
                {
                    if (ChanceSuccessful(Enemy.Stun))
                    {
                        AnsiConsole.Write(new Markup(
                            $"Then enemy hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to you and [yellow1]stunned[/] you!"));
                            InTurn = Enemy;
                    }
                    else
                    {
                        AnsiConsole.Write(new Markup($"The enemy hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to you!"));
                        InTurn = Hero;
                    }

                    AnsiConsole.Write(new Markup("\nThe enemy achieved a [gold1]combo[/] and he strikes again!"));
                    Console.ReadKey();
                    EnemyCalcDamage(dmgMultiplier, stunMultiplier);
                }
                else
                {
                    if (ChanceSuccessful(Enemy.Stun))
                    {
                        AnsiConsole.Write(new Markup($"Then enemy hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to you and [yellow1]stunned[/] you!"));
                        InTurn = Enemy;
                    }
                    else
                    {
                        AnsiConsole.Write(new Markup($"The enemy hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to you!"));
                        InTurn = Hero;
                    }
                }
            }
        }

        return dmg;
    }
    
    public bool Cooldown(int cooldown, int currentRound = 0)
    {
        if (currentRound + cooldown <= turncount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    int turncount = 0;
    int cooldown3 = 3;
    int cooldown3_2 = 3;
    int cooldown4 = 4;

    public bool bloodthirsty = false;
    public ICharacter Turn()
    {
        InTurn = Hero;
        var menu = new Menu(this); // wtf
        double def = 0;

        if (!Defeat() || !Victory())
        {
            if (InTurn == Hero)
            {
                turncount++;
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
                                    HeroCalcDamage();
                                    break;
                                case AssassinAttacks.PoisonDagger:
                                    if (cooldown3 >= 3)
                                    {
                                        HeroCalcDamage(0.4);
                                        cooldown3 = 0;
                                    }
                                    else
                                    {
                                        AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                        Console.ReadKey();
                                        Turn();
                                    }
                                    cooldown3++;
                                    //Next round 50dmg and -50% dmg from enemy
                                    //3 rounds cooldown
                                    break;
                                case AssassinAttacks.ShadowStrike:
                                    if (cooldown4 >= 4)
                                    {
                                        Hero.TempDodge = Hero.Dodge;
                                        Hero.Dodge = 75;
                                        HeroCalcDamage();
                                        Hero.Dodge = Hero.TempDodge;
                                        cooldown4 = 0;
                                    }
                                    else
                                    {
                                        AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                        Console.ReadKey();
                                        Turn();
                                    }
                                    cooldown4++;
                                    //4 rounds cooldown
                                    break;
                            }
                            break;
                        case CharacterType.Elf:
                            ElfAttacks b = menu.ShowElfAttacks();
                            switch (b)
                            {
                                case ElfAttacks.ArrowShot:
                                    HeroCalcDamage();
                                    break;
                                case ElfAttacks.ArrowRain:
                                    if (cooldown3 >= 3)
                                    {
                                        HeroCalcDamage(1.6);
                                        cooldown3 = 0;
                                    }
                                    else
                                    {
                                        AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                        Console.ReadKey();
                                        Turn();
                                    }
                                    cooldown3++;
                                    //3 rounds cooldown
                                    break;
                                case ElfAttacks.ShockingArrow:
                                    if (cooldown3_2 >= 3)
                                    {
                                        HeroCalcDamage(0.6, 5);
                                        cooldown3_2 = 0;
                                    }
                                    else
                                    {
                                        AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                        Console.ReadKey();
                                        Turn();
                                    }
                                    cooldown3_2++;
                                    //3 rounds cooldown
                                    break;
                            }
                            break;
                        case CharacterType.Hero:
                            HeroAttacks c = menu.ShowHeroAttacks();
                            switch (c)
                            {
                                case HeroAttacks.HeroicStrike:
                                    HeroCalcDamage();
                                    break;
                                case HeroAttacks.Crown:
                                    if (cooldown3 >= 3)
                                    {
                                        Hero.TempCrit = Hero.Crit;
                                        Hero.Crit += 25;
                                        HeroCalcDamage(0.3);
                                        Hero.TempDEF = Hero.DEF;
                                        Hero.DEF += 25;
                                        Hero.Crit = Hero.TempCrit;
                                        cooldown3 = 0;
                                    }
                                    else
                                    {
                                        AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                        Console.ReadKey();
                                        Turn();
                                    }
                                    cooldown3++;
                                    //3 rounds cooldown
                                    break;
                                case HeroAttacks.GettingACape:
                                    if (cooldown3_2 >= 3)
                                    {
                                        HeroCalcDamage();
                                        Hero.TempDmg = Hero.Damage;
                                        Hero.TempDEF = Hero.DEF;
                                        //Next 2 rounds
                                        /*Hero.Damage += 20;
                                        Hero.DEF += 10;*/
                                        cooldown3_2 = 0;
                                    }
                                    else
                                    {
                                        AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                        Console.ReadKey();
                                        Turn();
                                    }
                                    cooldown3_2++;
                                    //3 rounds cooldown
                                    break;
                            }
                            break;
                        case CharacterType.Hunter:
                            HunterAttacks d = menu.ShowHunterAttacks();
                            switch (d)
                            {
                                case HunterAttacks.BlastShot:
                                    HeroCalcDamage();
                                    break;
                                case HunterAttacks.Bloodthirsty:
                                    Enemy.Health *= 0.8;
                                    Hero.Damage *= 0.855;
                                    bloodthirsty = true;
                                    //Once/map
                                    break;
                                case HunterAttacks.Explorer:
                                    Hero.Damage *= 0.855;
                                    //Gets a random item on the map
                                    //Once/map
                                    break;
                            }
                            break;
                        case CharacterType.Mage:
                            MageAttacks e = menu.ShowMageAttacks();
                            switch (e)
                            {
                                case MageAttacks.Fireball:
                                    HeroCalcDamage();
                                    break;
                                case MageAttacks.IceShard:
                                    if (cooldown3 >= 3)
                                    {
                                        HeroCalcDamage(0.375);
                                        cooldown3 = 0;
                                        //Next round enemy dmg -50%
                                    }
                                    else
                                    {
                                        AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                        Console.ReadKey();
                                        Turn();
                                    }
                                    cooldown3++;
                                    //3 rounds cooldown
                                    break;
                                case MageAttacks.Thunderbolt:
                                    if (cooldown3_2 >= 3)
                                    {
                                        HeroCalcDamage(1.75);
                                        cooldown3_2 = 0;
                                    }
                                    else
                                    {
                                        AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                        Console.ReadKey();
                                        Turn();
                                    }
                                    cooldown3_2++;
                                    //3 rounds cooldown
                                    break;
                            }
                            break;
                        case CharacterType.Ninja:
                            NinjaAttacks f = menu.ShowNinjaAttacks();
                            if (f != NinjaAttacks.None)
                            {
                                switch (f)
                                {
                                    case NinjaAttacks.SpinningBlades:
                                        HeroCalcDamage();
                                        break;
                                    case NinjaAttacks.SmokeBomb: //???????????????????????
                                        if (cooldown3 >= 3)
                                        {
                                            HeroCalcDamage();
                                            cooldown3 = 0;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                            Turn();
                                        }
                                        cooldown3++;
                                        //3 rounds cooldwon
                                        break;
                                    case NinjaAttacks.SharperDagger:
                                        if (cooldown3_2 >= 3)
                                        {
                                            HeroCalcDamage(1.5);
                                            //Next round enemy -15% dmg
                                            cooldown3_2 = 0;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                            Turn();
                                        }
                                        cooldown3_2++;
                                        //3 rounds cooldown
                                        break;
                                }
                            }
                            break;
                        case CharacterType.Paladin:
                            PaladinAttacks g = menu.ShowPaladinAttacks();
                            switch (g)
                            {
                                case PaladinAttacks.HolyStrike:
                                    HeroCalcDamage();
                                    break;
                                case PaladinAttacks.HolyShield:
                                    if (cooldown3 >= 3)
                                    {
                                        Hero.Health += 500;
                                        //Next round DEF +20%
                                        cooldown3 = 0;
                                    }
                                    else
                                    {
                                        AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                        Console.ReadKey();
                                        Turn();
                                    }
                                    cooldown3++;
                                    //3 rounds cooldown
                                    break;
                                case PaladinAttacks.HolyLight:
                                    if (cooldown3_2 >= 3)
                                    {
                                        Hero.Health -= 300;
                                        HeroCalcDamage(2.667);
                                        //Next round -10% def and -25% catk
                                        cooldown3_2 = 0;
                                    }
                                    else
                                    {
                                        AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                        Console.ReadKey();
                                        Turn();
                                    }
                                    cooldown3_2++;
                                    //3 rounds cooldown
                                    break;
                            }
                            break;
                        case CharacterType.Warrior:
                            WarriorAttacks h = menu.ShowWarriorAttacks();
                            switch (h)
                            {
                                case WarriorAttacks.Slash:
                                    HeroCalcDamage();
                                    break;
                                case WarriorAttacks.ShieldBash:
                                    if (cooldown3 >= 3)
                                    {
                                        Hero.Health += 200;
                                        //Next round DEF +70% and CATK +70%
                                        cooldown3 = 0;
                                    }
                                    else
                                    {
                                        AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                        Console.ReadKey();
                                        Turn();
                                    }
                                    cooldown3++;
                                    //3 rounds cooldown
                                    break;
                                case WarriorAttacks.WarCry:
                                    if (cooldown3_2 >= 3)
                                    {
                                        Hero.TempCombo = Hero.Combo;
                                        Hero.Combo += 45;
                                        HeroCalcDamage(0.5);
                                        Hero.Combo = Hero.TempCombo;
                                        cooldown3_2 = 0;
                                        //Next round +20% DEF
                                    }
                                    else
                                    {
                                        AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                        Console.ReadKey();
                                        Turn();
                                    }
                                    cooldown3_2++;
                                    //3 rounds cooldown
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
                turncount++;
                AnsiConsole.Write(new Markup("The enemy attacks!"));
                EnemyCalcDamage();
            }
        }
        else
        {
            if (Defeat())
            {
                AnsiConsole.Write(new Markup("You are [red1]Defeated[/] by the enemy"));
            }
            else
            {
                AnsiConsole.Write(new Markup("You [green3]Defeated[/] the enemy"));
            }
        }

        return InTurn == Hero ? Enemy : Hero;
    }

    public bool Defeat()
    {
        if(Hero.Health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Victory()
    {
        if(Enemy.Health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public void Dispose() => GC.SuppressFinalize(this);
}
