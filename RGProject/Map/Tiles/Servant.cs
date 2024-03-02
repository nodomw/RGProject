namespace FantasyRPG.Map.Tiles
{
    public class Servant : Tile
    {
        public readonly Guid Id = Guid.NewGuid();
        public readonly TileType Type = TileType.Servant;
        public string Name { get; set; } = "Servant";
        public string Interact() => "Your fellow ally, ready to help out at a moment's notice.";
    }
}
