using FantasyRPG.UI;
using FantasyRPG.Map;
using Spectre.Console;
using FantasyRPG.Combat;
using FantasyRPG.Map.Tiles;
using FantasyRPG.Characters;
using RGProject.Characters.Heroes;
using RGProject.Characters.Enemies;

var menu = new Menu();
var battle = new Battle(new Hunter("joni"), new Vampire("gino"));
var font = FigletFont.Load("ANSI Shadow.flf");
var font2 = FigletFont.Load("Cyberlarge.flf");
string charname = "";

battle.Turn();

/*Console.Clear();
AnsiConsole.Write(new FigletText(font2, "Welcome to").Centered().Color(Color.White));
AnsiConsole.Write(new FigletText(font, "Fantasy Frontiers").Centered().Color(Color.Red));

AnsiConsole.Write(new Markup("[red]Press any key to continue.....[/]"));
Console.ReadKey();

game.Show();
game.ShowPeaceMenu();*/
