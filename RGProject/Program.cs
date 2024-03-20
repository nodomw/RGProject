using FantasyRPG.Map;
using Spectre.Console;
using FantasyRPG.Map.Tiles;
using RGProject.Characters.Heroes;
using RGProject.Characters.Enemies;

// Enemy v = new("vampire", new Vampire("gino juno"));
// Player p = new("joni", new Assassin("joni"));
// Empty e = new();
// Terrain t = new();

// Map m1 = new Map("map 1", new ITile[,] {
// 	// when making an actual map b sure to create actual instances instead of substituting stuff in
// 	{ e, e, e, e, e, e, e, e, e, e },
// 	{ e, e, e, e, e, e, e, e, e, e },
// 	{ e, e, e, e, e, e, e, e, e, e },
// 	{ e, e, e, e, e, e, e, e, e, e },
// 	{ e, e, e, e, p, e, e, e, e, e },
// 	{ e, e, e, e, e, e, e, e, e, e },
// 	{ e, e, e, e, e, e, e, e, e, e },
// 	{ e, e, e, e, e, e, e, e, e, e },
// 	{ e, e, e, e, e, e, e, e, e, e },
// 	{ e, e, e, e, e, e, e, e, e, e }
// });

Player pl = new("joni", new Assassin("joni"));
Terrain g = new()
{
	DisplayCharacter = new Markup("[darkgreen]■[/]")
};
Terrain w = new()
{
	DisplayCharacter = new Markup("[bold blue]#[/]"),
	Passable = false
};
Terrain p = new()
{
	DisplayCharacter = new Markup("[grey]X[/]")
};
Terrain dr = new() // darker gray than p but not as dark as dgr
{
	DisplayCharacter = new Markup("[grey37]X[/]")
};
Terrain dgr = new()
{
	DisplayCharacter = new Markup("[grey15]X[/]")
};
Terrain et = new() // exit
{
	DisplayCharacter = new Markup("[bold white]■[/]")

};
Map map1 = new Map("Map 1", new ITile[,]{
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, w, g, g, w, g, w, w, w, w, w, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, w, w, w, w, w, w, w, w, w, w, w, w, w, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, w, w, w, w, w, w, w, w, w, w, w, w, w, w, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, w, w, w, w, w, w, g, g, w, g, g, w, w, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, w, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, p, p, p, p, p, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, p, g, g, g, p, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, p, g,pl, g, p, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, p, p, p, p, p, g, g,dr,dr,dr, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, p, g, g, g,dr,dr,et,dr,dr, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, p, g, g, g,dr,dgr,et,dgr,dr,g,g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, p, g, g, g, g, g, p, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, p, g, g, g, g, g, p, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, p, g, g, g, g, g, p, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, p, p, p, p, p, p, p, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
		{ g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
	});

map1.DrawFull(DrawCriteria.DisplayCharacter);

map1.MoveTile(pl, new TilePosition(1, 1));
System.Console.WriteLine();

map1.DrawFull(DrawCriteria.DisplayCharacter);
System.Console.WriteLine(map1.PlayerTile.Position.ToString());

AnsiConsole.Write(map1.GetTileByPosition(new TilePosition(-1, -1)).DisplayCharacter);
