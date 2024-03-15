using Spectre.Console;

namespace FantasyRPG.Map.Tiles
{
    public class Terrain : Tile
    {
        public new readonly Guid Id = Guid.NewGuid();
        public new readonly TileType Type = TileType.Terrain;
        public new string Name { get; set; } = "Terrain";
        public new Markup DisplayCharacter { get; } = new Markup("[green]#[/]");
        public new string Interact() => "Nature, in all it's might and glory.";
    }
}
