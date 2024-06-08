namespace Smab.DiceAndTiles.Games.QLess;

public abstract record class QLessDiceStatus();

public record Win() : QLessDiceStatus;

public record Errors(IEnumerable<PositionedDie> DiceWithErrors, ErrorReasons ErrorReasons) : QLessDiceStatus;

[Flags]
public enum ErrorReasons
{
	None = 0,
	MultipleBlocks = 1,
	TwoLetterWords = 2,
	MissingDice = 4,
	Misspelt = 8,
}
