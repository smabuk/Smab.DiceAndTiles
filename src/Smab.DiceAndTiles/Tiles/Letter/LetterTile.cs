namespace Smab.DiceAndTiles;

public record LetterTile(string Letter) : Tile
{
	public const string Blank = "#";
	public LetterTile(char letter) : this(letter.ToString()) { }

	public virtual bool IsBlank    => Letter is     Blank;
	public virtual bool IsNotBlank => Letter is not Blank;
}
