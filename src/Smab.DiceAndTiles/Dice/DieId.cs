namespace Smab.DiceAndTiles;
public readonly record struct DieId(string Value)
{
	public static DieId Empty => new(string.Empty);
	public static DieId CreateNew() => new(Guid.NewGuid().ToString());

	public static implicit operator string(DieId dieId) => dieId.ToString();
	public override string ToString() => Value;
}
