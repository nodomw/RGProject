using System;
namespace FantasyRPG.Map.Tiles
{
    public class Empty : Tile
    {
        public new readonly Guid Id = Guid.NewGuid();
        public new readonly TileType Type = TileType.Empty;
        public new string Name { get; set; } = "Empty";
        public new string Interact() => "An empty piece of land. Nothing to see here.";
    }
}
