using FantasyRPG.Characters;
using FantasyRPG.Combat;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles;


public class Enemy(ICharacter character) : ITile, IFightable, ICharacterTile
{
    public Guid Id { get; } = Guid.NewGuid();
    public TileType Type { get; } = TileType.Enemy;
    public ICharacter Character { get; } = character;
    public TilePosition Position { get; set; }
    public bool Passable { get; set; } = false;
    public string Name { get; set; } = "Enemy";
    public Markup DisplayCharacter { get; set; } = new Markup("[red]![/]");
    public void Interact(Battle battle) => battle.Turn();
}
