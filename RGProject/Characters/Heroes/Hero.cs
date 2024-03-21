using FantasyRPG.Characters;
using FantasyRPG.Map;
using FantasyRPG.Items;

namespace RGProject.Characters.Heroes;

public enum HeroAttacks
{
	None,
	HeroicStrike,
	Crown,
	GettingACape
}

public class Hero : ICharacter
{
	public Hero(string name)
	{
		Name = name;
	}
	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; set; }
	public CharacterType Type { get; } = CharacterType.Hero;
	public TilePosition Position { get; set; }
	public bool IsHero { get; set; } = true;
	public bool IsBoss { get; set; } = false;
	public int Level { get; set; } = 0;
	public int XP { get; set; } = 0;
	public double Health { get; set; } = 1000;
	public double MaxHealth { get; set; } = 1000;
	public double Damage { get; set; } = 450;
	public double CATK { get; set; } = 10;
	public double DEF { get; set; } = 20;
	public double Crit { get; set; } = 0;

	public double Dodge { get; set; } = 10;
	public double Stun { get; set; } = 20;
	public double Combo { get; set; } = 0;
	public double TempDodge { get; set; }
	public double TempStun { get; set; } // %
	public double TempCrit { get; set; } // %
	public double TempDmg { get; set; } // %
	public double TempDEF { get; set; } // %
	public double TempCombo { get; set; } // %
	public double TempCATK { get; set; } // %
	public List<Item> Items { get; set; }
	public IWeapon Weapon { get; set; }
}