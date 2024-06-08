namespace Smab.DiceAndTiles.Games.QLess;
public static class QLessDiceExtensions
{
	private const int ANY_COL = int.MinValue;

	public static QLessDiceStatus GameStatus(this QLessDice qLessDice)
	{
		HashSet<PositionedDie> errorDice = [];
		ErrorReasons errorReasons = ErrorReasons.None;
		ScrabbleWordFinder swf = new(qLessDice.Board, qLessDice.dictionaryOfWords);
		List<string> words = swf.FindWords();
		bool notFinished = false;

		if (qLessDice.Board.Count != qLessDice.Dice.Count)
		{
			errorReasons |= ErrorReasons.MissingDice;
			notFinished = true;
		}

		if (swf.ValidWordsAsTiles.Concat(swf.InvalidWordsAsTiles).Any(t => t.Count == 2))
		{
			errorReasons |= ErrorReasons.TwoLetterWords;
			notFinished = true;
			errorDice = [.. errorDice,
				.. swf
				.ValidWordsAsTiles
				.Concat(swf.InvalidWordsAsTiles)
				.Where(t => t.Count == 2)
				.SelectMany(t => t)
				.Distinct()
				.Select(t => qLessDice.Board.SingleDieAt(t.Col, t.Row))
			];
		}

		if (swf.IsBlockInMoreThanOnePiece())
		{
			errorReasons |= ErrorReasons.MultipleBlocks;
			notFinished = true;
			errorDice = [.. errorDice,
				.. swf
				.Islands
				.OrderByDescending(i => i.Count)
				.Skip(1)
				.Where(i => i.Count != 0)
				.SelectMany(t => t)
				.Select(t => qLessDice.Board.SingleDieAt(t.Col, t.Row))
			];
		}

		if (qLessDice.dictionaryOfWords is not null && qLessDice.dictionaryOfWords.HasWords)
		{
			if (notFinished is false && swf.InvalidWordsAsTiles.Count == 0)
			{
				return new Win();
			}

			if (swf.InvalidWordsAsTiles.Count != 0)
			{
				errorReasons |= ErrorReasons.Misspelt;
				foreach (List<PositionedTile> tiles in swf.InvalidWordsAsTiles)
				{
					tiles.ForEach(t => errorDice.Add(qLessDice.Board.SingleDieAt(t.Col, t.Row)));
				}
			}
		}
		else if (notFinished is false && errorDice.Count == 0)
		{
			return new Win();
		}

		return new Errors(errorDice, errorReasons);
	}

	public static (bool Success, QLessDice QLessDice) PlaceOnBoard(this QLessDice qLessDice, Die die, int col, int row) => qLessDice.PlaceOnBoard(die.Id, col, row);
	public static (bool Success, QLessDice QLessDice) PlaceOnBoard(this QLessDice qLessDice, DieId name, int col, int row)
	{
		if (qLessDice.Board.Any(d => d.Row == row && d.Col == col))
		{
			return (false, qLessDice);
		}

		PositionedQLessDie positionedDie = qLessDice.DiceDictionary[name].PlaceOnBoard(col, row);
		Dictionary<DieId, PositionedQLessDie> newDiceDictionary = new(qLessDice.DiceDictionary)
		{
			[name] = positionedDie
		};
		return (true, qLessDice with { DiceDictionary = newDiceDictionary });
	}

	public static (bool Success, QLessDice QLessDice) PlaceOnRack(this QLessDice qLessDice, Die die, int col = ANY_COL) => qLessDice.PlaceOnRack(die.Id, col);
	public static (bool Success, QLessDice QLessDice) PlaceOnRack(this QLessDice qLessDice, DieId dieId, int col = ANY_COL)
	{
		if (col != ANY_COL && qLessDice.Rack.Any(p => p.Col == col))
		{
			return (false, qLessDice);
		}

		if (col == ANY_COL)
		{
			col = Enumerable.Range(0, qLessDice.Dice.Count).Except(qLessDice.Rack.Select(d => d.Col)).Min();
		}

		if (qLessDice.Rack.Any(p => p.Col == col))
		{
			return (false, qLessDice);
		}

		PositionedQLessDie positionedDie = qLessDice.DiceDictionary[dieId].PlaceOnRack(col);
		Dictionary<DieId, PositionedQLessDie> newDiceDictionary = new(qLessDice.DiceDictionary)
		{
			[dieId] = positionedDie
		};
		return (true, qLessDice with { DiceDictionary = newDiceDictionary });
	}

	internal static Dictionary<DieId, PositionedQLessDie> ShakeAndFillRack(IEnumerable<LetterDie> dice, bool rollDice)
	{
		Dictionary<DieId, PositionedQLessDie> diceDictionary = [];
		LetterDie[] bag = [.. dice];
		Random.Shared.Shuffle(bag);

		for (int i = 0; i < bag.Length; i++)
		{
			LetterDie die = bag[i];
			if (rollDice)
			{
				die = (LetterDie)die.Roll();
			}
			diceDictionary.Add(die.Id, new PositionedQLessDie(die, i));
		}
		return diceDictionary;
	}
}
