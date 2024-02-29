using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Map.Tiles
{
    public class Enemy : ITile
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly Tile Type = Tile.Enemy;
        public string Name { get; set; }
        public string Interact() => "A vicious foe.";
    }
}
