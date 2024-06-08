namespace Smab.DiceAndTiles.Games.Boggle;

public record class BoggleDice(BoggleType Type = BoggleType.Classic4x4, IDictionaryService? DictionaryService = null)
{
	public BoggleDice(string type, IDictionaryService? dictionary = null) : this(type.ToBoggleType(), dictionary) { }
	
	/// <summary>
	/// Unicode character ⯀ (Black Square Centred (U+2BC0))
	/// </summary>
	public const string BlankDisplay = "\u2BC0";

	internal readonly IDictionaryService dictionaryOfWords = DictionaryService ?? new DictionaryService();
	public BoggleType Type { get; } = Type;

	public ImmutableList<PositionedDie> Board { get; init; } = [.. ShakeAndCreateBoard(Type)];
	public ImmutableList<WordScore> WordScores { get; init; } = [];
	public int Score => WordScores.Sum(w => w.Score);
	public int BoardSize => Type.BoardSize();
	public int BoardHeight => BoardSize;
	public int BoardWidth => BoardSize ;

	public bool HasDictionary => dictionaryOfWords.HasWords;
}
