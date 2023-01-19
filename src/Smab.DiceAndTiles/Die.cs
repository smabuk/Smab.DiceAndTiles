namespace Smab.DiceAndTiles;

public record Face(string Name = "");
public record NumericFace(string Name, string Display, int Value) : Face(Name);
public record LetterFace(string Name, string Display, string? Value, int? NumericValue = null) : Face(Name);

public record Die(string Name = "", int NoOfFaces = 6) : IDie
{
	protected Random Rnd { get; set; } = new ();
	public int UpperFace { get; set; }

	public virtual void Roll() => UpperFace = Rnd.Next(0, NoOfFaces);

	public virtual string Display => this switch
	{
		NumericDie die => die.FaceValue.Display,
		LetterDie  die => die.FaceValue.Display,
		_ => "",
	};

}

public record NumericDie(int NoOfFaces = 6) : Die(NoOfFaces: NoOfFaces)
{
	// Workaround to validate
	private readonly bool _validate = 
		NoOfFaces <= 0
		? throw new ArgumentOutOfRangeException($"{nameof(NoOfFaces)} must be greater than 0") 
		: true;

	public List<NumericFace> Faces { get; set; } = Enumerable
		.Range(1, NoOfFaces)
		.Select(i => new NumericFace($"{i}", $"{i}", i ))
		.ToList();

	public NumericFace FaceValue => Faces[UpperFace];
}

public record LetterDie : Die
{
	public LetterDie(string[] faces) : base(NoOfFaces: faces.Length)
		=> Faces = faces.Select(face => new LetterFace(face, face, face)).ToList();

	public LetterDie((string face, int numericValue)[] faces) : base(NoOfFaces: faces.Length)
		=> Faces = faces.Select(item => new LetterFace(item.face, item.face, item.face, item.numericValue)).ToList();

	public List<LetterFace> Faces { get; set; } = new();
	public LetterFace FaceValue => Faces[UpperFace];
	public int Orientation { get; set; } = 0;
}

public record PositionedDie(Die Die, int Col, int Row, int? Index = null);
