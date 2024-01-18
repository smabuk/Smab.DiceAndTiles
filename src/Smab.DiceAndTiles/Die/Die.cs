namespace Smab.DiceAndTiles;

public record Die(string Name = "", int NoOfFaces = 6)
{
	public int UpperFace { get; set; }

	public virtual string Display => this switch
	{
		NumericDie die => die.FaceValue.Display,
		LetterDie  die => die.FaceValue.Display,
		_ => "",
	};

	public virtual void Roll() => UpperFace = Random.Shared.Next(0, NoOfFaces);
}
