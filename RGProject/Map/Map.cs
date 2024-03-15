// Ignore Spelling: Enums
using Spectre.Console;

namespace FantasyRPG.Map;

public class Map(string name, Tile[,] tiles)
{
    public Tile[,] Tiles { get; set; } = tiles; // Tile & TileType
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; } = name;

    public bool SwapTile(Tile tile, Tile tile2) // TODO (should work now though)
    {
        if (Tiles[tile.Position.X, tile.Position.Y] == null || Tiles[tile2.Position.X, tile2.Position.Y] == null) return false;

        Tiles[tile.Position.X, tile.Position.Y] = tile2;
        Tiles[tile2.Position.X, tile2.Position.Y] = tile;

        return true;
    }
    public bool ReplaceTile(TilePosition at, Tile to) // TODO (same here)
    {
        if (Tiles[at.X, at.Y] == null) return false;

        Tiles[at.X, at.Y] = to;

        return true;
    }
    public void ReplaceEnums() // this is pretty much so that you dont nessecarily need to have every single thing as a class, only stuff that has actual data (e.g: loot, players, enemies, servants)
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
    public void Draw() // Draw the map;
    {
        for (int x = 0; x < Tiles.GetLength(0); x++)
        {
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                AnsiConsole.Write(Tiles[x, y].DisplayCharacter);
                AnsiConsole.Write("     ");
            }
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();
        }
    }
}
