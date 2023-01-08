namespace Smab.DiceAndTiles;

public record QLessDice
{
	public static int BoardSize => 10;

	private static readonly List<LetterDie> s_letterDice = new()
	{
		new LetterDie(new string[] { "M", "M", "L", "L", "B", "Y" }) { Name = "MMLLBY" },
		new LetterDie(new string[] { "V", "F", "G", "K", "P", "P" }) { Name = "VFGKPP" },
		new LetterDie(new string[] { "H", "H", "N", "N", "R", "R" }) { Name = "HHNNRR" },
		new LetterDie(new string[] { "D", "F", "R", "L", "L", "W" }) { Name = "DFRLLW" },
		new LetterDie(new string[] { "R", "R", "D", "L", "G", "G" }) { Name = "RRDLGG" },
		new LetterDie(new string[] { "X", "K", "B", "S", "Z", "N" }) { Name = "XKBSZN" },
		new LetterDie(new string[] { "W", "H", "H", "T", "T", "P" }) { Name = "WHHTTP" },
		new LetterDie(new string[] { "C", "C", "B", "T", "J", "D" }) { Name = "CCBTJD" },
		new LetterDie(new string[] { "C", "C", "M", "T", "T", "S" }) { Name = "CCMTTS" },
		new LetterDie(new string[] { "O", "I", "I", "N", "N", "Y" }) { Name = "OIINNY" },
		new LetterDie(new string[] { "A", "E", "I", "O", "U", "U" }) { Name = "AEIOUU" },
		new LetterDie(new string[] { "A", "A", "E", "E", "O", "O" }) { Name = "AAEEOO" },
	};

	public void ShakeAndFillRack()
	{
		List<LetterDie> bag = new(Dice);

		Rack = new();
		Random rnd = new();

		foreach (LetterDie die in bag)
		{
		}

		do
		{
			int i = rnd.Next(0, bag.Count);
			bag[i].Roll();
			bag[i].Orientation = rnd.Next(0, 4) * 90;
			Rack.Add(bag[i]);
			bag.Remove(bag[i]);
		} while (bag.Count > 0);

	}

	public List<LetterDie> Board { get; set; } = new();
	public List<LetterDie> Dice  { get; set; } = new(s_letterDice);

	public int NoOfDice => Dice.Count;
	public int NoOfDiceOnBoard => Board.Count;

	public List<LetterDie> Rack { get; set; } = new();
}
