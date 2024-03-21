using FantasyRPG.Characters;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles
{
    public class Player : ITile
    {
        public Player(string name, ICharacter character)
        {
            Name = name;
            Character = character;
        }
        public Guid Id { get; } = Guid.NewGuid();
        public TileType Type { get; } = TileType.Player;
        public string Name { get; set; }
        public ICharacter Character { get; }
        public bool Passable { get; set; } = true;
        public TilePosition Position { get; set; }
        public Markup DisplayCharacter { get; set; } = new Markup("[bold white]@[/]");
    }
}
