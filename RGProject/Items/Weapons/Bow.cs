namespace FantasyRPG.Items.Weapons;

public class Bow : Weapon
{
    public Bow(int level) => Level = level;
    public new string Name { get; } = "Longbow";
    public new string Description { get; } = "Mastered by Hungarian archers, stolen by the Ango-Saxons.";
    public new int Level { get; set; } = 0;
    public new int Damage { get; set; } = 15;

    // TODO: temporary
    public new int Attack() => Damage;
    public new double Critical() => Damage * 2;
    public new string Interact() => "";

}
