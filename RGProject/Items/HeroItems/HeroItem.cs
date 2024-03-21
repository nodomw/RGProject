namespace FantasyRPG.Items.HeroItems;

public interface IHeroItem : Item
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

    public bool _SilentStep { get; set; }
    public bool _Fans { get; set; }
    public bool _RunBoost { get; set; } // 10% -> 5% hp lost when run away
    public bool _MultiBooster { get; set; } // 10% -> 8% hp lost when run away
}