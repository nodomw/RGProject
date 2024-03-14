using FantasyRPG.Map;
using FantasyRPG.Map.Tiles;
using FantasyRPG.Characters;
using FantasyRPG.Combat;
using FantasyRPG.UI;
using RGProject.Characters.Enemies;
using Spectre.Console;
using RGProject.Characters.Heroes;

var game = new Menu();
var battle = new Battle(new Hunter("joni"), new Vampire("gino"));
var font = FigletFont.Load("ANSI Shadow.flf");
var font2 = FigletFont.Load("Cyberlarge.flf");
string charname = "";

Console.WriteLine("asd");
battle.Turn();
Console.WriteLine("asd");

/*Console.Clear();
AnsiConsole.Write(new FigletText(font2, "Welcome to").Centered().Color(Color.White));
AnsiConsole.Write(new FigletText(font, "Fantasy Frontiers").Centered().Color(Color.Red));

AnsiConsole.Write(new Markup("[red]Press any key to continue.....[/]"));
Console.ReadKey();

game.Show();
game.ShowPeaceMenu();*/
