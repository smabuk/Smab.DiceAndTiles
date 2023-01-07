namespace Smab.DiceAndTiles;

public record QLessDice
{
	private static readonly List<LetterDie> s_letterDice = new()
	{
		new LetterDie(new (string, int)[] { ("M", 1), ("M", 1), ("L", 1), ("L", 1), ("B", 1), ("Y", 1) }) { Name = "MMLLBY" },
		new LetterDie(new (string, int)[] { ("V", 1), ("F", 1), ("G", 1), ("K", 1), ("P", 1), ("P", 1) }) { Name = "VFGKPP" },
		new LetterDie(new (string, int)[] { ("H", 1), ("H", 1), ("N", 1), ("N", 1), ("R", 1), ("R", 1) }) { Name = "HHNNRR" },
		new LetterDie(new (string, int)[] { ("D", 1), ("F", 1), ("R", 1), ("L", 1), ("L", 1), ("W", 1) }) { Name = "DFRLLW" },
		new LetterDie(new (string, int)[] { ("R", 1), ("R", 1), ("D", 1), ("L", 1), ("G", 1), ("G", 1) }) { Name = "RRDLGG" },
		new LetterDie(new (string, int)[] { ("X", 1), ("K", 1), ("B", 1), ("S", 1), ("Z", 1), ("N", 1) }) { Name = "XKBSZN" },
		new LetterDie(new (string, int)[] { ("W", 1), ("H", 1), ("H", 1), ("T", 1), ("T", 1), ("P", 1) }) { Name = "WHHTTP" },
		new LetterDie(new (string, int)[] { ("C", 1), ("C", 1), ("B", 1), ("T", 1), ("J", 1), ("D", 1) }) { Name = "CCBTJD" },
		new LetterDie(new (string, int)[] { ("C", 1), ("C", 1), ("M", 1), ("T", 1), ("T", 1), ("S", 1) }) { Name = "CCMTTS" },
		new LetterDie(new (string, int)[] { ("O", 1), ("I", 1), ("I", 1), ("N", 1), ("N", 1), ("Y", 1) }) { Name = "OIINNY" },
		new LetterDie(new (string, int)[] { ("A", 1), ("E", 1), ("I", 1), ("O", 1), ("U", 1), ("U", 1) }) { Name = "AEIOUU" },
		new LetterDie(new (string, int)[] { ("A", 1), ("A", 1), ("E", 1), ("E", 1), ("O", 1), ("O", 1) }) { Name = "AAEEOO" },
	};

	public List<LetterDie> Dice { get; set; } = s_letterDice;
	public int NoOfDice => Dice.Count;

	public List<LetterDie> Board { get; set; } = new();
	public int NoOfDiceOnBoard => Board.Count;
	public int BoardSize => 10;

	public List<LetterDie> Rack { get; set; } = new();

	public void ShakeAndFillRack()
	{
		List<LetterDie> bag = new(Dice);

		Rack = new();
		Random rnd = new();

		foreach (LetterDie die in bag)
		{
			die.Roll();
			die.Orientation = rnd.Next(0, 4) * 90;
		}
		do
		{
			int i = rnd.Next(0, bag.Count);
			Rack.Add(bag[i]);
			bag.Remove(bag[i]);
		} while (bag.Count > 0);

	}
}
