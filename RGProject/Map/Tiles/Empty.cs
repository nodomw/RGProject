﻿using Spectre.Console;
namespace FantasyRPG.Map.Tiles;

public class Empty : ITile
{
    public Guid Id { get; } = Guid.NewGuid();
    public TileType Type { get; } = TileType.Empty;
    public string Name { get; set; } = "Empty";
    public bool Fake { get; set; } = false; // needed for when GetTileByPosition returns a fake tile which does not exist on the map
    public bool Passable { get; set; } = true;
    public TilePosition Position { get; set; }
    public Markup DisplayCharacter { get; } = new Markup("[grey]#[/]");
    public string Interact() => "An empty piece of land. Nothing to see here.";
}
