﻿// Ignore Spelling: Enums
using FantasyRPG.Characters;
using FantasyRPG.Combat;
using FantasyRPG.Items;
using FantasyRPG.Map.Tiles;
using FantasyRPG.UI;
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
    Right, // Tile.Position.X + 1
    None
}

public class Map
{
    public Map(string name, Type placeholder, ITile[,] tiles)
    {
        Name = name;
        Placeholder = placeholder;
        Tiles = tiles;
        // set the TilePosition for all tiles
        for (int x = 0; x < Tiles.GetLength(0); x++)
        {
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                Tiles[x, y].Position = new TilePosition(x, y);
                if (Tiles[x, y] is Player)
                {
                    PlayerTile = (Player)Tiles[x, y];
                }
            }
        }
        MutableTiles = (ITile[,])Tiles.Clone();
        if (PlayerTile is not null)
        {
            PlayerTile = (Player)MutableTiles[PlayerTile.Position.X, PlayerTile.Position.Y];
            Tiles[PlayerTile.Position.X, PlayerTile.Position.Y] = (ITile)Activator.CreateInstance(Placeholder);
        }
    }
    // TODO: immutable & mutable map relations;
    // basically, where player is not and is not 'Empty()',
    // draw the mutable map.
    // otherwise, if 'Empty()'
    // then draw the tile from
    // the immutable map.

    // a bit iffy tho because
    // how do u handle the tile
    // the player spawned on
    public ITile[,] Tiles { get; set; } //! IMMUTABLE; Tile & TileType
    public ITile[,] MutableTiles { get; set; } //! MUTABLE
    public Guid Id { get; } = Guid.NewGuid();
    public bool Running { get; set; } = true; // needed for while-loop checks
    public Type Placeholder { get; }
    public string Name { get; }
    public Player PlayerTile { get; set; }

    public void MoveTile(ITile tile, TilePosition to)
    {
        try
        {
            if (GetTileByPosition(to).Passable)
            {
                // store previous position so that we can set it to empty
                TilePosition PrevPosition = tile.Position;

                // TODO: test all thees if they actually work
                if (GetTileByPosition(to) is Exit)
                {
                    Running = false;
                }

                // move 'tile' to 'to'
                MutableTiles[to.X, to.Y] = tile;
                tile.Position = to;

                if (GetTileByPosition(to, true) is Enemy enemy)
                {
                    if (!enemy.Character.Dead)
                    {
                        Console.Clear();
                        AnsiConsole.Write(new Markup("You have encountered an [red1]Enemy[/]!"));
                        Console.ReadKey();
                        new Battle(PlayerTile.Character, enemy.Character, false).Turn();
                    }
                }
                if (GetTileByPosition(to, true) is ClassLoot cl)
                {
                    Console.Clear();
                    Console.WriteLine(InteractWithTile(cl));
                    Console.ReadKey();
                }
                if (GetTileByPosition(to, true) is Servant servant)
                {
                    switch (servant.Class)
                    {
                        case ServantType.Captain:
                            Console.Clear();
                            AnsiConsole.Write(new Markup("You have encountered the [blue3_1]Captain[/]!"));
                            PlayerTile.Character.IsCaptain = true;
                            Console.ReadKey();
                            break;
                        case ServantType.Healer:
                            Console.Clear();
                            AnsiConsole.Write(new Markup("You have encountered the [blue3_1]Healer[/]!"));
                            PlayerTile.Character.IsHealer = true;
                            Console.ReadKey();
                            break;
                        case ServantType.Support:
                            Console.Clear();
                            AnsiConsole.Write(new Markup("You have encountered the [blue3_1]Support[/]!"));
                            PlayerTile.Character.IsSupport = true;
                            Console.ReadKey();
                            break;
                    }
                    servant.DisplayCharacter = new Markup("[blue]X[/]");
                }
                // finally, set the previous position to empty
                // MutableTiles[PrevPosition.X, PrevPosition.Y] = new Empty();
                ReplaceTile(PrevPosition, new Empty());
            }
        }

        catch (IndexOutOfRangeException) // dont let yo ass move out de map
        {
            // AnsiConsole.MarkupLine("[red1]You can't move there![/]");
            return; // bomboclaat
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
                MoveTile(tile, new TilePosition(tile.Position.X - 1, tile.Position.Y));
                break;
            case MoveDirection.Down:
                MoveTile(tile, new TilePosition(tile.Position.X + 1, tile.Position.Y));
                break;
            case MoveDirection.Left:
                MoveTile(tile, new TilePosition(tile.Position.X, tile.Position.Y - 1));
                break;
            case MoveDirection.Right:
                MoveTile(tile, new TilePosition(tile.Position.X, tile.Position.Y + 1));
                break;
        }
    }
    public bool ReplaceTile(TilePosition at, ITile tile)
    {
        if (MutableTiles[at.X, at.Y] == null) return false;

        MutableTiles[at.X, at.Y] = tile;

        return true;
    }

    //! DO NOT USE THIS!! THIS SHIT IS SLOW AS FUCK!!
    //! this was mainly meant as a debug function
    //! so that you could see where you're going
    //! instead of the shitty 5x5 grid that tells you
    //! absolutely nothing

    private Hud hud = new Hud();
    public void DrawFull(DrawCriteria criteria, ICharacter hero)
    {
        for (int x = 0; x < Tiles.GetLength(0); x++)
        {
            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                if (typeof(Empty).IsInstanceOfType(MutableTiles[x, y]))
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
                }
                else
                {
                    switch (criteria)
                    {
                        case DrawCriteria.Name:
                            Console.Write(MutableTiles[x, y].Name);
                            break;
                        case DrawCriteria.Guid:
                            Console.Write(MutableTiles[x, y].Id);
                            break;
                        case DrawCriteria.DisplayCharacter:
                            AnsiConsole.Write(MutableTiles[x, y].DisplayCharacter);
                            break;
                    }
                }
                AnsiConsole.Write("  ");
            }
            // AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();
        }
        Console.WriteLine(PlayerTile.Position.ToString());
        AnsiConsole.WriteLine();
        hud.Stats(hero);
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
    public ITile GetTileByCharacter(ICharacter character)
    {
        foreach (ICharacterTile Tile in Tiles)
        {
            if (character == Tile.Character)
            {
                return (ITile)Tile;
            }
        }
        throw new Exception("Tile not found");
    }
    // Get a tile by its position
    public ITile GetTileByPosition(TilePosition tp, bool ImmutableMap = false)
    {
        try
        {
            if (typeof(Empty).IsInstanceOfType(MutableTiles[tp.X, tp.Y]) || ImmutableMap)
            {
                return Tiles[tp.X, tp.Y];
            }
            else
            {
                return MutableTiles[tp.X, tp.Y];
            }
        }
        catch (IndexOutOfRangeException)
        {
            Empty FakeTile = new()
            {
                Passable = true,
                Fake = true,
                DisplayCharacter = new Markup(" ")
            };
            return FakeTile;
        }
    }
    public string InteractWithTile(ITile tile)
    {
        if (tile is ILootable lootable)
        {
            Item loot = lootable.Interact(PlayerTile.Character);
            tile.DisplayCharacter = new Markup("[green]X[/]");
            return $"Looted {loot.Name}";
        }
        // else if (tile is IFightable)
        // {
        //     ((Enemy)tile).Interact(new Battle(PlayerTile.Character, ((Enemy)tile).Character));
        // }
        return "Nothing happened.";
    }
}
