using FantasyRPG.Map;
using Spectre.Console;

namespace FantasyRPG;

public class Exit : ITile, ITileExit
{
	public Guid Id { get; } = Guid.NewGuid();
	public TileType Type { get; } = TileType.Exit;
	public TilePosition Position { get; set; }
	public bool Passable { get; set; }
	public string Name { get; set; } = "Exit";
	public Markup DisplayCharacter { get; set; } = new Markup("[grey58]■[/]");
	public void Interact(Map.Map map)
	{

	}
}
