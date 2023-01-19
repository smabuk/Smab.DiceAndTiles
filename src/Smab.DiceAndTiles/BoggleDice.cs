namespace Smab.DiceAndTiles;

public class BoggleDice
{
	private static readonly List<LetterDie> s_Dice_Classic4x4 = new()
	{
		new LetterDie(new string[] { "A", "A", "C", "I", "O", "T" }) { Name = "AACIOT" },
		new LetterDie(new string[] { "A", "B", "I", "L", "T", "Y" }) { Name = "ABILTY" },
		new LetterDie(new string[] { "A", "B", "J", "M", "O", "Qu" }) { Name = "ABJMOQu" },
		new LetterDie(new string[] { "A", "C", "D", "E", "M", "P" }) { Name = "ACDEMP" },

		new LetterDie(new string[] { "A", "C", "E", "L", "R", "S" }) { Name = "ACELRS" },
		new LetterDie(new string[] { "A", "D", "E", "N", "V", "Z" }) { Name = "ADENVZ" },
		new LetterDie(new string[] { "A", "H", "M", "O", "R", "S" }) { Name = "AHMORS" },
		new LetterDie(new string[] { "B", "I", "F", "O", "R", "X" }) { Name = "BIFORX" },

		new LetterDie(new string[] { "D", "E", "N", "O", "S", "W" }) { Name = "DENOSW" },
		new LetterDie(new string[] { "D", "K", "N", "O", "T", "U" }) { Name = "DKNOTU" },
		new LetterDie(new string[] { "E", "E", "F", "H", "I", "Y" }) { Name = "EEFHIY" },
		new LetterDie(new string[] { "E", "G", "K", "L", "U", "Y" }) { Name = "EGKLUY" },

		new LetterDie(new string[] { "E", "G", "I", "N", "T", "V" }) { Name = "EGINTV" },
		new LetterDie(new string[] { "E", "H", "I", "N", "P", "S" }) { Name = "EHINPS" },
		new LetterDie(new string[] { "E", "L", "P", "S", "T", "U" }) { Name = "ELPSTU" },
		new LetterDie(new string[] { "G", "I", "L", "R", "U", "W" }) { Name = "GILRUW" }
	};

	private static readonly List<LetterDie> s_Dice_New4x4 = new()
	{
		new LetterDie(new string[] { "A", "A", "E", "E", "G", "N" }) { Name = "AAEEGN" },
		new LetterDie(new string[] { "A", "B", "B", "J", "O", "O" }) { Name = "ABBJOO" },
		new LetterDie(new string[] { "A", "C", "H", "O", "P", "S" }) { Name = "ACHOPS" },
		new LetterDie(new string[] { "A", "F", "F", "K", "P", "S" }) { Name = "AFFKPS" },
		new LetterDie(new string[] { "A", "O", "O", "T", "T", "W" }) { Name = "AOOTTW" },
		new LetterDie(new string[] { "C", "I", "M", "O", "T", "U" }) { Name = "CIMOTU" },
		new LetterDie(new string[] { "D", "E", "I", "L", "R", "X" }) { Name = "DEILRX" },
		new LetterDie(new string[] { "D", "E", "L", "R", "V", "Y" }) { Name = "DELRVY" },
		new LetterDie(new string[] { "D", "I", "S", "T", "T", "Y" }) { Name = "DISTTY" },
		new LetterDie(new string[] { "E", "E", "G", "H", "N", "W" }) { Name = "EEGHNW" },
		new LetterDie(new string[] { "E", "E", "I", "N", "S", "U" }) { Name = "EEINSU" },
		new LetterDie(new string[] { "E", "H", "R", "T", "V", "W" }) { Name = "EHRTVW" },
		new LetterDie(new string[] { "E", "I", "O", "S", "S", "T" }) { Name = "EIOSST" },
		new LetterDie(new string[] { "E", "L", "R", "T", "T", "Y" }) { Name = "ELRTTY" },
		new LetterDie(new string[] { "H", "I", "M", "N", "U", "Qu" }) { Name = "HIMNUQu" },
		new LetterDie(new string[] { "H", "L", "N", "N", "R", "Z" }) { Name = "HLNNRZ" }
	};

	private static readonly List<LetterDie> s_Dice_BigBoggleOriginal = new()
	{
		new LetterDie(new string[] { "A", "A", "A", "F", "R", "S" }) { Name = "AAAFRS" },
		new LetterDie(new string[] { "A", "A", "E", "E", "E", "E" }) { Name = "AAEEEE" },
		new LetterDie(new string[] { "A", "A", "F", "I", "R", "S" }) { Name = "AAFIRS" },
		new LetterDie(new string[] { "A", "D", "E", "N", "N", "N" }) { Name = "ADENNN" },
		new LetterDie(new string[] { "A", "E", "E", "E", "E", "M" }) { Name = "AEEEEM" },

		new LetterDie(new string[] { "A", "E", "E", "G", "M", "U" }) { Name = "AEEGMU" },
		new LetterDie(new string[] { "A", "E", "G", "M", "N", "N" }) { Name = "AEGMNN" },
		new LetterDie(new string[] { "A", "F", "I", "R", "S", "Y" }) { Name = "AFIRSY" },
		new LetterDie(new string[] { "B", "J", "K", "Qu", "X", "Z" }) { Name = "BJKQuXZ" },
		new LetterDie(new string[] { "C", "C", "E", "N", "S", "T" }) { Name = "CCENST" },

		new LetterDie(new string[] { "C", "E", "I", "I", "L", "T" }) { Name = "CEIILT" },
		new LetterDie(new string[] { "C", "E", "I", "L", "P", "T" }) { Name = "CEILPT" },
		new LetterDie(new string[] { "C", "E", "I", "P", "S", "T" }) { Name = "CEIPST" },
		new LetterDie(new string[] { "D", "D", "H", "N", "O", "T" }) { Name = "DDHNOT" },
		new LetterDie(new string[] { "D", "H", "H", "L", "O", "R" }) { Name = "DHHLOR" },

		new LetterDie(new string[] { "D", "H", "H", "L", "O", "R" }) { Name = "DHHLOR2" },
		new LetterDie(new string[] { "D", "H", "L", "N", "O", "R" }) { Name = "DHLNOR" },
		new LetterDie(new string[] { "E", "I", "I", "I", "T", "T" }) { Name = "EIIITT" },
		new LetterDie(new string[] { "E", "M", "O", "T", "T", "T" }) { Name = "EMOTTT" },
		new LetterDie(new string[] { "E", "N", "S", "S", "S", "U" }) { Name = "ENSSSU" },

		new LetterDie(new string[] { "F", "I", "P", "R", "S", "Y" }) { Name = "FIPRSY" },
		new LetterDie(new string[] { "G", "O", "R", "R", "V", "W" }) { Name = "GORRVW" },
		new LetterDie(new string[] { "I", "P", "R", "R", "R", "Y" }) { Name = "IPRRRY" },
		new LetterDie(new string[] { "N", "O", "O", "T", "U", "W" }) { Name = "NOOTUW" },
		new LetterDie(new string[] { "O", "O", "O", "T", "T", "U" }) { Name = "OOOTTU" }
	};

	private static readonly List<LetterDie> s_Dice_BigBoggleDeluxe = new()
	{
		new LetterDie(new string[] { "A", "A", "A", "F", "R", "S" }) { Name = "AAAFRS" },
		new LetterDie(new string[] { "A", "A", "E", "E", "E", "E" }) { Name = "AAEEEE" },
		new LetterDie(new string[] { "A", "A", "F", "I", "R", "S" }) { Name = "AAFIRS" },
		new LetterDie(new string[] { "A", "D", "E", "N", "N", "N" }) { Name = "ADENNN" },
		new LetterDie(new string[] { "A", "E", "E", "E", "E", "M" }) { Name = "AEEEEM" },

		new LetterDie(new string[] { "A", "E", "E", "G", "M", "U" }) { Name = "AEEGMU" },
		new LetterDie(new string[] { "A", "E", "G", "M", "N", "N" }) { Name = "AEGMNN" },
		new LetterDie(new string[] { "A", "F", "I", "R", "S", "Y" }) { Name = "AFIRSY" },
		new LetterDie(new string[] { "B", "J", "K", "Qu", "X", "Z" }) { Name = "BJKQuXZ" },
		new LetterDie(new string[] { "C", "C", "N", "S", "T", "W" }) { Name = "CCNSTW" },

		new LetterDie(new string[] { "C", "E", "I", "I", "L", "T" }) { Name = "CEIILT" },
		new LetterDie(new string[] { "C", "E", "I", "L", "P", "T" }) { Name = "CEILPT" },
		new LetterDie(new string[] { "C", "E", "I", "P", "S", "T" }) { Name = "CEIPST" },
		new LetterDie(new string[] { "D", "H", "H", "N", "O", "T" }) { Name = "DHHNOT" },
		new LetterDie(new string[] { "D", "H", "H", "L", "O", "R" }) { Name = "DHHLOR" },

		new LetterDie(new string[] { "D", "H", "L", "N", "O", "R" }) { Name = "DHLNOR" },
		new LetterDie(new string[] { "D", "D", "L", "N", "O", "R" }) { Name = "DDLNOR" },
		new LetterDie(new string[] { "E", "I", "I", "I", "T", "T" }) { Name = "EIIITT" },
		new LetterDie(new string[] { "E", "M", "O", "T", "T", "T" }) { Name = "EMOTTT" },
		new LetterDie(new string[] { "E", "N", "S", "S", "S", "U" }) { Name = "ENSSSU" },

		new LetterDie(new string[] { "F", "I", "P", "R", "S", "Y" }) { Name = "FIPRSY" },
		new LetterDie(new string[] { "G", "O", "R", "R", "V", "W" }) { Name = "GORRVW" },
		new LetterDie(new string[] { "H", "I", "P", "R", "R", "Y" }) { Name = "HIPRRY" },
		new LetterDie(new string[] { "N", "O", "O", "T", "U", "W" }) { Name = "NOOTUW" },
		new LetterDie(new string[] { "O", "O", "O", "T", "T", "U" }) { Name = "OOOTTU" }
	};

	private static readonly List<LetterDie> s_Dice_SuperBigBoggle2012 = new()
	{
		new LetterDie(new string[] { "A", "A", "A", "F", "R", "S" }) { Name = "AAAFRS" },
		new LetterDie(new string[] { "A", "A", "E", "E", "E", "E" }) { Name = "AAEEEE" },
		new LetterDie(new string[] { "A", "A", "E", "E", "O", "O" }) { Name = "AAEEOO" },
		new LetterDie(new string[] { "A", "A", "F", "I", "R", "S" }) { Name = "AAFIRS" },
		new LetterDie(new string[] { "A", "B", "D", "E", "I", "O" }) { Name = "ABDEIO" },
		new LetterDie(new string[] { "A", "D", "E", "N", "N", "N" }) { Name = "ADENNN" },

		new LetterDie(new string[] { "A", "E", "E", "E", "E", "M" }) { Name = "AEEEEM" },
		new LetterDie(new string[] { "A", "E", "E", "G", "M", "U" }) { Name = "AEEGMU" },
		new LetterDie(new string[] { "A", "E", "G", "M", "N", "N" }) { Name = "AEGMNN" },
		new LetterDie(new string[] { "A", "E", "I", "L", "M", "N" }) { Name = "AEILMN" },
		new LetterDie(new string[] { "A", "E", "I", "N", "O", "U" }) { Name = "AEINOU" },
		new LetterDie(new string[] { "A", "F", "I", "R", "S", "Y" }) { Name = "AFIRSY" },

		new LetterDie(new string[] { "An", "Er", "He", "In", "Qu", "Th" }) { Name = "AnErHeInQuTh" },
		new LetterDie(new string[] { "B", "B", "J", "K", "X", "Z" }) { Name = "BBJKXZ" },
		new LetterDie(new string[] { "C", "C", "E", "N", "S", "T" }) { Name = "CCENST" },
		new LetterDie(new string[] { "C", "D", "D", "L", "N", "N" }) { Name = "CDDLNN" },
		new LetterDie(new string[] { "C", "E", "I", "I", "T", "T" }) { Name = "CEIITT" },
		new LetterDie(new string[] { "C", "E", "I", "P", "S", "T" }) { Name = "CEIPST" },

		new LetterDie(new string[] { "C", "F", "G", "N", "U", "Y" }) { Name = "CFGNUY" },
		new LetterDie(new string[] { "D", "D", "H", "N", "O", "T" }) { Name = "DDHNOT" },
		new LetterDie(new string[] { "D", "H", "H", "L", "O", "R" }) { Name = "DHHLOR" },
		new LetterDie(new string[] { "D", "H", "H", "N", "O", "W" }) { Name = "DHHNOW" },
		new LetterDie(new string[] { "D", "H", "L", "N", "O", "R" }) { Name = "DHLNOR" },
		new LetterDie(new string[] { "E", "H", "I", "L", "R", "S" }) { Name = "EHILRS" },

		new LetterDie(new string[] { "E", "I", "I", "L", "S", "T" }) { Name = "EIILST" },
		new LetterDie(new string[] { "E", "I", "L", "P", "S", "T" }) { Name = "EILPST" },
		new LetterDie(new string[] { "E", "I", "O", "#", "#", "#" }) { Name = "EIO###" },
		new LetterDie(new string[] { "E", "M", "T", "T", "T", "O" }) { Name = "EMTTTO" },
		new LetterDie(new string[] { "E", "N", "S", "S", "S", "U" }) { Name = "ENSSSU" },
		new LetterDie(new string[] { "G", "O", "R", "R", "V", "W" }) { Name = "GORRVW" },

		new LetterDie(new string[] { "H", "I", "R", "S", "T", "V" }) { Name = "HIRSTV" },
		new LetterDie(new string[] { "H", "O", "P", "R", "S", "T" }) { Name = "HOPRST" },
		new LetterDie(new string[] { "I", "P", "R", "S", "Y", "Y" }) { Name = "IPRSYY" },
		new LetterDie(new string[] { "J", "K", "Qu", "W", "X", "Z" }) { Name = "JKQuWXZ" },
		new LetterDie(new string[] { "N", "O", "O", "T", "U", "W" }) { Name = "NOOTUW" },
		new LetterDie(new string[] { "O", "O", "O", "T", "T", "U" }) { Name = "OOOTTU" }
	};

	public BoggleDice(BoggleType type = BoggleType.Classic4x4)
	{
		Type = type;

		BoardSize = (int)Math.Sqrt(Type switch
		{
			BoggleType.Classic4x4 => s_Dice_Classic4x4.Count,
			BoggleType.New4x4 => s_Dice_New4x4.Count,
			BoggleType.BigBoggleOriginal => s_Dice_BigBoggleOriginal.Count,
			BoggleType.BigBoggleDeluxe => s_Dice_BigBoggleDeluxe.Count,
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

	public List<PositionedDie> Board { get; private set; } = new();
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
		List<PositionedDie> board = new();

		Board      = new();
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
			bag.Remove(bag[bagIndex]);
			boardIndex++;
		} while (bag.Count > 0);

		return board;
	}

	public (int score, CheckResult reason) CheckAndScoreWord(string word)
	{
		CheckResult reason = CheckResult.Success;
		List<PositionedDie> validSlots = SearchBoard(word);
		int score = 0;
		if (validSlots.Any())
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
		return (Type, word.Length) switch
		{
			(BoggleType.BigBoggleDeluxe or BoggleType.BigBoggleOriginal or BoggleType.BigBoggleChallenge or BoggleType.SuperBigBoggle2012, <= 3) => 0,
			(BoggleType.SuperBigBoggle2012, >= 9) => word.Length * 2,
			(_, 3)    =>  1,
			(_, 4)    =>  1,
			(_, 5)    =>  2,
			(_, 6)    =>  3,
			(_, 7)    =>  5,
			(_, >= 8) => 11,
			(_, _)    =>  0
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
		List<PositionedDie> result = new();
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
		if (current.Die.Display.ToUpperInvariant() != word[index..newIndex])
		{
			return false;
		}

		result.Add(current);
		visited[col, row] = true;
		bool found = SearchBoardDFS(word, newIndex, col - 1, row - 1, visited, result) ||
					 SearchBoardDFS(word, newIndex, col, row - 1, visited, result) ||
					 SearchBoardDFS(word, newIndex, col + 1, row - 1, visited, result) ||
					 SearchBoardDFS(word, newIndex, col - 1, row, visited, result) ||
					 SearchBoardDFS(word, newIndex, col + 1, row, visited, result) ||
					 SearchBoardDFS(word, newIndex, col - 1, row + 1, visited, result) ||
					 SearchBoardDFS(word, newIndex, col, row + 1, visited, result) ||
					 SearchBoardDFS(word, newIndex, col + 1, row + 1, visited, result);
		if (!found)
		{
			result.Remove(current);
		}

		visited[col, row] = false;
		return found;
	}

}
