using Smab.DiceAndTiles.Games.ScrabbleDice;

namespace Smab.DiceAndTiles.Test;

public class ScrabbleDiceTests
{
	[Fact]
	public void Should_Have_7_Dice()
	{
		int expected = 7;
		ScrabbleDice set = new();
		int actual = set.NoOfDice;

		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Should_Have_7_Dice_In_Rack()
	{
		int expected = 7;
		ScrabbleDice set = new();

		set.ShakeAndFillRack();
		int actual = set.Rack.Count;

		Assert.Equal(expected, actual);
	}

}
