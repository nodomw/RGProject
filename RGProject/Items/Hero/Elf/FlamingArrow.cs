namespace FantasyRPG.Items.HeroItems.Elf;

public class FlamingArrow : IBoost
{
    public Guid Id { get; }
    public string Name { get; set; } = "Flaming Arrow";
    public string Description { get; set; }

    public double HPBuff { get; set; }
    public double DmgBuff { get; set; } = 10;
    public double DEFBuff { get; set; }
    public double StunBuff { get; set; }
    public double ComboBuff { get; set; }
    public double CATKBuff { get; set; }
    public double DodgeBuff { get; set; }
    public double CritBuff { get; set; }
}