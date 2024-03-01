using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Controller
{
    public enum PlayerState
    {
        Map, // walking around the map
        Menu, // has any menu open
        Fighting // in midst of a fight
    }
    public interface Player
    { 
        Character character { get; }
    }
}
