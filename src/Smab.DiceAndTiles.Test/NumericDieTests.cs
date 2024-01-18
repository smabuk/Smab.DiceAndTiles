﻿namespace Smab.DiceAndTiles.Test;

public class NumericDieTests
{
	private const int NO_OF_ITERATIONS = 1000;

	[Theory]
	[InlineData(1, 1)]
	[InlineData(6, 6)]
	public void Create_WithNFaces_ReturnsDieWithNFaces(int noOfFaces, int expected)
	{
		var die = new NumericDie(noOfFaces);
		var actual = die.NoOfFaces;

		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(4, 4)]
	[InlineData(6, 6)]
	public void Create_WithNFaces_ExpectsFaceValueInRange(int noOfFaces, int expectedMax)
	{

		var dice = new List<NumericDie>[NO_OF_ITERATIONS]
			.Select(d => new NumericDie(noOfFaces))
			.ToList();

		foreach (var die in dice)
		{
			die.Roll();
		}

		Assert.All(dice, d => Assert.InRange(d.FaceValue.Value, 1, expectedMax));

	}

	[Theory]
	[InlineData(-1)]
	[InlineData(0)]
	public void Create_WithZeroOrNegativeFaces_ArgumentOutOfRangeException(int noOfFaces)
	{
#pragma warning disable CA1806 // Do not ignore method results
		void actual() => new NumericDie(noOfFaces);
#pragma warning restore CA1806 // Do not ignore method results

		_ = Assert.Throws<ArgumentOutOfRangeException>(actual);
	}

	[Fact]
	public void Create_Doubling_Die()
	{
		int[] values = [2, 4, 8, 16, 32, 64];
		NumericDie actual = new NumericDie(values);
		actual.NoOfFaces.ShouldBe(6);
		actual.Faces.Select(face => face.Value).ShouldBe(values, ignoreOrder: true);
	}
}
