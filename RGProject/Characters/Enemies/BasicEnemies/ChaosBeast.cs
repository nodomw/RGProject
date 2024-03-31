using FantasyRPG.Items;
using FantasyRPG.Map;

namespace FantasyRPG.Characters.Enemies.BasicEnemies;

public class ChaosBeast(string name) : ICharacter
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; } = name;
    public CharacterType Type { get; } = CharacterType.ChaosBeast;
    public TilePosition Position { get; set; }
    public ITile Parent { get; set; }
    public bool IsHero { get; set; } = false;
    public bool IsBoss { get; set; } = false;
    public bool IsCaptain { get; set; }
    public bool IsHealer { get; set; }
    public bool IsSupport { get; set; }
    public bool SilentStep { get; set; } = false;
    public bool Fans { get; set; } = false;
    public bool RunBoost { get; set; } = false;
    public bool MultiBooster { get; set; } = false;
    public bool BloodThirsty { get; set; }
    public bool Explorer { get; set; }
    public bool Dead { get; set; } = false;
    public int Level { get; set; } = 0;
    public int XP { get; set; } = 0;
    public double Health { get; set; } = 900;
    public double MaxHealth { get; set; } = 900;
    public double Damage { get; set; } = 500;
    public double CATK { get; set; } = 0;
    public double DEF { get; set; } = 0;
    public double Crit { get; set; } = 0;
    public double Dodge { get; set; } = 0;
    public double Stun { get; set; } = 0;
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