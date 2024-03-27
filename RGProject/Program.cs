using FantasyRPG.UI;
using FantasyRPG.Map;
using Spectre.Console;
using FantasyRPG.Combat;
using FantasyRPG.Map.Tiles;
using FantasyRPG.Characters;
using RGProject.Characters.Heroes;
using FantasyRPG.Characters.Enemies.Bosses;
using FantasyRPG.Characters.Enemies.BasicEnemies;
using FantasyRPG.Items;
using FantasyRPG;
using System.Security.Cryptography;

var enemy = new Emperor("Lajos");
// var font = FigletFont.Load("ANSI Shadow.flf");
// var font2 = FigletFont.Load("Cyberlarge.flf");

var tempmenu = new Menu(new Battle(new Hero("john doe"), new Emperor("Lajos")));
ICharacter hero = tempmenu.ShowCharSelection();
// ICharacter hero = new Warrior("john doe");

Battle battle = new Battle(hero, enemy, true);
// var menu = new Menu(battle);
// battle.Turn();

// AnsiConsole.Write(new FigletText(font2, "Welcome to").Centered().Color(Color.White));
// AnsiConsole.Write(new FigletText(font, "Fantasy Frontiers").Centered().Color(Color.Red));

// AnsiConsole.Write(new Markup("[red]Press any key to continue.....[/]"));
// Console.ReadKey();


long before = GC.GetTotalMemory(true);
Menu menu = new(battle);
Player pl = new(hero);
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
	DisplayCharacter = new Markup("[grey23]X[/]")
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
	DisplayCharacter = new Markup("[grey58]■[/]")
};
Enemy vamp = new(new Vampire("joni"));
Map map1 = new("Map 1", new ITile[,]{
	{ new ClassLoot(), g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
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
	{ d, d, d, d, d, v, v, v, new Enemy(new BloodScream("lemon")), v, v, v, v, v, v, v, v, v, v, new Enemy(new BoneCrusher("golem")), v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, new Enemy(new ChaosBeast("funny guy")), v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, d, v, v, v, v, new Enemy(new Nightshade("slender guy")), v, v, v, v, v, v, new Enemy(new Skeleton("boney")), v, v, v, v, v, v, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, new Enemy(new Vampire("Dracula")), v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
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
	{ d, d, d, d, d, d, v, v, v, v, v, v, v, v, new Enemy(new Nightshade("slender guy 2")), v, v, v, v, v, v, v, v, v, d, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, d, d, d, d, d, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, d, d, d, d, d, d, d, d, d, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, new Enemy(new BoneCrusher("anti scrankler")), v, v, d, d, d, d, d, d, d, d, d, d, d, v, new Enemy(new Skeleton("scrankler")), v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, d, d, d, d, d, d, d, d, d, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, d, d, d, d, d, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, d, v, v, v, v, v, v, v, new Enemy(new Prince("little prince")), v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d },
	{ et, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
});
Map map4 = new("map 4", new ITile[,] {
	{ d,et, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, pl},
	{ d, v, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, new Enemy(new Skeleton("bonka")), v, d, d, d, d, d, d, d, d },
	{ d, new Enemy(new BoneCrusher("foxcoon factory lemon")), d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, new Enemy(new Emperor("big prince")), d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, new Enemy(new ChaosBeast("badabeebo")), v, new Enemy(new Nightshade("badabingo")), v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, new Enemy(new BloodScream("bingyboingo")), v, v, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, new Enemy(new Skeleton("helen skeltoj")), d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d },
	{ d, v, new Enemy(new Skeleton("skeleer")), v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, new Enemy(new Skeleton("skeler")), v, v, v, v, v, v, v, v, v, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
});
Map map5 = new("map 5", new ITile[,] {
	{ d, d, d, d, d, d, d, d, d, d, d, d, d,et,et,et, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, d, v, v, v, v, v, v, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, v, v, v, new Enemy(new Headhunter("big man")), v, v, v, d, d, d, d, v, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, d, d, d, v, d, d, d, d, d, d, d },
	{ d, v, v, v, v, v, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, v, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, v, d, v, v, v, d, d, d },
	{ d, v, d, d, d, d, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, v, v, v, v, v, d, d, d },
	{ d, v, d, d, d, v, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d },
	{ d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, v, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, v, v, new Enemy(new Nightshade("hater")), v, v, v, v, v, v, new Enemy(new BoneCrusher("hater also")), v, d, d, d, d, d, v, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, new Enemy(new Nightshade("bikiboko")), v, v, v, v, d, d, d, d },
	{ d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, v, v, v, d },
	{ d, new Enemy(new Skeleton("dry gong")), d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, d, d, new Enemy(new Skeleton("bakibako")), d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, d, d, v, d },
	{ d, v, v, v, v, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, v, d, d, v, d },
	{ d, d, d, d, d, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, d, d, d, d, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, v, v, v, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, new Enemy(new BloodScream("sour elmone")), d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, v, v, v, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, d, d, d, d, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, d, d, d, d, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, v, v, v, v, d, d, d, v, v, v, new Enemy(new BloodScream("wakcer")), v, v, v, v, new Enemy(new Skeleton("skelr")), v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d },
	{ d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d,pl, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
});


// System.Console.WriteLine("drawing map 1");
// map1.DrawFull(DrawCriteria.DisplayCharacter);
//
// System.Console.WriteLine("drawing map 2");
// map2.DrawFull(DrawCriteria.DisplayCharacter);
//
// System.Console.WriteLine("drawing map 3");
// map3.DrawFull(DrawCriteria.DisplayCharacter);
//
// System.Console.WriteLine("drawing map 4");
// map4.DrawFull(DrawCriteria.DisplayCharacter);
//
// System.Console.WriteLine("drawing map 5");
// map5.DrawFull(DrawCriteria.DisplayCharacter);

long after = GC.GetTotalMemory(true);
long objectSize = after - before;
AnsiConsole.MarkupLine($"[bold gold1]Size difference: {objectSize} bytes, before: {before} bytes, after: {after} bytes[/]");

switch (AnsiConsole.Prompt(
	new SelectionPrompt<string>()
	.Title("What would you like to do?")
	.AddChoices(["Demo Battle", "Map navigation"])
))
{
	case "Map navigation":
		Map SelectedMap;
		string Maps = AnsiConsole.Prompt(
			new SelectionPrompt<string>()
			.Title("[bold steelblue1] hello and wlecom please chose youre map[/]")
			.AddChoices(["map 1", "map 2", "map 3", "map 4", "map 5"])
			);

		SelectedMap = Maps switch
		{
			"map 1" => map1,
			"map 2" => map2,
			"map 3" => map3,
			"map 4" => map4,
			_ => map5
		};

		bool Break = false;
		while (Break == false)
		{
			SelectedMap.DrawFull(DrawCriteria.DisplayCharacter);
			Console.WriteLine(SelectedMap.PlayerTile.Position.ToString());
			Console.ReadLine();
			Console.WriteLine(menu.ShowMoveMenu(SelectedMap));
			_ = AnsiConsole.Confirm("Continue?") ? Break = false : Break = true;
		}

		break;
	case "Demo Battle":
		Console.WriteLine("did something happen??");
		{
			hero.Items.Add(new Potion()
			{
				Name = "Dmg",
				Power = 10,
				Stat = PotionModifier.Damage
			});
		}
		Console.WriteLine("something happened");
		Console.WriteLine(string.Join(", ", hero.Items));
		//
		Battle b = new(hero, enemy, false);
		b.Turn();
		break;
}
