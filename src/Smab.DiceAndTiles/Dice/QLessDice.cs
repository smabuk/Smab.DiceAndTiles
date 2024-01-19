namespace Smab.DiceAndTiles;

public class QLessDice
{
	public static readonly int BoardHeight = 10;
	public static readonly int BoardWidth  = 12;
	public static readonly int RackSize    = 12;

	private static readonly List<LetterDie> s_letterDice =
	[
		new([ "M", "M", "L", "L", "B", "Y" ]),
		new([ "V", "F", "G", "K", "P", "P" ]),
		new([ "H", "H", "N", "N", "R", "R" ]),
		new([ "D", "F", "R", "L", "L", "W" ]),
		new([ "R", "R", "D", "L", "G", "G" ]),
		new([ "X", "K", "B", "S", "Z", "N" ]),
		new([ "W", "H", "H", "T", "T", "P" ]),
		new([ "C", "C", "B", "T", "J", "D" ]),
		new([ "C", "C", "M", "T", "T", "S" ]),
		new([ "O", "I", "I", "N", "N", "Y" ]),
		new([ "A", "E", "I", "O", "U", "U" ]),
		new([ "A", "A", "E", "E", "O", "O" ]),
	];

	public QLessDice()
	{
		ShakeAndFillRack();
	}

	public void ShakeAndFillRack()
	{
		Rack = [];

		LetterDie[] bag = [.. Dice];
		Random.Shared.Shuffle(bag);

		for (int i = 0; i < bag.Length; i++)
		{
			LetterDie die = bag[i];
			die.Roll();
			die.Orientation = Random.Shared.Next(0, 4) * 90;
			Rack.Add(die);
		}
	}

	public List<PositionedDie> Board { get; set; } = [];
	public List<LetterDie>     Dice  { get; set; } = new(s_letterDice);

	public int NoOfDice        => Dice.Count;
	public int NoOfDiceOnBoard => Board.Count;

	public List<LetterDie> Rack { get; set; } = [];
}
