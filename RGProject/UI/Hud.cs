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
                levelCap = 2000;
                break;
            case 2:
                levelCap = 3500;
                break;
            case 3:
                levelCap = 5700;
                break;
            case 4:
                levelCap = 6500;
                break;
        }

        if (hero.Level == 5)
        {
            return 100;
        }
        else
        {
            return Math.Round((double)hero.XP / levelCap * 100, 2);
        }
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

    public void BattleStats(ICharacter hero, ICharacter enemy)
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


        var battleStats = new Table();
        battleStats.AddColumn(new TableColumn("[green bold]Your Stats[/]").Centered());
        battleStats.AddColumn(new TableColumn("[green bold]Your Value[/]").Centered());
        battleStats.AddColumn(new TableColumn("|").Centered());
        battleStats.AddColumn(new TableColumn("[green bold]Enemy's Stats[/]").Centered());
        battleStats.AddColumn(new TableColumn("[green bold]Enemy's Value[/]").Centered());

        battleStats.AddRow($"[white]Name[/]", $"[white]{hero.Name}[/]", "|", "[white]Enemy's name[/]" , $"[white]{enemy.Name}[/]");
        battleStats.AddRow("[white]Class[/]", $"[white]{hero.Type}[/]", "|", "[white]Enemy's class[/]", $"[white]{enemy.Type}[/]");
        battleStats.AddRow($"[green]Level[/]", $"[green]{hero.Level}[/]", "|", "[green]Enemy's level[/]", $"[green]{enemy.Level}[/]");
        battleStats.AddRow($"[gold1]XP[/]", $"[gold1]{hero.XP}[/]", "|", "[gold1]Enemy's XP[/]", $"[gold1]{enemy.XP}[/]");
        battleStats.AddRow("[red3_1]HP[/]", $"[red3_1]{hero.Health}[/]", "|", "[red3_1]Enemy's HP[/]", $"[red3_1]{enemy.Health}[/]");
        battleStats.AddRow($"[darkred_1]Dmg[/]", $"[darkred_1]{hero.Damage}[/]", "|", "[darkred_1]Enemy's Dmg[/]", $"[darkred_1]{enemy.Damage}[/]");
        battleStats.AddRow($"[grey37]DEF[/]", $"[grey37]{hero.DEF}%[/]", "|", "[grey37]Enemy's DEF[/]", $"[grey37]{enemy.DEF}%[/]");
        battleStats.AddRow($"[gold1]Combo[/]", $"[gold1]{hero.Combo}%[/]", "|", "[gold1]Enemy's Combo[/]", $"[gold1]{enemy.Combo}%[/]");
        battleStats.AddRow($"[yellow1]Stun[/]", $"[yellow1]{hero.Stun}%[/]", "|", "[yellow1]Enemy's Stun[/]", $"[yellow1]{enemy.Stun}%[/]");
        battleStats.AddRow($"[blue1]Dodge[/]", $"[blue1]{hero.Dodge}%[/]", "|", "[blue1]Enemy's Dodge[/]", $"[blue1]{enemy.Dodge}%[/]");
        battleStats.AddRow($"[red1]Crit[/]", $"[red1]{hero.Crit}%[/]", "|", "[red1]Enemy's Crit[/]", $"[red1]{enemy.Crit}%[/]");
        battleStats.AddRow($"[deeppink3_1]CATK[/]", $"[deeppink3_1]{hero.CATK}%[/]", "|", "[deeppink3_1]Enemy's CATK[/]", $"[deeppink3_1]{enemy.CATK}%[/]");

        AnsiConsole.Write(battleStats);
    }
}