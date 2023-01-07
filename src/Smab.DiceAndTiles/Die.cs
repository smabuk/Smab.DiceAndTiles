namespace Smab.DiceAndTiles;

public class Face
{
	public string Name { get; set; } = string.Empty;
}

public class NumericFace : Face
{
	public string Display { get; set; } = string.Empty;
	public int Value { get; set; } = 0;
}

public class LetterFace : Face
{
	public string Display { get; set; } = string.Empty;
	public string? Value { get; set; }
	public int? NumericValue { get; set; }
}

public class Die : IDie
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
public class NumericDie : Die
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

public class LetterDie : Die
{
	public List<LetterFace> Faces { get; set; } = new List<LetterFace>();
	public LetterFace FaceValue => Faces[UpperFace];
	public int Orientation { get; set; } = 0;

	public LetterDie() : base(6)
	{
	}

	public LetterDie(string[] faces) : base(faces.Length)
	{
		foreach (var f in faces)
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
		foreach (var (face, numericValue) in faces)
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
