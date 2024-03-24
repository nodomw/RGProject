using System.Diagnostics;

namespace FantasyRPG.Map.Tiles;

using FantasyRPG.Characters;
using FantasyRPG.Items.Potions;
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
	public TilePosition Position { get; set; }
	public Markup DisplayCharacter { get; set; } = new Markup("[yellow]$[/]");
	public void Interact(ICharacter character) => character.Items.Add(character.Type switch // Vermin! Do you seek to repeat the actions of Celtor?!
	{
		CharacterType.Hero => new Random().Next(1, 2) switch
		{
			1 => new Crown(),
			_ => new Fans(),
		},
		CharacterType.Warrior => new Random().Next(1, 2) switch
		{
			// 1 => new Boots(),
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
		CharacterType.Hunter => new Random().Next(1, 2) switch
		{
			1 => new Shotgun(),
			_ => new SniperRifle(),
		},
		_ => new Random().Next(1, 4) switch
		{
			1 => new Damage(),
			2 => new Resistance(),
			3 => new Multi(),
			_ => new Run(),
		},
	});
}
