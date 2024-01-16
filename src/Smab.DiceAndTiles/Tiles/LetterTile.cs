namespace Smab.DiceAndTiles;

public record LetterTile(string Letter) : ITile
{
	public LetterTile(char letter) : this(letter.ToString()) { }
}
