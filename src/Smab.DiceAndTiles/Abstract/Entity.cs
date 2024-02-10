namespace Smab.DiceAndTiles.Abstract;
public abstract record Entity<TId> where TId : IEquatable<TId>
{
	public TId Id { get; private set; }
	protected Entity(TId id) => Id = id;

	public static IEqualityComparer<Entity<TId>> IdEqualityComparer =>
		EqualityComparer<Entity<TId>>.Create((x, y) =>
		x is null ? y is null
		: y is not null && x.GetType() == y.GetType() && x.Id.Equals(y.Id));
}
