using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using FantasyRPG.Characters;
using FantasyRPG.Combat;
using RGProject.Characters.Enemies;
using RGProject.Characters.Heroes;
using Spectre.Console;

namespace FantasyRPG.UI;

public class Menu(Battle battle)
{
    // TODO: get the classes n shit from the external part
    public Battle battle { get; set; } = battle;
    public string currentmenu = "";

    public void PreviousMenu()
    {
        switch (currentmenu)
        {
            case "ShowElfInfo" or "ShowWarriorInfo" or "ShowMageInfo" or "ShowAssassinInfo" or "ShowPaladinInfo" or "ShowHeroInfo" or "ShowHunterInfo" or "ShowNinjaInfo":
                battle.Turn();
                break;
            case "ShowElfAttacks" or "ShowWarriorAttacks" or "ShowMageAttacks" or "ShowAssassinAttacks" or "ShowPaladinAttacks" or "ShowHeroAttacks" or "ShowHunterAttacks" or "ShowNinjaAttacks":
                battle.Turn();
                break;
        }
    }
    // Starting the game
    public void Show()
    {
        currentmenu = "Show";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select an option, use arrow keys to navigate.")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more Options.)[/]")
                .AddChoices(new[]
                {
                    "[gray]New Game[/]",
                    "[green]Load Game[/]",
                    "[red]Exit[/]"
                }));

        hero = hero.Split('[', ']')[2];

        if (hero == "New Game")
        {
            ShowCharSelection();
        }
        else if (hero == "Load Game")
        {
            Console.WriteLine("Loading Game...");
            Console.ReadKey();
        }
        else if (hero == "Exit")
        {
            AnsiConsole.Write(new Markup("See you next time [red1]Adventurer[/]!"));

            Environment.Exit(0);
        }

    }

    public ICharacter ShowCharSelection()
    {
        currentmenu = "ShowCharSelection";

        Console.Clear();
        var @class = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose your [green]Character[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Assassin", "Elf", "Hero", "Hunter", "Mage", "Ninja", "Paladin", "Warrior"
                }));

        string name = ShowCharCreation();
        ICharacter hero = @class switch
        {
            "Warrior" => new Warrior(name),
            "Mage" => new Mage(name),
            "Elf" => new Elf(name),
            "Assassin" => new Assassin(name),
            "Paladin" => new Paladin(name),
            "Hero" => new Hero(name),
            "Hunter" => new Hunter(name),
            "Ninja" => new Ninja(name),
            _ => throw new ArgumentOutOfRangeException()
        };
        AnsiConsole.WriteLine($"You chose {hero.Name}, who is a(n) {@class}! Good luck on your adventure!");
        Console.ReadKey();
        return hero;
    }

    public string ShowCharCreation()
    {
        currentmenu = "ShowCharCreation";

        Console.Clear();
        AnsiConsole.WriteLine($"Enter your character's name: ");
        return Console.ReadLine();
    }

    public void ShowMaps()
    {
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose the [green]Map[/] you want to play on!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "First Map", "Second Map", "Third Map", "Fourth Map", "[red]Exit[/]"
                }));
    }

    /*-----------------------------------------------------------------------------------------------------------------------------------------------------*/
    // During the game

    public void ShowMainMenu()
    {
        currentmenu = "ShowMainMenu";

        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Main Menu")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "[white]Continue[/]", "[green]Save[/]", "[red]Exit[/]"
                }));
    }

    public void ShowInGameMenu()
    {
        currentmenu = "ShowInGameMenu";

        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Game Menu")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Show Stats", "Show Inventory", "Show Equipment", "Show Skills", "Show Map", "[red]Exit[/]"
                }));
    }

    public void ShowInventoryMenu()
    {
        currentmenu = "ShowInventoryMenu";

        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[gold1]Inventory[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Use Item", "Equip Item", "[red]Exit[/]"
                }));
    }

    public void ShowEquipMenu()
    {
        currentmenu = "ShowEquipMenu";

        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Equip one item!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Equip Weapon", "Equip Armor", "[red]Exit[/]"
                }));
    }

    public string ShowItemMenu()
    {
        currentmenu = "ShowItemMenu";

        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose the [yellow]Item[/] you want to use!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Use Health Potion", "Use Mana Potion", "[red]Exit[/]"
                }));

        return hero;
    }

    /*-----------------------------------------------------------------------------------------------------------------------------------------------------*/
    // During battle

    public string ShowBattleMenu()
    {
        currentmenu = "ShowBattleMenu";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose your [red]Move[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Attack", "Defend", "Use Item", "Information", "[red]Run[/]"
                }));

        return hero;
    }

    public void ShowWarriorInfo()
    {
        currentmenu = "ShowWarriorInfo";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 10% hp",
                    "Defend: increases your defense by 25%" ,
                    "Slash: basic attack",
                    "Shield bash: gives 200 hp but deals 0 damage, in the next round you will gain 70% defence and counter-attack" ,
                    "War cry: deals 200 damage and boosts your combo to 45%. Next round you will gain 20% defence." ,
                    "[red]Exit[/]"
                }));

        if (hero != "[red]Exit[/]")
        {
            ShowWarriorInfo();
        }
        else
        {
            PreviousMenu();
        }
    }

    public WarriorAttacks ShowWarriorAttacks()
    {
        currentmenu = "ShowWarriorAttacks";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose your [red]Attack[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Slash", "Shield Bash", "War Cry", "[red]Exit[/]"
                }));

        switch (hero)
        {
            case "Slash":
                return WarriorAttacks.Slash;
            case "Shield Bash":
                return WarriorAttacks.ShieldBash;
            case "War Cry":
                return WarriorAttacks.WarCry;
            default:
                PreviousMenu();
                return WarriorAttacks.None;
        }
    }

    public void ShowMageInfo()
    {
        currentmenu = "ShowMageInfo";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 10% hp",
                    "Defend: increases your defense by 25%",
                    "Fireball: Basic attack, deals 400 damage",
                    "Ice shard: deals 150 damage and in the next round the enemy only deals 50% damage.",
                    "Thunderbolt: deals 700 damage. Cooldown: 3 rounds!",
                    "[red]Exit[/]"
                }));

        if (hero != "[red]Exit[/]")
        {
            ShowMageInfo();
        }
        else
        {
            PreviousMenu();
        }
    }

    public MageAttacks ShowMageAttacks()
    {
        currentmenu = "ShowMageAttacks";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose your [red]Attack[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Fireball", "Ice Shard", "Thunderbolt", "[red]Exit[/]"
                }));

        switch (hero)
        {
            case "Fireball":
                return MageAttacks.Fireball;
            case "Ice Shard":
                return MageAttacks.IceShard;
             case "Thunderbolt":
                return MageAttacks.Thunderbolt;
            default:
                PreviousMenu();
                return MageAttacks.None;
        }
    }

    public void ShowElfInfo()
    {
        currentmenu = "ShowElfInfo";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 10% hp",
                    "Defend: increases your defense by 25%",
                    "Arrow shot: basic attack, deals 500 damage",
                    "Arrow rain: deals 800 damage and in the next round you will lose 15% stun and combo",
                    "Shocking arrow: deals 300 damage while giving you a 60% stun",
                    "[red]Exit[/]"
                }));

        if (hero != "[red]Exit[/]")
        {
            ShowElfInfo();
        }
        else
        {
            PreviousMenu();
        }
    }

    public ElfAttacks ShowElfAttacks()
    {
        currentmenu = "ShowElfAttacks";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose your [red]Attack[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Arrow Shot", "Arrow Rain", "Shocking Arrow", "[red]Exit[/]"
                }));

        switch (hero)
        {
            case "Arrow Shot":
                return ElfAttacks.ArrowShot;
            case "Arrow Rain":
                return ElfAttacks.ArrowRain;
            case "Shocking Arrow":
                return ElfAttacks.ShockingArrow;
            default:
                PreviousMenu();
                return ElfAttacks.None;
        }
    }

    public void ShowAssassinInfo()
    {
        currentmenu = "ShowAssassinInfo";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Every ability has a 3 rounds cooldown, except for the basic attack.",
                    "Run: you lose 10% hp",
                    "Defend: increases your defense by 25%",
                    "Dagger strike: Basic attack, deals 600 damage",
                    "Poison strike: deals 200 damage. In the next round you will damage your enemy with 50hp and sets the enemy damage to 50%",
                    "Shadow strike: Deals 0 damage and sets dodge to 70% and every other stats to 0%. Cooldown? 4 rounds",
                    "[red]Exit[/]"
                }));

        if (hero != "[red]Exit[/]")
        {
            ShowAssassinInfo();
        }
        else
        {
            PreviousMenu();
        }
    }

    public AssassinAttacks ShowAssassinAttacks()
    {
        currentmenu = "ShowAssassinAttacks";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose your [red]Attack[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Dagger Strike", "Poison Dagger", "Shadow Strike", "[red]Exit[/]"
                }));

        switch (hero)
        {
            case "Dagger Strike":
                return AssassinAttacks.DaggerStrike;
            case "Poison Dagger":
                return AssassinAttacks.PoisonDagger;
            case "Shadow Strike":
                return AssassinAttacks.ShadowStrike;
            default:
                PreviousMenu();
                return AssassinAttacks.None;
        }
    }

    public void ShowPaladinInfo()
    {
        currentmenu = "ShowPaladinInfo";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 10% hp",
                    "Defend: increases your defense by 25%",
                    "Holy strike: basic attack, deals 300 damage",
                    "Holy shield: doesnt deal damage but gives you 300 hp, and in next round boosts your defence by 15%",
                    "Holy light: 800 damage but damages you for 300 and the next round you lose 25% counter-attack and 10% defense. 3 round cooldown.",
                    "[red]Exit[/]"
                }));

        if (hero != "[red]Exit[/]")
        {
           ShowPaladinInfo();
        }
        else
        {
            PreviousMenu();
        }
    }

    public PaladinAttacks ShowPaladinAttacks()
    {
        currentmenu = "ShowPaladinAttacks";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose your [red]Attack[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Holy Strike", "Holy Shield", "Holy Light", "[red]Exit[/]"
                }));

        switch (hero)
        {
            case "Holy Strike":
                return PaladinAttacks.HolyStrike;
            case "Holy Shield":
                return PaladinAttacks.HolyShield;
            case "Holy Light":
                return PaladinAttacks.HolyLight;
            default:
                PreviousMenu();
                return PaladinAttacks.None;
        }
    }

    public void ShowHeroInfo()
    {
        currentmenu = "ShowHeroInfo";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 10% hp",
                    "Defend: increases your defense by 25%",
                    "Heroic strike:",
                    "Crown: deals 100 damage and givs you 25% critical damage. The next round you will gain 25% defence. 3 round cooldown",
                    "Getting a cape: The next 2 rounds you will gain 20% dmg and 10% def. 3 rounds cooldown.",
                    "[red]Exit[/]"
                }));

        if (hero != "[red]Exit[/]")
        {
            ShowHeroInfo();
        }
        else
        {
            PreviousMenu();
        }
    }

    public HeroAttacks ShowHeroAttacks()
    {
        currentmenu = "ShowHeroAttacks";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose your [red]Attack[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Heroic Strike", "Crown", "Getting a cape", "[red]Exit[/]"
                }));

        switch (hero)
        {
            case "Heroic Strike":
                return HeroAttacks.HeroicStrike;
            case "Crown":
                return HeroAttacks.Crown;
            case "Getting a cape":
                return HeroAttacks.GettingACape;
            default:
                PreviousMenu();
                return HeroAttacks.None;
        }
    }

    public void ShowHunterInfo()
    {
        currentmenu = "ShowHunterInfo";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 10% hp",
                    "Defend: increases your defense by 25%",
                    "Blast shot: basic attack, deals 700 damage",
                    "Bloodthristy: -20% from the enemy's health, and boosting your stun by 10%, but your damage is decreasing by 14,5% for this map. Can be used only once/map after 3 hit!",
                    "Explorer: Gives you 1 random item which can be found on the current map. After it's used your damage is decreasing by 14,5% for this map. Can be used once/map",
                    "[red]Exit[/]"
                }));

        if (hero != "[red]Exit[/]")
        {
            ShowHunterInfo();
        }
        else
        {
            PreviousMenu();
        }
    }

    public HunterAttacks ShowHunterAttacks()
    {
        currentmenu = "ShowHunterAttacks";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose your [red]Attack[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Blast Shot", "Bloodthirsty", "Explorer", "[red]Exit[/]"
                }));

        switch (hero)
        {
            case "Blast Shot":
                return HunterAttacks.BlastShot;
            case "Bloodthirsty":
                return HunterAttacks.Bloodthirsty;
            case "Explorer":
                return HunterAttacks.Explorer;
            default:
                PreviousMenu();
                return HunterAttacks.None;
        }
    }

    public void ShowNinjaInfo()
    {
        currentmenu = "ShowNinjaInfo";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 10% hp",
                    "Defend: increases your defense by 25%",
                    "Spinning blades: basic attack, deals 400 damage",
                    "Smoke bomb: Doesnt deals damage and you cannot shoot for 2 rounds but you gain 3x multiplier for run and you wont lose hp if you run",
                    "Sharper dagger: 600 dmg, enemy only has 85% damage in the next round. 3 rounds cooldown",
                    "[red]Exit[/]"
                }));

        if (hero != "[red]Exit[/]")
        {
            ShowNinjaInfo();
        }
        else
        {
            PreviousMenu();
        }
    }

    public NinjaAttacks ShowNinjaAttacks()
    {
        currentmenu = "ShowNinjaAttacks";
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose your [red]Attack[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Spinning Blades", "Smoke Bomb", "Sharper dagger", "[red]Exit[/]"
                }));

        switch (hero)
        {
            case "Spinning Blades":
                return NinjaAttacks.SpinningBlades;
            case "Smoke Bomb":
                return NinjaAttacks.SmokeBomb;
            case "Sharper dagger":
                return NinjaAttacks.SharperDagger;
            default:
                PreviousMenu();
                return NinjaAttacks.None;
        }
    }

    /*-----------------------------------------------------------------------------------------------------------------------------------------------------*/
    // During peacetime

    public void ShowPeaceMenu()
    {
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose what you want to [green]Do[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Move", "Use Item", "Show In Game Menu", "Show Main Menu"
                }));


    }

    public string[] ShowMoveMenu()
    {
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose what direction you want to [green]Move[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                     "Up", "Down", "Left", "Right", "[red]Exit[/]"
                }));

        string[] everything = new string[2];

        if (hero != "[red]Exit[/]")
        {
            string length = ShowMoveLengthMenu();
            everything[0] = hero;
            everything[1] = length;
        }
        else
        {
            everything[0] = hero;
        }
        return everything;

    }

    public string ShowMoveLengthMenu()
    {
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose how many tiles you want to [green]Move[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
                }));

        return hero;
    }
}