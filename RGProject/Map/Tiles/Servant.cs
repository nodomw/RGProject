using FantasyRPG.Characters;

namespace FantasyRPG.Map.Tiles
{
    public class Servant : Tile
    {
        public Servant(string name, Character character)
        {
            Name = name;
            Character = character;
        }
        public new readonly TileType Type = TileType.Servant;
        public Character Character { get; }
        public new string Name { get; set; } = "Servant";
        public new string Interact() => "Your fellow ally, ready to help out at a moment's notice.";
    }
}
