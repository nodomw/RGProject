using FantasyRPG.Characters;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles
{
    public class Servant(string name, ICharacter character) : ITile, ICharacterTile
    {
        public Guid Id { get; } = Guid.NewGuid();
        public TileType Type { get; } = TileType.Servant;
        public ICharacter Character { get; } = character;
        public TilePosition Position { get; set; }
        public bool Passable { get; set; } = true;
        public string Name { get; set; } = name;
        public Markup DisplayCharacter { get; set; } = new Markup("[blue]S[/]");
    }
}
