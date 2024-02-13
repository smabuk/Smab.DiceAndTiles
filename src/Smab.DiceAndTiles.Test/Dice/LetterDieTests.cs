namespace Smab.DiceAndTiles.Test.Dice;

public class LetterDieTests
{
	private const int NO_OF_ITERATIONS = 1000;

	[Theory]
	[InlineData(new string[] { "A" }, 1)]
	[InlineData(new string[] { "A", "Qu" }, 2)]
	[InlineData(new string[] { "A", "B", "C" }, 3)]
	public void Create_WithNFaces_ReturnsDieWithNFaces(string[] faces, int expected)
	{
		LetterDie die = new(faces);
		die.NoOfFaces.ShouldBe(expected);
	}

	[Theory]
	[InlineData(new string[] { "A", "B", "C", "D" }, 4)]
	[InlineData(new string[] { "A", "B", "C", "D", "Qu" }, 5)]
	public void Create_WithNFaces_ExpectsFaceValueInRange(string[] faces, int expectedFaces)
	{

		List<LetterDie> dice = [.. new List<LetterDie>[NO_OF_ITERATIONS].Select(d => new LetterDie(faces))];

		foreach (LetterDie die in dice)
		{
			_ = die.Roll();
		}

		dice.First().Faces.Count.ShouldBe(expectedFaces);
		dice.ShouldAllBe(d => faces.Contains(d.Display));
	}

	[Theory]
	[InlineData(new string[] { "A", "B", "C", "D" }, "ABCD")]
	[InlineData(new string[] { "A", "B", "C", "D", "Qu" }, "ABCDQu")]
	public void LetterDie_Name_Is_Set_Automatically(string[] faces, string expected)
	{
		LetterDie die = new(faces);
		die.Id.ToString().ShouldBe(expected);
	}

	[Theory]
	[InlineData(new string[] { "A", "B", "C", "D" }, "ABCD")]
	[InlineData(new string[] { "A", "B", "C", "D", "Qu" }, "ABCDQu")]
	public void LetterDie_Behaves_As_A_Die(string[] faces, string expected)
	{
		Die die = new LetterDie(faces) { UpperFaceIndex = 2 };
		LetterDie letterDie = (LetterDie)die;

		die.Id.ToString().ShouldBe(expected);
		die.Id.ToString().ShouldBe(letterDie.Id.ToString());

		die.UpperFaceIndex.ShouldBe(2);
		die.UpperFaceIndex.ShouldBe(letterDie.UpperFaceIndex);

		die.UpperFace.Display.ShouldBe(letterDie.UpperFace.Display);
		die.Display.ShouldBe(die.UpperFace.Display);
		die.Display.ShouldBe(letterDie.Display);
		die.Display.ShouldBe("C");

		die.Value.ShouldBe(0);
		die.Value.ShouldBe(letterDie.UpperFace.NumericValue);
		die.Value.ShouldBe(letterDie.Value);
	}

	[Theory]
	[InlineData(new string[] { "A", "B", "C", "D" }, "ABCD")]
	[InlineData(new string[] { "A", "B", "C", "D", "Qu" }, "ABCDQu")]
	public void LetterDie_With_Values_Behaves_As_A_Die(string[] faces, string expected)
	{

		Die die = new LetterDie(faces.Select(f => (f, f[0] - 'A' + 1))) { UpperFaceIndex = 2 };
		LetterDie letterDie = (LetterDie)die;

		die.Id.ToString().ShouldBe(expected);
		die.Id.ToString().ShouldBe(letterDie.Id.ToString());

		die.UpperFaceIndex.ShouldBe(2);
		die.UpperFaceIndex.ShouldBe(letterDie.UpperFaceIndex);

		die.UpperFace.Display.ShouldBe(letterDie.UpperFace.Display);
		die.Display.ShouldBe(die.UpperFace.Display);
		die.Display.ShouldBe(letterDie.Display);
		die.Display.ShouldBe("C");

		die.Value.ShouldBe(3);
		die.Value.ShouldBe(letterDie.UpperFace.NumericValue);
		die.Value.ShouldBe(letterDie.Value);
	}
}
