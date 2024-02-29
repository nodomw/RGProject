using FantasyRPG.Map.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Items
{ 
    public enum Magic
    {
        Fire, // Enemy takes passive damage over time (2-3 turns)
        Ice, // Decreases enemy DMG
        Dark, // Cast spells to support the damage output of your team
        Light // Heal your team
    }
    public enum Weapon
    {
        Sword,
        Bow,
        Spell
    }
    public enum Modifier // Potion and spell Modifiers
    {
        Heal, // Heals (n)
        Damage, // Increases damage by (n)%
        Resistance // Increases resistance to attacks by (n)%
    }
    public interface IWeapon
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
        int Level { get; set; }
        int Damage { get; set; }
        
        // damage from attacks is returned as 'int'. double is needed for multiplication
        int Attack();
        double Critical();
        string Interact();
    }
    public interface IPotion
    {
        string Name { get; }
        string Description { get; }
        Modifier Stat { get; }
        double Use(double Input);
        string Interact();
    }
    public interface IMagic : IWeapon
    {
        Magic Type { get; }
    }
}
