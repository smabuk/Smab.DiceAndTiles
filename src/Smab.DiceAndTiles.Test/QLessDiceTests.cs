namespace Smab.DiceAndTiles.Test;

public class QLessDiceTests
{
	private const int NO_OF_ITERATIONS = 1000;

	[Fact]
	public void Should_Have_12_Dice()
	{
		int expected = 12;
		QLessDice set = new();
		int actual = set.NoOfDice;

		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Should_Have_12_Dice_In_Rack()
	{
		int expected = 12;
		QLessDice set = new();

		set.ShakeAndFillRack();
		int actual = set.Rack.Count;

		Assert.Equal(expected, actual);
	}

}
