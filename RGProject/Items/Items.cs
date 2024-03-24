using FantasyRPG.Characters;

namespace FantasyRPG.Items;

public enum MagicType
{
    Fire, // Enemy takes passive damage over time (2-3 turns)
    Ice, // Decreases enemy DMG
    Dark, // Cast spells to support the damage output of your team
    Light // Heal your team
}
public enum WeaponType
{
    Sword,
    Bow,
    Spell
}
public enum PotionModifier // Potion modifiers
{
    Heal, // Heals (n)
    Damage, // Increases damage by (n)%
    Resistance, // Increases resistance to attacks by (n)%
    Run,
    Multi
}
public interface IWeapon
{
    Guid Id { get; }
    string Name { get; }
    string Description { get; }
    int Level { get; set; }
    int Damage { get; set; }

    // damage from attacks is returned as 'int'. double is needed for multiplication
    int Attack();
    double Critical();
    string Interact();
}
public interface IPotion
{
    string Name { get; }
    string Description { get; }
    int Power { get; }
    PotionModifier Stat { get; }
    double Use(ICharacter character);
}
public interface IMagic : IWeapon
{
    MagicType Type { get; }
}
public interface ITem // haha get it
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
}
public abstract class Weapon : ITem
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; }
    public string Description { get; }
    // public int Level { get; set; }
    // public int Damage { get; set; }

    public double HPBuff { get; set; }
    public double DmgBuff { get; set; }
    public double DEFBuff { get; set; }
    public double StunBuff { get; set; }
    public double ComboBuff { get; set; }
    public double CATKBuff { get; set; }
    public double DodgeBuff { get; set; }
    public double CritBuff { get; set; }

    // damage from attacks is returned as 'int'. double is needed for multiplication
    // public int Attack() => Damage;
    // public double Critical() => Damage * 1.5;
    public dynamic Interact() => "";
}
public abstract class Potion : ITem, IPotion
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; }
    public string Description { get; }
    public int Power { get; }
    public PotionModifier Stat { get; }
    public double Use(ICharacter character)
    {
        switch (Stat)
        {
            case PotionModifier.Heal:
                character.Health += Power;
                return (double)character.Health;
            case PotionModifier.Damage:
                character.Weapon.Damage += Power;
                return (double)character.Damage;
            case PotionModifier.Resistance:
                character.DEF += Power;
                return (double)character.DEF;
            case PotionModifier.Run: // do nothing cuz it doesnt do anything in battles just on map
                character.RunBoost = true;
                goto default;
            case PotionModifier.Multi:
                character.DEF += 10;
                character.Health += 5;
                goto default;
            default:
                return 0;
        }
    }
}
