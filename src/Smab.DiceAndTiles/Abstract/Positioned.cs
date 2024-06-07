namespace Smab.DiceAndTiles.Abstract;

public record Positioned<T>(T Item, Position Position) where T : class;
