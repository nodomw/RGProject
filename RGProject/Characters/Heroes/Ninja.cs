using FantasyRPG.Characters;
using FantasyRPG.Map;
using FantasyRPG.Items;

namespace RGProject.Characters.Heroes;

public class Ninja : Character
{
	public Ninja(string name)
	{
		Name = name;
	}

	public new CharacterType Type { get; }
	public new TilePosition Position { get; set; }
	public new int Level { get; set; } = 0;
	public new int XP { get; set; } = 0;
	public new double Health { get; set; } = 500;
	public new double Damage { get; set; } = 400;
	public new double CounterDamage { get; set; } = 0;
	public new double Defense { get; set; } = 0;
	public new double Dodge { get; set; } = 40;
	public new double Stun { get; set; } = 5;
	public new List<IPotion> Potions { get; set; }
	public new IWeapon Weapon { get; set; }
}