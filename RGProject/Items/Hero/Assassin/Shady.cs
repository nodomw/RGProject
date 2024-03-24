namespace FantasyRPG.Items.HeroItems.Assassin;

public class Shady : IBoost
{
    public Guid Id { get; }
    public string Name { get; set; } = "Shady";
    public string Description { get; set; }

    public double HPBuff { get; set; }
    public double DmgBuff { get; set; }
    public double DEFBuff { get; set; }
    public double StunBuff { get; set; }
    public double ComboBuff { get; set; }
    public double CATKBuff { get; set; }
    public double DodgeBuff { get; set; } = 10;
    public double CritBuff { get; set; }
}