using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smab.DiceAndTiles.Scrabble;
using Xunit;

namespace Smab.DiceAndTiles.Test
{
    public class ScrabbleTests
    {
		private const int NO_OF_ITERATIONS = 1000;

		[Theory]
		[InlineData(ScrabbleType.English, 100)]
		[InlineData(ScrabbleType.English_SuperScrabble, 200)]
		public void Should_Have_N_Tiles(ScrabbleType scrabbleType, int expected)
		{
			var scrabbleSet = new ScrabbleGame(scrabbleType);
			var actual = scrabbleSet.NoOfTiles;

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(ScrabbleType.English, 100)]
		[InlineData(ScrabbleType.English_SuperScrabble, 200)]
		public void Should_Have_N_Tiles_In_Bag(ScrabbleType scrabbleType, int expected)
		{
			var scrabbleSet = new ScrabbleGame(scrabbleType);
			scrabbleSet.ShakeAndFillBag();
			var actual = scrabbleSet.Bag.Count;

			Assert.Equal(expected, actual);
		}

	}
}
