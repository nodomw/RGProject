using Spectre.Console;

namespace FantasyRPG.Map;

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
public abstract class Tile
{
    public Guid Id { get; } = Guid.NewGuid();
    public TileType Type { get; }
    public TilePosition Position { get; set; } // TODO: add to all classes that inherit
    public string Name { get; set; }
    public string Interact() => "The world is at your fingertips.";
    public Markup DisplayCharacter { get; } = new Markup("[blue].[/]");
}

