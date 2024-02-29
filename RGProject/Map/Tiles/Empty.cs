using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Map.Tiles
{
    public class Empty : ITile
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly Tile Type = Tile.Empty;
        public string Name { get; set; }

        public string Interact() => "An empty piece of land. Nothing to see here.";
    }
}
