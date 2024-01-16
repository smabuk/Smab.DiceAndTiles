namespace Smab.DiceAndTiles;

public record LetterDie : Die
{
	public LetterDie(string[] faces) : base(NoOfFaces: faces.Length)
		=> Faces = faces.Select(face => new LetterFace(face, face, face)).ToList();

	public LetterDie((string face, int numericValue)[] faces) : base(NoOfFaces: faces.Length)
		=> Faces = faces.Select(item => new LetterFace(item.face, item.face, item.face, item.numericValue)).ToList();

	public List<LetterFace> Faces { get; set; } = [];
	public LetterFace FaceValue => Faces[UpperFace];
	public int Orientation { get; set; } = 0;
}
