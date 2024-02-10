namespace Smab.DiceAndTiles;

public abstract record Face(string Display = "", string Id = "")
{
	public const string Blank = "#";
	public virtual bool IsBlank    => Id is     Blank;
	public virtual bool IsNotBlank => Id is not Blank;
}
