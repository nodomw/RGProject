using FantasyRPG.UI;
using FantasyRPG.Map;
using Spectre.Console;
using FantasyRPG.Combat;
using FantasyRPG.Map.Tiles;
using FantasyRPG.Characters;
using RGProject.Characters.Heroes;
using FantasyRPG.Characters.Enemies.Bosses;
using FantasyRPG.Items.HeroItems.BasicItems;

var enemy = new Emperor("Lajos");
// var font = FigletFont.Load("ANSI Shadow.flf");
// var font2 = FigletFont.Load("Cyberlarge.flf");

var tempmenu = new Menu(new Battle(new Hero("john doe"), new Emperor("Lajos")));
ICharacter hero = tempmenu.ShowCharSelection();

Battle battle = new Battle(hero, enemy);
// var menu = new Menu(battle);
// battle.Turn();

/*Console.Clear();
AnsiConsole.Write(new FigletText(font2, "Welcome to").Centered().Color(Color.White));
AnsiConsole.Write(new FigletText(font, "Fantasy Frontiers").Centered().Color(Color.Red));

AnsiConsole.Write(new Markup("[red]Press any key to continue.....[/]"));
Console.ReadKey();

temp = menu.Show();
charname = temp[0];
charclass = temp[1];*/
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

long before = GC.GetTotalMemory(true);
Menu menu = new(battle);
Player pl = new("joni", hero);
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
Terrain d = new() // darker gray than p but not as dark as dgr
{
	DisplayCharacter = new Markup("[grey37]X[/]")
};
Terrain dr = new()
{
	DisplayCharacter = new Markup("[grey15]X[/]")
};
Terrain et = new() // exit
{
	DisplayCharacter = new Markup("[bold white]■[/]")
};
Terrain v = new()
{
	DisplayCharacter = new Markup("[grey37]■[/]")
};
Enemy vamp = new("joni", new Vampire("joni"));
Map map1 = new("Map 1", new ITile[,]{
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
	{ g, g, g, g, g, g, g, g, g, g, p, p, p, p, p, g, g, d, d, d, g, g, g, g, g, g, g, g, g, g },
	{ g, g, g, g, g, g, g, g, g, g, g, g, p, g, g, g, d, d, d, d, d, g, g, g, g, g, g, g, g, g },
	{ g, g, g, g, g, g, g, g, g, g, g, g, p, g, g, g, d, dr,et,dr,d, g, g, g, g, g, g, g, g, g },
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
});

Map map2 = new("map 2", new ITile[,] {
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v,pl, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, d, v, v, v, v, vamp, v, v, v, v, v, v, vamp, v, v, v, v, v, v, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, vamp, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v,et, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
});
Map map3 = new("map 3", new ITile[,] {
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d,pl, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, v, v, v, v, v, v, v, v, vamp, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, d, d, d, d, d, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, d, d, d, d, d, d, d, d, d, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, vamp, v, v, d, d, d, d, d, d, d, d, d, d, d, v, vamp, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, d, d, d, d, d, d, d, d, d, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, d, d, d, d, d, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, d, v, v, v, v, v, v, v, vamp, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d },
	{ et, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
});
Map map4 = new("map 4", new ITile[,] {
	{ d,et, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, v, d, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, pl},
	{ d, v, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, vamp, v, d, d, d, d, d, d, d, d },
	{ d, vamp, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, vamp, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, vamp, v, vamp, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, vamp, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, vamp, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d },
	{ d, v, vamp, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, vamp, v, v, v, v, v, v, v, v, v, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
});
Map map5 = new("map 5", new ITile[,] {
	{ d, d, d, d, d, d, d, d, d, d, d, d, d,et,et,et, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, d, v, v, v, v, v, v, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, d, d, d, d, v, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, d, d, d, v, d, d, d, d, d, d, d },
	{ d, v, v, v, v, v, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, v, d, d, new Loot(new RunBoost()), d, d, d, d },
	{ d, v, d, d, d, d, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, v, d, v, v, v, d, d, d },
	{ d, v, d, d, d, d, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, v, v, v, v, v, d, d, d },
	{ d, v, d, d, d, v, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d },
	{ d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, v, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, v, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d },
	{ d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, v, v, v, d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, d, d, v, d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, d, d, v, d },
	{ d, v, v, v, v, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, v, d, d, v, d },
	{ d, d, d, d, d, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, d, d, d, d, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, v, v, v, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, v, v, v, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, d, d, d, d, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, d, d, d, d, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, v, v, v, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d },
	{ d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d,pl, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
});

long after = GC.GetTotalMemory(true);
long objectSize = after - before;
AnsiConsole.MarkupLine($"[bold gold1]Object size: {objectSize} bytes, before: {before} bytes, after: {after} bytes[/]");
// map5.DrawFull(DrawCriteria.DisplayCharacter);


