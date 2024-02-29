using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Map
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
}
    
