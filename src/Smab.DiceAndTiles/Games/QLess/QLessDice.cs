namespace Smab.DiceAndTiles.Games.QLess;

public record class QLessDice(IDictionaryService? DictionaryService = null, ImmutableList<LetterDie> Dice = null!, bool RollDice = true)
{
	internal Dictionary<DieId, PositionedQLessDie> DiceDictionary { get; init; } = ShakeAndFillRack(Dice ?? [.. DefaultDiceSet], RollDice);
	internal readonly IDictionaryService dictionaryOfWords = DictionaryService ?? new DictionaryService();

	public ImmutableList<LetterDie> Dice { get; } = Dice ?? [.. DefaultDiceSet];

	public IReadOnlyList<PositionedDie> Board => [.. DiceDictionary.Values.Where(p => p.Location is Location.Board)];
	public IReadOnlyList<PositionedDie> Rack => [.. DiceDictionary.Values.Where(p => p.Location is Location.Rack)];

	public bool HasDictionary => dictionaryOfWords.HasWords;
}
