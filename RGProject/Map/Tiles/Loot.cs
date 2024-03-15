using FantasyRPG.Items;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles;

public class Loot : Tile
{
    public Loot(Item item)
    {
        Item = item;
    }
    public new readonly Guid Id = Guid.NewGuid();
    public new readonly TileType Type = TileType.Loot;
    public Item Item { get; set; }
    public new string Name { get; set; } = "Loot";
    public new Markup DisplayCharacter { get; } = new Markup("[yellow]$[/]");
    public new string Interact() => "Treasures galore!";
}
