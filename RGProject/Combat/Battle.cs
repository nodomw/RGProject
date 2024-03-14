using FantasyRPG.Characters;
using FantasyRPG.Controller;

namespace FantasyRPG.Combat;

public interface IBattle : IDisposable
{
    Character Hero { get; }
    Character Enemy { get; }
    Character InTurn { get; set; }
    void Initiate();
    Character Turn(); // Advance to next turn
    void Defeat(Character Character);
}
public class Battle : IBattle // cant really work on this until there is concrete information on how shit should work
{
    public Character Hero { get; }
    public Character Enemy { get; }
    public Player Player { get; }
    public Character InTurn { get; set; }
    public void Initiate()
    {
        InTurn = Hero;
        Player.State = State.Fighting;
    }

    public Character Turn()
    {
        double dmg = 0;

        if (InTurn == Hero)
        {
            dmg = Hero.Damage - Enemy.Defense;
        }
        else
        {
            dmg = Enemy.Damage - Hero.Defense;
        }

        return InTurn == Hero ? Enemy : Hero;
    }
    public void Defeat(Character Character) { }
    public void Dispose() => GC.SuppressFinalize(this);
}
