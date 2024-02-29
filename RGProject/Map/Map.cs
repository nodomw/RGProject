using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Map
{
    internal interface IMap
    {
        Guid Id { get; }
        string Name { get; }
        Tile[,,] Tiles { get; set; }
        Tile SwapTile(Tile tileToSwap);
        Tile[,,] ReplaceTile(Tile tileToReplace);
    }
    public class Map : IMap
    {
        // Map is a 3D matrix of 'Tile'
        // Z0: Decorations and 'Terrain' Tiles
        // Z1: Enemy Tiles
        // Z2: Loot and Servant Tiles
        // Z3: Player Tile

        public Map(string name, Tile[,,] tiles)
        {
            Name = name;
            Tiles = tiles;
        }
        public Tile[,,] Tiles { get; set; }
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
        
        public Tile SwapTile(Tile tile) // TODO
        {
            return tile;
        }
    }
}
