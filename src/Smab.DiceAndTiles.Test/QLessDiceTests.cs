namespace Smab.DiceAndTiles.Test;

public class QLessDiceTests
{
	private static readonly string[] _wordsList = ["this", "is", "a", "sample", "word", "list", "of", "words"];
	private static readonly DictionaryOfWords _dictionaryOfWords = new(_wordsList);

	[Fact]
	public void Should_Have_12_Dice()
	{
		QLessDice qLessDice = new();
		qLessDice.Board.ShouldBeEmpty();
		qLessDice.Dice.Count.ShouldBe(12);
		qLessDice.Rack.Count.ShouldBe(12);
	}

	[Fact]
	public void Instances_Should_Not_Share_Dice()
	{
		QLessDice qLessDice1 = new();
		string rack1 = string.Join("", qLessDice1.Rack.OrderBy(x => x.Die.Display).Select(x => x.Die.Display));

		QLessDice qLessDice2 = new();
		string rack2 = string.Join("", qLessDice2.Rack.OrderBy(x => x.Die.Display).Select(x => x.Die.Display));
		
		rack1.ShouldNotBe(rack2);

		rack1 = string.Join("", qLessDice1.Rack.OrderBy(x => x.Die.Display).Select(x => x.Die.Display));
		rack1.ShouldNotBe(rack2);
	}

	[Fact]
	public void Play_A_Game()
	{
		QLessDice qLessDice = new();
		qLessDice.HasDictionary.ShouldBeFalse();

		foreach (var die in qLessDice.Dice)
		{
			die.UpperFace = 0;
		}

		qLessDice.Board.ShouldBeEmpty();
		qLessDice.Dice.Count.ShouldBe(12);
		qLessDice.Rack.Count.ShouldBe(12);

		Die die0 = qLessDice.Rack.Single(d => d.Col == 0).Die;
		Die die7 = qLessDice.Rack.Single(d => d.Col == 7).Die;

		qLessDice.PlaceOnBoard(die0, 5, 5).ShouldBeTrue();
		qLessDice.Board.Count.ShouldBe(1);
		qLessDice.Rack.Count.ShouldBe(11);

		qLessDice.PlaceOnBoard(die7, 5, 5).ShouldBeFalse();
		qLessDice.Board.Count.ShouldBe(1);
		qLessDice.Rack.Count.ShouldBe(11);

		qLessDice.PlaceOnBoard(die7, 4, 5).ShouldBeTrue();
		qLessDice.Board.Count.ShouldBe(2);
		qLessDice.Rack.Count.ShouldBe(10);

		QLessDice.Status status = qLessDice.GameStatus();
		((QLessDice.Errors)status).ErrorReasons.ShouldHaveFlag(QLessDice.ErrorReasons.TwoLetterWords);
		((QLessDice.Errors)status).ErrorReasons.ShouldHaveFlag(QLessDice.ErrorReasons.MissingDice);
		((QLessDice.Errors)status).ErrorReasons.ShouldNotHaveFlag(QLessDice.ErrorReasons.MultipleBlocks);

		qLessDice.PlaceOnRack(die7, 4).ShouldBeFalse();
		qLessDice.Board.Count.ShouldBe(2);
		qLessDice.Rack.Count.ShouldBe(10);

		qLessDice.PlaceOnRack(die7).ShouldBeTrue();
		qLessDice.Board.Count.ShouldBe(1);
		qLessDice.Rack.Count.ShouldBe(11);


		int row = 0;
		for (int i = 0; i < qLessDice.Dice.Count; i++)
		{
			row = (row + 2) % 10;
			qLessDice.PlaceOnBoard(qLessDice.Dice[i], i, row).ShouldBeTrue();
		}

		status = qLessDice.GameStatus();
		_ = status.ShouldBeOfType<QLessDice.Errors>();
		((QLessDice.Errors)status).ErrorReasons.ShouldNotHaveFlag(QLessDice.ErrorReasons.TwoLetterWords);
		((QLessDice.Errors)status).ErrorReasons.ShouldNotHaveFlag(QLessDice.ErrorReasons.MissingDice);
		((QLessDice.Errors)status).ErrorReasons.ShouldHaveFlag(QLessDice.ErrorReasons.MultipleBlocks);

		for (int i = 0; i < qLessDice.Dice.Count; i++)
		{
			row = 1; 
			qLessDice.PlaceOnBoard(qLessDice.Dice[i], i, row).ShouldBeTrue();
		}

		status = qLessDice.GameStatus();
		_ = status.ShouldBeOfType<QLessDice.Win>();
	}

	[Fact]
	public void Play_A_Game_With_A_Dictionary()
	{
		QLessDice qLessDice = new(_dictionaryOfWords);
		qLessDice.HasDictionary.ShouldBeTrue();

		foreach (var die in qLessDice.Dice)
		{
			die.UpperFace = 0;
		}

	}

}
