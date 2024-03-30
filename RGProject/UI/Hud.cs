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
    public void Stats(ICharacter hero)
    {
        if (hero.IsHero)
        {
            AnsiConsole.Write(new BarChart()
                .Width(100)
                .Label("[green bold underline]Your Stats[/]")
                .CenterLabel()
                .AddItem("HP in %", HpConverter(hero), Color.Red3_1)
                .AddItem("XP in %", XpConverter(hero), Color.Gold1)
                .AddItem("[black]100%[/]", 100, Color.Black));
        }
        else
        {
            AnsiConsole.Write(new BarChart()
                .Width(100)
                .Label("[red bold underline]Enemy Stats[/]")
                .CenterLabel()
                .AddItem("HP in %", HpConverter(hero), Color.Red3_1)
                .AddItem("[black]100%[/]", 100, Color.Black));
        }


        var stats = new Table();
        stats.AddColumn(new TableColumn("[green bold]Stats[/]").Centered());
        stats.AddColumn(new TableColumn("[green bold]Value[/]").Centered());

        stats.AddRow($"[white]Name[/]", $"[white]{hero.Name}[/]").Width(30);
        stats.AddRow("[white]Class[/]", $"[white]{hero.Type}[/]");
        stats.AddRow($"[green]Level[/]", $"[green]{hero.Level}[/]");
        stats.AddRow($"[gold1]XP[/]", $"[gold1]{hero.XP}[/]");
        stats.AddRow("[red3_1]HP[/]", $"[red3_1]{hero.Health}[/]");
        stats.AddRow($"[darkred_1]Dmg[/]", $"[darkred_1]{hero.Damage}[/]");
        stats.AddRow($"[grey37]DEF[/]", $"[grey37]{hero.DEF}%[/]");
        stats.AddRow($"[gold1]Combo[/]", $"[gold1]{hero.Combo}%[/]");
        stats.AddRow($"[yellow1]Stun[/]", $"[yellow1]{hero.Stun}%[/]");
        stats.AddRow($"[blue1]Dodge[/]", $"[blue1]{hero.Dodge}%[/]");
        stats.AddRow($"[red1]Crit[/]", $"[red1]{hero.Crit}%[/]");
        stats.AddRow($"[deeppink3_1]CATK[/]", $"[deeppink3_1]{hero.CATK}%[/]");

        AnsiConsole.Write(stats);
    }
}