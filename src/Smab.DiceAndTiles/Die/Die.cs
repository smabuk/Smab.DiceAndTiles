namespace Smab.DiceAndTiles;

/// <summary>
/// 
/// </summary>
/// <param name="Name">A name that must be unique within a set of dice.</param>
/// <param name="NoOfFaces">The number of faces</param>
public abstract record Die(string Name = "", int NoOfFaces = 6)
{
	public int UpperFaceIndex { get; set; }

	public abstract string Display { get; }
	public abstract Face   UpperFace { get; }
	public abstract int    Value { get; }

	public virtual void Roll() => UpperFaceIndex = Random.Shared.Next(0, NoOfFaces);
}
