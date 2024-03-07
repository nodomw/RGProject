namespace FantasyRPG.Items.Potions;

public class Resistance : Potion // TODO
{
    public string Name { get; } = "Resistance Potion";
    public string Description { get; } = "";
    public PotionModifier Stat { get; } = PotionModifier.Resistance;
    public double Use(double Input) => Input;
    public string Interact() => "";
}
