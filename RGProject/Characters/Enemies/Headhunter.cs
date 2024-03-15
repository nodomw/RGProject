using FantasyRPG.Characters;
using FantasyRPG.Map;
using FantasyRPG.Items;

namespace RGProject.Characters.Enemies;

public class Headhunter : ICharacter
{
	public Headhunter(string name)
	{
		Name = name;
	}
	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; set; }
	public CharacterType Type { get; }
	public TilePosition Position { get; set; }
	public int Level { get; set; } = 0;
	public int XP { get; set; } = 0;
	public double Health { get; set; } = 6000;
	public double Damage { get; set; } = 300;
	public double CounterDamage { get; set; } = 0;
	public double DEF { get; set; } = 0;
	public double Dodge { get; set; } = 25;
	public double Stun { get; set; } = 10;
	public double Combo { get; set; } = 0;
	public List<IPotion> Potions { get; set; }
	public IWeapon Weapon { get; set; }
}