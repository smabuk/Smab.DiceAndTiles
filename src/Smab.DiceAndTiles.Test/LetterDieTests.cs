using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Smab.DiceAndTiles.Test
{
	public class LetterDieTests
	{
		private const int NO_OF_ITERATIONS = 1000;

		[Theory]
		[InlineData(new string[] { "A" }, 1)]
		[InlineData(new string[] { "A", "Qu" }, 2)]
		[InlineData(new string[] { "A", "B", "C" }, 3)]
		public void Create_WithNFaces_ReturnsDieWithNFaces(string[] faces, int expected)
		{
			var die = new LetterDie(faces);
			var actual = die.NoOfFaces;

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(new string[] { "A", "B", "C", "D" }, 4)]
		[InlineData(new string[] { "A", "B", "C", "D", "Qu" }, 5)]
		public void Create_WithNFaces_ExpectsFaceValueInRange(string[] faces, int expectedFaces)
		{

			var dice = new List<LetterDie>[NO_OF_ITERATIONS]
				.Select(d => new LetterDie(faces))
				.ToList();

			foreach (var die in dice)
			{
				die.Roll();
			}

			Assert.All(dice, d => Assert.Contains(d.FaceValue.Value, faces.ToList()));

		}

		[Fact]
		public void Create_ExpectsNullReferenceException()
		{
			void actual() => new LetterDie(null);

			Assert.Throws<NullReferenceException>(actual);
		}


	}
}
