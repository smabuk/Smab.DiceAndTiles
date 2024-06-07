namespace Smab.DiceAndTiles.Games.Boggle;

public record struct WordScore(string Word, int Score, ScoreReason Reason)
{
	public static implicit operator (string word, int score, ScoreReason reason)(WordScore value)
		=> (value.Word, value.Score, value.Reason);

	public static implicit operator WordScore((string word, int score, ScoreReason reason) value)
		=> new(value.word, value.score, value.reason);
}
