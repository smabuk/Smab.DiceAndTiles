namespace Smab.DiceAndTiles;
internal sealed class Trie {
	public TrieNode Root { get; set; }

	public Trie() {
		Root = new TrieNode();
	}

	public void Insert(string word) {
		TrieNode current = Root;

		for (int i = 0; i < word.Length; i++) {
			char c = word[i];

			if (!current.Children.TryGetValue(c, out var value)) {
				value = new TrieNode();
				current.Children.Add(c, value);
			}

			current = value;
		}

		current.IsWord = true;
	}

	public bool Search(string word) {
		TrieNode current = Root;

		for (int i = 0; i < word.Length; i++) {
			char c = word[i];

			if (!current.Children.TryGetValue(c, out var value)) {
				return false;
			}

			current = value;
		}

		return current.IsWord;
	}

	internal class TrieNode {
		public Dictionary<char, TrieNode> Children { get; set; } = [];
		public bool IsWord { get; set; }
	}
}

