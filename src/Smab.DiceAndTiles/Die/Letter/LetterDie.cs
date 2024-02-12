namespace Smab.DiceAndTiles;

public record LetterDie : Die
{
	public LetterDie(IEnumerable<string> faces, DieId? dieId = null)
		: base(faces.Count(), dieId ?? new DieId(string.Join("", faces)))
		=> Faces = [..faces.Select(face => new LetterFace(face, face, face))];

	public LetterDie(IEnumerable<(string face, int numericValue)> faces, DieId? dieId = null)
		: base(NoOfFaces: faces.Count(), Id: dieId ?? new DieId(string.Join("", faces.Select(f => f.face))))
		=> Faces = [..faces.Select(item => new LetterFace(item.face, item.face, item.face, item.numericValue))];

	public List<LetterFace> Faces { get; init; } = [];
	public override string Display => UpperFace.Display;
	public override int Value => UpperFace.NumericValue;

	public override LetterFace UpperFace => Faces[UpperFaceIndex];
	public int Orientation { get; set; } = 0;

}
