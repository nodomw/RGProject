// Ignore Spelling: Enums
using FantasyRPG.Combat;
using FantasyRPG.Map.Tiles;
using Spectre.Console;

namespace FantasyRPG.Map;

public enum DrawCriteria
{
    Name,
    Guid,
    DisplayCharacter
}

public enum MoveDirection
{
    Up, // Tile.Position.Y + 1
    Down, // Tile.Position.Y - 1
    Left, // Tile.Position.X - 1
    Right // Tile.Position.X + 1
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
        try
        {
            // move the tile at 'to' to the position of 'tile'
            ITile tile1 = GetTileByPosition(to);
            Tiles[tile.Position.X, tile.Position.Y] = tile1;

            // move 'tile' to 'to'
            Tiles[to.X, to.Y] = tile;
            tile.Position = to;
        }
        catch (IndexOutOfRangeException)
        {
            AnsiConsole.MarkupLine("[red1]You can't move there![/]");
        }

        // in case
        if (typeof(Player).IsInstanceOfType(tile))
        {
            PlayerTile = (Player)tile;
        }

    }
    public void MoveTileDirection(ITile tile, MoveDirection direction)
    {
        switch (direction)
        {
            case MoveDirection.Up:
                MoveTile(tile, new TilePosition(tile.Position.Y + 1, tile.Position.X));
                break;
            case MoveDirection.Down:
                MoveTile(tile, new TilePosition(tile.Position.Y - 1, tile.Position.X));
                break;
            case MoveDirection.Left:
                MoveTile(tile, new TilePosition(tile.Position.Y, tile.Position.X - 1));
                break;
            case MoveDirection.Right:
                MoveTile(tile, new TilePosition(tile.Position.Y, tile.Position.X + 1));
                break;
        }
    }
    public bool ReplaceTile(TilePosition at, ITile tile)
    {
        if (Tiles[at.X, at.Y] == null) return false;

        Tiles[at.X, at.Y] = tile;

        return true;
    }
    public void DrawFull(DrawCriteria criteria) // Draw the map;
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
                AnsiConsole.Write("  ");
            }
            // AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();
        }
    }
    public void DrawGrid() // do not look at this
    {
        TilePosition Center = PlayerTile.Position;

        Markup[,] grid = new Markup[,]
        {
            {
                GetTileByPosition(new TilePosition(Center.X - 2, Center.Y + 2)).DisplayCharacter,
                GetTileByPosition(new TilePosition(Center.X - 1, Center.Y + 2)).DisplayCharacter,
                GetTileByPosition(new TilePosition(Center.X, Center.Y + 2)).DisplayCharacter,
                GetTileByPosition(new TilePosition(Center.X + 1, Center.Y + 2)).DisplayCharacter,
                GetTileByPosition(new TilePosition(Center.X + 2, Center.Y + 2)).DisplayCharacter,
            },
            {
                GetTileByPosition(new TilePosition(Center.X - 2, Center.Y + 1)).DisplayCharacter,
                GetTileByPosition(new TilePosition(Center.X - 1, Center.Y + 1)).DisplayCharacter, // Northwest
                GetTileByPosition(new TilePosition(Center.X, Center.Y + 1)).DisplayCharacter, // North
                GetTileByPosition(new TilePosition(Center.X + 1, Center.Y + 1)).DisplayCharacter, // Northeast
                GetTileByPosition(new TilePosition(Center.X + 2, Center.Y + 1)).DisplayCharacter,
            },
            {
                GetTileByPosition(new TilePosition(Center.X - 2, Center.Y)).DisplayCharacter,
                GetTileByPosition(new TilePosition(Center.X - 1, Center.Y)).DisplayCharacter, // West
                GetTileByPosition(Center).DisplayCharacter, // Center
                GetTileByPosition(new TilePosition(Center.X + 1, Center.Y)).DisplayCharacter, // East
                GetTileByPosition(new TilePosition(Center.X + 2, Center.Y)).DisplayCharacter,
            },
            {
                GetTileByPosition(new TilePosition(Center.X - 2, Center.Y - 1)).DisplayCharacter,
                GetTileByPosition(new TilePosition(Center.X - 1, Center.Y - 1)).DisplayCharacter, // Southwest
                GetTileByPosition(new TilePosition(Center.X, Center.Y - 1)).DisplayCharacter, // South
                GetTileByPosition(new TilePosition(Center.X + 1, Center.Y - 1)).DisplayCharacter, // Southeast
                GetTileByPosition(new TilePosition(Center.X + 2, Center.Y - 1)).DisplayCharacter,
            },
            {
                GetTileByPosition(new TilePosition(Center.X - 2, Center.Y - 2)).DisplayCharacter,
                GetTileByPosition(new TilePosition(Center.X - 1, Center.Y - 2)).DisplayCharacter,
                GetTileByPosition(new TilePosition(Center.X, Center.Y - 2)).DisplayCharacter,
                GetTileByPosition(new TilePosition(Center.X + 1, Center.Y - 2)).DisplayCharacter,
                GetTileByPosition(new TilePosition(Center.X + 2, Center.Y - 2)).DisplayCharacter,
            }
        };

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                AnsiConsole.Write(grid[x, y]);
                AnsiConsole.Write("  ");
            }
            // AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();
        }
    }
    public ITile GetTileById(Guid id) // just hope it doesn't take O(n^2)
    {
        // if LINQ was evil:
        // Tiles.AsQueryable().Select(tile => tile.Id == id);

        // if LINQ was good:
        foreach (var Tile in Tiles)
        {
            if (Tile.Id == id)
            {
                return Tile;
            }
        }
        throw new Exception("Tile not found");
    }
    // Get a tile by its position
    public ITile GetTileByPosition(TilePosition tp)
    {
        try
        {
            return Tiles[tp.X, tp.Y];
        }
        catch (IndexOutOfRangeException)
        {
            Empty FakeTile = new()
            {
                Passable = true,
                Fake = true,
                DisplayCharacter = new Markup("[grey15].[/]")
            };
            return FakeTile;
        }
    }
    public string InteractWithTile(TilePosition tp)
    {
        ITile tile = GetTileByPosition(tp);
        if (tile is ILootable lootable)
        {
            lootable.Interact(PlayerTile.Character);
            return "Looted";
        }
        else if (tile is IFightable)
        {
            ((Enemy)tile).Interact(new Battle(PlayerTile.Character, ((Enemy)tile).Character));
        }
        return "Nothing happened.";
    }
}
