using FantasyRPG.Characters;
using FantasyRPG.Items;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles;

public class Loot(Item item) : ITile, ILootable
{
    public Guid Id { get; } = Guid.NewGuid();
    public TileType Type { get; } = TileType.Loot;
    public Item Item { get; set; } = item;
    public string Name { get; set; } = "Loot";
    public bool Looted { get; set; } = false;
    public bool Passable { get; set; } = true;
    public TilePosition Position { get; set; }
    public Markup DisplayCharacter { get; set; } = new Markup("[yellow]$[/]");
    public Item Interact(ICharacter character)
    {
        if (Item is not null)
        {
            character.Items.Add(Item);
        }
        else
        {
            character.Items.Add(new Random().Next(1, 6) switch
            {
                1 => new Potion()
                {
                    Name = "Damage Potion",
                    Power = 10,
                    Stat = PotionModifier.Damage
                },
                2 => new Potion()
                {
                    Name = "Health Potion",
                    Power = 50,
                    Stat = PotionModifier.Heal
                },
                3 => new Potion()
                {
                    Name = "Run Potion",
                    Stat = PotionModifier.Run
                },
                4 => new Potion()
                {
                    Name = "Multi",
                    Stat = PotionModifier.Multi
                },
                5 => new Potion()
                {
                    Name = "Combo Potion",
                    Power = 5,
                    Stat = PotionModifier.Combo
                },
                _ => new Potion()
                {
                    Name = "Defense Potion",
                    Power = 15,
                    Stat = PotionModifier.Resistance
                }
            });

        }
        return new Potion()
        {
            Name = "Nothingburger",
            Power = -0.1,
            Stat = PotionModifier.Heal
        };
    }
}
