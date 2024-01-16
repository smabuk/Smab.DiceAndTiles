namespace Smab.DiceAndTiles;

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
