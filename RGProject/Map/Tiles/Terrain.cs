using Spectre.Console;

namespace FantasyRPG.Map.Tiles
{
    public class Terrain : ITile
    {
        public Guid Id { get; } = Guid.NewGuid();
        public TileType Type { get; } = TileType.Terrain;
        public string Name { get; set; } = "Terrain";
        public TilePosition Position { get; set; }
        public bool Passable { get; set; } = true;
        public Markup DisplayCharacter { get; set; } = new Markup("[green]#[/]");
    }
}
