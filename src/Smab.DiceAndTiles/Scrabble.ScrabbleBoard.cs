using System;

namespace Smab.DiceAndTiles
{
	public partial class Scrabble
	{
		public partial class ScrabbleBoard
		{
			public ScrabbleBoard()
			{
			}

			public class Square
			{
				public SquareType Type { get; set; } = SquareType.Normal;
				public ScrabbleTile? Tile { get; set; } = null;
				public bool Empty => Tile is null;
				public int Value => (Tile?.NumericValue ?? 0) * LetterMultiplier;

				public int LetterMultiplier => Type switch
				{
					SquareType.DoubleLetter => 2,
					SquareType.TripleLetter => 3,
					SquareType.QuadrupleLetter => 4,
					_ => 1
				};

				public int WordMultiplier => Type switch
				{
					SquareType.CentreSquare => 2,
					SquareType.DoubleWord => 2,
					SquareType.TripleWord => 3,
					SquareType.QuadrupleWord => 4,
					_ => 1
				};

			}

		}

	}
}
