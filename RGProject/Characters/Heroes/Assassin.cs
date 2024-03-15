using FantasyRPG.Characters;
using FantasyRPG.Map;
using FantasyRPG.Items;

namespace RGProject.Characters.Heroes;

public class Assassin : ICharacter
{
	public Assassin(string name)
	{
		Name = name;
	}

	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; set; }
	public CharacterType Type { get; }
	public TilePosition Position { get; set; }
	public int Level { get; set; } = 0;
	public int XP { get; set; } = 0;
	public double Health { get; set; } = 300;
	public double Damage { get; set; } = 600;
	public double CounterDamage { get; set; } = 10;
	public double DEF { get; set; } = 5; // %
	public double Dodge { get; set; } = 25;
	public double Stun { get; set; } = 25;
	public double Combo { get; set; } = 0;
	public List<IPotion> Potions { get; set; }
	public IWeapon Weapon { get; set; }
}