namespace Smab.DiceAndTiles;

public record ScrabbleTile(string Letter, int Score) : LetterTile(Letter)
{
	public ScrabbleTile(char letter, int score) : this(letter.ToString(), score) { }
}
