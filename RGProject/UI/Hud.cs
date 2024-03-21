using FantasyRPG.Characters;
using RGProject.Characters.Heroes;
using Spectre.Console;

namespace FantasyRPG.UI;

public class Hud
{
    public double PercentageConverter(ICharacter hero)
    {
        return (double)hero.Health / hero.MaxHealth * 100;
    }
    public void HeroHud(ICharacter hero)
    {
        AnsiConsole.Write(new BarChart()
            .Width(100)
            .Label("[green bold underline]Your Stats[/]")
            .CenterLabel()
            .AddItem("HP", hero.Health , Color.Red)
            .AddItem("XP", hero.XP, Color.Gold1));
    }
}