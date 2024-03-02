using FantasyRPG.Characters;

namespace FantasyRPG.Map.Tiles
{
    public class Player : Tile
    {
        public Player(string name, Character character)
        {
            Name = name;
            Character = character;
        }
        public new readonly Guid Id = Guid.NewGuid();
        public new readonly TileType Type = TileType.Player;
        public new required string Name { get; set; }
        public Character Character { get; }
        public new string Interact() => "You, yourself and you.";
    }
}
