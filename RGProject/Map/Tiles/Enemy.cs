using FantasyRPG.Characters;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles;


public class Enemy : ITile
{
    public Enemy(string name, ICharacter character)
    {
        Name = name;
        Character = character;
    }
    public Guid Id { get; } = Guid.NewGuid();
    public TileType Type { get; } = TileType.Enemy;
    public ICharacter Character { get; }
    public TilePosition Position { get; set; }
    public bool Passable { get; set; } = false;
    public string Name { get; set; } = "Enemy";
    public Markup DisplayCharacter { get; set; } = new Markup("[red]![/]");
    public string Interact() => "A vicious foe.";
}
