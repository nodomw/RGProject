using FantasyRPG.UI;
using FantasyRPG.Map;
using Spectre.Console;
using FantasyRPG.Items;
using FantasyRPG.Combat;
using FantasyRPG.Map.Tiles;
using FantasyRPG.Characters;
using RGProject.Characters.Heroes;
using RGProject.Characters.Enemies;
using FantasyRPG.Items.Potions;

var game = new Menu();
var battle = new Battle(new Hunter("joni"), new Vampire("gino"));
var font = FigletFont.Load("ANSI Shadow.flf");
var font2 = FigletFont.Load("Cyberlarge.flf");
string charname = "";

battle.Turn();
Enemy v = new("vampire", new Vampire("gino juno"));
Loot dp = new(new Damage());
Loot hp = new(new Heal());
Loot rp = new(new Resistance());
Empty e = new();
Terrain t = new();

Map m1 = new Map("map 1", new ITile[,] {
	// Create a 10x10 array of Tiles which consist of the following:
	// Empty, Terrain, Loot, Enemy
	// There must be only one Player tile
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e }
});

m1.Draw();

/*Console.Clear();
AnsiConsole.Write(new FigletText(font2, "Welcome to").Centered().Color(Color.White));
AnsiConsole.Write(new FigletText(font, "Fantasy Frontiers").Centered().Color(Color.Red));

AnsiConsole.Write(new Markup("[red]Press any key to continue.....[/]"));
Console.ReadKey();

game.Show();
game.ShowPeaceMenu();*/
