using FantasyRPG.Items;
using FantasyRPG.Map;

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
    public int Level { get; set; }
    public int XP { get; set; } // TODO: figure out xp amount for each level

    public double Health { get; set; } // HP
    public double Damage { get; set; } // ATK
    public double CounterDamage { get; set; } // CATK%
    public double DEF { get; set; } // DEF%
    public double Dodge { get; set; } // %
    public double Stun { get; set; } // %
    public double Combo { get; set; } // %
    public List<IPotion> Potions { get; set; }
    public IWeapon Weapon { get; set; }

    public int Attack() => Weapon.Damage * (Level / 100); // should increase with level so like level 12 should give you a 1.2% passive damage increase
    public int LevelUp() // TODO: need xp limits for levels (e.g: level 12 at 5200xp or lvl 20 at 10_000xp)
    {
        Level += 1;

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
}
