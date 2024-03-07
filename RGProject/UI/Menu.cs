using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.UI
{
    internal class Menu
    {
        public static void Show()
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
                Console.WriteLine("Exiting Game...");
                Console.ReadKey();
            }
        }

        public string ShowCharSelection()
        {
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Elf");
            Console.WriteLine("4. Assassin");
            Console.WriteLine("5. Paladin");
            Console.WriteLine("6. Hero");
            Console.WriteLine("7. Hunter");
            Console.WriteLine("8. Ninja");
        }

        public static void ShowCharCreation()
        {
            Console.WriteLine("Enter your character's name: ");
        }

        public static void ShowInGameMenu()
        {
            Console.WriteLine("1. Show Stats");
            Console.WriteLine("2. Show Inventory");
            Console.WriteLine("3. Show Equipment");
            Console.WriteLine("4. Show Skills");
            Console.WriteLine("5. Show Map");
            Console.WriteLine("6. Exit");
        }

        public static void ShowMaps()
        {
            Console.WriteLine("1. First Map");
            Console.WriteLine("2. Second Map");
            Console.WriteLine("3. Third Map");
            Console.WriteLine("4. Fourth Map");
            Console.WriteLine("5. Exit");
        }

        public static void ShowMainMenu()
        {
            Console.WriteLine("1. Continue");
            Console.WriteLine("2. Save");
            Console.WriteLine("3. Exit");
        }

        public static void ShowInventoryMenu()
        {
            Console.WriteLine("1. Use Item");
            Console.WriteLine("2. Equip Item");
            Console.WriteLine("3. Exit");
        }

        public static void ShowEquipMenu()
        {
            Console.WriteLine("1. Equip Weapon");
            Console.WriteLine("2. Equip Armor");
            Console.WriteLine("3. Exit");
        }

        public static void ShowItemMenu()
        {
            Console.WriteLine("1. Use Health Potion");
            Console.WriteLine("2. Use Mana Potion");
            Console.WriteLine("3. Exit");
        }

        /*-----------------------------------------------------------------------------------------------------------------------------------------------------*/

        public static void ShowBattleMenu()
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
            Console.WriteLine("1. Dagger Strike");
            Console.WriteLine("2. Poison Strike");
            Console.WriteLine("3. Shadow Strike");
            Console.WriteLine("4. Exit");
        }

        public static void ShowPaladinAttacks()
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

        public static void ShowNinjaAttacks()
        {
            Console.WriteLine("1. Ninja Strike");
            Console.WriteLine("2. Ninja Shield");
            Console.WriteLine("3. Ninja Light");
            Console.WriteLine("4. Exit");
        }
    }
}
