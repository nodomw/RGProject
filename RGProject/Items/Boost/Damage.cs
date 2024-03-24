namespace FantasyRPG.Items.Potions;

public class Damage : Potion // TODO
{
    public new string Name { get; } = "Damage Potion";
    public new string Description { get; } = "";
    public new int Power { get; } = 10;
    public new PotionModifier Stat { get; } = PotionModifier.Damage;
}
