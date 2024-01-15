namespace Smab.DiceAndTiles;

public class DictionaryOfWords {
	
	private readonly Trie _trie = new();

	public DictionaryOfWords(string filename) {
		if (!File.Exists(filename)) {
			throw new FileNotFoundException(nameof(filename));
		}
		
		foreach (string word in File.ReadAllLines(filename))
		{
			_trie.Insert(word.ToUpperInvariant());
		}
	}

	public DictionaryOfWords(IEnumerable<string> words) {
		foreach (string word in words)
		{
			_trie.Insert(word.ToUpperInvariant());
		}
	}

	public bool IsWord(string word) => _trie.Search(word.ToUpperInvariant());
}
