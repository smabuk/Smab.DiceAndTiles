namespace Smab.DiceAndTiles;

public record NumericDie(int NoOfFaces = 6) : Die(NoOfFaces: NoOfFaces > 0 ? NoOfFaces : throw new ArgumentOutOfRangeException(nameof(NoOfFaces)))
{
	public NumericDie(IEnumerable<int> values) : this(values.Count())
		=> Faces = [.. values.Select(i => new NumericFace(i.ToString(), i.ToString(), i))];

	public ImmutableList<NumericFace> Faces { get; init; }
		= [..Enumerable
			.Range(1, NoOfFaces)
			.Select(i => new NumericFace(i.ToString(), i.ToString(), i ))
		];

	public override string Display => UpperFace.Display;
	public override NumericFace UpperFace => Faces[UpperFaceIndex];
	public override int Value => UpperFace.Value;
}
