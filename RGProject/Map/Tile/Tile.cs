using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Map.Tile
{
    public enum Tile
    {
        Empty,
        Terrain,
        Enemy,
        Loot,
        Servant,
        Player
    }
    internal interface ITile
    {
        dynamic Interact() => "The world is at your fingertips.";
        // dynamic Clone(); // figure this one out
    }
    public class Empty : ITile
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly Tile Type = Tile.Empty;
        public string Name { get; set; }

    public string Interact() => "An empty piece of land. Nothing to see here.";
    }
    public class Terrain : ITile
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly Tile Type = Tile.Terrain;
        public string Name { get; set; }
        public string Interact() => "Nature, in all it's might and glory.";
    }
    public class Enemy : ITile
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly Tile Type = Tile.Enemy;
        public string Name { get; set; }
        public string Interact() => "A vicious foe.";
    }
    public class Loot : ITile
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly Tile Type = Tile.Loot;
        public string Name { get; set; }
        public string Interact() => "Treasures galore!";
    }
    public class Servant : ITile
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly Tile Type = Tile.Servant;
        public string Name { get; set; }
        public string Interact() => "Your fellow ally, ready to help out at a moment's notice.";
    }
    public class Player : ITile
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly Tile Type = Tile.Player;
        public string Name { get; set; }
        public string Interact() => "You, yourself and you.";
    }
}
