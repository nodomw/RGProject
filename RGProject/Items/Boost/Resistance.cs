namespace FantasyRPG.Items.Potions;

public class Resistance : Potion // TODO
{
    public new string Name { get; } = "Resistance Potion";
    public new string Description { get; } = "";
    public new PotionModifier Stat { get; } = PotionModifier.Resistance;
    public double Use(double Input) => Input;
    public string Interact() => "";
}
