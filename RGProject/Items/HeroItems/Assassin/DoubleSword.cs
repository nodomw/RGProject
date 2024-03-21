namespace FantasyRPG.Items.HeroItems.Assassin;

public class DoubleSword : IHeroItem
{
    public Guid Id { get; }
    public string Name { get; set; } = "Double Sword";
    public string Description { get; set; }

    public double HPBuff { get; set; }
    public double DmgBuff { get; set; }
    public double DEFBuff { get; set; }
    public double StunBuff { get; set; }
    public double ComboBuff { get; set; } = 10;
    public double CATKBuff { get; set; }
    public double DodgeBuff { get; set; }
    public double CritBuff { get; set; }

    public bool _SilentStep { get; set; } = false;
    public bool _Fans { get; set; } = false;
    public bool _RunBoost { get; set; } = false;
    public bool _MultiBooster { get; set; } = false;
}