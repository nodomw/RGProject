using FantasyRPG.Map;
using Spectre.Console;
using FantasyRPG.Map.Tiles;
using RGProject.Characters.Heroes;
using RGProject.Characters.Enemies;

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

Terrain g = new();
Terrain w = new()
{
	DisplayCharacter = new Markup("[blue]#[/]"),
	Passable = false
};
List<Map> Maps = new() // 30x30
{
	new Map("Map 1", new ITile[,]{
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
		// {},
	})
};

System.Console.WriteLine($"showing map '{m1.Name}'");
m1.DrawFull(DrawCriteria.DisplayCharacter);
m1.DrawGrid();

AnsiConsole.Write(m1.GetTileByPosition(new TilePosition(-1, -1)).DisplayCharacter);
