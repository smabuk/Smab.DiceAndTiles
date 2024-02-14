namespace Smab.DiceAndTiles.Games.Boggle;

public partial class BoggleDice
{
	/// <summary>
	/// Unicode character ⯀ (Black Square Centred (U+2BC0))
	/// </summary>
	public const string BlankDisplay = "\u2BC0";

	private readonly IDictionaryOfWords dictionaryOfWords;

	public BoggleDice(string type, IDictionaryOfWords? dictionary = null) : this(type.ToBoggleType(), dictionary) { }
	
	public BoggleDice(BoggleType type = BoggleType.Classic4x4, IDictionaryOfWords? dictionary = null)
	{
		dictionaryOfWords = dictionary ?? new DictionaryOfWords();
		Type = type;

		BoardSize = (int)Math.Sqrt(Type switch
		{
			BoggleType.Classic4x4         => _Dice_Classic4x4.Count,
			BoggleType.New4x4             => _Dice_New4x4.Count,
			BoggleType.BigBoggleOriginal  => _Dice_BigBoggleOriginal.Count,
			BoggleType.BigBoggleDeluxe    => _Dice_BigBoggleDeluxe.Count,
			BoggleType.SuperBigBoggle2012 => _Dice_SuperBigBoggle2012.Count,
			_ => throw new NotImplementedException(),
		});

		BoardHeight = BoardSize;
		BoardWidth  = BoardSize;

		ShakeAndFillBoard();
	}

	public List<PositionedDie> Board { get; private set; } = [];
	public BoggleType Type { get; init; }
	
	private List<WordScore> Words { get; set; } = [];
	public IEnumerable<WordScore> WordScores => [.. Words];
	public int Score => Words.Sum(w => w.Score);

	public int BoardSize   { get; }
	public int BoardHeight { get; }
	public int BoardWidth  { get; }

	public List<LetterDie> Dice => Type switch
	{
		BoggleType.Classic4x4         => new(_Dice_Classic4x4),
		BoggleType.New4x4             => new(_Dice_New4x4),
		BoggleType.BigBoggleOriginal  => new(_Dice_BigBoggleOriginal),
		BoggleType.BigBoggleDeluxe    => new(_Dice_BigBoggleDeluxe),
		BoggleType.SuperBigBoggle2012 => new(_Dice_SuperBigBoggle2012),
		_ => throw new NotImplementedException(),
	};

	public bool HasDictionary => dictionaryOfWords.HasWords;

	public void ShakeAndFillBoard() => Board = ShakeAndCreateBoard();

	private List<PositionedDie> ShakeAndCreateBoard()
	{
		Words = [];
		LetterDie[] bag = [..Dice];
		Random.Shared.Shuffle(bag);

		List<PositionedDie> board = [];

		for (int boardIndex = 0; boardIndex < bag.Length; boardIndex++)
		{
			LetterDie die = bag[boardIndex];
			_ = die.Roll();
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

			board.Add(new PositionedDie(die with { Orientation = Random.Shared.Next(0, 4) * 90 }, boardIndex % BoardSize, boardIndex / BoardSize));
		}

		return board;
	}

	public WordScore PlayWord(string word)
	{
		ScoreReason reason = ScoreReason.Success;
		word = word.ToUpperInvariant();

		List<PositionedDie> validSlots = SearchBoard(word);
		int score = 0;
		if (validSlots.Count == 0) {
			reason = ScoreReason.Unplayable;
		} else if (dictionaryOfWords.HasWords) {
			reason = dictionaryOfWords.IsWord(word) ? ScoreReason.Success : ScoreReason.Misspelt;
		}

		if (reason == ScoreReason.Success)
		{
			score = ScoreWord(word);
			if (score == 0)
			{
				reason = ScoreReason.TooShort;
			}
		}

		if (Words.Any(w => w.Word.Equals(word, StringComparison.InvariantCultureIgnoreCase)))
		{
			score  = 0;
			reason = ScoreReason.AlreadyPlayed;
		}

		Words.Add(new WordScore(word, score, reason));
		return new WordScore(word, score, reason);
	}

	public int ScoreWord(string word)
	{
		return word.Length switch
		{
			<= 3 when Type  is BoggleType.BigBoggleDeluxe
							or BoggleType.BigBoggleOriginal
							or BoggleType.BigBoggleChallenge
							or BoggleType.SuperBigBoggle2012 => 0,
			>= 9 when Type is BoggleType.SuperBigBoggle2012 => word.Length * 2,
			   3 =>  1,
			   4 =>  1,
			   5 =>  2,
			   6 =>  3,
			   7 =>  5,
			>= 8 => 11,
			_    =>  0
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
	public List<PositionedDie> SearchBoard(string word)
	{
		List<PositionedDie> result = [];
		int cols = Board.Max(x => x.Col) + 1;
		int rows = Board.Max(x => x.Row) + 1;
		bool[,] visited = new bool[rows, cols];
		for (int i = 0; i < Board.Count; i++)
		{
			if (SearchBoardDFS(word, 0, Board[i].Col, Board[i].Row, visited, result))
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
	private bool SearchBoardDFS(string word, int index, int col, int row, bool[,] visited, List<PositionedDie> result)
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

		PositionedDie current = Board.First(d => d.Col == col && d.Row == row);
		int newIndex = Math.Min(word.Length, index + current.Die.Display.Length);
		if (!current.Die.Display.Equals(word[index..newIndex], StringComparison.InvariantCultureIgnoreCase))
		{
			return false;
		}

		result.Add(current);
		visited[col, row] = true;
		bool found = SearchBoardDFS(word, newIndex, col - 1, row - 1, visited, result) ||
					 SearchBoardDFS(word, newIndex, col,     row - 1, visited, result) ||
					 SearchBoardDFS(word, newIndex, col + 1, row - 1, visited, result) ||
					 SearchBoardDFS(word, newIndex, col - 1, row,     visited, result) ||
					 SearchBoardDFS(word, newIndex, col + 1, row,     visited, result) ||
					 SearchBoardDFS(word, newIndex, col - 1, row + 1, visited, result) ||
					 SearchBoardDFS(word, newIndex, col,     row + 1, visited, result) ||
					 SearchBoardDFS(word, newIndex, col + 1, row + 1, visited, result);
		if (!found)
		{
			_ = result.Remove(current);
		}

		visited[col, row] = false;
		return found;
	}
}
