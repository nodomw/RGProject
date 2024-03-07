namespace FantasyRPG.Map.Tiles
{
    public class Servant : Tile
    {
        public new readonly Guid Id = Guid.NewGuid();
        public new readonly TileType Type = TileType.Servant;
        public new string Name { get; set; } = "Servant";
        public new string Interact() => "Your fellow ally, ready to help out at a moment's notice.";
    }
}
