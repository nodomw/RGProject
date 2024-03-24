namespace FantasyRPG.Items.Potions;

public class Heal : Potion // TODO
{
    public new string Name { get; } = "Healing Potion";
    public new string Description { get; } = "";
    public new PotionModifier Stat { get; } = PotionModifier.Heal;
    public double Use(double Input) => 50;
    public string Interact() => "";
}
