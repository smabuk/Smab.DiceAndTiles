namespace Smab.DiceAndTiles;

public record LetterFace(string Name, string Display, string? StringValue, int NumericValue = 0) : Face(Name, Display);
