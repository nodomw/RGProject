﻿using FantasyRPG.Characters;
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
            defDmg = Hero.Damage*dmgMultiplier / 100;
            dmg = Hero.Damage*dmgMultiplier - (defDmg * Enemy.DEF);
            Enemy.Health -= dmg;
            AnsiConsole.Write(new Markup($"You dealt [green3]{dmg}dmg[/] to the enemy!"));
            if (ChanceSuccessful(Hero.Stun*stunMultiplier))
            {
                // Stun was successful
                InTurn = Hero;
                AnsiConsole.Write(new Markup("\nThe enemy is [yellow3_1]stunned![/]"));
            }
            else
            {
                // Stun was not successful
                InTurn = Enemy;
            }
        }

        return dmg;
    }

    public ICharacter Turn()
    {
        InTurn = Hero;
        var menu = new Menu();
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
                                CalcDamage();
                                break;
                            case AssassinAttacks.ShadowStrike:
                                CalcDamage();
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
                            case HeroAttacks.Crown:
                                CalcDamage();
                                break;
                            case HeroAttacks.GettingACape:
                                CalcDamage();
                                break;
                            case HeroAttacks.HeroicStrike:
                                CalcDamage();
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
                                CalcDamage();
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
                double losthp = Hero.Health/100 * 10;
                Hero.Health -= losthp;
                AnsiConsole.Write(new Markup($"You chose run and lost [red1]{losthp}hp[/] during the escape!"));
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
