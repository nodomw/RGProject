using FantasyRPG.UI;
using FantasyRPG.Map;
using Spectre.Console;
using FantasyRPG.Combat;
using FantasyRPG.Map.Tiles;
using FantasyRPG.Characters;
using RGProject.Characters.Heroes;
using RGProject.Characters.Enemies;

var enemy = new Emperor("Lajos");
var font = FigletFont.Load("ANSI Shadow.flf");
var font2 = FigletFont.Load("Cyberlarge.flf");
string charclass = "";
string charname = "";
string[] temp = new string[2];

var tempmenu = new Menu(new Battle(new Hero("john doe"), new Emperor("Lajos")));
temp = tempmenu.ShowCharSelection();
charname = temp[0];
charclass = temp[1];

ICharacter hero = charclass switch
{
	"Warrior" => new Warrior(charname),
	"Mage" => new Mage(charname),
	"Elf" => new Elf(charname),
	"Assassin" => new Assassin(charname),
	"Paladin" => new Paladin(charname),
	"Hero" => new Hero(charname),
	"Hunter" => new Hunter(charname),
	"Ninja" => new Ninja(charname),
	_ => throw new ArgumentOutOfRangeException()
};

Battle battle = new Battle(hero, enemy);
var menu = new Menu(battle);
battle.Turn();

/*Console.Clear();
AnsiConsole.Write(new FigletText(font2, "Welcome to").Centered().Color(Color.White));
AnsiConsole.Write(new FigletText(font, "Fantasy Frontiers").Centered().Color(Color.Red));

AnsiConsole.Write(new Markup("[red]Press any key to continue.....[/]"));
Console.ReadKey();

temp = menu.Show();
charname = temp[0];
charclass = temp[1];*/