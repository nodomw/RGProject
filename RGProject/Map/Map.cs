﻿// Ignore Spelling: Enums

namespace FantasyRPG.Map
{
    internal interface IMap
    {
        Guid Id { get; }
        string Name { get; }
        Tile[,,] Tiles { get; set; }
        bool SwapTile(TilePosition tile1, TilePosition tile2);
        bool ReplaceTile(TilePosition tp, Tile tile);
        bool ReplaceEnums();
    }
    
    public class Map : IMap
    {
        // Map is a 3D matrix of 'Tile'
        // Z0: Decorations and 'Terrain' Tiles
        // Z1: Enemy Tiles
        // Z2: Loot and Servant Tiles
        // Z3: Player Tile

        public Map(string name, Tile[,,] tiles)
        {
            Name = name;
            Tiles = tiles;
        }
        public Tile[,,] Tiles { get; set; }
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; }
        
        public bool SwapTile(TilePosition tile1, TilePosition tile2) // TODO (should work now though)
        {
            if (Tiles[tile1.X, tile1.Y, tile1.Z] == null || Tiles[tile2.X, tile2.Y, tile2.Z] == null) return false;

            Tiles[tile1.X, tile1.Y, tile1.Z] = tile2.Tile;
            Tiles[tile2.X, tile2.Y, tile2.Z] = tile1.Tile;

            return true;
        }
        public bool ReplaceTile(TilePosition tp, Tile tile) // TODO (same here)
        {
            if (Tiles[tp.X, tp.Y, tp.Z] == null) return false;

            Tiles[tp.X, tp.Y, tp.Z] = tile;

            return true;
        }
        public bool ReplaceEnums() // TODO (and here)
        {
            for (int x = 0; x < Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < Tiles.GetLength(1); y++)
                {
                    for (int z = 0; z < Tiles.GetLength(2); z++)
                    {
                        if (Tiles[x, y, z] == null) continue;

                        switch (Tiles[x, y, z].Type)
                        {
                            case TileType.Terrain:
                                Tiles[x, y, z] = new Tiles.Terrain();
                                break;
                            case TileType.Enemy:
                                Tiles[x, y, z] = new Tiles.Enemy();
                                break;
                            case TileType.Loot:
                                Tiles[x, y, z] = new Tiles.Loot();
                                break;
                            case TileType.Player:
                                Tiles[x, y, z] = new Tiles.Player();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            return true;
        }
    }
}
