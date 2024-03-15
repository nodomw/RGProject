using FantasyRPG.Characters;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles;


public class Enemy : ITile
{
    public Enemy(string name, Character character)
    {
        Name = name;
        Character = character;
    }
    public Guid Id { get; } = Guid.NewGuid();
    public TileType Type { get; } = TileType.Enemy;
    public Character Character { get; }
    public TilePosition Position { get; set; }
    public string Name { get; set; } = "Enemy";
    public Markup DisplayCharacter { get; } = new Markup("[red]![/]");
    public string Interact() => "A vicious foe.";
}
