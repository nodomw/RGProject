using FantasyRPG.UI;
using Spectre.Console;

var game = new Menu();
var font = FigletFont.Load("ANSI Shadow.flf");
var font2 = FigletFont.Load("Cyberlarge.flf");
string charname = "";

Console.Clear();
AnsiConsole.Write(new FigletText(font2, "Welcome to").Centered().Color(Color.White));
AnsiConsole.Write(new FigletText(font, "Fantasy Frontiers").Centered().Color(Color.Red));

AnsiConsole.Write(new Markup("[red]Press any key to continue.....[/]"));
Console.ReadKey();

game.Show();
game.ShowPeaceMenu();
charname = game.ShowCharSelection();
