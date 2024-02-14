namespace Smab.DiceAndTiles.Games.QLess;

public class QLessDice
{
	private const int ANY_COL  = int.MinValue;

	private Dictionary<DieId, PositionedQLessDie> diceDictionary = [];
	private readonly IDictionaryOfWords dictionaryOfWords;

	private readonly List<LetterDie> diceSet =
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

	public QLessDice(IDictionaryOfWords? dictionary = null)
	{
		Dice = [.. diceSet];
		ShakeAndFillRack();
		dictionaryOfWords = dictionary ?? new DictionaryOfWords();
	}

	public List<LetterDie>     Dice  { get; set; }

	public IReadOnlyList<PositionedDie> Board => [.. diceDictionary.Values.Where(p => p.Location is Location.Board)];
	public IReadOnlyList<PositionedDie> Rack  => [.. diceDictionary.Values.Where(p => p.Location is Location.Rack)];

	public bool HasDictionary => dictionaryOfWords.HasWords;

	private void ShakeAndFillRack()
	{
		diceDictionary = [];
		LetterDie[] bag = [.. Dice];
		Random.Shared.Shuffle(bag);

		for (int i = 0; i < bag.Length; i++)
		{
			LetterDie die = bag[i];
			_ = die.Roll();
			diceDictionary.Add(die.Id, new PositionedQLessDie(die, i));
		}
	}

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

		if (swf.ValidWordsAsTiles.Concat(swf.InvalidWordsAsTiles).Any(t => t.Count == 2)) {
			errorReasons |= ErrorReasons.TwoLetterWords;
			notFinished = true;
			errorDice = [.. errorDice,
				.. swf
				.ValidWordsAsTiles
				.Concat(swf.InvalidWordsAsTiles)
				.Where(t => t.Count == 2)
				.SelectMany(t => t)
				.Distinct()
				.Select(t => Board.SingleDieAt(t.Col, t.Row))
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
				.Select(t => Board.SingleDieAt(t.Col, t.Row))
			];
		}

		if (dictionaryOfWords is not null && dictionaryOfWords.HasWords) {
			if (notFinished is false && swf.InvalidWordsAsTiles.Count == 0) {
				return new Win();
			}

			if (swf.InvalidWordsAsTiles.Count != 0)
			{
				errorReasons |= ErrorReasons.Misspelt;
				foreach (List<PositionedTile> tiles in swf.InvalidWordsAsTiles)
				{
					tiles.ForEach(t => errorDice.Add(Board.SingleDieAt(t.Col, t.Row)));
				}
			}
		}
		else if (notFinished is false && errorDice.Count == 0) {
			return new Win();
		}

		return new Errors(errorDice, errorReasons);
	}

	public bool PlaceOnBoard(Die die, int col, int row) => PlaceOnBoard(die.Id, col, row);
	public bool PlaceOnBoard(DieId name, int col, int row)
	{
		PositionedQLessDie positionedDie = diceDictionary[name];
		if (Board.Any(d => d.Row == row && d.Col == col)) {
			return false;
		}

		positionedDie = positionedDie.PlaceOnBoard(col, row);
		diceDictionary[name] = positionedDie;
		return true;
	}

	public bool PlaceOnRack(Die die, int col = ANY_COL) => PlaceOnRack(die.Id, col);
	public bool PlaceOnRack(DieId dieId, int col = ANY_COL)
	{
		PositionedQLessDie positionedDie = diceDictionary[dieId];
		if (col != ANY_COL && Rack.Any(p => p.Col == col)) {
			return false;
		}

		if (col == ANY_COL) {
			col = Enumerable.Range(0, Dice.Count).Except(Rack.Select(d => d.Col)).Min();
		}

		if (Rack.Any(p => p.Col == col)) {
			return false;
		}

		positionedDie = positionedDie.PlaceOnRack(col);
		diceDictionary[dieId] = positionedDie;
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
		Misspelt        = 8,
	}
}
