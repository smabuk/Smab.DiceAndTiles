namespace Smab.DiceAndTiles.Games.ScrabbleDice;

public partial class ScrabbleDice
{
	private static readonly List<LetterDie> s_letterDice =
	[
		new([ ("A", 1), ("E", 1), ("I",  1), ("O", 1), ("U",  1), ("Y", 4) ], new DieId("AEIOUY1")),
		new([ ("A", 1), ("E", 1), ("I",  1), ("O", 1), ("U",  1), ("Y", 4) ], new DieId("AEIOUY2")),
		new([ ("A", 1), ("E", 1), ("I",  1), ("L", 1), ("O",  1), ("#", 0) ]),
		new([ ("B", 3), ("F", 4), ("H",  4), ("N", 1), ("W",  4), ("#", 0) ]),
		new([ ("C", 3), ("D", 2), ("G",  2), ("T", 1), ("V",  4), ("#", 0) ]),
		new([ ("J", 8), ("K", 5), ("Q", 10), ("X", 8), ("Z", 10), ("#", 0) ]),
		new([ ("M", 3), ("N", 1), ("P",  3), ("R", 1), ("S",  1), ("#", 0) ]),
	];

	public List<LetterDie> Dice { get; set; } = new(s_letterDice);
	public int NoOfDice => Dice.Count;

	public List<LetterDie> Board { get; set; } = [];
	public int NoOfDiceOnBoard => Board.Count;
	public readonly int BoardSize = 9;

	public List<LetterDie> Rack { get; set; } = [];

	public void ShakeAndFillRack()
	{
		List<LetterDie> bag = new(Dice);

		Rack = [];
		Random rnd = new();

		do
		{
			int i = rnd.Next(0, bag.Count);
			_ = bag[i].Roll();
			bag[i].Orientation = rnd.Next(0, 4) * 90;

			if (bag[i].IsBlank)
			{
				bag[i].Faces[bag[i].UpperFaceIndex] = bag[i].UpperFace with { Display = "■" };
			}

			Rack.Add(bag[i]);
			_ = bag.Remove(bag[i]);
		} while (bag.Count > 0);

	}
}
