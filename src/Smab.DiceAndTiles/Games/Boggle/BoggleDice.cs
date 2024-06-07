namespace Smab.DiceAndTiles.Games.Boggle;

public partial record class BoggleDice(BoggleType Type = BoggleType.Classic4x4, IDictionaryService? DictionaryService = null)
{
	/// <summary>
	/// Unicode character ⯀ (Black Square Centred (U+2BC0))
	/// </summary>
	public const string BlankDisplay = "\u2BC0";

	private readonly IDictionaryService dictionaryOfWords = DictionaryService ?? new DictionaryService();

	public BoggleDice(string type, IDictionaryService? dictionary = null) : this(type.ToBoggleType(), dictionary) { }

	public List<PositionedDie> Board { get; private set; } = ShakeAndCreateBoard(Type);
	public BoggleType Type { get; init; } = Type;
	private List<WordScore> Words { get; set; } = [];
	public IEnumerable<WordScore> WordScores => [.. Words];
	public int Score => Words.Sum(w => w.Score);

	public int BoardSize   { get; } = (int)Math.Sqrt(Type switch
	{
		BoggleType.Classic4x4 => _Dice_Classic4x4.Count,
		BoggleType.New4x4 => _Dice_New4x4.Count,
		BoggleType.BigBoggleOriginal => _Dice_BigBoggleOriginal.Count,
		BoggleType.BigBoggleDeluxe => _Dice_BigBoggleDeluxe.Count,
		BoggleType.SuperBigBoggle2012 => _Dice_SuperBigBoggle2012.Count,
		_ => throw new NotImplementedException(),
	});

	public int BoardHeight => BoardSize;
	public int BoardWidth => BoardSize ;

	public static List<LetterDie> Dice(BoggleType type) => type switch
	{
		BoggleType.Classic4x4         => new(_Dice_Classic4x4),
		BoggleType.New4x4             => new(_Dice_New4x4),
		BoggleType.BigBoggleOriginal  => new(_Dice_BigBoggleOriginal),
		BoggleType.BigBoggleDeluxe    => new(_Dice_BigBoggleDeluxe),
		BoggleType.SuperBigBoggle2012 => new(_Dice_SuperBigBoggle2012),
		_ => throw new NotImplementedException(),
	};

	public bool HasDictionary => dictionaryOfWords.HasWords;

	private static List<PositionedDie> ShakeAndCreateBoard(BoggleType type)
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

	public WordScore PlayWord(string word)
	{
		ScoreReason reason = ScoreReason.Success;
		word = word.ToUpperInvariant();

		List<PositionedDie> validSlots = this.SearchBoard(word);
		int score = 0;
		if (validSlots.Count == 0) {
			reason = ScoreReason.Unplayable;
		} else if (dictionaryOfWords.HasWords) {
			reason = dictionaryOfWords.IsWord(word) ? ScoreReason.Success : ScoreReason.Misspelt;
		}

		if (reason == ScoreReason.Success)
		{
			score = this.ScoreWord(word);
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
}
