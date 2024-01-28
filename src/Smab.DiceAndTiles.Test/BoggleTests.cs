namespace Smab.DiceAndTiles.Test;

public class BoggleTests
{
	private static readonly string[] _wordsList = ["this", "is", "a", "sample", "word", "list", "of", "words"];
	private static readonly DictionaryOfWords _dictionaryOfWords = new(_wordsList);

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
			die.UpperFace = 0;
		}

		string word = "";
		WordScore wordScore;

		word = string.Join("", boggleDice.Board.Where(d => d.Row == 3 && d.Col < 3).Select(d => d.Die.Display));
		wordScore = boggleDice.PlayWord(word);
		wordScore.Score.ShouldBe(0);
		wordScore.Reason.ShouldBe(BoggleDice.ScoreReason.TooShort);

		word = string.Join("", boggleDice.Board.Where(d => d.Row == 0).Select(d => d.Die.Display));
		wordScore = boggleDice.PlayWord(word);
		wordScore.Reason.ShouldBe(BoggleDice.ScoreReason.Success);
		wordScore.Score.ShouldBe(2);

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

		boggleDice.Score.ShouldBe(13);
	}
}
