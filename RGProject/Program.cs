using FantasyRPG.UI;
using FantasyRPG.Map;
using Spectre.Console;
using FantasyRPG.Combat;
using FantasyRPG.Map.Tiles;
using FantasyRPG.Characters;
using RGProject.Characters.Heroes;
using FantasyRPG.Characters.Enemies.Bosses;
using FantasyRPG.Characters.Enemies.BasicEnemies;
using FantasyRPG;
using FantasyRPG.Items;

var enemy = new Emperor("Lajos");
var font = FigletFont.Load("../../../ANSI Shadow.flf");
var font2 = FigletFont.Load("../../../Cyberlarge.flf");

AnsiConsole.Write(new FigletText(font2, "Welcome to").Centered().Color(Color.White));
AnsiConsole.Write(new FigletText(font, "Fantasy Frontiers").Centered().Color(Color.Red));

AnsiConsole.Write(new Markup("[red]Press any key to continue.....[/]"));
Console.ReadKey();

MakeChar:
var tempmenu = new Menu(new Battle(new Hero("john doe"), new Emperor("Lajos")));
ICharacter hero = tempmenu.ShowCharSelection();
// ICharacter hero = new Warrior("john doe");

Battle battle = new Battle(hero, enemy, true);

long before = GC.GetTotalMemory(true);
Menu menu = new(battle);
// Player pl = new(hero);
Terrain g = new()
{
	DisplayCharacter = new Markup("[darkgreen]■[/]"),
	Passable = false
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
	DisplayCharacter = new Markup("[grey23]X[/]"),
	Passable = false
};
Terrain dr = new()
{
	DisplayCharacter = new Markup("[grey15]X[/]")
};
Exit et = new() // exit
{
	DisplayCharacter = new Markup("[bold white]■[/]"),
	Passable = true
};
Terrain v = new()
{
	DisplayCharacter = new Markup("[grey58]■[/]")
};
Enemy vamp = new(new Vampire("joni"));
Map surface = new("Surface", typeof(Terrain), new ITile[,]{
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
	{ g, g, g, g, g, g, g, g, g, g, p, g,new Player(hero), g, p, g, g, g, g, g, g, g, g, g, g, g, g, g, g, g },
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

Map map1 = new("1-1", typeof(Terrain), new ITile[,] {
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v,new Player(hero), v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, new Servant(ServantType.Healer), v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, new Enemy(new BloodScream("lemon")), v, v, v, v, v, v, v, v, v, v, new Enemy(new BoneCrusher("golem")), v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, new ClassLoot(), v, v, v, v, v, v, v, v, d, d, d, d, d },
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
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v, new ClassLoot(), v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, v,et, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
});
Map map2 = new("1-2", typeof(Terrain), new ITile[,] {
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d,new Player(hero), d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
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
	{ d, d, d, d, d, v, v, v, v, v, v, v, d, d, d, d, d, v, v, v, v, v, new Servant(ServantType.Captain), v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d },
	{ d, d, d, d, d, d, v, v, v, v, v, v, v, new Enemy(new Prince("little prince")), v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d },
	{ et, v, v, v, new ClassLoot(), v, v, v, v, v, v, v, v, v, v, v, v, v, new ClassLoot(), v, v, v, v, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
});
Map map3 = new("1-3", typeof(Terrain), new ITile[,] {
	{ d,et, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, v, d, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, new Player(hero)},
	{ d, v, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, new Enemy(new Skeleton("bonka")), v, d, d, d, d, d, d, d, d },
	{ d, new Enemy(new BoneCrusher("foxcoon factory lemon")), d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, new Servant(ServantType.Support), d, d, d, d, d, d, v, v, v, d, d, d, d, d, d, d, d },
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
	{ d, v, d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, new ClassLoot(), v, v, v, v, v, v, v, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, new Enemy(new Skeleton("helen skeltoj")), d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d },
	{ d, v, new Enemy(new Skeleton("skeleer")), v, v, v, v, v, new ClassLoot(), v, v, v, v, v, v, v, v, v, new Enemy(new Skeleton("skeler")), v, v, v, v, v, v, v, v, v, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
});
Map map4 = new("1-4", typeof(Terrain), new ITile[,] {
	{ d, d, d, d, d, d, d, d, d, d, d, d, d,et,et,et, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, d, d, d, d, d, v, v, v, v, v, v, d, d },
	{ d, d, d, d, d, d, d, d, d, d, d, v, v, v, new Enemy(new Headhunter("big man")), v, v, new ClassLoot(), d, d, d, d, v, d, d, d, d, d, d, d },
	{ d, d, d, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, d, d, d, v, d, d, d, d, d, d, d },
	{ d, v, v, v, v, v, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, v, d, d, d, d, d, d, d },
	{ d, v, d, d, d, d, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, v, d, v, v, v, d, d, d },
	{ d, v, d, d, d, d, v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, v, v, v, v, v, d, d, d },
	{ d, v, d, d, d, new ClassLoot(), v, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, v, v, v, d, d, d },
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
	{ d, d, d, d, d, new ClassLoot(), d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, v, v, v, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, new Enemy(new BloodScream("sour elmone")), d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, new ClassLoot(), d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, v, v, v, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, d, d, d, d, v, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, d, d, d, d, new ClassLoot(), d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, v, v, v, v, d, d, d, v, v, v, new Enemy(new BloodScream("wakcer")), v, v, v, v, new Enemy(new Skeleton("skelr")), v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, d, d, d, d, d, d, d, v, v, v, v, v, v, v, v, v, v, v, d, d, d, d, d, d, d, d, v, d },
	{ d, v, d, d, d, d, d, d, d, d, d, d, d, d, v, d, d, d, d, d, d, d, d, d, d, d, d, d, v, d },
	{ d, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, v, d },
	{ d, d, d, d, d, d, d, d, d, d, d, d, d, d,new Player(hero), d, d, d, d, d, d, d, d, d, d, d, d, d, d, d },
});

long after = GC.GetTotalMemory(true);
long objectSize = after - before;
AnsiConsole.MarkupLine($"[bold gold1]Size difference: {objectSize} bytes, before: {before} bytes, after: {after} bytes[/]");

hero.Items.Add(new Potion()
{
	Name = "HP",
	Power = 150,
	Stat = PotionModifier.Heal
});

List<Map> Maps =
[
	surface,
	map1,
	map2,
	map3,
	map4
];

foreach (Map map in Maps)
{

	if (map is null)
	{
		goto MakeChar;
	}

	Hud hud = new Hud();
	// bool Break = false;
	while (map.Running)
	{
		map.DrawFull(DrawCriteria.DisplayCharacter, hero);
		menu.ShowMoveMenu(map, hero);
		// _ = AnsiConsole.Confirm("Continue?") ? Break = false : Break = true;
	}
	Console.Clear();
}

AnsiConsole.Write(new FigletText(font, "Victory").Centered().Color(Color.Gold1));
Console.WriteLine("Press any key to continue...");
Console.ReadKey();