// Ignore Spelling: Enums
using System.ComponentModel;
using FantasyRPG.Map.Tiles;
using Spectre.Console;

namespace FantasyRPG.Map;

public enum DrawCriteria
{
    Name,
    Guid,
    DisplayCharacter
}

public class Map
{
    public Map(string name, ITile[,] tiles)
    {
        Name = name;
        Tiles = tiles;
        // set the TilePosition for all tiles
        for (int x = 0; x < tiles.GetLength(0); x++)
        {
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                tiles[x, y].Position = new TilePosition(x, y);
                if (tiles[x, y] is Player)
                {
                    PlayerTile = (Player)tiles[x, y];
                }
            }
        }
    }
    public ITile[,] Tiles { get; set; } // Tile & TileType
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; }
    public Player PlayerTile { get; set; }

    public void MoveTile(ITile tile, TilePosition to)
    {
        // move the tile at 'to' to the position of 'tile'
        ITile tile1 = GetTileByPosition(to);
        Tiles[tile.Position.X, tile.Position.Y] = tile1;

        // move 'tile' to 'to'
        Tiles[to.X, to.Y] = tile;
        tile.Position = to;
    }
    public bool ReplaceTile(TilePosition at, ITile tile) // TODO (same here)
    {
        if (Tiles[at.X, at.Y] == null) return false;

        Tiles[at.X, at.Y] = tile;

        return true;
    }
    public void Draw(DrawCriteria criteria) // Draw the map;
    {
        for (int x = 0; x < Tiles.GetLength(0); x++)
        {
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                switch (criteria)
                {
                    case DrawCriteria.Name:
                        Console.Write(Tiles[x, y].Name);
                        break;
                    case DrawCriteria.Guid:
                        Console.Write(Tiles[x, y].Id);
                        break;
                    case DrawCriteria.DisplayCharacter:
                        AnsiConsole.Write(Tiles[x, y].DisplayCharacter);
                        break;
                }
                AnsiConsole.Write("     ");
            }
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();
        }
    }
    public ITile GetTileById(Guid id) // Get a tile by its id
    {
        foreach (var tile in Tiles)
        {
            if (tile.Id == id) return tile;
        }
        return new Empty();
    }
    // Get a tile by its position
    public ITile GetTileByPosition(TilePosition position) => Tiles[position.X, position.Y];
}
