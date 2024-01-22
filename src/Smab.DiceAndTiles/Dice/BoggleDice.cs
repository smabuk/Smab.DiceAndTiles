namespace Smab.DiceAndTiles;

public class BoggleDice
{
	private readonly List<LetterDie> _Dice_Classic4x4 =
	[
		new([ "A", "A", "C", "I", "O", "T" ]),
		new([ "A", "B", "I", "L", "T", "Y" ]),
		new([ "A", "B", "J", "M", "O", "Qu" ]),
		new([ "A", "C", "D", "E", "M", "P" ]),

		new([ "A", "C", "E", "L", "R", "S" ]),
		new([ "A", "D", "E", "N", "V", "Z" ]),
		new([ "A", "H", "M", "O", "R", "S" ]),
		new([ "B", "I", "F", "O", "R", "X" ]),

		new([ "D", "E", "N", "O", "S", "W" ]),
		new([ "D", "K", "N", "O", "T", "U" ]),
		new([ "E", "E", "F", "H", "I", "Y" ]),
		new([ "E", "G", "K", "L", "U", "Y" ]),

		new([ "E", "G", "I", "N", "T", "V" ]),
		new([ "E", "H", "I", "N", "P", "S" ]),
		new([ "E", "L", "P", "S", "T", "U" ]),
		new([ "G", "I", "L", "R", "U", "W" ]),
	];

	private readonly List<LetterDie> _Dice_New4x4 =
	[
		new([ "A", "A", "E", "E", "G", "N" ]),
		new([ "A", "B", "B", "J", "O", "O" ]),
		new([ "A", "C", "H", "O", "P", "S" ]),
		new([ "A", "F", "F", "K", "P", "S" ]),
		new([ "A", "O", "O", "T", "T", "W" ]),
		new([ "C", "I", "M", "O", "T", "U" ]),
		new([ "D", "E", "I", "L", "R", "X" ]),
		new([ "D", "E", "L", "R", "V", "Y" ]),
		new([ "D", "I", "S", "T", "T", "Y" ]),
		new([ "E", "E", "G", "H", "N", "W" ]),
		new([ "E", "E", "I", "N", "S", "U" ]),
		new([ "E", "H", "R", "T", "V", "W" ]),
		new([ "E", "I", "O", "S", "S", "T" ]),
		new([ "E", "L", "R", "T", "T", "Y" ]),
		new([ "H", "I", "M", "N", "U", "Qu" ]),
		new([ "H", "L", "N", "N", "R", "Z" ]),
	];

	private readonly List<LetterDie> _Dice_BigBoggleOriginal =
	[
		new([ "A", "A", "A", "F", "R", "S" ]),
		new([ "A", "A", "E", "E", "E", "E" ]),
		new([ "A", "A", "F", "I", "R", "S" ]),
		new([ "A", "D", "E", "N", "N", "N" ]),
		new([ "A", "E", "E", "E", "E", "M" ]),

		new([ "A", "E", "E", "G", "M", "U" ]),
		new([ "A", "E", "G", "M", "N", "N" ]),
		new([ "A", "F", "I", "R", "S", "Y" ]),
		new([ "B", "J", "K", "Qu", "X", "Z" ]),
		new([ "C", "C", "E", "N", "S", "T" ]),

		new([ "C", "E", "I", "I", "L", "T" ]) ,
		new([ "C", "E", "I", "L", "P", "T" ]) ,
		new([ "C", "E", "I", "P", "S", "T" ]) ,
		new([ "D", "D", "H", "N", "O", "T" ]) ,
		new([ "D", "H", "H", "L", "O", "R" ]) { Name = "DHHLOR1" } ,

		new([ "D", "H", "H", "L", "O", "R" ]) { Name = "DHHLOR2" },
		new([ "D", "H", "L", "N", "O", "R" ]),
		new([ "E", "I", "I", "I", "T", "T" ]),
		new([ "E", "M", "O", "T", "T", "T" ]),
		new([ "E", "N", "S", "S", "S", "U" ]),

		new([ "F", "I", "P", "R", "S", "Y" ]),
		new([ "G", "O", "R", "R", "V", "W" ]),
		new([ "I", "P", "R", "R", "R", "Y" ]),
		new([ "N", "O", "O", "T", "U", "W" ]),
		new([ "O", "O", "O", "T", "T", "U" ]),
	];

	private readonly List<LetterDie> _Dice_BigBoggleDeluxe =
	[
		new([ "A", "A", "A", "F", "R", "S" ]),
		new([ "A", "A", "E", "E", "E", "E" ]),
		new([ "A", "A", "F", "I", "R", "S" ]),
		new([ "A", "D", "E", "N", "N", "N" ]),
		new([ "A", "E", "E", "E", "E", "M" ]),

		new([ "A", "E", "E", "G", "M", "U" ]),
		new([ "A", "E", "G", "M", "N", "N" ]),
		new([ "A", "F", "I", "R", "S", "Y" ]),
		new([ "B", "J", "K", "Qu", "X", "Z" ]),
		new([ "C", "C", "N", "S", "T", "W" ]),

		new([ "C", "E", "I", "I", "L", "T" ]),
		new([ "C", "E", "I", "L", "P", "T" ]),
		new([ "C", "E", "I", "P", "S", "T" ]),
		new([ "D", "H", "H", "N", "O", "T" ]),
		new([ "D", "H", "H", "L", "O", "R" ]),

		new([ "D", "H", "L", "N", "O", "R" ]),
		new([ "D", "D", "L", "N", "O", "R" ]),
		new([ "E", "I", "I", "I", "T", "T" ]),
		new([ "E", "M", "O", "T", "T", "T" ]),
		new([ "E", "N", "S", "S", "S", "U" ]),

		new([ "F", "I", "P", "R", "S", "Y" ]),
		new([ "G", "O", "R", "R", "V", "W" ]),
		new([ "H", "I", "P", "R", "R", "Y" ]),
		new([ "N", "O", "O", "T", "U", "W" ]),
		new([ "O", "O", "O", "T", "T", "U" ]),
	];

	private readonly List<LetterDie> _Dice_SuperBigBoggle2012 =
	[
		new([ "A", "A", "A", "F", "R", "S" ]),
		new([ "A", "A", "E", "E", "E", "E" ]),
		new([ "A", "A", "E", "E", "O", "O" ]),
		new([ "A", "A", "F", "I", "R", "S" ]),
		new([ "A", "B", "D", "E", "I", "O" ]),
		new([ "A", "D", "E", "N", "N", "N" ]),

		new([ "A", "E", "E", "E", "E", "M" ]),
		new([ "A", "E", "E", "G", "M", "U" ]),
		new([ "A", "E", "G", "M", "N", "N" ]),
		new([ "A", "E", "I", "L", "M", "N" ]),
		new([ "A", "E", "I", "N", "O", "U" ]),
		new([ "A", "F", "I", "R", "S", "Y" ]),

		new([ "An", "Er", "He", "In", "Qu", "Th" ]),
		new([ "B", "B", "J", "K", "X", "Z" ]),
		new([ "C", "C", "E", "N", "S", "T" ]),
		new([ "C", "D", "D", "L", "N", "N" ]),
		new([ "C", "E", "I", "I", "T", "T" ]),
		new([ "C", "E", "I", "P", "S", "T" ]),

		new([ "C", "F", "G", "N", "U", "Y" ]),
		new([ "D", "D", "H", "N", "O", "T" ]),
		new([ "D", "H", "H", "L", "O", "R" ]),
		new([ "D", "H", "H", "N", "O", "W" ]),
		new([ "D", "H", "L", "N", "O", "R" ]),
		new([ "E", "H", "I", "L", "R", "S" ]),

		new([ "E", "I", "I", "L", "S", "T" ]),
		new([ "E", "I", "L", "P", "S", "T" ]),
		new([ "E", "I", "O", "#", "#", "#" ]),
		new([ "E", "M", "T", "T", "T", "O" ]),
		new([ "E", "N", "S", "S", "S", "U" ]),
		new([ "G", "O", "R", "R", "V", "W" ]),

		new([ "H", "I", "R", "S", "T", "V" ]),
		new([ "H", "O", "P", "R", "S", "T" ]),
		new([ "I", "P", "R", "S", "Y", "Y" ]),
		new([ "J", "K", "Qu", "W", "X", "Z" ]),
		new([ "N", "O", "O", "T", "U", "W" ]),
		new([ "O", "O", "O", "T", "T", "U" ]),
	];

	private readonly DictionaryOfWords dictionaryOfWords;

	public BoggleDice(BoggleType type = BoggleType.Classic4x4, DictionaryOfWords? dictionary = null)
	{
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
		dictionaryOfWords = dictionary ?? new();
	}

	public enum BoggleType
	{
		Classic4x4,
		New4x4,
		BigBoggleOriginal,
		BigBoggleChallenge,
		BigBoggleDeluxe,
		SuperBigBoggle2012,
	}

	public enum CheckResult
	{
		Success,
		Unplayable,
		Misspelt,
	}

	public List<PositionedDie> Board { get; private set; } = [];
	public BoggleType Type { get; init; }

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

	public int NoOfDice        => Dice.Count;
	public int NoOfDiceOnBoard => Board.Count;

	public void ShakeAndFillBoard() => Board = ShakeAndCreateBoard();

	private List<PositionedDie> ShakeAndCreateBoard()
	{
		LetterDie[] bag = [..Dice];
		Random.Shared.Shuffle(bag);

		List<PositionedDie> board = [];

		for (int boardIndex = 0; boardIndex < bag.Length; boardIndex++)
		{
			LetterDie die = bag[boardIndex];
			die.Roll();
			if (die.FaceValue.Name == "#")
			{
				die.Faces[die.UpperFace] = die.FaceValue with { Display = "■" };
			}

			board.Add(new PositionedDie(die with { Orientation = Random.Shared.Next(0, 4) * 90 }, boardIndex % BoardSize, boardIndex / BoardSize));
		}

		return board;
	}

	public (int score, CheckResult reason) CheckAndScoreWord(string word)
	{
		CheckResult reason = CheckResult.Success;

		List<PositionedDie> validSlots = SearchBoard(word);
		int score = 0;
		if (validSlots.Count == 0) {
			reason = CheckResult.Unplayable;
		} else if (dictionaryOfWords.HasWords) {
			reason = dictionaryOfWords.IsWord(word) ? CheckResult.Success : CheckResult.Misspelt;
		}

		if (reason == CheckResult.Success)
		{
			score = ScoreWord(word);
		}

		return (score, reason);
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
