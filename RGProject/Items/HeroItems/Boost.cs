namespace FantasyRPG.Items.HeroItems;

public interface IBoost : Item
{
    public new Guid Id { get; }
    public new string Name { get; set; }
    public new string Description { get; set; }

    public double HPBuff { get; set; }
    public double DmgBuff { get; set; }
    public double DEFBuff { get; set; }
    public double StunBuff { get; set; }
    public double ComboBuff { get; set; }
    public double CATKBuff { get; set; }
    public double DodgeBuff { get; set; }
    public double CritBuff { get; set; }
}