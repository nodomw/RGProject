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
        ICharacter Hero { get; }
        ICharacter Enemy { get; }
        void Initiate();
        void Turn(); // Advance to next turn
        void Defeat(ICharacter Character);
    }
    public class Battle : IBattle
    {
        public Guid Id { get; } = Guid.NewGuid();
        public ICharacter Hero { get; }
        public ICharacter Enemy { get; }
        public ICharacter CurrentlyAttacking { get; set; }
        public void Initiate() { }
        public void Turn() { }
        public void Defeat(ICharacter Character) { }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
