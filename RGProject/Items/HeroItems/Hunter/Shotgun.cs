namespace FantasyRPG.Items.HeroItems.Hunter;

public class Shotgun : IHeroItem
{
    public Guid Id { get; }
    public string Name { get; set; } = "Shotgun";
    public string Description { get; set; }

    public double HPBuff { get; set; }
    public double DmgBuff { get; set; }
    public double DEFBuff { get; set; }
    public double StunBuff { get; set; }
    public double ComboBuff { get; set; }
    public double CATKBuff { get; set; } = 10;
    public double DodgeBuff { get; set; }
    public double CritBuff { get; set; }
}