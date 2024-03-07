// Ignore Spelling: Enums

namespace FantasyRPG.Map
{
    internal interface IMap
    {
        Guid Id { get; }
        string Name { get; }
        // Tile[,,] Tiles { get; set; } // maybe
        Tile[,] Tiles { get; }
        // !! NO RETURN VALUE ONLY STATUS !!
        bool SwapTile(TilePosition tile1, TilePosition tile2);
        bool ReplaceTile(TilePosition tp, Tile tile);
        void ReplaceEnums();
    }

    public class Map(string name, Tile[,] tiles) : IMap
    {
        public Tile[,] Tiles { get; set; } = tiles;
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; } = name;

        public bool SwapTile(TilePosition tile1, TilePosition tile2) // TODO (should work now though)
        {
            if (Tiles[tile1.X, tile1.Y] == null || Tiles[tile2.X, tile2.Y] == null) return false;

            Tiles[tile1.X, tile1.Y] = tile2.Tile;
            Tiles[tile2.X, tile2.Y] = tile1.Tile;

            return true;
        }
        public bool ReplaceTile(TilePosition tp, Tile tile) // TODO (same here)
        {
            if (Tiles[tp.X, tp.Y] == null) return false;

            Tiles[tp.X, tp.Y] = tile;

            return true;
        }
        public void ReplaceEnums() // TODO (and here)
        {
            for (int x = 0; x < Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < Tiles.GetLength(1); y++)
                {
                    // All tiles that contain data should be a class, not enum 
                    switch (Tiles[x, y].Type)
                    {
                        case TileType.Terrain:
                            Tiles[x, y] = new Tiles.Terrain();
                            break;
                        case TileType.Empty:
                            Tiles[x, y] = new Tiles.Empty();
                            break;
                        default: // do nothing for everything else
                            break;
                    }
                }
            }
        }
    }
}
