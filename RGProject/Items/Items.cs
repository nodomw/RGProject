using FantasyRPG.Characters;

namespace FantasyRPG.Items;

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
public interface Item // haha get it
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
}

