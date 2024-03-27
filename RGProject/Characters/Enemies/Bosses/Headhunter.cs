using FantasyRPG.Characters;
using FantasyRPG.Map;
using FantasyRPG.Items;

namespace FantasyRPG.Characters.Enemies.Bosses;

public class Headhunter(string name) : ICharacter
{
	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; set; } = name;
	public CharacterType Type { get; }
	public TilePosition Position { get; set; }
	public bool IsHero { get; set; } = false;
	public bool IsBoss { get; set; } = true;
	public bool IsCaptain { get; set; }
	public bool IsHealer { get; set; }
	public bool IsSupport { get; set; }
	public bool SilentStep { get; set; } = false;
	public bool Fans { get; set; } = false;
	public bool RunBoost { get; set; } = false;
	public bool MultiBooster { get; set; } = false;
	public int Level { get; set; } = 0;
	public int XP { get; set; } = 0;
	public double Health { get; set; } = 6000;
	public double MaxHealth { get; set; } = 6000;
	public double Damage { get; set; } = 300;
	public double CATK { get; set; } = 0;
	public double DEF { get; set; } = 0;
	public double Crit { get; set; } = 0;
	public double Dodge { get; set; } = 25;
	public double Stun { get; set; } = 10;
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