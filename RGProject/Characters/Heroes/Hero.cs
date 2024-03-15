using FantasyRPG.Characters;
using FantasyRPG.Map;
using FantasyRPG.Items;

namespace RGProject.Characters.Heroes;

public class Hero : ICharacter
{
	public Hero(string name)
	{
		Name = name;
	}
	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; set; }
	public CharacterType Type { get; }
	public TilePosition Position { get; set; }
	public int Level { get; set; } = 0;
	public int XP { get; set; } = 0;
	public double Health { get; set; } = 1000;
	public double Damage { get; set; } = 450;
	public double CounterDamage { get; set; } = 10;
	public double DEF { get; set; } = 20;
	public double Dodge { get; set; } = 10;
	public double Stun { get; set; } = 20;
	public double Combo { get; set; } = 0;
	public List<IPotion> Potions { get; set; }
	public IWeapon Weapon { get; set; }
}