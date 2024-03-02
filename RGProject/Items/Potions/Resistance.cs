using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Items.Potions
{
    public class Resistance : IPotion // TODO
    {
        public string Name { get; } = "Resistance Potion";
        public string Description { get; } = "";
        public PotionModifier Stat { get; } = PotionModifier.Resistance;
        public double Use(double Input) => Input;
        public string Interact() => "";
    }
}
