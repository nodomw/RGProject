using FantasyRPG.Characters;
using FantasyRPG.Map;

namespace FantasyRPG.Controller;

public enum State
{
    Map, // walking around the map
    Menu, // has any menu open
    Fighting, // in midst of a fight
    Main, // main menu
}
public interface IPlayer // THE ONLY OBJECT WITHOUT ID...
{
    public ICharacter Character { get; } // not that many properties cuz most r in character
    public List<ICharacter>? Servants { get; set; } // servants are characters that are not the main character
    public Player Tile { get; } // !! PLAYER TILE !! NOT THIS INTERFACE!!
    public State State { get; set; }

    // NOT IMPLEMENTING MOVE FUNCTIONS BECAUSE THEY SHOULD BE IN TILE ITS REDUNDANT TO HAVE THEM HERE
}

public class Player : IPlayer
{
    public ICharacter Character { get; }
    public List<ICharacter>? Servants { get; set; }
    public Player Tile { get; }
    public State State { get; set; }
    public Player(ICharacter character, Player tile)
    {
        Character = character;
        Tile = tile;
    }

    public Player()
    {
    }
}
