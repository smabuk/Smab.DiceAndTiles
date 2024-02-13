namespace Smab.DiceAndTiles.Games.Boggle;

public partial class BoggleDice
{
	public enum ScoreReason
	{
		Success,
		AlreadyPlayed,
		Misspelt,
		TooShort,
		Unplayable,
	}
}
