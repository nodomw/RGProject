﻿using FantasyRPG.UI;
using FantasyRPG.Map;
using Spectre.Console;
using FantasyRPG.Combat;
using FantasyRPG.Map.Tiles;
using FantasyRPG.Characters;
using RGProject.Characters.Heroes;
using FantasyRPG.Characters.Enemies.Bosses;
using FantasyRPG.Items.HeroItems.BasicItems;
using FantasyRPG.Characters.Enemies.BasicEnemies;

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
	{ d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, d, d, d, d, v, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, d, d, d, v, d, d, d, d, d, d, d },
	{ d, v, v, v, v, v, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, v, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, v, d, v, v, v, d, d, d },
	{ d, v, d, d, d, d, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, v, v, v, v, v, d, d, d },
	{ d, v, d, d, d, v, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d },
	{ d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, v, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, v, v, new Enemy(new Nightshade("hater")), v, v, v, v, v, v, v, v, d, d, d, d, d, v, d, d, d, d },
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


System.Console.WriteLine("drawing map 1");
map1.DrawFull(DrawCriteria.DisplayCharacter);

System.Console.WriteLine("drawing map 2");
map2.DrawFull(DrawCriteria.DisplayCharacter);

System.Console.WriteLine("drawing map 3");
map3.DrawFull(DrawCriteria.DisplayCharacter);

System.Console.WriteLine("drawing map 4");
map4.DrawFull(DrawCriteria.DisplayCharacter);

System.Console.WriteLine("drawing map 5");
map5.DrawFull(DrawCriteria.DisplayCharacter);

long after = GC.GetTotalMemory(true);
long objectSize = after - before;
AnsiConsole.MarkupLine($"[bold gold1]Size difference: {objectSize} bytes, before: {before} bytes, after: {after} bytes[/]");