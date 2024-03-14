using FantasyRPG.Characters;
using FantasyRPG.Map;
using FantasyRPG.Items;

namespace RGProject.Characters.Enemies;

public class Prince : Character
{
	public Prince(string name)
	{
		Name = name;
	}

	public new CharacterType Type { get; }
	public new TilePosition Position { get; set; }
	public new int Level { get; set; } = 0;
	public new int XP { get; set; } = 0;
	public new double Health { get; set; } = 2700;
	public new double DEF { get; set; } = 0;
	public new double Dodge { get; set; } = 20;
	public new double Stun { get; set; } = 10;
	public new List<IPotion> Potions { get; set; }
	public new IWeapon Weapon { get; set; }
}