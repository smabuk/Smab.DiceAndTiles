namespace Smab.DiceAndTiles;

public record LetterTile(string Letter) : Tile
{
	public LetterTile(char letter) : this(letter.ToString()) { }
}
