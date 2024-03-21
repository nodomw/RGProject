using FantasyRPG.Characters;
using RGProject.Characters.Heroes;
using Spectre.Console;

namespace FantasyRPG.UI;

public class Hud
{
    private double HpConverter(ICharacter hero)
    {
        return Math.Round((double)hero.Health / hero.MaxHealth * 100, 2);
    }
    private double XpConverter(ICharacter hero)
    {
        double levelCap = 1;

        switch (hero.Level)
        {
            case 0:
                levelCap = 1000;
                break;
            case 1:
                levelCap = 1500;
                break;
            case 2:
                levelCap = 2200;
                break;
            case 3:
                levelCap = 3200;
                break;
            case 4:
                levelCap = 4500;
                break;
        }

        return Math.Round((double)hero.XP / levelCap * 100, 2);
    }
    public void HeroHud(ICharacter hero)
    {
        AnsiConsole.Write(new BarChart()
            .Width(100)
            .Label("[green bold underline]Your Stats[/]")
            .CenterLabel()
            .AddItem("HP in %", HpConverter(hero), Color.Red)
            .AddItem("XP in %", XpConverter(hero), Color.Gold1));

        var stats = new Table();
        stats.AddColumn(new TableColumn("[green bold]Stats[/]").Centered());
        stats.AddColumn(new TableColumn("[green bold]Value[/]").Centered());

        stats.AddRow($"[white]Name[/]", $"{hero.Name}");
        stats.AddRow($"[green]Level[/]", $"{hero.Level}");
        stats.AddRow($"[maroon]Dmg[/]", $"{hero.Damage}");
        stats.AddRow($"[grey37]DEF[/]", $"{hero.DEF}%");
        stats.AddRow($"[gold1]Combo[/]", $"{hero.Combo}%");
        stats.AddRow($"[yellow1]Stun[/]", $"{hero.Stun}%");
        stats.AddRow($"[blue1]Dodge[/]", $"{hero.Dodge}%");
        stats.AddRow($"[red1]Crit[/]", $"{hero.Crit}%");
        stats.AddRow($"[deeppink3_1]CATK[/]", $"{hero.CATK}%");

        AnsiConsole.Write(stats);

    }
}