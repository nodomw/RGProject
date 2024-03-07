namespace FantasyRPG.Items.Weapons;

public class Sword : Weapon
{
    public Sword(int level) => Level = level;
    public string Name { get; } = "Greatsword";
    public string Description { get; } = "Your typical run of the mill greatsword. Good for looking cool, and sometimes for slaying monsters.";
    public int Level { get; set; } = 0;
    public int Damage { get; set; } = 15;

    // TODO: temporary
    public int Attack() => Damage;
    public double Critical() => Damage * 1.5;
    public string Interact() => "";

}
