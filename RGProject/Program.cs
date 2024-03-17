using FantasyRPG.UI;
using FantasyRPG.Map;
using Spectre.Console;
using FantasyRPG.Combat;
using FantasyRPG.Map.Tiles;
using FantasyRPG.Characters;
using RGProject.Characters.Heroes;
using RGProject.Characters.Enemies;

Menu menu = new Menu();
var font = FigletFont.Load("ANSI Shadow.flf");
var font2 = FigletFont.Load("Cyberlarge.flf");
string charclass = "";
string charname = "";
string[] temp = new string[2];

temp = menu.ShowCharSelection();
charname = temp[0];
charclass = temp[1];

ICharacter hero;

switch (charclass)
{
    case "Assassin":
        hero= new Assassin(charname);
        break;
    case "Elf":
        hero = new Elf(charname);
        break;
    case "Hero":
        hero = new Hero(charname);
        break;
    case "Hunter":
        hero = new Hunter(charname);
        break;
    case "Mage":
        hero = new Mage(charname);
        break;
    case "Ninja":
        hero = new Ninja(charname);
        break;
    case "Paladin":
        hero = new Paladin(charname);
        break;
    case "Warrior":
        hero = new Warrior(charname);
        break;
    default:
        hero = new Hero(charname);
        break;
}
Battle battle = new Battle(hero,new Emperor("Lajos"));
menu = new Menu { menubattle = battle };

battle.Turn();

/*Console.Clear();
AnsiConsole.Write(new FigletText(font2, "Welcome to").Centered().Color(Color.White));
AnsiConsole.Write(new FigletText(font, "Fantasy Frontiers").Centered().Color(Color.Red));

AnsiConsole.Write(new Markup("[red]Press any key to continue.....[/]"));
Console.ReadKey();

temp = menu.Show();
charname = temp[0];
charclass = temp[1];*/
