using FantasyRPG.Characters;
using FantasyRPG.Map;
using FantasyRPG.Items;

namespace RGProject.Characters.Heroes;

public class Warrior : ICharacter
{
	public Warrior(string name)
	{
		Name = name;
	}
	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; set; }
	public CharacterType Type { get; }
	public TilePosition Position { get; set; }
	public int Level { get; set; } = 0;
	public int XP { get; set; } = 0;
	public double Health { get; set; } = 400;
	public double Damage { get; set; } = 500;
	public double CounterDamage { get; set; } = 20;
	public double DEF { get; set; } = 20;
	public double Dodge { get; set; } = 0;
	public double Stun { get; set; } = 5;
	public double Combo { get; set; } = 0;
	public List<IPotion> Potions { get; set; }
	public IWeapon Weapon { get; set; }
}