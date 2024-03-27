using FantasyRPG.Characters;

namespace FantasyRPG.Items;

public class Potion() : Item
{
	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; set; }
	public string Description { get; set; }
	public int Power { get; set; }
	public PotionModifier Stat { get; set; }
}
