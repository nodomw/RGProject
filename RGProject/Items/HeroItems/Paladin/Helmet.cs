namespace FantasyRPG.Items.HeroItems.Paladin;

public class Helmet : IHeroItem
{
    public Guid Id { get; }
    public string Name { get; set; } = "Paladin's Helmet";
    public string Description { get; set; }

    public double HPBuff { get; set; }
    public double DmgBuff { get; set; }
    public double DEFBuff { get; set; } = 15;
    public double StunBuff { get; set; }
    public double ComboBuff { get; set; }
    public double CATKBuff { get; set; }
    public double DodgeBuff { get; set; }
    public double CritBuff { get; set; }
}