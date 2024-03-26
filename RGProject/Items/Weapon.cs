namespace FantasyRPG.Items;

public class Weapon : Item
{
	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; }
	public string Description { get; }
	// public int Level { get; set; }
	// public int Damage { get; set; }

	public double HPBuff { get; set; }
	public double DmgBuff { get; set; }
	public double DEFBuff { get; set; }
	public double StunBuff { get; set; }
	public double ComboBuff { get; set; }
	public double CATKBuff { get; set; }
	public double DodgeBuff { get; set; }
	public double CritBuff { get; set; }

	// damage from attacks is returned as 'int'. double is needed for multiplication
	// public int Attack() => Damage;
	// public double Critical() => Damage * 1.5;
	public dynamic Interact() => "";
}
public interface IWeapon
{
	Guid Id { get; }
	string Name { get; }
	string Description { get; }
	int Level { get; set; }
	int Damage { get; set; }

	// damage from attacks is returned as 'int'. double is needed for multiplication
	int Attack();
	double Critical();
	string Interact();
}
