using System.Diagnostics;

namespace FantasyRPG.Map.Tiles;

using System.Security.Cryptography;
using FantasyRPG.Characters;
using FantasyRPG.Items;
using FantasyRPG.Items.HeroItems.Elf;
using FantasyRPG.Items.HeroItems.Hero;
using FantasyRPG.Items.HeroItems.Hunter;
using FantasyRPG.Items.HeroItems.Mage;
using FantasyRPG.Items.HeroItems.Ninja;
using FantasyRPG.Items.HeroItems.Paladin;
using FantasyRPG.Items.HeroItems.Warrior;
using Spectre.Console;

public class ClassLoot() : ITile, ILootable
{
	public Guid Id { get; } = Guid.NewGuid();
	public TileType Type { get; } = TileType.Loot;
	public string Name { get; set; } = "Loot";
	public bool Passable { get; set; } = true;
	public bool Looted { get; set; } = false;
	public TilePosition Position { get; set; }
	public Markup DisplayCharacter { get; set; } = new Markup("[yellow]$[/]");
	public void Interact(ICharacter character)
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
				_ => new Random().Next(1, 2) switch // Hunter
				{
					1 => new Shotgun(),
					_ => new SniperRifle(),
				}
			};

			if (!character.Items.Contains(SelectedItem))
			{
				character.Items.Add(SelectedItem);
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
			Looted = true;
		}
	}
}
