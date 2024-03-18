using FantasyRPG.UI;
using FantasyRPG.Map;
using Spectre.Console;
using FantasyRPG.Combat;
using FantasyRPG.Map.Tiles;
using FantasyRPG.Characters;
using FantasyRPG.Items.Potions;
using RGProject.Characters.Heroes;
using RGProject.Characters.Enemies;

// Assassin hero = new("joni");
// var battle = new Battle(hero, new Vampire("gino"));
var font = FigletFont.Load("ANSI Shadow.flf");
var font2 = FigletFont.Load("Cyberlarge.flf");
Enemy v = new("vampire", new Vampire("gino juno"));
Player p = new("joni", new Assassin("joni"));
Empty e = new();
Terrain t = new();

Map m1 = new Map("map 1", new ITile[,] {
	// when making an actual map b sure to create actual instances instead of substituting stuff in
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, p, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e },
	{ e, e, e, e, e, e, e, e, e, e }
});

System.Console.WriteLine($"showing map '{m1.Name}'");
m1.DrawFull(DrawCriteria.DisplayCharacter);
m1.DrawGrid();

AnsiConsole.Write(m1.GetTileByPosition(new TilePosition(-1, -1)).DisplayCharacter);
