using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Map
{
    public enum TileType
    {
        Empty,
        Terrain,
        Enemy,
        Loot,
        Servant,
        Player
    }
    public class TilePosition
    {
        public TilePosition(Tile tile, int x, int y, int z)
        {
            Tile = tile;
            X = x;
            Y = y;
            Z = z;
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public Tile Tile { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
    internal interface ITile
    {
        public Guid Id { get; }
        public TileType Type { get; }
        public string Name { get; set; }
        string Interact();
        // dynamic Clone(); // figure this one out
    }
    public abstract class Tile : ITile
    {
        public Guid Id { get; } = Guid.NewGuid();
        public TileType Type { get; }
        public string Name { get; set; }
        public string Interact() => "The world is at your fingertips.";
    }
}
    
