using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Smab.DiceAndTiles.Test
{
    public class ScrabbleTests
    {
		private const int NO_OF_ITERATIONS = 1000;

		[Theory]
		[InlineData(Scrabble.ScrabbleType.English, 100)]
		[InlineData(Scrabble.ScrabbleType.English_SuperScrabble, 200)]
		public void Should_Have_N_Tiles(Scrabble.ScrabbleType scrabbleType, int expected)
		{
			var scrabbleSet = new Scrabble(scrabbleType);
			var actual = scrabbleSet.NoOfTiles;

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(Scrabble.ScrabbleType.English, 100)]
		[InlineData(Scrabble.ScrabbleType.English_SuperScrabble, 200)]
		public void Should_Have_N_Tiles_In_Bag(Scrabble.ScrabbleType scrabbleType, int expected)
		{
			var scrabbleSet = new Scrabble(scrabbleType);
			scrabbleSet.ShakeAndFillBag();
			var actual = scrabbleSet.Bag.Count;

			Assert.Equal(expected, actual);
		}

	}
}
