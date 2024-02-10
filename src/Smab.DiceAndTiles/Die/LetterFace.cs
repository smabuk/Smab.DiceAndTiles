namespace Smab.DiceAndTiles;

public record LetterFace(string Id, string Display, string? StringValue, int NumericValue = 0) : Face(Id, Display)
{
	public override bool IsBlank    => StringValue is     Blank;
	public override bool IsNotBlank => StringValue is not Blank;
}
