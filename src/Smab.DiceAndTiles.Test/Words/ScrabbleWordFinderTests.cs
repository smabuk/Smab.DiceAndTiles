namespace Smab.DiceAndTiles.Test.Words;

public class ScrabbleWordFinderTests
{
	private static readonly string[] _wordsList = ["this", "is", "a", "bit", "of", "a", "list", "of", "words"];
	private static readonly DictionaryOfWords _dictionaryOfWords = new(_wordsList);

	[Fact]
	public void Board_Should_Have_Islands()
	{
		List<PositionedTile> board = [
			new PositionedTile(new ScrabbleTile('T', 1), 4, 3),
			new PositionedTile(new ScrabbleTile('H', 4), 5, 3),
			new PositionedTile(new ScrabbleTile('I', 1), 6, 3),
			new PositionedTile(new ScrabbleTile('S', 1), 7, 3),

			new PositionedTile(new ScrabbleTile('I', 1), 4, 2),

			new PositionedTile(new ScrabbleTile('B', 3), 1, 1),
			new PositionedTile(new ScrabbleTile('A', 1), 2, 1),
			new PositionedTile(new ScrabbleTile('D', 2), 3, 1),
		];

		ScrabbleWordFinder swf = new(board);

		swf.IsBlockInMoreThanOnePiece().ShouldBeTrue();
		swf.Islands.Count.ShouldBe(2);

		swf.Islands[0].Count.ShouldBe(5);  // T H I S I
		swf.Islands[1].Count.ShouldBe(3);  // B A D


		List<string> words = swf.FindWords();
		words.Count.ShouldBe(3);
		words.ShouldBe(["THIS", "IT", "BAD"], ignoreOrder: true);

		swf.ValidWordsAsTiles.Count.ShouldBe(3);
	}

	[Fact]
	public void Board_Should_Be_In_One_Piece()
	{
		List<PositionedTile> board = [
			new PositionedTile(new LetterTile('T'), 4, 3),
			new PositionedTile(new LetterTile('H'), 5, 3),
			new PositionedTile(new LetterTile('I'), 6, 3),
			new PositionedTile(new LetterTile('S'), 7, 3),

			new PositionedTile(new LetterTile('I'), 4, 2),

			new PositionedTile(new LetterTile('B'), 4, 1),
			new PositionedTile(new LetterTile('A'), 5, 1),
			new PositionedTile(new LetterTile('D'), 6, 1),
		];

		ScrabbleWordFinder swf = new(board);

		swf.IsBlockInMoreThanOnePiece().ShouldBeFalse();
		swf.Islands.Count.ShouldBe(1);

		swf.Islands[0].Count.ShouldBe(8);  // T H I S I H A D

		List<string> words = swf.FindWords();
		words.Count.ShouldBe(3);
		words.ShouldBe(["THIS", "BIT", "BAD"], ignoreOrder: true);

		swf.ValidWordsAsTiles.Count.ShouldBe(3);
	}

	[Fact]
	public void Words_Should_Be_Spelt_Correctly()
	{
		List<PositionedTile> board = [
			new PositionedTile(new LetterTile('T'), 4, 3),
			new PositionedTile(new LetterTile('H'), 5, 3),
			new PositionedTile(new LetterTile('I'), 6, 3),
			new PositionedTile(new LetterTile('S'), 7, 3),

			new PositionedTile(new LetterTile('I'), 4, 2),

			new PositionedTile(new LetterTile('B'), 4, 1),
			new PositionedTile(new LetterTile('A'), 5, 1),
			new PositionedTile(new LetterTile('D'), 6, 1),
		];

		ScrabbleWordFinder swf = new(board, _dictionaryOfWords);

		List<string> words = swf.FindWords();
		words.Count.ShouldBe(2);
		words.ShouldBe(["THIS", "BIT"], ignoreOrder: true);

		swf.ValidWordsAsTiles.Count.ShouldBe(2);
		swf.InvalidWordsAsTiles.Count.ShouldBe(1);
	}
}
