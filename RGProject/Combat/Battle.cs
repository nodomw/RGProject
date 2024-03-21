﻿using System.Runtime.CompilerServices;
using FantasyRPG.Characters;
using FantasyRPG.UI;
using RGProject.Characters.Heroes;
using Spectre.Console;

 namespace FantasyRPG.Combat;

public interface IBattle : IDisposable
{
    ICharacter Hero { get; }
    ICharacter Enemy { get; }
    ICharacter InTurn { get; set; }
    void Initiate();
    void Turn(); // Advance to next turn
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
    public ICharacter InTurn { get; set; }
    public int Turns { get; set; }
    public void Initiate()
    {
        InTurn = Hero;
    }

    Random rnd = new Random();
    public bool ChanceSuccessful(double chance)
    {
        int randomNumber = rnd.Next(101);
        return randomNumber <= (int)chance;
    }

    public double HeroCalcDamage(double dmgMultiplier = 1.0, double stunMultiplier = 1.0)
    {
        double dmg = 0;
        double defDmg = 0;

        Hero.TempCrit = Hero.Crit;
        Hero.TempDmg = Hero.Damage;
        Hero.TempDEF = Hero.DEF;
        Hero.TempStun = Hero.Stun;
        Hero.TempCombo = Hero.Combo;
        Hero.TempCATK = Hero.CATK;
        Enemy.TempDmg = Enemy.Damage;
        Enemy.TempDEF = Enemy.DEF;
        Enemy.TempStun = Enemy.Stun;
        Enemy.TempCombo = Enemy.Combo;
        Enemy.TempCATK = Enemy.CATK;
        Enemy.TempCrit = Enemy.Crit;

        AnsiConsole.Clear();

        switch (Hero.Type)
        {
            case CharacterType.Assassin:
                AnsiConsole.Write(new Markup($"You chose {a}!"));
                break;
            case CharacterType.Elf:
                AnsiConsole.Write(new Markup($"You chose {b}!"));
                break;
            case CharacterType.Hero:
                AnsiConsole.Write(new Markup($"You chose {c}!"));
                break;
            case CharacterType.Hunter:
                AnsiConsole.Write(new Markup($"You chose {d}!"));
                break;
            case CharacterType.Mage:
                AnsiConsole.Write(new Markup($"You chose {e}!"));
                break;
            case CharacterType.Ninja:
                AnsiConsole.Write(new Markup($"You chose {f}!"));
                break;
            case CharacterType.Paladin:
                AnsiConsole.Write(new Markup($"You chose {g}!"));
                break;
            case CharacterType.Warrior:
                AnsiConsole.Write(new Markup($"You chose {h}!"));
                break;
        }

        switch (Hero.Type)
        {
            case CharacterType.Hero:
                if (GettingACape2)
                {
                    if (turncooldown2_2 > 0)
                    {
                        Hero.Damage *= 1.2;
                        AnsiConsole.Write(new Markup("\nYou used [green3]Getting a Cape[/] and increased your [green3]Dmg[/] by 20% and [green3]DEF[/] by 10%!"));
                        turncooldown2_2--;
                    }
                    else
                    {
                        GettingACape2 = false;
                    }
                }
                break;
            case CharacterType.Ninja:
                if (SmokeBomb)
                {
                    if (turncooldown == 1)
                    {
                        Hero.Damage *= 0.8;
                        AnsiConsole.Write(new Markup("\nYou used a [green3]Smoke Bomb[/] and attacked again (-20% dmg for you)!"));
                        turncooldown = 0;
                    }
                    else
                    {
                        SmokeBomb = false;
                    }
                }
                break;
            case CharacterType.Paladin:
                if (HolyLight)
                {
                    if (turncooldown_2 == 1)
                    {
                        Enemy.DEF *= 0.9;
                        Enemy.CATK *= 0.75;
                        AnsiConsole.Write(new Markup("\nThe enemy is [red1]weakened[/] (-10% def, -25% catk) by your [green3]Holy Light[/]!"));
                        turncooldown_2 = 0;
                    }
                    else
                    {
                        HolyLight = false;
                    }
                }
                break;
        }

        if (ChanceSuccessful(Enemy.Dodge))
        {
            // Dodge was successful
            InTurn = Enemy;
            AnsiConsole.Console.Write(new Markup("\nThe enemy [blue1]dodged[/] the attack!"));
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
                    Hero.Stun += 20;
                    bloodthirsty = false;
                    if (ChanceSuccessful(Hero.Combo))
                    {
                        if (ChanceSuccessful(Hero.Stun))
                        {
                            AnsiConsole.Write(new Markup($"\nYou hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            Hero.Stun = Hero.TempStun;
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"\nYou hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy!"));
                            Hero.Stun = Hero.TempStun;
                            if (ChanceSuccessful(Enemy.CATK))
                            {
                                AnsiConsole.Write(new Markup("\nThe enemy performed a [red1]Counter Attack[/]!"));
                                Console.ReadKey();
                                EnemyCalcDamage();
                            }
                        }
                        AnsiConsole.Write(new Markup("\nYou achieved a [gold1]combo[/] and you strike again!"));
                        HeroCalcDamage(dmgMultiplier, stunMultiplier);
                    }
                    else
                    {
                        if (ChanceSuccessful(Hero.Stun))
                        {
                            AnsiConsole.Write(new Markup($"\nYou hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            Hero.Stun = Hero.TempStun;
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"\nYou hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy!"));
                            Hero.Stun = Hero.TempStun;
                            if (ChanceSuccessful(Enemy.CATK))
                            {
                                AnsiConsole.Write(new Markup("\nThe enemy performed a [red1]Counter Attack[/]!"));
                                Console.ReadKey();
                                EnemyCalcDamage();
                            }
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
                            AnsiConsole.Write(new Markup($"\nYou dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"\nYou dealt [green3]{dmg}dmg[/] to the enemy!"));
                            InTurn = Enemy;
                        }
                        AnsiConsole.Write(new Markup("\nYou achieved a [gold1]combo[/] and you strike again!"));
                        HeroCalcDamage(dmgMultiplier, stunMultiplier);
                    }
                    else
                    {
                        if (ChanceSuccessful(Hero.Stun))
                        {
                            AnsiConsole.Write(new Markup($"\nYou dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"\nYou dealt [green3]{dmg}dmg[/] to the enemy!"));
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
                    Hero.Stun += 20;
                    if (ChanceSuccessful(Hero.Combo))
                    {
                        if (ChanceSuccessful(Hero.Stun))
                        {
                            AnsiConsole.Write(new Markup($"\nYou hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            Hero.Stun = Hero.TempStun;
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"\nYou hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy!"));
                            Hero.Stun = Hero.TempStun;
                            if (ChanceSuccessful(Enemy.CATK))
                            {
                                AnsiConsole.Write(new Markup("\nThe enemy performed a [red1]Counter Attack[/]!"));
                                Console.ReadKey();
                                EnemyCalcDamage();
                            }
                        }
                        AnsiConsole.Write(new Markup("\nYou achieved a [gold1]combo[/] and you strike again!"));
                        HeroCalcDamage(dmgMultiplier, stunMultiplier);
                    }
                    else
                    {
                        if (ChanceSuccessful(Hero.Stun))
                        {
                            AnsiConsole.Write(new Markup($"\nYou hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            Hero.Stun = Hero.TempStun;
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"\nYou hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to the enemy!"));
                            Hero.Stun = Hero.TempStun;
                            if (ChanceSuccessful(Enemy.CATK))
                            {
                                AnsiConsole.Write(new Markup("\nThe enemy performed a [red1]Counter Attack[/]!"));
                                Console.ReadKey();
                                EnemyCalcDamage();
                            }
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
                            AnsiConsole.Write(new Markup($"\nYou dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"\nYou dealt [green3]{dmg}dmg[/] to the enemy!"));
                            if (ChanceSuccessful(Enemy.CATK))
                            {
                                AnsiConsole.Write(new Markup("\nThe enemy performed a [red1]Counter Attack[/]!"));
                                Console.ReadKey();
                                EnemyCalcDamage();
                            }
                            InTurn = Enemy;
                        }
                        AnsiConsole.Write(new Markup("\nYou achieved a [gold1]combo[/] and you strike again!"));
                        HeroCalcDamage(dmgMultiplier, stunMultiplier);
                    }
                    else
                    {
                        if (ChanceSuccessful(Hero.Stun))
                        {
                            AnsiConsole.Write(new Markup($"\nYou dealt [green3]{dmg}dmg[/] to the enemy and [yellow1]stunned[/] it!"));
                            InTurn = Hero;
                        }
                        else
                        {
                            AnsiConsole.Write(new Markup($"\nYou dealt [green3]{dmg}dmg[/] to the enemy!"));
                            if (ChanceSuccessful(Enemy.CATK))
                            {
                                AnsiConsole.Write(new Markup("\nThe enemy performed a [red1]Counter Attack[/]!"));
                                Console.ReadKey();
                                EnemyCalcDamage();
                            }
                            InTurn = Enemy;
                        }
                    }
                }
            }
        }

        Hero.Damage = Hero.TempDmg;
        Hero.DEF = Hero.TempDEF;
        Hero.Stun = Hero.TempStun;
        Hero.Combo = Hero.TempCombo;
        Hero.CATK = Hero.TempCATK;
        Hero.Crit = Hero.TempCrit;
        Enemy.Damage = Enemy.TempDmg;
        Enemy.DEF = Enemy.TempDEF;
        Enemy.Stun = Enemy.TempStun;
        Enemy.Combo = Enemy.TempCombo;
        Enemy.CATK = Enemy.TempCATK;
        Enemy.Crit = Enemy.TempCrit;

        Console.ReadKey();
        return dmg;
    }

    private double EnemyCalcDamage(double dmgMultiplier = 1.0)
    {
        double dmg = 0;

        Enemy.TempDmg = Enemy.Damage;
        Enemy.TempDEF = Enemy.DEF;
        Enemy.TempStun = Enemy.Stun;
        Enemy.TempCombo = Enemy.Combo;
        Enemy.TempCATK = Enemy.CATK;
        Enemy.TempCrit = Enemy.Crit;
        Hero.TempCrit = Hero.Crit;
        Hero.TempDmg = Hero.Damage;
        Hero.TempDEF = Hero.DEF;
        Hero.TempStun = Hero.Stun;
        Hero.TempCombo = Hero.Combo;
        Hero.TempCATK = Hero.CATK;

        AnsiConsole.Clear();
        AnsiConsole.Write(new Markup("The enemy attacks!"));

        switch (Hero.Type)
        {
            case CharacterType.Assassin:
                if (PosionDaggers)
                {
                    if (turncooldown == 1)
                    {
                        Enemy.Health -= 50;
                        Enemy.Damage *= 0.5;
                        AnsiConsole.Write(new Markup("\nThe enemy is [green3]poisoned[/], weakened (-50% dmg), and takes [red1]50dmg[/]!"));
                        turncooldown = 0;
                    }
                    else
                    {
                        PosionDaggers = false;
                    }
                }
                break;
            case CharacterType.Elf:
                if (ArrowRain)
                {
                    if (turncooldown == 1)
                    {
                        Enemy.Stun *= 0.85;
                        Enemy.Combo *= 0.85;
                        AnsiConsole.Write(new Markup("\nThe enemy is [red1]weakened[/] (-15% stun, -15% combo) by your [green3]Arrow Rain[/]!"));
                        turncooldown = 0;
                    }
                    else
                    {
                        ArrowRain = false;
                    }
                }
                break;
            case CharacterType.Hero:
                if (Crown)
                {
                    if (turncooldown == 1)
                    {
                        Hero.DEF += 25;
                        AnsiConsole.Write(new Markup("\nYou used [green3]Crown[/] and increased your [red1]DEF[/] by 25%!"));
                        turncooldown = 0;
                    }
                    else
                    {
                        Crown = false;
                    }
                }
                if (GettingACape1)
                {
                    if (turncooldown2 > 0)
                    {
                        Hero.DEF *= 1.1;
                        AnsiConsole.Write(new Markup("\nYou used [green3]Getting a Cape[/] and increased your [green3]Dmg[/] by 20% and [green3]DEF[/] by 10%!"));
                        turncooldown2--;
                    }
                    else
                    {
                        GettingACape1 = false;
                    }
                }
                break;
            case CharacterType.Mage:
                if (IceShard)
                {
                    if (turncooldown == 1)
                    {
                        Enemy.Damage *= 0.5;
                        AnsiConsole.Write(new Markup("\nThe enemy is [red1]weakened[/] (-50% dmg) by your [green3]Ice Shard[/]!"));
                        turncooldown = 0;
                    }
                    else
                    {
                        IceShard = false;
                    }
                }
                break;
            case CharacterType.Paladin:
                if (HolyShield)
                {
                    if (turncooldown == 1)
                    {
                        Hero.DEF *= 1.2;
                        AnsiConsole.Write(new Markup("\nYou used [green3]Holy Shield[/] and increased your [red1]DEF[/] by 20%!"));
                        turncooldown = 0;
                    }
                    else
                    {
                        HolyShield = false;
                    }
                }
                break;
            case CharacterType.Ninja:
                if (SharperDagger)
                {
                    if (turncooldown_2 == 1)
                    {
                        Enemy.Damage *= 0.85;
                        AnsiConsole.Write(new Markup("\nThe enemy is [red1]weakened[/] (-15% dmg) by your [green3]Sharper Dagger[/]!"));
                        turncooldown_2 = 0;
                    }
                    else
                    {
                        SharperDagger = false;
                    }
                }
                break;
            case CharacterType.Warrior:
                if (ShieldBash)
                {
                    if (turncooldown == 1)
                    {
                        Hero.CATK *= 1.7;
                        Hero.DEF *= 1.7;
                        AnsiConsole.Write(new Markup("\nYou used [green3]Shield Bash[/] and increased your [green3]Dmg[/] and [red1]DEF[/] by 70%!"));
                        turncooldown = 0;
                    }
                    else
                    {
                        ShieldBash = false;
                    }
                }
                if (WarCry)
                {
                    if (turncooldown_2 == 1)
                    {
                        Hero.DEF *= 1.2;
                        AnsiConsole.Write(new Markup("\nYou used [green3]War Cry[/] and increased your [red1]DEF[/] by 20%!"));
                        turncooldown_2 = 0;
                    }
                    else
                    {
                        WarCry = false;
                    }
                }
                break;

        }

        if (ChanceSuccessful(Hero.Dodge))
        {
            // Dodge was successful
            InTurn = Hero;
            AnsiConsole.Console.Write(new Markup("\nYou [blue1]dodged[/] the attack!"));
        }
        else
        {
            double defDmg;

            if (ChanceSuccessful(Enemy.Crit))
            {
                defDmg = Enemy.Damage*dmgMultiplier / 100;
                dmg = Enemy.Damage*dmgMultiplier*2 - (defDmg * Hero.DEF);
                Hero.Health -= dmg;
                Enemy.Stun += 20;
                if (ChanceSuccessful(Enemy.Combo))
                {
                    if (ChanceSuccessful(Enemy.Stun))
                    {
                        AnsiConsole.Write(new Markup($"\nThen enemy hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to you and [yellow1]stunned[/] you!"));
                        Enemy.Stun = Enemy.TempStun;
                        InTurn = Enemy;
                    }
                    else
                    {
                        AnsiConsole.Write(new Markup($"\nThe enemy hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to you!"));
                        Enemy.Stun = Enemy.TempStun;
                        if (ChanceSuccessful(Hero.CATK))
                        {
                            AnsiConsole.Write(new Markup("\nYou performed a [red1]Counter Attack[/]!"));
                            Console.ReadKey();
                            HeroCalcDamage();
                        }
                    }
                    AnsiConsole.Write(new Markup("\nThe enemy achieved a [gold1]combo[/] and he strikes again!"));
                    EnemyCalcDamage(dmgMultiplier);
                }
                else
                {
                    if (ChanceSuccessful(Enemy.Stun))
                    {
                        AnsiConsole.Write(new Markup($"\nThen enemy hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to you and [yellow1]stunned[/] you!"));
                        Enemy.Stun = Enemy.TempStun;
                        InTurn = Enemy;
                    }
                    else
                    {
                        AnsiConsole.Write(new Markup($"\nThe enemy hit a [red1]critical[/] point and dealt [green3]{dmg}dmg[/] to you!"));
                        Enemy.Stun = Enemy.TempStun;
                        if (ChanceSuccessful(Hero.CATK))
                        {
                            AnsiConsole.Write(new Markup("\nYou performed a [red1]Counter Attack[/]!"));
                            Console.ReadKey();
                            HeroCalcDamage();
                        }
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
                        AnsiConsole.Write(new Markup($"\nThen enemy dealt [green3]{dmg}dmg[/] to you and [yellow1]stunned[/] you!"));
                        InTurn = Enemy;
                    }
                    else
                    {
                        AnsiConsole.Write(new Markup($"\nThe enemy dealt [green3]{dmg}dmg[/] to you!"));
                        if (ChanceSuccessful(Hero.CATK))
                        {
                            AnsiConsole.Write(new Markup("\nYou performed a [red1]Counter Attack[/]!"));
                            Console.ReadKey();
                            HeroCalcDamage();
                        }
                    }

                    AnsiConsole.Write(new Markup("\nThe enemy achieved a [gold1]combo[/] and he strikes again!"));
                    EnemyCalcDamage(dmgMultiplier);
                }
                else
                {
                    if (ChanceSuccessful(Enemy.Stun))
                    {
                        AnsiConsole.Write(new Markup($"\nThen enemy dealt [green3]{dmg}dmg[/] to you and [yellow1]stunned[/] you!"));
                        InTurn = Enemy;
                    }
                    else
                    {
                        AnsiConsole.Write(new Markup($"\nThe enemy dealt [green3]{dmg}dmg[/] to you!"));
                        if (ChanceSuccessful(Hero.CATK))
                        {
                            AnsiConsole.Write(new Markup("\nYou performed a [red1]Counter Attack[/]!"));
                            Console.ReadKey();
                            HeroCalcDamage();
                        }
                        InTurn = Hero;
                    }
                }
            }
        }

        Enemy.Damage = Enemy.TempDmg;
        Enemy.DEF = Enemy.TempDEF;
        Enemy.Stun = Enemy.TempStun;
        Enemy.Combo = Enemy.TempCombo;
        Enemy.CATK = Enemy.TempCATK;
        Enemy.Crit = Enemy.TempCrit;
        Hero.Damage = Hero.TempDmg;
        Hero.DEF = Hero.TempDEF;
        Hero.Stun = Hero.TempStun;
        Hero.Combo = Hero.TempCombo;
        Hero.CATK = Hero.TempCATK;
        Hero.Crit = Hero.TempCrit;

        Console.ReadKey();
        return dmg;
    }

    int turncooldown = 0;
    int turncooldown_2 = 0;
    int turncooldown2 = 0;
    int turncooldown2_2 = 0;

    bool ShieldBash = false;
    bool WarCry = false;
    bool HolyShield = false;
    bool Crown = false;
    bool GettingACape1 = false;
    bool GettingACape2 = false;
    bool SharperDagger = false;
    bool PosionDaggers = false;
    bool IceShard = false;
    bool ArrowRain = false;
    bool HolyLight = false;
    bool SmokeBomb = false;

    int cooldown3 = 3;
    int cooldown3_2 = 3;
    int cooldown4 = 4;

    bool bloodthirsty = false;
    bool runaway = false;

    private AssassinAttacks a;
    private ElfAttacks b;
    private HeroAttacks c;
    private HunterAttacks d;
    private MageAttacks e;
    private NinjaAttacks f;
    private PaladinAttacks g;
    private WarriorAttacks h;

    public void Turn()
    {
        InTurn = Hero;
        var menu = new Menu(this); // wtf
        double def = 0;

        bool correctatk = false;

        while (!Defeat() && !Victory() && !runaway)
        {
            if (InTurn == Hero)
            {
                cooldown3++;
                cooldown3_2++;
                cooldown4++;
                while (!correctatk)
                {
                    string move = menu.ShowBattleMenu();

                    if (move == "Attack")
                    {
                        switch (Hero.Type)
                        {
                            case CharacterType.Assassin:
                                a = menu.ShowAssassinAttacks();
                                switch (a)
                                {
                                    case AssassinAttacks.DaggerStrike:
                                        HeroCalcDamage();
                                        correctatk = true;
                                        break;
                                    case AssassinAttacks.PoisonDagger:
                                        if (cooldown3 >= 3)
                                        {
                                            HeroCalcDamage(0.4);
                                            cooldown3 = 0;
                                            PosionDaggers = true;
                                            turncooldown = 1;
                                            correctatk = true;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                        }
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
                                            correctatk = true;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                        }
                                        //4 rounds cooldown
                                        break;
                                }
                                break;
                            case CharacterType.Elf:
                                b = menu.ShowElfAttacks();
                                switch (b)
                                {
                                    case ElfAttacks.ArrowShot:
                                        HeroCalcDamage();
                                        correctatk = true;
                                        break;
                                    case ElfAttacks.ArrowRain:
                                        if (cooldown3 >= 3)
                                        {
                                            ArrowRain = true;
                                            HeroCalcDamage(1.6);
                                            cooldown3 = 0;
                                            ArrowRain = true;
                                            turncooldown = 1;
                                            correctatk = true;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                        }
                                        //3 rounds cooldown
                                        break;
                                    case ElfAttacks.ShockingArrow:
                                        if (cooldown3_2 >= 3)
                                        {
                                            HeroCalcDamage(0.6, 5);
                                            cooldown3_2 = 0;
                                            correctatk = true;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                        }
                                        //3 rounds cooldown
                                        break;
                                }
                                break;
                            case CharacterType.Hero:
                                c = menu.ShowHeroAttacks();
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
                                            Crown = true;
                                            HeroCalcDamage(0.3);
                                            Hero.Crit = Hero.TempCrit;
                                            cooldown3 = 0;
                                            Crown = true;
                                            turncooldown = 1;
                                            correctatk = true;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                        }
                                        //3 rounds cooldown
                                        break;
                                    case HeroAttacks.GettingACape:
                                        if (cooldown3_2 >= 3)
                                        {
                                            HeroCalcDamage();
                                            cooldown3_2 = 0;
                                            GettingACape1 = true;
                                            GettingACape2 = true;
                                            turncooldown2 = 2;
                                            turncooldown2_2 = 2;
                                            correctatk = true;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                        }
                                        //3 rounds cooldown
                                        break;
                                }
                                break;
                            case CharacterType.Hunter:
                                d = menu.ShowHunterAttacks();
                                switch (d)
                                {
                                    case HunterAttacks.BlastShot:
                                        HeroCalcDamage();
                                        correctatk = true;
                                        break;
                                    case HunterAttacks.Bloodthirsty:
                                        Enemy.Health *= 0.8;
                                        Hero.Damage *= 0.855;
                                        bloodthirsty = true;
                                        correctatk = true;
                                        //Once/map
                                        break;
                                    case HunterAttacks.Explorer:
                                        Hero.Damage *= 0.855;
                                        correctatk = true;
                                        //Gets a random item on the map
                                        //Once/map
                                        break;
                                }
                                break;
                            case CharacterType.Mage:
                                e = menu.ShowMageAttacks();
                                switch (e)
                                {
                                    case MageAttacks.Fireball:
                                        HeroCalcDamage();
                                        correctatk = true;
                                        break;
                                    case MageAttacks.IceShard:
                                        if (cooldown3 >= 3)
                                        {
                                            IceShard = true;
                                            HeroCalcDamage(0.375);
                                            cooldown3 = 0;
                                            IceShard = true;
                                            turncooldown = 1;
                                            correctatk = true;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                        }
                                        //3 rounds cooldown
                                        break;
                                    case MageAttacks.Thunderbolt:
                                        if (cooldown3_2 >= 3)
                                        {
                                            HeroCalcDamage(1.75);
                                            cooldown3_2 = 0;
                                            correctatk = true;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                        }
                                        //3 rounds cooldown
                                        break;
                                }
                                break;
                            case CharacterType.Ninja:
                                f = menu.ShowNinjaAttacks();
                                switch (f)
                                {
                                    case NinjaAttacks.SpinningBlades:
                                        HeroCalcDamage();
                                        correctatk = true;
                                        break;
                                    case NinjaAttacks.SmokeBomb:
                                        if (cooldown3 >= 3)
                                        {
                                            HeroCalcDamage();
                                            cooldown3 = 0;
                                            SmokeBomb = true;
                                            turncooldown = 1;
                                            correctatk = true;
                                            InTurn = Hero;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                        }
                                        //3 rounds cooldown
                                        break;
                                    case NinjaAttacks.SharperDagger:
                                        if (cooldown3_2 >= 3)
                                        {
                                            SharperDagger = true;
                                            HeroCalcDamage(1.5);
                                            cooldown3_2 = 0;
                                            SharperDagger = true;
                                            turncooldown_2 = 1;
                                            correctatk = true;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                        }
                                        //3 rounds cooldown
                                        break;
                                }
                                break;
                            case CharacterType.Paladin:
                                 g = menu.ShowPaladinAttacks();
                                switch (g)
                                {
                                    case PaladinAttacks.HolyStrike:
                                        HeroCalcDamage();
                                        correctatk = true;
                                        break;
                                    case PaladinAttacks.HolyShield:
                                        if (cooldown3 >= 3)
                                        {
                                            Hero.Health += 500;
                                            cooldown3 = 0;
                                            HolyShield = true;
                                            turncooldown = 1;
                                            correctatk = true;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                        }
                                        //3 rounds cooldown
                                        break;
                                    case PaladinAttacks.HolyLight:
                                        if (cooldown3_2 >= 3)
                                        {
                                            Hero.Health -= 300;
                                            HeroCalcDamage(2.667);
                                            cooldown3_2 = 0;
                                            HolyLight = true;
                                            turncooldown_2 = 1;
                                            correctatk = true;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                        }
                                        //3 rounds cooldown
                                        break;
                                }
                                break;
                            case CharacterType.Warrior:
                                h = menu.ShowWarriorAttacks();
                                switch (h)
                                {
                                    case WarriorAttacks.Slash:
                                        HeroCalcDamage();
                                        correctatk = true;
                                        break;
                                    case WarriorAttacks.ShieldBash:
                                        if (cooldown3 >= 3)
                                        {
                                            Hero.Health += 200;
                                            cooldown3 = 0;
                                            ShieldBash = true;
                                            turncooldown = 1;
                                            correctatk = true;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                        }
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
                                            WarCry = true;
                                            turncooldown_2 = 1;
                                            correctatk = true;
                                        }
                                        else
                                        {
                                            AnsiConsole.Write(new Markup("You can't use this attack yet!"));
                                            Console.ReadKey();
                                        }
                                        //3 rounds cooldown
                                        break;
                                }
                                break;
                        }
                    }
                    else if(move == "Defend" )
                    {
                        if (SmokeBomb)
                        {
                            SmokeBomb = false;
                        }
                        correctatk = true;
                        def = Hero.DEF + (25 * (Hero.DEF / 100));
                        AnsiConsole.Write(new Markup($"You chose defend and increased your DEF by [green3]{25 * (Hero.DEF / 100)}[/]!"));
                        Console.ReadKey();
                        InTurn = Enemy;
                    }
                    else if (move == "Use Item")
                    {
                        if (SmokeBomb)
                        {
                            SmokeBomb = false;
                        }
                        correctatk = true;
                        menu.ShowItemMenu();
                        InTurn = Enemy;
                    }
                    else if (move == "Information")
                    {
                        correctatk = true;
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
                        if (SmokeBomb)
                        {
                            SmokeBomb = false;
                        }
                        correctatk = true;
                        double losthp = Hero.Health/100 * 10;
                        Hero.Health -= losthp;
                        AnsiConsole.Write(new Markup($"You chose run and lost [red1]{losthp}hp[/] during the escape!"));
                        Console.ReadKey();
                        runaway = true;
                        break;
                    }
                    else
                    {
                        correctatk = true;
                        AnsiConsole.Write(new Markup("404 Choice not found!"));
                        Console.ReadKey();

                    }
                }
                correctatk = false;
            }
            else
            {
                EnemyCalcDamage();
                // correctatk = false;
            }
        }


        if (Defeat())
        {

            Console.Clear();
            AnsiConsole.Write(new Markup("You are [red1]Defeated[/] by the enemy!"));
        }
        else if(Victory())
        {
            Console.Clear();
            if (Enemy.IsBoss)
            {
                AnsiConsole.Write(new Markup("You [green3]Defeated[/] the map's boss and earned [gold1]1000XP[/]!"));
                Hero.XP += 1000;
            }
            else
            {
                AnsiConsole.Write(new Markup("You [green3]Defeated[/] the enemy and earned [gold1]100XP[/]!"));
                Hero.XP += 100;
            }

            switch (Hero.Level)
            {
                case 0:
                    if (Hero.XP >= 1000)
                    {
                        Hero.Level++;
                        AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and all of your [gold1]stats[/] are increased by 10%!\nYou also unlocked your first ability, and you can now your first special item, if you found it!"));
                    }
                    if (Hero.XP >= 1500)
                    {
                        Hero.Level++;
                        AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and your [green3]hp[/] and [red1]dmg[/] are increased by 20%!\nYou also unlocked your second ability!"));
                    }
                    break;
                case 1:
                    if (Hero.XP >= 1500)
                    {
                        Hero.Level++;
                        AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and your [green3]hp[/] and [red1]dmg[/] are increased by 10%!\nYou also unlocked your second ability!"));
                    }
                    if (Hero.XP >= 2200)
                    {
                        Hero.Level++;
                        AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and your [green3]hp[/] and [red1]dmg[/] are increased by 20%!\nYou can also use your second special item, if you found it!"));
                    }
                    break;
                case 2:
                    if (Hero.XP >= 2200)
                    {
                        Hero.Level++;
                        AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and your [green3]hp[/] and [red1]dmg[/] are increased by 20%!\nYou can also use your second special item, if you found it!"));
                    }
                    if (Hero.XP >= 3200)
                    {
                        Hero.Level++;
                        AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and your [green3]hp[/] and [red1]dmg[/] are increased by 20%!"));
                    }
                    break;
                case 3:
                    if (Hero.XP >= 3200)
                    {
                        Hero.Level++;
                        AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and your [green3]hp[/] and [red1]dmg[/] are increased by 20%!"));
                    }
                    if (Hero.XP >= 4500)
                    {
                        Hero.Level++;
                        AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and your [green3]hp[/] and [red1]dmg[/] are increased by 20% and all of your [gold1]stats[/] are increased by 10%!"));
                    }
                    break;
                case 4:
                    if (Hero.XP >= 4500)
                    {
                        Hero.Level++;
                        AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and reached [gold1]MAX[/] level!\nYour [green3]hp[/] and [red1]dmg[/] are increased by 20% and all of your [gold1]stats[/] are increased by 10%!"));
                    }
                    break;
            }

        }
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