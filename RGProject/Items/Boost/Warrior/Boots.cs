namespace FantasyRPG.Items.HeroItems.Warrior;

public class Boots : IBoost
{
    public Guid Id { get; }
    public string Name { get; set; } = "Boots";
    public string Description { get; set; }

    public double HPBuff { get; set; }
    public double DmgBuff { get; set; }
    public double DEFBuff { get; set; }
    public double StunBuff { get; set; }
    public double ComboBuff { get; set; }
    public double CATKBuff { get; set; }
    public double DodgeBuff { get; set; }
    public double CritBuff { get; set; } = 10;
}