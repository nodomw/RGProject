namespace FantasyRPG.Map.Tiles
{
    public class Enemy : Tile
    {
        public new readonly Guid Id = Guid.NewGuid();
        public new readonly TileType Type = TileType.Enemy;
        public new string Name { get; set; } = "Enemy";
        public new string Interact() => "A vicious foe.";
    }
}
