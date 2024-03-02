using FantasyRPG.Items;

namespace FantasyRPG.Map.Tiles
{
    public class Loot : Tile
    {
        public new readonly Guid Id = Guid.NewGuid();
        public new readonly TileType Type = TileType.Loot;
        public new string Name { get; set; } = "Loot";
        public Item Treasure { get; set; }
        public new string Interact() => "Treasures galore!";
    }
}
