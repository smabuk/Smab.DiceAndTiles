namespace Smab.DiceAndTiles;

public interface IDictionaryOfWords
{
	int Count { get; }
	bool HasWords { get; }

	bool IsWord(string word);
}