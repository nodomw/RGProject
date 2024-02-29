using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Map.Tiles
{
    public class Terrain : ITile
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly Tile Type = Tile.Terrain;
        public string Name { get; set; }
        public string Interact() => "Nature, in all it's might and glory.";
    }
}
