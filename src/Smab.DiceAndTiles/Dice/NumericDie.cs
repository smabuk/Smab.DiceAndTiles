namespace Smab.DiceAndTiles;

public record NumericDie(int NoOfFaces = 6) : Die(NoOfFaces: NoOfFaces)
{
#pragma warning disable IDE0052 // Remove unread private members
	// Workaround to validate
	private readonly bool _validate =
		NoOfFaces <= 0
		? throw new ArgumentOutOfRangeException($"{nameof(NoOfFaces)} must be greater than 0")
		: true;
#pragma warning restore IDE0052 // Remove unread private members

	public List<NumericFace> Faces { get; set; } = Enumerable
		.Range(1, NoOfFaces)
		.Select(i => new NumericFace($"{i}", $"{i}", i ))
		.ToList();

	public NumericFace FaceValue => Faces[UpperFace];
}
