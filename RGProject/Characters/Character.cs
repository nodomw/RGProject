using FantasyRPG.Items;
using FantasyRPG.Map;

namespace FantasyRPG.Characters;

public enum CharacterType
{
    Controller, // Player
    Servant,
    Enemy
}
public enum UpgradableTraits
{
    Health,
    Resistance,
    Dodge
}
public enum Hero { } // TODO
public enum Enemy { } // TODO
public abstract class Character
{
    public Guid Id { get; }
    public string Name { get; }
    public CharacterType Type { get; }
    public TilePosition Position { get; set; }
    public int Level { get; set; }
    public int XP { get; set; } // figure out xp amount for each level
    public double Health { get; set; }
    public double Resistance { get; set; }
    public double Dodge { get; set; }
    public List<IPotion> Potions { get; set; }
    public List<IWeapon> Weapons { get; set; }
    public IWeapon CurrentWeapon { get; set; }

    public int Attack() => CurrentWeapon.Damage * (Level / 100); // should increase with level so like level 12 should give you a 1.2% passive damage increase
    public int LevelUp()
    {
        Level += 1;

        return Level;
    }
    public int TakeDamage(int Damage)
    {
        // TODO: calculate dodge probability chance
        Health -= Damage * (1 - (Resistance / 100));

        return Damage;
    }
}
