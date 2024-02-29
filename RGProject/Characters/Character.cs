﻿using FantasyRPG.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.Characters
{
    public enum Character
    {
        Controller, // Player
        Servant,
        Enemy
    }
    public enum Hero
    {

    }
    public enum Enemy
    {

    }
    public interface ICharacter
    {
        Guid Id { get; }
        string Name { get; }
        int Level { get; set; }
        double Health { get; set; }
        double Damage { get; set; }
        double Resistance { get; set; }
        double Dodge { get; set; }
        Character Type { get; }
        List<IPotion> Potions { get; set; }
        List<IWeapon> Weapons { get; set; }
        IWeapon CurrentWeapon { get; set; }

        int LevelUp();
        int Attack(int Damage);
        int TakeDamage(int Damage);
        void Interact(dynamic Thing);
    }
}
