using FantasyRPG.Items;

namespace FantasyRPG;

public class Run : Potion
{
	public new string Name { get; } = "Run boost";
	public new string Description { get; } = "Allows you to move 10 tiles instead of 5 at once. Stays permanently.";
	public new PotionModifier Stat { get; } = PotionModifier.Run;
}
