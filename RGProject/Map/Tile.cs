using Spectre.Console;
using FantasyRPG.Characters;
using FantasyRPG.Combat;

namespace FantasyRPG.Map;

public enum EnemyTile
{
    Emperor,
    Headhunter,
    Prince,
    Vampire
}
public enum CharacterTile
{
    Assasin,
    Elf,
    Hero,
    Hunter,
    Mage,
    Ninja,
    Paladin,
    Warrior
}
public enum TileType
{
    Empty,
    Terrain,
    Enemy,
    Loot,
    Servant,
    Player,
    Exit
}

public class TilePosition(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}
public interface ITile
{
    public Guid Id { get; }
    public TileType Type { get; }
    public TilePosition Position { get; set; }
    public bool Passable { get; set; }
    public string Name { get; set; }
    public Markup DisplayCharacter { get; set; }
}

public interface ILootable
{
    public bool Looted { get; set; }
    public void Interact(ICharacter character);
}

public interface IFightable
{
    public void Interact(Battle battle);
}

public interface ICharacterTile
{
    public ICharacter Character { get; }
}

public interface ITileExit
{
    public void Interact(Map map);
}

