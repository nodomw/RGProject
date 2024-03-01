using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Items.Weapons
{
    public class Bow : Weapon
    {
        public Bow(int level) => Level = level;
        public string Name { get; } = "Longbow";
        public string Description { get; } = "Mastered by Hungarian archers, stolen by the Ango-Saxons.";
        public int Level { get; set; } = 0;
        public int Damage { get; set; } = 15;

        // TODO: temporary
        public int Attack() => Damage;
        public double Critical() => Damage * 2;
        public string Interact() => "";

    }
}
