namespace Smab.DiceAndTiles;

public class BoggleDice
{
	private static readonly List<LetterDie> s_Dice_Classic4x4 =
	[
		new LetterDie([ "A", "A", "C", "I", "O", "T" ]) { Name = "AACIOT" },
		new LetterDie([ "A", "B", "I", "L", "T", "Y" ]) { Name = "ABILTY" },
		new LetterDie([ "A", "B", "J", "M", "O", "Qu" ]) { Name = "ABJMOQu" },
		new LetterDie([ "A", "C", "D", "E", "M", "P" ]) { Name = "ACDEMP" },

		new LetterDie([ "A", "C", "E", "L", "R", "S" ]) { Name = "ACELRS" },
		new LetterDie([ "A", "D", "E", "N", "V", "Z" ]) { Name = "ADENVZ" },
		new LetterDie([ "A", "H", "M", "O", "R", "S" ]) { Name = "AHMORS" },
		new LetterDie([ "B", "I", "F", "O", "R", "X" ]) { Name = "BIFORX" },

		new LetterDie([ "D", "E", "N", "O", "S", "W" ]) { Name = "DENOSW" },
		new LetterDie([ "D", "K", "N", "O", "T", "U" ]) { Name = "DKNOTU" },
		new LetterDie([ "E", "E", "F", "H", "I", "Y" ]) { Name = "EEFHIY" },
		new LetterDie([ "E", "G", "K", "L", "U", "Y" ]) { Name = "EGKLUY" },

		new LetterDie([ "E", "G", "I", "N", "T", "V" ]) { Name = "EGINTV" },
		new LetterDie([ "E", "H", "I", "N", "P", "S" ]) { Name = "EHINPS" },
		new LetterDie([ "E", "L", "P", "S", "T", "U" ]) { Name = "ELPSTU" },
		new LetterDie([ "G", "I", "L", "R", "U", "W" ]) { Name = "GILRUW" }
	];

	private static readonly List<LetterDie> s_Dice_New4x4 =
	[
		new LetterDie([ "A", "A", "E", "E", "G", "N" ]) { Name = "AAEEGN" },
		new LetterDie([ "A", "B", "B", "J", "O", "O" ]) { Name = "ABBJOO" },
		new LetterDie([ "A", "C", "H", "O", "P", "S" ]) { Name = "ACHOPS" },
		new LetterDie([ "A", "F", "F", "K", "P", "S" ]) { Name = "AFFKPS" },
		new LetterDie([ "A", "O", "O", "T", "T", "W" ]) { Name = "AOOTTW" },
		new LetterDie([ "C", "I", "M", "O", "T", "U" ]) { Name = "CIMOTU" },
		new LetterDie([ "D", "E", "I", "L", "R", "X" ]) { Name = "DEILRX" },
		new LetterDie([ "D", "E", "L", "R", "V", "Y" ]) { Name = "DELRVY" },
		new LetterDie([ "D", "I", "S", "T", "T", "Y" ]) { Name = "DISTTY" },
		new LetterDie([ "E", "E", "G", "H", "N", "W" ]) { Name = "EEGHNW" },
		new LetterDie([ "E", "E", "I", "N", "S", "U" ]) { Name = "EEINSU" },
		new LetterDie([ "E", "H", "R", "T", "V", "W" ]) { Name = "EHRTVW" },
		new LetterDie([ "E", "I", "O", "S", "S", "T" ]) { Name = "EIOSST" },
		new LetterDie([ "E", "L", "R", "T", "T", "Y" ]) { Name = "ELRTTY" },
		new LetterDie([ "H", "I", "M", "N", "U", "Qu" ]) { Name = "HIMNUQu" },
		new LetterDie([ "H", "L", "N", "N", "R", "Z" ]) { Name = "HLNNRZ" }
	];

	private static readonly List<LetterDie> s_Dice_BigBoggleOriginal =
	[
		new LetterDie([ "A", "A", "A", "F", "R", "S" ]) { Name = "AAAFRS" },
		new LetterDie([ "A", "A", "E", "E", "E", "E" ]) { Name = "AAEEEE" },
		new LetterDie([ "A", "A", "F", "I", "R", "S" ]) { Name = "AAFIRS" },
		new LetterDie([ "A", "D", "E", "N", "N", "N" ]) { Name = "ADENNN" },
		new LetterDie([ "A", "E", "E", "E", "E", "M" ]) { Name = "AEEEEM" },

		new LetterDie([ "A", "E", "E", "G", "M", "U" ]) { Name = "AEEGMU" },
		new LetterDie([ "A", "E", "G", "M", "N", "N" ]) { Name = "AEGMNN" },
		new LetterDie([ "A", "F", "I", "R", "S", "Y" ]) { Name = "AFIRSY" },
		new LetterDie([ "B", "J", "K", "Qu", "X", "Z" ]) { Name = "BJKQuXZ" },
		new LetterDie([ "C", "C", "E", "N", "S", "T" ]) { Name = "CCENST" },

		new LetterDie([ "C", "E", "I", "I", "L", "T" ]) { Name = "CEIILT" },
		new LetterDie([ "C", "E", "I", "L", "P", "T" ]) { Name = "CEILPT" },
		new LetterDie([ "C", "E", "I", "P", "S", "T" ]) { Name = "CEIPST" },
		new LetterDie([ "D", "D", "H", "N", "O", "T" ]) { Name = "DDHNOT" },
		new LetterDie([ "D", "H", "H", "L", "O", "R" ]) { Name = "DHHLOR" },

		new LetterDie([ "D", "H", "H", "L", "O", "R" ]) { Name = "DHHLOR2" },
		new LetterDie([ "D", "H", "L", "N", "O", "R" ]) { Name = "DHLNOR" },
		new LetterDie([ "E", "I", "I", "I", "T", "T" ]) { Name = "EIIITT" },
		new LetterDie([ "E", "M", "O", "T", "T", "T" ]) { Name = "EMOTTT" },
		new LetterDie([ "E", "N", "S", "S", "S", "U" ]) { Name = "ENSSSU" },

		new LetterDie([ "F", "I", "P", "R", "S", "Y" ]) { Name = "FIPRSY" },
		new LetterDie([ "G", "O", "R", "R", "V", "W" ]) { Name = "GORRVW" },
		new LetterDie([ "I", "P", "R", "R", "R", "Y" ]) { Name = "IPRRRY" },
		new LetterDie([ "N", "O", "O", "T", "U", "W" ]) { Name = "NOOTUW" },
		new LetterDie([ "O", "O", "O", "T", "T", "U" ]) { Name = "OOOTTU" }
	];

	private static readonly List<LetterDie> s_Dice_BigBoggleDeluxe =
	[
		new LetterDie([ "A", "A", "A", "F", "R", "S" ]) { Name = "AAAFRS" },
		new LetterDie([ "A", "A", "E", "E", "E", "E" ]) { Name = "AAEEEE" },
		new LetterDie([ "A", "A", "F", "I", "R", "S" ]) { Name = "AAFIRS" },
		new LetterDie([ "A", "D", "E", "N", "N", "N" ]) { Name = "ADENNN" },
		new LetterDie([ "A", "E", "E", "E", "E", "M" ]) { Name = "AEEEEM" },

		new LetterDie([ "A", "E", "E", "G", "M", "U" ]) { Name = "AEEGMU" },
		new LetterDie([ "A", "E", "G", "M", "N", "N" ]) { Name = "AEGMNN" },
		new LetterDie([ "A", "F", "I", "R", "S", "Y" ]) { Name = "AFIRSY" },
		new LetterDie([ "B", "J", "K", "Qu", "X", "Z" ]) { Name = "BJKQuXZ" },
		new LetterDie([ "C", "C", "N", "S", "T", "W" ]) { Name = "CCNSTW" },

		new LetterDie([ "C", "E", "I", "I", "L", "T" ]) { Name = "CEIILT" },
		new LetterDie([ "C", "E", "I", "L", "P", "T" ]) { Name = "CEILPT" },
		new LetterDie([ "C", "E", "I", "P", "S", "T" ]) { Name = "CEIPST" },
		new LetterDie([ "D", "H", "H", "N", "O", "T" ]) { Name = "DHHNOT" },
		new LetterDie([ "D", "H", "H", "L", "O", "R" ]) { Name = "DHHLOR" },

		new LetterDie([ "D", "H", "L", "N", "O", "R" ]) { Name = "DHLNOR" },
		new LetterDie([ "D", "D", "L", "N", "O", "R" ]) { Name = "DDLNOR" },
		new LetterDie([ "E", "I", "I", "I", "T", "T" ]) { Name = "EIIITT" },
		new LetterDie([ "E", "M", "O", "T", "T", "T" ]) { Name = "EMOTTT" },
		new LetterDie([ "E", "N", "S", "S", "S", "U" ]) { Name = "ENSSSU" },

		new LetterDie([ "F", "I", "P", "R", "S", "Y" ]) { Name = "FIPRSY" },
		new LetterDie([ "G", "O", "R", "R", "V", "W" ]) { Name = "GORRVW" },
		new LetterDie([ "H", "I", "P", "R", "R", "Y" ]) { Name = "HIPRRY" },
		new LetterDie([ "N", "O", "O", "T", "U", "W" ]) { Name = "NOOTUW" },
		new LetterDie([ "O", "O", "O", "T", "T", "U" ]) { Name = "OOOTTU" }
	];

	private static readonly List<LetterDie> s_Dice_SuperBigBoggle2012 =
	[
		new LetterDie([ "A", "A", "A", "F", "R", "S" ]) { Name = "AAAFRS" },
		new LetterDie([ "A", "A", "E", "E", "E", "E" ]) { Name = "AAEEEE" },
		new LetterDie([ "A", "A", "E", "E", "O", "O" ]) { Name = "AAEEOO" },
		new LetterDie([ "A", "A", "F", "I", "R", "S" ]) { Name = "AAFIRS" },
		new LetterDie([ "A", "B", "D", "E", "I", "O" ]) { Name = "ABDEIO" },
		new LetterDie([ "A", "D", "E", "N", "N", "N" ]) { Name = "ADENNN" },

		new LetterDie([ "A", "E", "E", "E", "E", "M" ]) { Name = "AEEEEM" },
		new LetterDie([ "A", "E", "E", "G", "M", "U" ]) { Name = "AEEGMU" },
		new LetterDie([ "A", "E", "G", "M", "N", "N" ]) { Name = "AEGMNN" },
		new LetterDie([ "A", "E", "I", "L", "M", "N" ]) { Name = "AEILMN" },
		new LetterDie([ "A", "E", "I", "N", "O", "U" ]) { Name = "AEINOU" },
		new LetterDie([ "A", "F", "I", "R", "S", "Y" ]) { Name = "AFIRSY" },

		new LetterDie([ "An", "Er", "He", "In", "Qu", "Th" ]) { Name = "AnErHeInQuTh" },
		new LetterDie([ "B", "B", "J", "K", "X", "Z" ]) { Name = "BBJKXZ" },
		new LetterDie([ "C", "C", "E", "N", "S", "T" ]) { Name = "CCENST" },
		new LetterDie([ "C", "D", "D", "L", "N", "N" ]) { Name = "CDDLNN" },
		new LetterDie([ "C", "E", "I", "I", "T", "T" ]) { Name = "CEIITT" },
		new LetterDie([ "C", "E", "I", "P", "S", "T" ]) { Name = "CEIPST" },

		new LetterDie([ "C", "F", "G", "N", "U", "Y" ]) { Name = "CFGNUY" },
		new LetterDie([ "D", "D", "H", "N", "O", "T" ]) { Name = "DDHNOT" },
		new LetterDie([ "D", "H", "H", "L", "O", "R" ]) { Name = "DHHLOR" },
		new LetterDie([ "D", "H", "H", "N", "O", "W" ]) { Name = "DHHNOW" },
		new LetterDie([ "D", "H", "L", "N", "O", "R" ]) { Name = "DHLNOR" },
		new LetterDie([ "E", "H", "I", "L", "R", "S" ]) { Name = "EHILRS" },

		new LetterDie([ "E", "I", "I", "L", "S", "T" ]) { Name = "EIILST" },
		new LetterDie([ "E", "I", "L", "P", "S", "T" ]) { Name = "EILPST" },
		new LetterDie([ "E", "I", "O", "#", "#", "#" ]) { Name = "EIO###" },
		new LetterDie([ "E", "M", "T", "T", "T", "O" ]) { Name = "EMTTTO" },
		new LetterDie([ "E", "N", "S", "S", "S", "U" ]) { Name = "ENSSSU" },
		new LetterDie([ "G", "O", "R", "R", "V", "W" ]) { Name = "GORRVW" },

		new LetterDie([ "H", "I", "R", "S", "T", "V" ]) { Name = "HIRSTV" },
		new LetterDie([ "H", "O", "P", "R", "S", "T" ]) { Name = "HOPRST" },
		new LetterDie([ "I", "P", "R", "S", "Y", "Y" ]) { Name = "IPRSYY" },
		new LetterDie([ "J", "K", "Qu", "W", "X", "Z" ]) { Name = "JKQuWXZ" },
		new LetterDie([ "N", "O", "O", "T", "U", "W" ]) { Name = "NOOTUW" },
		new LetterDie([ "O", "O", "O", "T", "T", "U" ]) { Name = "OOOTTU" }
	];

	public BoggleDice(BoggleType type = BoggleType.Classic4x4)
	{
		Type = type;

		BoardSize = (int)Math.Sqrt(Type switch
		{
			BoggleType.Classic4x4         => s_Dice_Classic4x4.Count,
			BoggleType.New4x4             => s_Dice_New4x4.Count,
			BoggleType.BigBoggleOriginal  => s_Dice_BigBoggleOriginal.Count,
			BoggleType.BigBoggleDeluxe    => s_Dice_BigBoggleDeluxe.Count,
			BoggleType.SuperBigBoggle2012 => s_Dice_SuperBigBoggle2012.Count,
			_ => throw new NotImplementedException(),
		});
		BoardHeight = BoardSize;
		BoardWidth  = BoardSize;

		ShakeAndFillBoard();
	}

	public enum BoggleType
	{
		Classic4x4,
		New4x4,
		BigBoggleOriginal,
		BigBoggleChallenge,
		BigBoggleDeluxe,
		SuperBigBoggle2012
	}

	public enum CheckResult
	{
		Success,
		Unplayable,
		Misspelt
	}

	public List<PositionedDie> Board { get; private set; } = [];
	public BoggleType Type { get; init; }

	public int BoardSize   { get; }
	public int BoardHeight { get; }
	public int BoardWidth  { get; }

	public List<LetterDie> Dice => Type switch
	{
		BoggleType.Classic4x4         => new(s_Dice_Classic4x4),
		BoggleType.New4x4             => new(s_Dice_New4x4),
		BoggleType.BigBoggleOriginal  => new(s_Dice_BigBoggleOriginal),
		BoggleType.BigBoggleDeluxe    => new(s_Dice_BigBoggleDeluxe),
		BoggleType.SuperBigBoggle2012 => new(s_Dice_SuperBigBoggle2012),
		_ => throw new NotImplementedException(),
	};

	public int NoOfDice        => Dice.Count;
	public int NoOfDiceOnBoard => Board.Count;

	public void ShakeAndFillBoard() => Board = ShakeAndCreateBoard();

	private List<PositionedDie> ShakeAndCreateBoard()
	{
		List<LetterDie>       bag = new(Dice);
		List<PositionedDie> board = [];

		Board      = [];
		Random rnd = new();

		int boardIndex = 0;
		do
		{
			int bagIndex = rnd.Next(0, bag.Count);
			bag[bagIndex].Roll();
			if (bag[bagIndex].FaceValue.Name == "#")
			{
				bag[bagIndex].Faces[bag[bagIndex].UpperFace] = bag[bagIndex].FaceValue with { Display = "■" };
			}

			board.Add(new PositionedDie(bag[bagIndex] with { Orientation = rnd.Next(0, 4) * 90 }, boardIndex % BoardSize, boardIndex / BoardSize));
			_ = bag.Remove(bag[bagIndex]);
			boardIndex++;
		} while (bag.Count > 0);

		return board;
	}

	public (int score, CheckResult reason) CheckAndScoreWord(string word)
	{
		CheckResult reason = CheckResult.Success;
		List<PositionedDie> validSlots = SearchBoard(word);
		int score = 0;
		if (validSlots.Count != 0)
		{
			score = ScoreWord(word);
		}
		else
		{
			reason = CheckResult.Unplayable;
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
