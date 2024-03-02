using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Items.Potions
{
    public class Damage : Potion // TODO
    {
        public new string Name { get; } = "Damage Potion";
        public new string Description { get; } = "";
        public new PotionModifier Stat { get; } = PotionModifier.Damage;
        public double Use(double Input) => Input;
        public string Interact() => "";
    }
}
