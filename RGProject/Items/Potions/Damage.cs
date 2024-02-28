using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Items.Potions
{
    public class Damage : IPotion // TODO
    {
        public string Name { get; } = "Damage Potion";
        public string Description { get; } = "";
        public Modifier Stat { get; } = Modifier.Damage;
        public double Use(double Input) => Input;
        public string Interact() => "";
    }
}
