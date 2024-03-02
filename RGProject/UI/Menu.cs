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
        
        public static void ShowCharSelection()
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
        
        public static void ShowCharCreation()
        {
            Console.WriteLine("Enter your character's name: ");
        }
        
        public static void ShowInGameMenu()
        {
            Console.WriteLine("1. Show Stats");
            Console.WriteLine("2. Show Inventory");
            Console.WriteLine("3. Show Equipment");
            Console.WriteLine("4. Show Skills");
            Console.WriteLine("5. Show Map");
            Console.WriteLine("6. Exit");
        }
        
        public static void ShowMaps()
        {
            Console.WriteLine("1. First Map");
            Console.WriteLine("2. Second Map");
            Console.WriteLine("3. Third Map");
            Console.WriteLine("4. Fourth Map");
            Console.WriteLine("5. Exit");
        }
        
        public static void ShowMainMenu()
        {
            Console.WriteLine("1. Continue");
            Console.WriteLine("2. Save");
            Console.WriteLine("3. Exit");
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
        
/*-----------------------------------------------------------------------------------------------------------------------------------------------------*/
        
        public static void ShowBattleMenu()
        {
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");
            Console.WriteLine("3. Use Item");
            Console.WriteLine("5. Run");
        }
        
        public static void ShowMageAttacks()
        {
            Console.WriteLine("1. Fireball");
            Console.WriteLine("2. Ice Shard");
            Console.WriteLine("3. Thunderbolt");
            Console.WriteLine("4. Exit");
        }
        
        public static void ShowWarriorAttacks()
        {
            Console.WriteLine("1. Slash");
            Console.WriteLine("2. Shield Bash");
            Console.WriteLine("3. War Cry");
            Console.WriteLine("4. Exit");
        }
        
        public static void ShowAssassinAttacks()
        {
            Console.WriteLine("1. Dagger Strike");
            Console.WriteLine("2. Poison Strike");
            Console.WriteLine("3. Shadow Strike");
            Console.WriteLine("4. Exit");
        }
        
        public static void ShowPaladinAttacks()
        {
            Console.WriteLine("1. Holy Strike");
            Console.WriteLine("2. Holy Shield");
            Console.WriteLine("3. Holy Light");
            Console.WriteLine("4. Exit");
        }
        
        public static void ShowElfAttacks()
        {
            Console.WriteLine("1. Arrow Shot");
            Console.WriteLine("2. Arrow Rain");
            Console.WriteLine("3. Arrow Storm");
            Console.WriteLine("4. Exit");
        }
        
        public static void ShowHeroAttacks()
        {
            Console.WriteLine("1. Heroic Strike");
            Console.WriteLine("2. Heroic Shield");
            Console.WriteLine("3. Heroic Light");
            Console.WriteLine("4. Exit");
        }
        
        public static void ShowHunterAttacks()
        {
            Console.WriteLine("1. Hunter's Strike");
            Console.WriteLine("2. Hunter's Shield");
            Console.WriteLine("3. Hunter's Light");
            Console.WriteLine("4. Exit");
        }
        
        public static void ShowNinjaAttacks()
        {
            Console.WriteLine("1. Ninja Strike");
            Console.WriteLine("2. Ninja Shield");
            Console.WriteLine("3. Ninja Light");
            Console.WriteLine("4. Exit");
        }
    }
}
