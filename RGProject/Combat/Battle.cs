using FantasyRPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Combat
{
    public interface IBattle : IDisposable
    {
        Guid Id { get; }
        Character Hero { get; }
        Character Enemy { get; }
        Character CurrentlyAttacking { get; set; }
        void Initiate();
        void Turn(); // Advance to next turn
        void Defeat(Character Character);
    }
    public class Battle : IBattle // cant really work on this until there is concrete information on how shit sould work
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Character Hero { get; }
        public Character Enemy { get; }
        public Character CurrentlyAttacking { get; set; }
        public void Initiate() { }
        public void Turn() { }
        public void Defeat(Character Character) { }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
