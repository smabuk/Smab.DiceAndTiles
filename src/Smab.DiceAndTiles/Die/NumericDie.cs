namespace Smab.DiceAndTiles;

public record NumericDie(int NoOfFaces = 6) : Die(NoOfFaces: NoOfFaces)
{
	public NumericDie(IEnumerable<int> values) : this(values.Count())
		=> Faces = [.. values.Select(i => new NumericFace(i.ToString(), i.ToString(), i))];

	public List<NumericFace> Faces { get; init; }
		= [..Enumerable
			.Range(1, NoOfFaces)
			.Select(i => new NumericFace(i.ToString(), i.ToString(), i ))
		];

	public NumericFace FaceValue => Faces[UpperFace];

#pragma warning disable IDE0052 // Remove unread private members
	// Workaround to validate
	private readonly bool _validate =
		NoOfFaces <= 0
		? throw new ArgumentOutOfRangeException($"{nameof(NoOfFaces)} must be greater than 0")
		: true;
#pragma warning restore IDE0052 // Remove unread private members
}
