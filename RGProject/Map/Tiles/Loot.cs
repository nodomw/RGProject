using FantasyRPG.Items;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles;

public class Loot : ITile
{
    public Loot(Item item)
    {
        Item = item;
    }
    public Guid Id { get; } = Guid.NewGuid();
    public TileType Type { get; } = TileType.Loot;
    public Item Item { get; set; }
    public string Name { get; set; } = "Loot";
    public TilePosition Position { get; set; }
    public Markup DisplayCharacter { get; } = new Markup("[yellow]$[/]");
    public string Interact() => "Treasures galore!";
}
