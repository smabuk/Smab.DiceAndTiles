namespace Smab.DiceAndTiles;

public interface IBoggleDice
{
	List<LetterDie> Board { get; set; }
	int BoardSize { get; set; }
	List<LetterDie> Dice { get; set; }
	int NoOfDice { get; }
	int NoOfDiceOnBoard { get; }
	BoggleDice.BoggleType Type { get; set; }

	void ShakeAndFillBoard();
}
