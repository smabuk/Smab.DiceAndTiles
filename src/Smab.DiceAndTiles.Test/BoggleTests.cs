namespace Smab.DiceAndTiles.Test;

public class BoggleTests
{
	[Theory]
	[InlineData(BoggleDice.BoggleType.Classic4x4, 16)]
	[InlineData(BoggleDice.BoggleType.BigBoggleDeluxe, 25)]
	[InlineData(BoggleDice.BoggleType.SuperBigBoggle2012, 36)]
	public void Should_Have_N_Dice(BoggleDice.BoggleType boggleType, int expected)
	{
		var boggleSet = new BoggleDice(boggleType);
		var actual = boggleSet.NoOfDice;

		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineData(BoggleDice.BoggleType.Classic4x4, 16)]
	[InlineData(BoggleDice.BoggleType.BigBoggleDeluxe, 25)]
	[InlineData(BoggleDice.BoggleType.SuperBigBoggle2012, 36)]
	public void Should_Have_N_Dice_On_Board(BoggleDice.BoggleType boggleType, int expected)
	{
		var boggleSet = new BoggleDice(boggleType);

		boggleSet.ShakeAndFillBoard();
		var actual = boggleSet.Board.Count;

		Assert.Equal(expected, actual);
	}


}
