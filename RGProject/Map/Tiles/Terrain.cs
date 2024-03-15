using Spectre.Console;

namespace FantasyRPG.Map.Tiles
{
    public class Terrain : ITile
    {
        public Guid Id { get; } = Guid.NewGuid();
        public TileType Type { get; } = TileType.Terrain;
        public string Name { get; set; } = "Terrain";
        public TilePosition Position { get; set; }
        public Markup DisplayCharacter { get; } = new Markup("[green]#[/]");
        public string Interact() => "Nature, in all it's might and glory.";
    }
}
