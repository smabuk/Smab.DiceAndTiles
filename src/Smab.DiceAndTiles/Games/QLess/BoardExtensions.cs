namespace Smab.DiceAndTiles.Games.QLess;

internal static class BoardExtensions
{
	public static PositionedQLessDie SingleDieAt(this IReadOnlyList<PositionedDie> board, int col, int row)
		=> new(board.Single(p => p.Col == col && p.Row == row).Die, col, row);
}
