using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace FantasyRPG.UI;

internal class Menu
{
    // Starting the game
    public string[] Show()
    {
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
        
        string [] temp = new string[2];

        if (hero == "New Game")
        {
            temp = ShowCharSelection();
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

        return temp;
    }

    public string[] ShowCharSelection()
    {
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose your [green]Character[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Warrior", "Mage", "Elf", "Assassin", "Paladin", "Hero", "Hunter", "Ninja"
                }));
        
        string name = ShowCharCreation();
        string[] everything = {name, hero};
        AnsiConsole.WriteLine($"You chose {name}, who is a(n) {hero}! Good luck on your adventure!");
        Console.ReadKey();
        return everything;
    }

    public string ShowCharCreation()
    {
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

    public void ShowItemMenu()
    {
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
    }

    /*-----------------------------------------------------------------------------------------------------------------------------------------------------*/
    // During battle

    public void ShowBattleMenu()
    {
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
    }

    public void ShowWarriorInfo()
    {
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 5% hp"
                    "Defend: increases your defense by 25%" ,
                    "Slash: basic attack", 
                    "Shield bash: gives 200 hp but deals 0 damage, in the next round you will gain 70% defence and counter-attack" , 
                    "War cry: deals 200 damage and boosts your combo to 45%. Next round you will gain 20% defence." , 
                    "[red]Exit[/]"
                }));
    }

    public void ShowWarriorAttacks()
    {
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
    }

    public void ShowMageInfo()
    {
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 5% hp",
                    "Defend: increases your defense by 25%",
                    "Fireball: Basic attack, deals 400 damage", 
                    "Ice shard: deals 150 damage and in the next round the enemy only deals 50% damage.", 
                    "Thunderbolt: deals 700 damage. Cooldown: 3 rounds!", 
                    "[red]Exit[/]"
                }));
    }

    public void ShowMageAttacks()
    {
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
    }

    public void ShowEfInfo()
    {
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 5% hp",
                    "Defend: increases your defense by 25%",
                    "Arrow shot: basic attack, deals 550 damage",
                    "Arrow rain: deals 800 damage and in the next round you will lose 15% stun and combo",
                    "Shocking arrow: deals 300 damage while giving you a 60% stun", 
                    "[red]Exit[/]"
                }));
    }

    public void ShowElfAttacks()
    {
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
    }

    public void ShowAssassinInfo()
    {
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 5% hp",
                    "Defend: increases your defense by 25%",
                    "Dagger strike: Basic attack, deals 600 damage",
                    "Poison strike: deals 200 damage. In the next round you will damage your enemy with 50hp and sets the enemy damage to 50%",
                    "Shadow strike: Deals 0 damage and sets dodge to 70% and every other stats to 0%. Cooldown? 4 rounds", 
                    "[red]Exit[/]"
                }));
    }

    public void ShowAssassinAttacks()
    {
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
    }

    public void ShowPaladinInfo()
    {
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 5% hp",
                    "Defend: increases your defense by 25%",
                    "Holy strike: basic attack, deals 300 damage",
                    "Holy shield: doesnt deal damage but gives you 300 hp, and in next round boosts your defence by 15%",
                    "Holy light: 800 damage but damages you for 300 and the next round you lose 25% counter-attack and 10% defense. 3 round cooldown.",
                    "[red]Exit[/]"
                }));
    }

    public void ShowPaladinAttacks()
    {
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
    }

    public void ShowHeroInfo()
    {
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 5% hp",
                    "Defend: increases your defense by 25%",
                    "Heroic strike:",
                    "Crown: deals 100 damage and givs you 25% critical damage. The next round you will gain 25% defence. 3 round cooldown",
                    "Getting a cape: The next 2 rounds you will gain 20% dmg and 10% def. 3 round cooldown.",
                    "[red]Exit[/]"
                }));
    }


    public void ShowHeroAttacks()
    {
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
    }

    public void ShowHunterInfo()
    {
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 5% hp",
                    "Defend: increases your defense by 25%",
                    "Blast shot: basic attack, deals 700 damage",
                    "Bloodthristy: -20% from the enemy's health while dealing 600 damage to them, and boosting your stun by 10%. Useable only once after 3 hit!",
                    "Explorer: Gives you 1 random item which can be found on the current map. After used yoour item you get you deal 550 damage automatically. Useable once/map",
                    "[red]Exit[/]"
                }));
    }

    public void ShowHunterAttacks()
    {
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
    }

    public void ShowNinjaInfo()
    {
        Console.Clear();
        var hero = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("These are your [red]Abilities[/]!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more.)[/]")
                .AddChoices(new[]
                {
                    "Run: you lose 5% hp",
                    "Defend: increases your defense by 25%",
                    "Spinning blades: basic attack, deals 400 damage",
                    "Smoke bomb: Doesnt deals damage and you cannot shoot for 2 rounds but you gain 3x multiplier for run and you wont lose hp if you run",
                    "Sharper dagger: 600 dmg, enemy only has 85% damage in the next round. 3 round cooldown",
                    "[red]Exit[/]"
                }));
    }

    public void ShowNinjaAttacks()
    {
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