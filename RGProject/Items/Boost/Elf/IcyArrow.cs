﻿namespace FantasyRPG.Items.HeroItems.Elf;

public class IcyArrow : IBoost
{
    public Guid Id { get; }
    public string Name { get; set; } = "Icy Arrow";
    public string Description { get; set; }

    public double HPBuff { get; set; }
    public double DmgBuff { get; set; }
    public double DEFBuff { get; set; }
    public double StunBuff { get; set; } = 10;
    public double ComboBuff { get; set; }
    public double CATKBuff { get; set; }
    public double DodgeBuff { get; set; }
    public double CritBuff { get; set; }
}