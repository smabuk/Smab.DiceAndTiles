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


	public override string Display => UpperFace.Display;
	public override NumericFace UpperFace => Faces[UpperFaceIndex];
	public override int Value => UpperFace.Value;


#pragma warning disable IDE0052 // Remove unread private members
	// Hack to ensure the record goes through validation
	private readonly bool _validate =
		NoOfFaces <= 0
		? throw new ArgumentOutOfRangeException($"{nameof(NoOfFaces)} must be greater than 0")
		: true;
#pragma warning restore IDE0052 // Remove unread private members
}
