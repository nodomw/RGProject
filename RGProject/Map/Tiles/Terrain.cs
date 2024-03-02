using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Map.Tiles
{
    public class Terrain : Tile
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly TileType Type = TileType.Terrain;
        public string Name { get; set; } = "Terrain";
        public string Interact() => "Nature, in all it's might and glory.";
    }
}
