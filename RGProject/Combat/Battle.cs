using FantasyRPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Combat
{
    internal interface IBattle : IDisposable
    {
        Guid Id { get; }
        ICharacter Character { get; }
        ICharacter Enemy { get; }

        void Turn(); // Advance to next turn
        void Defeat(ICharacter Character);
    }
}
