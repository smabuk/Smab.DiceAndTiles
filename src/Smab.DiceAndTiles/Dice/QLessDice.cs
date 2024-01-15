namespace Smab.DiceAndTiles;

public class QLessDice
{
	public static readonly int BoardHeight = 10;
	public static readonly int BoardWidth  = 12;
	public static readonly int RackSize    = 12;

	private static readonly List<LetterDie> s_letterDice =
	[
		new LetterDie([ "M", "M", "L", "L", "B", "Y" ]) { Name = "MMLLBY" },
		new LetterDie([ "V", "F", "G", "K", "P", "P" ]) { Name = "VFGKPP" },
		new LetterDie([ "H", "H", "N", "N", "R", "R" ]) { Name = "HHNNRR" },
		new LetterDie([ "D", "F", "R", "L", "L", "W" ]) { Name = "DFRLLW" },
		new LetterDie([ "R", "R", "D", "L", "G", "G" ]) { Name = "RRDLGG" },
		new LetterDie([ "X", "K", "B", "S", "Z", "N" ]) { Name = "XKBSZN" },
		new LetterDie([ "W", "H", "H", "T", "T", "P" ]) { Name = "WHHTTP" },
		new LetterDie([ "C", "C", "B", "T", "J", "D" ]) { Name = "CCBTJD" },
		new LetterDie([ "C", "C", "M", "T", "T", "S" ]) { Name = "CCMTTS" },
		new LetterDie([ "O", "I", "I", "N", "N", "Y" ]) { Name = "OIINNY" },
		new LetterDie([ "A", "E", "I", "O", "U", "U" ]) { Name = "AEIOUU" },
		new LetterDie([ "A", "A", "E", "E", "O", "O" ]) { Name = "AAEEOO" },
	];

	public QLessDice()
	{
		ShakeAndFillRack();
	}

	public void ShakeAndFillRack()
	{
		List<LetterDie> bag = new(Dice);

		Rack = [];

		do
		{
			int i = Random.Shared.Next(0, bag.Count);
			bag[i].Roll();
			bag[i].Orientation = Random.Shared.Next(0, 4) * 90;
			Rack.Add(bag[i]);
			_ = bag.Remove(bag[i]);
		} while (bag.Count > 0);

		for (int i = 0; i < Rack.Count; i++)
		{
			Board.Add(new PositionedDie(Rack[i], 6, -1, i));
		}
	}

	public List<PositionedDie> Board { get; set; } = [];
	public List<LetterDie>     Dice  { get; set; } = new(s_letterDice);

	public int NoOfDice        => Dice.Count;
	public int NoOfDiceOnBoard => Board.Count;

	public List<LetterDie> Rack { get; set; } = [];
}
