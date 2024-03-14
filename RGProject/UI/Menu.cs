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
                    "Attack", "Defend", "Use Item", "[red]Run[/]"
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