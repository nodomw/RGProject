using FantasyRPG.Characters;
using FantasyRPG.Items;
using FantasyRPG.Items.HeroItems.Assassin;
using FantasyRPG.Items.HeroItems.Elf;
using FantasyRPG.Items.HeroItems.Hero;
using FantasyRPG.Items.HeroItems.Hunter;
using FantasyRPG.Items.HeroItems.Mage;
using FantasyRPG.Items.HeroItems.Ninja;
using FantasyRPG.Items.HeroItems.Paladin;
using FantasyRPG.Items.HeroItems.Warrior;
using Spectre.Console;

namespace FantasyRPG.Map.Tiles;
public class ClassLoot() : ITile, ILootable
{
	public Guid Id { get; } = Guid.NewGuid();
	public TileType Type { get; } = TileType.Loot;
	public string Name { get; set; } = "Loot";
	public bool Passable { get; set; } = true;
	public bool Looted { get; set; } = false;
	public TilePosition Position { get; set; }
	public Markup DisplayCharacter { get; set; } = new Markup("[yellow]$[/]");
	public Item Interact(ICharacter character)
	{
		if (!Looted)
		{
			character.XP += 250;
			Item SelectedItem = character.Type switch // Vermin! Do you seek to repeat the actions of Celtor?!
			{
				CharacterType.Hero => new Random().Next(1, 2) switch
				{
					1 => new Crown(),
					_ => new Fans(),
				},
				CharacterType.Warrior => new Random().Next(1, 2) switch
				{
					1 => new Boots(),
					_ => new GiantSword(),
				},
				CharacterType.Mage => new Random().Next(1, 2) switch
				{
					1 => new MedKit(),
					_ => new GoldenStick(),
				},
				CharacterType.Ninja => new Random().Next(1, 2) switch
				{
					1 => new FromTheBack(), // ayo?
					_ => new SilentSteps(),
				},
				CharacterType.Elf => new Random().Next(1, 2) switch
				{
					1 => new FlamingArrow(),
					_ => new IcyArrow(),
				},
				CharacterType.Paladin => new Random().Next(1, 2) switch
				{
					1 => new Helmet(),
					_ => new SpikeArmor(),
				},
				CharacterType.Assassin => new Random().Next(1, 2) switch
				{
					1 => new DoubleSword(),
					_ => new Shady(),
				},
				_ => new Random().Next(1, 2) switch
				{
					1 => new Shotgun(),
					_ => new SniperRifle(),
				}
			};

			if (character.Items.Exists(x => x.Name == SelectedItem.Name))
			{
				SelectedItem = new Random().Next(1, 6) switch
				{
					1 => new Potion()
					{
						Name = "Damage Potion",
						Power = 1.1,
						Stat = PotionModifier.Damage
					},
					2 => new Potion()
					{
						Name = "Health Potion",
						Power = 150,
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
						Power = 1.1,
						Stat = PotionModifier.Resistance
					}
				};

			}
			Looted = true;
			character.Items.Add(SelectedItem);
			return SelectedItem;
		}
		return new Potion()
		{
			Name = "Nothingburger",
			Power = -0.1,
			Stat = PotionModifier.Heal
		};
	}
}
