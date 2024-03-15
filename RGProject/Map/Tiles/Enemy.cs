using FantasyRPG.Characters;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles;


public class Enemy : Tile
{
    public Enemy(string name, Character character)
    {
        Name = name;
        Character = character;
    }
    public new readonly Guid Id = Guid.NewGuid();
    public new readonly TileType Type = TileType.Enemy;
    public Character Character { get; }
    public new TilePosition Position { get; set; }
    public new string Name { get; set; } = "Enemy";
    public new Markup DisplayCharacter { get; } = new Markup("[red]![/]");
    public new string Interact() => "A vicious foe.";
}
