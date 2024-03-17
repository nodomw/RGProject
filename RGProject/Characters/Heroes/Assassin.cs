using FantasyRPG.Characters;
using FantasyRPG.Map;
using FantasyRPG.Items;

namespace RGProject.Characters.Heroes;

public enum AssassinAttacks
{
	None,
	DaggerStrike,
	PoisonDagger,
	ShadowStrike
}

public class Assassin : ICharacter
{
	public Assassin(string name)
	{
		Name = name;
	}

	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; set; }
	public CharacterType Type { get; } = CharacterType.Assassin;
	public TilePosition Position { get; set; }
	public int Level { get; set; } = 0;
	public int XP { get; set; } = 0;
	public double Health { get; set; } = 300;
	public double Damage { get; set; } = 600;
	public double CATK { get; set; } = 10;
	public double DEF { get; set; } = 5; // %
	public double Crit { get; set; } = 0;
	public double Dodge { get; set; } = 25;
	public double Stun { get; set; } = 25;
	public double Combo { get; set; } = 0;
	public double TempDodge { get; set; } = 75;
	public double TempStun { get; set; } // %
	public double TempCrit { get; set; } // %
	public double DmgBoost { get; set; } // %
	public double DEFBoost { get; set; } // %
	public List<IPotion> Potions { get; set; }
	public IWeapon Weapon { get; set; }
}