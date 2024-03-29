﻿namespace FantasyRPG.Items.HeroItems.Mage;

public class MedKit : IBoost
{
    public Guid Id { get; }
    public string Name { get; set; } = "Med Kit";
    public string Description { get; set; }

    public double HPBuff { get; set; } = 300;
    public double DmgBuff { get; set; }
    public double DEFBuff { get; set; }
    public double StunBuff { get; set; }
    public double ComboBuff { get; set; }
    public double CATKBuff { get; set; }
    public double DodgeBuff { get; set; }
    public double CritBuff { get; set; }
}