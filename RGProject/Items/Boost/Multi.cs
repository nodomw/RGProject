using FantasyRPG.Items;

namespace FantasyRPG;

public class Multi : Potion
{
	public new string Name { get; } = "Multi Booster";
	public new string Description { get; } = "Jack of all trades, master of none. Boosts your DEF by 10% and DMG by 5%";
	public new PotionModifier Stat { get; } = PotionModifier.Multi;
}
