using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Items.Potions
{
    public class Heal : IPotion // TODO
    {
        public string Name { get; } = "Healing Potion";
        public string Description { get; } = "";
        public Modifier Stat { get; } = Modifier.Heal;
        public double Use(double Input) => 50;
        public string Interact() => "";
    }
}
