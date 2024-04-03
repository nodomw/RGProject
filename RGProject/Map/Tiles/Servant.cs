using FantasyRPG.Characters;
using Spectre.Console;

public enum ServantType
{
    Captain,
    Healer,
    Support
}

namespace FantasyRPG.Map.Tiles
{
    public class Servant(ServantType type) : ITile
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = "Servant";
        public TileType Type { get; } = TileType.Servant;
        public TilePosition Position { get; set; }
        public ServantType Class { get; set; } = type;
        public bool Passable { get; set; } = true;
        public Markup DisplayCharacter { get; set; } = new Markup("[blue]S[/]");
    }
}
