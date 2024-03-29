using FantasyRPG.Items;
using FantasyRPG.Map;
using Spectre.Console;

namespace FantasyRPG.Characters;

public enum UpgradableTraits
{
    Health,
    Resistance,
    Dodge,
    Stun
}
public enum CharacterType // TODO
{
    Elf,
    Mage,
    Warrior,
    Assassin,
    Paladin,
    Hero,
    Hunter,
    Ninja,
    // ENEMIES
    Prince,
    Vampire,
    Emperor,
    Headhunter
}
public interface ICharacter
{
    public Guid Id { get; }
    public string Name { get; set; }
    public CharacterType Type { get; }
    public TilePosition Position { get; set; }
    public ITile Parent { get; set; }
    public bool IsHero { get; set; }
    public bool IsBoss { get; set; }
    public bool IsCaptain { get; set; }
    public bool IsHealer { get; set; }
    public bool IsSupport { get; set; }
    public bool SilentStep { get; set; }
    public bool Fans { get; set; }
    public bool RunBoost { get; set; } // 10% -> 5% hp lost when run away
    public bool MultiBooster { get; set; } // 10% -> 8% hp lost when run away
    public bool BloodThirsty { get; set; }
    public bool Explorer { get; set; }
    public bool Dead { get; set; }
    public int Level { get; set; }
    public int XP { get; set; } // TODO: figure out xp amount for each level
    public double MaxHealth { get; set; }
    public double Health { get; set; } // HP
    public double Damage { get; set; } // ATK
    public double CATK { get; set; } // CATK%
    public double DEF { get; set; } // DEF%
    public double Crit { get; set; } // %
    public double Dodge { get; set; } // %
    public double Stun { get; set; } // %
    public double Combo { get; set; } // %
    public double TempDodge { get; set; } // %
    public double TempStun { get; set; } // %
    public double TempCrit { get; set; } // %
    public double TempDmg { get; set; } // %
    public double TempDEF { get; set; } // %
    public double TempCombo { get; set; } // %
    public double TempCATK { get; set; } // %
    public List<Item> Items { get; set; } // TODO: add initializer for all classes
    public IWeapon Weapon { get; set; }

    public int Attack() => Weapon.Damage * (Level / 100); // should increase with level so like level 12 should give you a 1.2% passive damage increase
    public int LevelUp()
    {
        switch (Level) // TODO: convert to case switch
        {
            case 0:
                if (XP >= 1000)
                {
                    Level++;
                    AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and all of your [gold1]stats[/] are increased by 10%!\nYou also unlocked your first ability, and you can now use your first special item, if you found it!"));
                }
                if (XP >= 1500)
                {
                    Level++;
                    AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and your [green3]hp[/] and [red1]dmg[/] are increased by 20%!\nYou also unlocked your second ability!"));
                }
                break;
            case 1:
                if (XP >= 1500)
                {
                    Level++;
                    AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and your [green3]hp[/] and [red1]dmg[/] are increased by 10%!\nYou also unlocked your second ability!"));
                }
                if (XP >= 2200)
                {
                    Level++;
                    AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and your [green3]hp[/] and [red1]dmg[/] are increased by 20%!\nYou can also use your second special item, if you found it!"));
                }
                break;
            case 2:
                if (XP >= 2200)
                {
                    Level++;
                    AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and your [green3]hp[/] and [red1]dmg[/] are increased by 20%!\nYou can also use your second special item, if you found it!"));
                }
                if (XP >= 3200)
                {
                    Level++;
                    AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and your [green3]hp[/] and [red1]dmg[/] are increased by 20%!"));
                }
                break;
            case 3:
                if (XP >= 3200)
                {
                    Level++;
                    AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and your [green3]hp[/] and [red1]dmg[/] are increased by 20%!"));
                }
                if (XP >= 4500)
                {
                    Level++;
                    AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and your [green3]hp[/] and [red1]dmg[/] are increased by 20% and all of your [gold1]stats[/] are increased by 10%!"));
                }
                break;
            case 4:
                if (XP >= 4500)
                {
                    Level++;
                    AnsiConsole.Write(new Markup("You [green3]Leveled Up[/] and reached [gold1]MAX[/] level!\nYour [green3]hp[/] and [red1]dmg[/] are increased by 20% and all of your [gold1]stats[/] are increased by 10%!"));
                }
                break;
        }


        return Level;
    }
    public int TakeDamage(int Damage)
    {
        // hoep this works, havent tested yet
        if (new Random().Next(100) < Dodge)
        {
            Health -= Damage * (1 - (DEF / 100));
        }

        return Damage;
    }
    public double UsePotion(Potion potion)
    {
        switch (potion.Stat)
        {
            case PotionModifier.Heal:
                Health += potion.Power;
                Items.Remove(potion);
                return (double)Health;
            case PotionModifier.Damage:
                Damage += potion.Power;
                Items.Remove(potion);
                return (double)Damage;
            case PotionModifier.Resistance:
                DEF += potion.Power;
                Items.Remove(potion);
                return (double)DEF;
            case PotionModifier.Run: // do nothing cuz it doesnt do anything in battles just on map
                RunBoost = true;
                goto default;
            case PotionModifier.Multi:
                DEF += 10;
                Health += 5;
                MultiBooster = true;
                goto default;
            case PotionModifier.Combo:
                Combo += potion.Power;
                return (double)Combo;
            default:
                Items.Remove(potion);
                return 0;
        }
    }
}
