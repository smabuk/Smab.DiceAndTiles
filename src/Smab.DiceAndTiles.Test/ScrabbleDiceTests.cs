namespace Smab.DiceAndTiles.Test;

public class ScrabbleDiceTests
{
	private const int NO_OF_ITERATIONS = 1000;

	[Fact]
	public void Should_Have_7_Dice()
	{
		int expected = 7;
		var set = new ScrabbleDice();
		var actual =set.NoOfDice;

		Assert.Equal(expected, actual);
	}

	[Fact]
	public void Should_Have_7_Dice_In_Rack()
	{
		var set = new ScrabbleDice();

		set.ShakeAndFillRack();
		var actual = set.Rack.Count;

		Assert.Equal(7, actual);
	}

}
