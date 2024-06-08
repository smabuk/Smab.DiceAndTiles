namespace Smab.DiceAndTiles.Games.Boggle;

 public static class BoggleDiceExtensions
{
	public static List<LetterDie> Dice(BoggleType type) => type switch
	{
		BoggleType.Classic4x4         => new(_Dice_Classic4x4),
		BoggleType.New4x4             => new(_Dice_New4x4),
		BoggleType.BigBoggleOriginal  => new(_Dice_BigBoggleOriginal),
		BoggleType.BigBoggleDeluxe    => new(_Dice_BigBoggleDeluxe),
		BoggleType.SuperBigBoggle2012 => new(_Dice_SuperBigBoggle2012),
		_ => throw new NotImplementedException(),
	};

	public static (BoggleDice BoggleDice, WordScore WordScore) PlayWord(this BoggleDice boggleDice, string word)
	{
		ScoreReason reason = ScoreReason.Success;
		word = word.ToUpperInvariant();

		List<PositionedDie> validSlots = boggleDice.SearchBoard(word);
		int score = 0;
		if (validSlots.Count == 0)
		{
			reason = ScoreReason.Unplayable;
		}
		else if (boggleDice.HasDictionary)
		{
			reason = boggleDice.dictionaryOfWords.IsWord(word) ? ScoreReason.Success : ScoreReason.Misspelt;
		}

		if (reason == ScoreReason.Success)
		{
			score = boggleDice.ScoreWord(word);
			if (score == 0)
			{
				reason = ScoreReason.TooShort;
			}
		}

		if (boggleDice.WordScores.Any(w => w.Word.Equals(word, StringComparison.InvariantCultureIgnoreCase)))
		{
			score = 0;
			reason = ScoreReason.AlreadyPlayed;
		}

		WordScore wordScore = new(word, score, reason);
		BoggleDice newBoggleDice = boggleDice with { WordScores = [.. boggleDice.WordScores, wordScore] };
		return (newBoggleDice, wordScore);
	}

	public static int ScoreWord(this BoggleDice boggleDice, string word)
	{
		return word.Length switch
		{
			<= 3 when boggleDice.Type is BoggleType.BigBoggleDeluxe
							or BoggleType.BigBoggleOriginal
							or BoggleType.BigBoggleChallenge
							or BoggleType.SuperBigBoggle2012 => 0,
			>= 9 when boggleDice.Type is BoggleType.SuperBigBoggle2012 => word.Length * 2,
			3 => 1,
			4 => 1,
			5 => 2,
			6 => 3,
			7 => 5,
			>= 8 => 11,
			_ => 0
		};

		/*
		*     4x4 version            5x5 version           6x6 version
		*
		*    Word                   Word                  Word
		*   length	Points         length	Points       length	Points
		*     3       1              3       0             3       0
		*     4       1              4       1             4       1
		*     5       2              5       2             5       2
		*     6       3              6       3             6       3
		*     7       5              7       5             7       5
		*     8+     11              8+     11             8      11
		*                                                  9+   2 pts per letter
		*/
	}

	/// <summary>
	/// Searches the Board and validates the word.
	/// </summary>
	/// <param name="word"></param>
	/// <returns>Returns the first list of slots that make up the word otherwise returns an empty List</returns>
	public static List<PositionedDie> SearchBoard(this BoggleDice boggleDice, string word)
	{
		List<PositionedDie> result = [];
		int cols = boggleDice.Board.Max(x => x.Col) + 1;
		int rows = boggleDice.Board.Max(x => x.Row) + 1;
		bool[,] visited = new bool[rows, cols];
		for (int i = 0; i < boggleDice.Board.Count; i++)
		{
			if (boggleDice.SearchBoardDFS(word, 0, boggleDice.Board[i].Col, boggleDice.Board[i].Row, visited, result))
			{
				return result;
			}
		}

		return result;
	}

	/// <summary>
	/// Uses a Depth First Search algorithm to find the slots that make up the word
	/// </summary>
	/// <param name="word"></param>
	/// <param name="index"></param>
	/// <param name="col"></param>
	/// <param name="row"></param>
	/// <param name="visited"></param>
	/// <param name="result"></param>
	/// <returns></returns>
	private static bool SearchBoardDFS(this BoggleDice boggleDice, string word, int index, int col, int row, bool[,] visited, List<PositionedDie> result)
	{
		if (index == word.Length)
		{
			return true;
		}

		if (col < 0 || col >= visited.GetLength(0) || row < 0 || row >= visited.GetLength(1))
		{
			return false;
		}

		if (visited[col, row])
		{
			return false;
		}

		PositionedDie current = boggleDice.Board.First(d => d.Col == col && d.Row == row);
		int newIndex = Math.Min(word.Length, index + current.Die.Display.Length);
		if (!current.Die.Display.Equals(word[index..newIndex], StringComparison.InvariantCultureIgnoreCase))
		{
			return false;
		}

		result.Add(current);
		visited[col, row] = true;
		bool found = boggleDice.SearchBoardDFS(word, newIndex, col - 1, row - 1, visited, result) ||
					 boggleDice.SearchBoardDFS(word, newIndex, col, row - 1, visited, result) ||
					 boggleDice.SearchBoardDFS(word, newIndex, col + 1, row - 1, visited, result) ||
					 boggleDice.SearchBoardDFS(word, newIndex, col - 1, row, visited, result) ||
					 boggleDice.SearchBoardDFS(word, newIndex, col + 1, row, visited, result) ||
					 boggleDice.SearchBoardDFS(word, newIndex, col - 1, row + 1, visited, result) ||
					 boggleDice.SearchBoardDFS(word, newIndex, col, row + 1, visited, result) ||
					 boggleDice.SearchBoardDFS(word, newIndex, col + 1, row + 1, visited, result);
		if (!found)
		{
			_ = result.Remove(current);
		}

		visited[col, row] = false;
		return found;
	}

	internal static List<PositionedDie> ShakeAndCreateBoard(BoggleType type)
	{
		LetterDie[] bag = [.. Dice(type)];
		Random.Shared.Shuffle(bag);

		List<PositionedDie> board = [];

		for (int boardIndex = 0; boardIndex < bag.Length; boardIndex++)
		{
			LetterDie die = bag[boardIndex];
			die = (LetterDie)die.Roll();
			if (die.HasBlank)
			{
				for (int i = 0; i < die.Faces.Count; i++)
				{
					if (die.Faces[i].IsBlank)
					{
						die.Faces[i] = die.Faces[i] with { Display = BlankDisplay };
					}
				}
			}

			int boardSize = (int)Math.Sqrt(bag.Count());

			board.Add(new PositionedDie(die with { Orientation = Random.Shared.Next(0, 4) * 90 }, boardIndex % boardSize, boardIndex / boardSize));
		}

		return board;
	}
}
