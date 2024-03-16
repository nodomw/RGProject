using FantasyRPG.Characters;
using FantasyRPG.Map;
using FantasyRPG.Items;

namespace RGProject.Characters.Heroes;

public enum ElfAttacks
{
	None,
	ArrowShot,
	ArrowRain,
	ShockingArrow
}
public class Elf : ICharacter
{
	public Elf(string name)
	{
		Name = name;
	}
	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; set; }
	public CharacterType Type { get; } = CharacterType.Elf;
	public TilePosition Position { get; set; }
	public int Level { get; set; } = 0;
	public int XP { get; set; } = 0;
	public double Health { get; set; } = 500;
	public double Damage { get; set; } = 500;
	public double CounterDamage { get; set; } = 15;
	public double DEF { get; set; } = 20;
	public double Dodge { get; set; } = 30;
	public double Stun { get; set; } = 15;
	public double Combo { get; set; } = 0;
	public List<IPotion> Potions { get; set; }
	public IWeapon Weapon { get; set; }
}

