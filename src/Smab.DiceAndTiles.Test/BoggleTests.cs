namespace Smab.DiceAndTiles.Test;

public class BoggleTests
{
	[Theory]
	[InlineData(BoggleDice.BoggleType.Classic4x4,         16)]
	[InlineData(BoggleDice.BoggleType.BigBoggleDeluxe,    25)]
	[InlineData(BoggleDice.BoggleType.SuperBigBoggle2012, 36)]
	public void Should_Have_N_Dice(BoggleDice.BoggleType boggleType, int expected)
	{
		var boggleSet = new BoggleDice(boggleType);
		boggleSet.Dice.Count.ShouldBe(expected);
		boggleSet.Board.Count.ShouldBe(expected);
	}
}
