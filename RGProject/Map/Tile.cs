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
public class TilePosition(Tile tile, int x, int y /*int z*/)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Tile Tile { get; set; } = tile;
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    // public int Z { get; set; }
}
internal interface ITile
{
    public Guid Id { get; }
    public TileType Type { get; }
    public string Name { get; set; }
    public Markup DisplayCharacter { get; }
    string Interact();
    // dynamic Clone(); // figure this one out
}
internal interface ICharacterTile
{
    public void Move(TilePosition to);
}
public abstract class Tile : ITile
{
    public Guid Id { get; } = Guid.NewGuid();
    public TileType Type { get; }
    public string Name { get; set; }
    public string Interact() => "The world is at your fingertips.";
    public Markup DisplayCharacter { get; } = new Markup("[darkgray].[/]");
}

