namespace FantasyRPG.Items.Weapons;

public class Spell : Weapon
{
    public Spell(int level, MagicType magicType)
    {
        Level = level;
        Type = magicType;
    }

    public string Name { get; } = "Magic Book";
    public string Description { get; } = "Show your worth as a mage on the battlefield.";
    public int Level { get; set; } = 0;
    public int Damage { get; set; } = 7;
    public MagicType Type { get; }

    // TODO: temporary
    public int Attack() => Damage;
    public double Critical() => Damage * 0.52;
    public string Interact() => "";

}
