namespace Smab.DiceAndTiles;

public interface IScrabbleDice
{
	List<LetterDie> Board { get; set; }
	int BoardSize { get; }
	List<LetterDie> Dice { get; set; }
	int NoOfDice { get; }
	int NoOfDiceOnBoard { get; }

	void ShakeAndFillRack();
}
