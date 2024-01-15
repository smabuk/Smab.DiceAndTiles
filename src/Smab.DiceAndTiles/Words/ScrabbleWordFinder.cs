using static Smab.DiceAndTiles.ScrabbleWordFinder;

namespace Smab.DiceAndTiles;

public class ScrabbleWordFinder(IEnumerable<PositionedLetter> board, DictionaryOfWords? dictionary = null)
{
	private readonly List<PositionedLetter> _board = board.ToList();
	private readonly HashSet<string> _visited = [];

	public List<List<PositionedLetter>> Islands      { get; private set; } = [];
	public List<List<PositionedLetter>> InvalidWordsAsTiles { get; private set; } = [];
	public List<List<PositionedLetter>> ValidWordsAsTiles   { get; private set; } = [];

	public bool IsBlockInMoreThanOnePiece()
	{
		HashSet<(int Col, int Row)> visited = [];
		List<PositionedLetter> island = [];

		int noOfIslands = 0;
		foreach (var tile in _board)
		{
			if (visited.Contains((tile.Col, tile.Row)))
			{
				continue;
			}

			noOfIslands++;
			island = [];
			VisitAdjacent(tile.Col, tile.Row);
			Islands.Add(island);
		}

		return noOfIslands != 1;

		void VisitAdjacent(int col, int row)
		{
			if (row < 0 || col < 0)
			{
				return;
			}

			PositionedLetter? tile = _board.SingleOrDefault(t => t.Col == col && t.Row == row);
			if (visited.Contains((col, row)) || tile is null)
			{
				return;
			}

			_ = visited.Add((col, row));
			island.Add(tile);

			VisitAdjacent(col - 1, row);
			VisitAdjacent(col + 1, row);
			VisitAdjacent(col,     row + 1);
			VisitAdjacent(col,     row - 1);
		}
	}

	public List<string> FindWords() {
		List<string> foundWords = [];
		ValidWordsAsTiles = [];
		InvalidWordsAsTiles = [];

		foreach (PositionedLetter currentTile in _board) {
			_ = _visited.Add(GetKey(currentTile.Col, currentTile.Row));
			List<PositionedLetter> currentWord = [currentTile];
			if (IsStartOfWord(currentTile, Direction.Horizontal)) {
				FindWords(currentTile, currentWord, foundWords, Direction.Horizontal);
			}
			if (IsStartOfWord(currentTile, Direction.Vertical)) {
				FindWords(currentTile, currentWord, foundWords, Direction.Vertical);
			}
			_ = _visited.Remove(GetKey(currentTile.Col, currentTile.Row));
		}
		return foundWords;
	}

	private void FindWords(PositionedLetter currentTile, List<PositionedLetter> currentWord, List<string> foundWords, Direction direction) {
		string currentWordString = CreateWord(currentWord);
		if (currentWordString.Length > 1 && IsEndOfWord(currentTile, direction)) {

			if (dictionary is not null) {
				if (dictionary.IsWord(currentWordString)) {
					foundWords.Add(currentWordString);
					ValidWordsAsTiles.Add(new(currentWord));
				} else {
					InvalidWordsAsTiles.Add(new(currentWord));
				}
			} else {
				foundWords.Add(currentWordString);
				ValidWordsAsTiles.Add(new(currentWord));
			}
		}

		List<PositionedLetter> neighbours = GetNeighbours(currentTile, direction);
		for (int i = 0; i < neighbours.Count; i++) {
			var nextTile = neighbours[i];
			if (!currentWord.Contains(nextTile)) {
				currentWord.Add(nextTile);
				FindWords(nextTile, currentWord, foundWords, direction);
				currentWord.RemoveAt(currentWord.Count - 1);
			}
		}
	}

	private static string GetKey(int col, int row) => $"{col}-{row}";

	private static string CreateWord(List<PositionedLetter> tiles) => string.Join("", tiles.Select(t => t.Letter));

	private List<PositionedLetter> GetNeighbours(PositionedLetter tile, Direction direction) {
		List<PositionedLetter> neighbours = [];

		for (int i = 0; i < _board.Count; i++) {
			var nextTile = _board[i];
			if (IsAdjacentAndInLine(tile, nextTile, direction)) {
				neighbours.Add(nextTile);
			}
		}
		return neighbours;
	}

	private static bool IsAdjacentAndInLine(PositionedLetter tile1, PositionedLetter tile2, Direction direction) {
		return direction switch {
			Direction.Vertical   => tile1.Col == tile2.Col && (tile1.Row == tile2.Row - 1 || tile1.Row == tile2.Row + 1),
			Direction.Horizontal => tile1.Row == tile2.Row && (tile1.Col == tile2.Col - 1 || tile1.Col == tile2.Col + 1),
			_ => throw new NotImplementedException()
		};
	}


	private bool IsEndOfWord(PositionedLetter currentTile, Direction direction) {
		return direction switch {
			Direction.Horizontal => !_board.Any(x => x.Col == currentTile.Col + 1 && x.Row == currentTile.Row),
			Direction.Vertical   => !_board.Any(x => x.Row == currentTile.Row + 1 && x.Col == currentTile.Col),
			_ => throw new NotImplementedException(),
		};
	}

	private bool IsStartOfWord(PositionedLetter currentTile, Direction direction) {
		return direction switch {
			Direction.Horizontal => !_board.Any(x => x.Col == currentTile.Col - 1 && x.Row == currentTile.Row),
			Direction.Vertical   => !_board.Any(x => x.Row == currentTile.Row - 1 && x.Col == currentTile.Col),
			_ => throw new NotImplementedException(),
		};
	}

	private enum Direction
	{
		Horizontal,
		Vertical
	}

	public record PositionedLetter(char Letter, int Col, int Row);
}
