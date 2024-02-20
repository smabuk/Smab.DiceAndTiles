namespace Smab.DiceAndTiles.Tests.Dice;

public class NumericDieTests
{
	private const int NO_OF_ITERATIONS = 1000;

	[Theory]
	[InlineData(1, 1)]
	[InlineData(6, 6)]
	public void Create_WithNFaces_ReturnsDieWithNFaces(int noOfFaces, int expected)
	{
		NumericDie die = new(noOfFaces);
		die.NoOfFaces.ShouldBe(expected);
	}

	[Theory]
	[InlineData(4, 4)]
	[InlineData(6, 6)]
	public void Create_WithNFaces_ExpectsFaceValueInRange(int noOfFaces, int expectedMax)
	{
		List<NumericDie> dice = new List<NumericDie>[NO_OF_ITERATIONS]
			.Select(d => new NumericDie(noOfFaces))
			.ToList();

		foreach (NumericDie die in dice)
		{
			_ = die.Roll();
		}

		dice.ShouldAllBe(d => d.UpperFace.Value >= 1 && d.UpperFace.Value <= expectedMax);
	}

	[Theory]
	[InlineData(-1)]
	[InlineData(0)]
	public void Create_WithZeroOrNegativeFaces_ArgumentOutOfRangeException(int noOfFaces)
	{
		_ = Should.Throw<ArgumentOutOfRangeException>(() => new NumericDie(noOfFaces));
	}

	[Fact]
	public void Create_Doubling_Die()
	{
		int[] values = [2, 4, 8, 16, 32, 64];
		NumericDie actual = new NumericDie(values);
		actual.NoOfFaces.ShouldBe(6);
		actual.Faces.Select(face => face.Value).ShouldBe(values, ignoreOrder: true);
	}

	[Theory]
	[InlineData(4)]
	[InlineData(8)]
	public void NumericDie_Behaves_As_A_Die(int noOfFaces)
	{
		Die die = new NumericDie(noOfFaces) { UpperFaceIndex = 0 };
		NumericDie numericDie = (NumericDie)die;

		die.Id.ShouldBe(numericDie.Id);

		die.UpperFaceIndex.ShouldBe(0);
		die.UpperFaceIndex.ShouldBe(numericDie.UpperFaceIndex);

		die.UpperFace.Display.ShouldBe(numericDie.UpperFace.Display);
		die.Display.ShouldBe(die.UpperFace.Display);
		die.Display.ShouldBe(numericDie.Display);

		die.Value.ShouldBe(1);
		die.Value.ShouldBe(numericDie.UpperFace.Value);
		die.Value.ShouldBe(numericDie.Value);
	}

}
