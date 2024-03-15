using FantasyRPG.Characters;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles
{
    public class Player : ITile
    {
        public Player(string name, Character character)
        {
            Name = name;
            Character = character;
        }
        public Guid Id { get; } = Guid.NewGuid();
        public TileType Type { get; } = TileType.Player;
        public string Name { get; set; }
        public Character Character { get; }
        public TilePosition Position { get; set; }
        public Markup DisplayCharacter { get; } = new Markup("[white]*[/]");
        public string Interact() => "You, yourself and you.";
    }
}
