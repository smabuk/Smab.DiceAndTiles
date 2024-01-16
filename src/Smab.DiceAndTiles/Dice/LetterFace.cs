namespace Smab.DiceAndTiles;

public record LetterFace(string Name, string Display, string? Value, int? NumericValue = null) : Face(Name);
