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
		[InlineData(100)]
		public void Should_Have_100_Tiles(int expected)
		{
			var scrabbleSet = new Scrabble();
			var actual = scrabbleSet.NoOfTiles;

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(100)]
		public void Should_Have_100_Tiles_In_Bag(int expected)
		{
			var scrabbleSet = new Scrabble();
			scrabbleSet.ShakeAndFillBag();
			var actual = scrabbleSet.Bag.Count;

			Assert.Equal(expected, actual);
		}

	}
}
