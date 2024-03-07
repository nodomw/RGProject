namespace FantasyRPG.Items.Weapons;

public class Spell : Weapon
{
    public Spell(int level, MagicType magicType)
    {
        Level = level;
        Type = magicType;
    }

    public new string Name { get; } = "Magic Book";
    public new string Description { get; } = "Show your worth as a mage on the battlefield.";
    public new int Level { get; set; } = 0;
    public new int Damage { get; set; } = 7;
    public MagicType Type { get; }

    // TODO: temporary
    public new int Attack() => Damage;
    public new double Critical() => Damage * 0.52;
    public new string Interact() => "";

}
