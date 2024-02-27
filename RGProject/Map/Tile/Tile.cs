using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Map.Tile
{
    enum TileType
    {
        Terrain,
        Enemy,
        Loot,
        Servant,
        Player
    }
    internal class Tile
    {

        public Tile(string TileName, TileType TileType)
        {
            ID = Guid.NewGuid();
            Name = TileName;
            Type = TileType;
        }

        public Guid ID { get; }
        public string Name { get; }
        public TileType Type { get; }

    }
}
