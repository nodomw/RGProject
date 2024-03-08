using FantasyRPG.Characters;
using FantasyRPG.Map;
using FantasyRPG.Items;

namespace RGProject.Characters.Enemies;

public class Vampire : Character
{
	public Vampire(string name)
	{
		Name = name;
	}

	public new CharacterType Type { get; }
	public new TilePosition Position { get; set; }
	public new int Level { get; set; } = 0;
	public new int XP { get; set; } = 0;
	public new double Health { get; set; } = 1800;
	public new double Resistance { get; set; } // uhm
	public new double Dodge { get; set; } = 0;
	public new double Stun { get; set; } = 0;
	public new List<IPotion> Potions { get; set; }
	public new IWeapon Weapon { get; set; }
}