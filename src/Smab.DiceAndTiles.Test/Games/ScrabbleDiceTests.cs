using Smab.DiceAndTiles.Games.ScrabbleDice;

namespace Smab.DiceAndTiles.Test.Games;

public class ScrabbleDiceTests
{
	[Fact]
	public void Should_Have_7_Dice()
	{
		var expected = 7;
		ScrabbleDice set = new();
		var actual = set.NoOfDice;

		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Should_Have_7_Dice_In_Rack()
	{
		var expected = 7;
		ScrabbleDice set = new();

		set.ShakeAndFillRack();
		var actual = set.Rack.Count;

		Assert.Equal(expected, actual);
	}

}
