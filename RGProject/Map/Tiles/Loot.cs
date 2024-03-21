using FantasyRPG.Characters;
using FantasyRPG.Items;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles;

public class Loot(Item item) : ITile, ILootable
{
    public Guid Id { get; } = Guid.NewGuid();
    public TileType Type { get; } = TileType.Loot;
    public Item Item { get; set; } = item;
    public string Name { get; set; } = "Loot";
    public bool Passable { get; set; } = true;
    public TilePosition Position { get; set; }
    public Markup DisplayCharacter { get; set; } = new Markup("[yellow]$[/]");
    public void Interact(ICharacter character) => character.Items.Add(Item);
}
