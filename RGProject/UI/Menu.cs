using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyRPG.UI
{
    internal class Menu
    {
        public static void Show()
        {
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Exit");
        }
        
        public static void CharSelection()
        {
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Mage");
            Console.WriteLine("3. Elf");
            Console.WriteLine("4. Assassin");
            Console.WriteLine("5. Paladin");
            Console.WriteLine("6. Hero");
            Console.WriteLine("7. Hunter");
            Console.WriteLine("8. Ninja");
        }
        
        public static void ShowMainMenu()
        {
            Console.WriteLine("1. Continue");
            Console.WriteLine("2. Save");
            Console.WriteLine("3. Exit");
        }
        
        public static void ShowBattleMenu()
        {
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");
            Console.WriteLine("3. Use Item");
            Console.WriteLine("4. Run");
        }
        
        public static void ShowInventoryMenu()
        {
            Console.WriteLine("1. Use Item");
            Console.WriteLine("2. Equip Item");
            Console.WriteLine("3. Exit");
        }
        
        public static void ShowEquipMenu()
        {
            Console.WriteLine("1. Equip Weapon");
            Console.WriteLine("2. Equip Armor");
            Console.WriteLine("3. Exit");
        }
        
        public static void ShowItemMenu()
        {
            Console.WriteLine("1. Use Health Potion");
            Console.WriteLine("2. Use Mana Potion");
            Console.WriteLine("3. Exit");
        }
    }
}
