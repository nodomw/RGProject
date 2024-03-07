namespace FantasyRPG.Items.Weapons;

public class Sword : Weapon
{
    public Sword(int level) => Level = level;
    public new string Name { get; } = "Greatsword";
    public new string Description { get; } = "Your typical run of the mill greatsword. Good for looking cool, and sometimes for slaying monsters.";
    public new int Level { get; set; } = 0;
    public new int Damage { get; set; } = 15;

    // TODO: temporary
    public new int Attack() => Damage;
    public new double Critical() => Damage * 1.5;
    public new string Interact() => "";

}
