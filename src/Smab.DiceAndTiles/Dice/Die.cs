namespace Smab.DiceAndTiles;

/// <summary>
/// 
/// </summary>
/// <param name="NoOfFaces">The number of faces</param>
/// <param name="Id">A name that must be unique within a set of dice.</param>
public abstract record Die(int NoOfFaces = 6, DieId Id = default) : Entity<DieId>(Id)
{
	public int UpperFaceIndex { get; init; }

	public abstract string Display { get; }
	public abstract Face   UpperFace { get; }
	public abstract int    Value { get; }

	public virtual Die Roll() => this with { UpperFaceIndex = Random.Shared.Next(0, NoOfFaces) };

	public virtual bool HasBlank => Id.ToString().Contains(Face.Blank); // Hack
	public virtual bool IsBlank  => UpperFace.IsBlank;
}
