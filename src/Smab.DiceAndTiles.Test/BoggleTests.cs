namespace Smab.DiceAndTiles.Test;

public class BoggleTests
{
	//private static readonly string[] _wordsList = ["this", "is", "a", "sample", "word", "list", "of", "words"];
	//private static readonly DictionaryOfWords _dictionaryOfWords = new(_wordsList);

	[Theory]
	[InlineData(BoggleDice.BoggleType.Classic4x4,         16)]
	[InlineData(BoggleDice.BoggleType.BigBoggleDeluxe,    25)]
	[InlineData(BoggleDice.BoggleType.SuperBigBoggle2012, 36)]
	public void Should_Have_N_Dice(BoggleDice.BoggleType boggleType, int expected)
	{
		BoggleDice boggleSet = new(boggleType);
		boggleSet.Dice.Count.ShouldBe(expected);
		boggleSet.Board.Count.ShouldBe(expected);
	}

	[Fact]
	public void Should_Handle_Dice_With_Blanks_Properly()
	{
		BoggleDice boggleDice = new(BoggleDice.BoggleType.SuperBigBoggle2012);
		boggleDice.Board.Count.ShouldBe(36);
		LetterDie die = (boggleDice.Board.Where(x => x.Die.Id.ToString().Contains('#')).First().Die as LetterDie)!;

		die.Faces.Where(f => f.IsBlank).ShouldAllBe(f => f.Id == Face.Blank);
		die.Faces.Where(f => f.IsBlank).ShouldAllBe(f => f.Display == BoggleDice.BlankDisplay);

		die.Faces.Where(f => f.IsNotBlank).ShouldAllBe(f => f.Display == f.StringValue);
	}

	[Fact]
	public void Play_A_Game()
	{
		BoggleDice boggleDice = new BoggleDice(BoggleDice.BoggleType.BigBoggleDeluxe);
		boggleDice.Board.Count.ShouldBe(25);
		boggleDice.BoardHeight.ShouldBe(5);
		boggleDice.BoardWidth.ShouldBe(5);
		boggleDice.BoardSize.ShouldBe(5);
		boggleDice.HasDictionary.ShouldBeFalse();

		foreach (var die in boggleDice.Dice)
		{
			die.UpperFaceIndex = 0;
		}

		string word = "";
		BoggleDice.WordScore wordScore;

		word = string.Join("", boggleDice.Board.Where(d => d.Row == 3 && d.Col < 3).Select(d => d.Die.Display));
		wordScore = boggleDice.PlayWord(word);
		wordScore.Score.ShouldBe(0);
		wordScore.Reason.ShouldBe(BoggleDice.ScoreReason.TooShort);

		word = string.Join("", boggleDice.Board.Where(d => d.Row == 0).Select(d => d.Die.Display));
		wordScore = boggleDice.PlayWord(word);
		wordScore.Reason.ShouldBe(BoggleDice.ScoreReason.Success);
		int shortWordBonus = word.Contains('Q') ? 1 : 0;
		wordScore.Score.ShouldBe(2 + shortWordBonus);

		wordScore = boggleDice.PlayWord(word);
		wordScore.Reason.ShouldBe(BoggleDice.ScoreReason.AlreadyPlayed);
		wordScore.Score.ShouldBe(0);

		word += string.Join("", boggleDice.Board.Where(d => d.Col == 4 && d.Row > 0).Select(d => d.Die.Display));
		wordScore = boggleDice.PlayWord(word);
		wordScore.Reason.ShouldBe(BoggleDice.ScoreReason.Success);
		wordScore.Score.ShouldBe(11);

		word += string.Join("", boggleDice.Board.Where(d => d.Col is 0 or 4 && d.Row is 0 or 4).Select(d => d.Die.Display));
		wordScore = boggleDice.PlayWord(word);
		wordScore.Reason.ShouldBe(BoggleDice.ScoreReason.Unplayable);
		wordScore.Score.ShouldBe(0);

		boggleDice.Score.ShouldBe(13 + shortWordBonus);
	}
}
