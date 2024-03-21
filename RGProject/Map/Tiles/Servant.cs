using FantasyRPG.Characters;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles
{
    public class Servant : ITile
    {
        public Servant(string name, ICharacter character)
        {
            Name = name;
            Character = character;
        }
        public Guid Id { get; } = Guid.NewGuid();
        public TileType Type { get; } = TileType.Servant;
        public ICharacter Character { get; }
        public TilePosition Position { get; set; }
        public bool Passable { get; set; } = true;
        public string Name { get; set; } = "Servant";
        public Markup DisplayCharacter { get; set; } = new Markup("[blue]S[/]");
        public string Interact() => "Your fellow ally, ready to help out at a moment's notice.";
    }
}
