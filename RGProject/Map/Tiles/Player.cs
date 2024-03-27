using FantasyRPG.Characters;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles
{
    public class Player(ICharacter character) : ITile, ICharacterTile
    {
        public Guid Id { get; } = Guid.NewGuid();
        public TileType Type { get; } = TileType.Player;
        public string Name { get; set; } = "Hero";
        public ICharacter Character { get; } = character;
        public bool Passable { get; set; } = true;
        public TilePosition Position { get; set; }
        public Markup DisplayCharacter { get; set; } = new Markup("[bold white]@[/]");
    }
}
