namespace Smab.DiceAndTiles;

public record Face(string Name = "");

public record NumericFace(string Display = "", int Value = 0) : Face();

public record LetterFace : Face
{
	public string Display { get; set; } = string.Empty;
	public string? Value { get; set; }
	public int? NumericValue { get; set; }
}

public record Die : IDie
{
	public string Name { get; set; } = string.Empty;
	public int NoOfFaces { get; set; } = 6;
	public int Version { get; } = 1;
	protected Random Rnd { get; set; } = new Random();
	public int UpperFace { get; set; }

	public Die()
	{
	}

	public Die(int faces)
	{
		NoOfFaces = faces;
	}

	public virtual void Roll()
	{
		UpperFace = Rnd.Next(0, NoOfFaces);
	}
}
public record NumericDie : Die
{
	public List<NumericFace> Faces { get; set; } = new List<NumericFace>();
	public NumericFace FaceValue => Faces[UpperFace];

	public NumericDie() : base(6)
	{
		Initialise();
	}

	public NumericDie(int faces) : base(faces)
	{
		Initialise();
	}

	private void Initialise()
	{
		if (NoOfFaces <= 0)
		{
			throw new ArgumentOutOfRangeException($"{nameof(NoOfFaces)} must be greater than 0");
		}

		for (int i = 1; i < NoOfFaces + 1; i++)
		{
			Faces.Add(new NumericFace
			{
				Name = i.ToString(),
				Display = i.ToString(),
				Value = i
			});
		}
	}
}

public record LetterDie : Die
{
	public List<LetterFace> Faces { get; set; } = new List<LetterFace>();
	public LetterFace FaceValue => Faces[UpperFace];
	public int Orientation { get; set; } = 0;

	public LetterDie() : base(6)
	{
	}

	public LetterDie(string[] faces) : base(faces.Length)
	{
		foreach (string f in faces)
		{
			Faces.Add(new LetterFace
			{
				Name = f,
				Display = f,
				Value = f
			});
		}
	}
	public LetterDie((string face, int numericValue)[] faces) : base(faces.Length)
	{
		foreach ((string face, int numericValue) in faces)
		{
			Faces.Add(new LetterFace
			{
				Name = face,
				Display = face,
				Value = face,
				NumericValue = numericValue
			});
		}
	}
}
