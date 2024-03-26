using FantasyRPG.Characters;

namespace FantasyRPG.Items;

public class Potion() : Item
{
	public Guid Id { get; } = Guid.NewGuid();
	public string Name { get; set; }
	public string Description { get; set; }
	public int Power { get; set; }
	public PotionModifier Stat { get; set; }
	public double Use(ICharacter character)
	{
		switch (Stat)
		{
			case PotionModifier.Heal:
				character.Health += Power;
				return (double)character.Health;
			case PotionModifier.Damage:
				character.Damage += Power;
				return (double)character.Damage;
			case PotionModifier.Resistance:
				character.DEF += Power;
				return (double)character.DEF;
			case PotionModifier.Run: // do nothing cuz it doesnt do anything in battles just on map
				character.RunBoost = true;
				goto default;
			case PotionModifier.Multi:
				character.DEF += 10;
				character.Health += 5;
				goto default;
			default:
				return 0;
		}
	}
}
