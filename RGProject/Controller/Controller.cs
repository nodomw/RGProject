using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyRPG.Characters;
using FantasyRPG.Map.Tiles;

namespace FantasyRPG.Controller
{
    public enum State
    {
        Map, // walking around the map
        Menu, // has any menu open
        Fighting // in midst of a fight
    }
    public interface IPlayer // THE ONLY OBJECT WITHOUT ID...
    { 
        public Character Character { get; } // not that many properties cuz most r in character
        public Player Tile { get; } // !! PLAYER TILE !! NOT THIS INTERFACE!!
        public State State { get; set; }

        // NOT IMPLEMENTING MOVE FUNCTIONS BECAUSE THEY SHOULD BE IN TILE ITS REDUNDANT TO HAVE THEM HERE
    }
}
