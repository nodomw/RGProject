using FantasyRPG.Characters;

namespace FantasyRPG.Items.HeroItems.Assassin;

public class DoubleSword
{
    public void _DuelSword(ICharacter hero)
    {
        hero.Combo += 10;
    }
}