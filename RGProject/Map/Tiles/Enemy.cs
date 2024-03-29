using FantasyRPG.Characters;
using FantasyRPG.Combat;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles;


public class Enemy : ITile, IFightable, ICharacterTile
{

    public Enemy(ICharacter character)
    {
        Character = character;
        Character.Parent = this;
    }
    public Guid Id { get; } = Guid.NewGuid();
    public TileType Type { get; } = TileType.Enemy;
    public ICharacter Character { get; }
    public TilePosition Position { get; set; }
    public bool Passable { get; set; } = true;
    public string Name { get; set; } = "Enemy";
    public Markup DisplayCharacter { get; set; } = new Markup("[red]![/]");
    public void Interact(Battle battle) => battle.Turn();
}
