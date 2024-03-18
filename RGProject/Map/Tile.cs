using Spectre.Console;

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
    Player
}
public class TilePosition(int x, int y /*int z*/)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    // public int Z { get; set; }
}
public interface ITile
{
    public Guid Id { get; }
    public TileType Type { get; }
    public TilePosition Position { get; set; } // TODO: add to all classes that inherit
    public bool Passable { get; set; }
    public string Name { get; set; }
    public string Interact();
    public Markup DisplayCharacter { get; }
}

