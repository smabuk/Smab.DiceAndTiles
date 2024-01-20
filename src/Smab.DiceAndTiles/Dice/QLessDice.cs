namespace Smab.DiceAndTiles;

public class QLessDice
{
	private const int ANY_COL  = int.MinValue;
	private const int RACK_ROW = int.MinValue;

	private Dictionary<string, PositionedDie> diceDictionary = [];
	private readonly DictionaryOfWords dictionaryOfWords;

	private static readonly List<LetterDie> s_letterDice =
	[
		new([ "M", "M", "L", "L", "B", "Y" ]),
		new([ "V", "F", "G", "K", "P", "P" ]),
		new([ "H", "H", "N", "N", "R", "R" ]),
		new([ "D", "F", "R", "L", "L", "W" ]),
		new([ "R", "R", "D", "L", "G", "G" ]),
		new([ "X", "K", "B", "S", "Z", "N" ]),
		new([ "W", "H", "H", "T", "T", "P" ]),
		new([ "C", "C", "B", "T", "J", "D" ]),
		new([ "C", "C", "M", "T", "T", "S" ]),
		new([ "O", "I", "I", "N", "N", "Y" ]),
		new([ "A", "E", "I", "O", "U", "U" ]),
		new([ "A", "A", "E", "E", "O", "O" ]),
	];

	public QLessDice(DictionaryOfWords? dictionary = null)
	{
		ShakeAndFillRack();
		dictionaryOfWords = dictionary ?? new();
	}

	private void ShakeAndFillRack()
	{
		diceDictionary = [];
		LetterDie[] bag = [.. Dice];
		Random.Shared.Shuffle(bag);

		for (int i = 0; i < bag.Length; i++) {
			LetterDie die = bag[i];
			die.Roll();
			diceDictionary.Add(die.Name, new PositionedDie(die, i, RACK_ROW, i));
		}
	}


	public List<LetterDie>     Dice  { get; set; } = new(s_letterDice);

	public List<PositionedDie> Board => [.. diceDictionary.Values.Where(d => d.Row != RACK_ROW)];
	public List<PositionedDie> Rack  => [.. diceDictionary.Values.Where(d => d.Row == RACK_ROW)];

	public Status GameStatus()
	{
		HashSet<PositionedDie> errorDice = [];
		ErrorReasons errorReasons = ErrorReasons.None;
		ScrabbleWordFinder swf = new(Board, dictionaryOfWords);
		List<string> words = swf.FindWords();
		bool notFinished = false;

		if (Board.Count != Dice.Count) {
			errorReasons |= ErrorReasons.MissingDice;
			notFinished = true;
		}

		if (swf.ValidWordsAsTiles.Concat(swf.InvalidWordsAsTiles).Where(t => t.Count == 2).Any()) {
			errorReasons |= ErrorReasons.TwoLetterWords;
			notFinished = true;
			errorDice = [.. errorDice,
				.. swf
				.ValidWordsAsTiles
				.Concat(swf.InvalidWordsAsTiles)
				.Where(t => t.Count == 2)
				.SelectMany(t => t)
				.Distinct()
				.Select(t => new PositionedDie(Board.Where(d => d.Col == t.Col && d.Row == t.Row).Single().Die, t.Col, t.Row))
			];
		}

		if (swf.IsBlockInMoreThanOnePiece()) {
			errorReasons |= ErrorReasons.MultipleBlocks;
			notFinished = true;
			errorDice = [.. errorDice,
				.. swf
				.Islands
				.OrderByDescending(i => i.Count)
				.Skip(1)
				.Where(i => i.Count != 0)
				.SelectMany(t => t)
				.Select(t => new PositionedDie(Board.Where(d => d.Col == t.Col && d.Row == t.Row).Single().Die, t.Col, t.Row))
			];
		}

		if (dictionaryOfWords is not null && dictionaryOfWords.HasWords) {
			if (notFinished is false && swf.InvalidWordsAsTiles.Count == 0) {
				return new Win();
			}

			errorReasons &= ErrorReasons.Spelling;
			foreach (List<PositionedTile> tiles in swf.InvalidWordsAsTiles) {
				tiles.ForEach(t => errorDice.Add(new PositionedDie(Board.Where(d => d.Col == t.Col && d.Row == t.Row).Single().Die, t.Col, t.Row)));
			}
		}
		else if (notFinished is false && errorDice.Count == 0) {
			return new Win();
		}

		return new Errors(errorDice, errorReasons);
	}

	public bool PlaceOnBoard(Die die, int col, int row)
	{
		PositionedDie positionedDie = diceDictionary[die.Name];
		if (Board.Any(d => d.Row == row && d.Col == col)) {
			return false;
		}

		positionedDie = positionedDie with { Col = col, Row = row };
		diceDictionary[die.Name] = positionedDie;
		return true;
	}

	public bool PlaceOnRack(Die die, int col = ANY_COL)
	{
		PositionedDie positionedDie = diceDictionary[die.Name];
		if (col != ANY_COL && Rack.Any(d => d.Col == col)) {
			return false;
		}

		if (col == ANY_COL) {
			col = Enumerable.Range(0, Dice.Count).Except(Rack.Select(d => d.Col)).Min();
		}

		if (Rack.Any(d => d.Row == RACK_ROW && d.Col == col)) {
			return false;
		}

		positionedDie = positionedDie with { Col = col, Row = RACK_ROW };
		diceDictionary[die.Name] = positionedDie;
		return true;
	}

	public abstract record class Status();
	public record Win() : Status;
	public record Errors(IEnumerable<PositionedDie> DiceWithErrors, ErrorReasons ErrorReasons) : Status;

	[Flags]
	public enum ErrorReasons
	{
		None            = 0,
		MultipleBlocks  = 1,
		TwoLetterWords  = 2,
		MissingDice     = 4,
		Spelling        = 8,
	}
}
