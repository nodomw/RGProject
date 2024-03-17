using FantasyRPG.Characters;
using FantasyRPG.Map;
using FantasyRPG.Items;

namespace RGProject.Characters.Enemies;

public class Prince : ICharacter
{
	public Prince(string name)
	{
		Name = name;
	}
	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; set; }
	public CharacterType Type { get; }
	public TilePosition Position { get; set; }
	public int Level { get; set; } = 0;
	public int XP { get; set; } = 0;
	public double Health { get; set; } = 2700;
	public double Damage { get; set; } = 300;
	public double CATK { get; set; } = 0;
	public double DEF { get; set; } = 0;
	public double Crit { get; set; } = 0;
	public double Dodge { get; set; } = 20;
	public double Stun { get; set; } = 10;
	public double Combo { get; set; } = 0;
	public double TempDodge { get; set; }
	public double TempStun { get; set; } // %
	public double TempCrit { get; set; } // %
	public double TempDmg { get; set; } // %
	public double TempDEF { get; set; } // %
	public List<IPotion> Potions { get; set; }
	public IWeapon Weapon { get; set; }
}