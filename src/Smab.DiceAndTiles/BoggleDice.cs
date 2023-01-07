namespace Smab.DiceAndTiles;

public partial class BoggleDice : IBoggleDice
{
	public List<LetterDie> Dice { get; set; } = new List<LetterDie>();
	public int NoOfDice { get => Dice.Count; }
	public List<LetterDie> Board { get; set; } = new List<LetterDie>();
	public int NoOfDiceOnBoard { get => Board.Count; }
	public int BoardSize { get; set; }

	public BoggleType Type { get; set; } = BoggleType.Classic4x4;

	public BoggleDice(BoggleType type = BoggleType.Classic4x4)
	{
		Type = type;
		switch (type)
		{
			case BoggleType.Classic4x4:
				Init_Classic4x4();
				break;
			case BoggleType.New4x4:
				Init_New4x4();
				break;
			case BoggleType.BigBoggleDeluxe:
				Init_BigBoggleDeluxe();
				break;
			case BoggleType.BigBoggleOriginal:
				Init_BigBoggleOriginal();
				break;
			case BoggleType.SuperBigBoggle2012:
				Init_SuperBigBoggle2012();
				break;
			default:
				break;
		}
		BoardSize = (int)Math.Sqrt(Dice.Count);
	}

	public void ShakeAndFillBoard()
	{
		List<LetterDie> bag = new List<LetterDie>(Dice);

		Board = new List<LetterDie>();
		Random rnd = new Random();

		foreach (var die in bag)
		{
			die.Roll();
			die.Orientation = rnd.Next(0, 4) * 90;
			if (die.FaceValue.Name == "#")
			{
				die.FaceValue.Display = "■";
			}
		}
		do
		{
			int i = rnd.Next(0, bag.Count);
			Board.Add(bag[i]);
			bag.Remove(bag[i]);
		} while (bag.Count > 0);

		BoardSize = (int)Math.Sqrt(Board.Count);
	}

	private void Init_Classic4x4()
	{
		Dice.Add(new LetterDie(new string[] { "A", "A", "C", "I", "O", "T" }) { Name = "AACIOT" });
		Dice.Add(new LetterDie(new string[] { "A", "B", "I", "L", "T", "Y" }) { Name = "ABILTY" });
		Dice.Add(new LetterDie(new string[] { "A", "B", "J", "M", "O", "Qu" }) { Name = "ABJMOQu" });
		Dice.Add(new LetterDie(new string[] { "A", "C", "D", "E", "M", "P" }) { Name = "ACDEMP" });

		Dice.Add(new LetterDie(new string[] { "A", "C", "E", "L", "R", "S" }) { Name = "ACELRS" });
		Dice.Add(new LetterDie(new string[] { "A", "D", "E", "N", "V", "Z" }) { Name = "ADENVZ" });
		Dice.Add(new LetterDie(new string[] { "A", "H", "M", "O", "R", "S" }) { Name = "AHMORS" });
		Dice.Add(new LetterDie(new string[] { "B", "I", "F", "O", "R", "X" }) { Name = "BIFORX" });

		Dice.Add(new LetterDie(new string[] { "D", "E", "N", "O", "S", "W" }) { Name = "DENOSW" });
		Dice.Add(new LetterDie(new string[] { "D", "K", "N", "O", "T", "U" }) { Name = "DKNOTU" });
		Dice.Add(new LetterDie(new string[] { "E", "E", "F", "H", "I", "Y" }) { Name = "EEFHIY" });
		Dice.Add(new LetterDie(new string[] { "E", "G", "K", "L", "U", "Y" }) { Name = "EGKLUY" });

		Dice.Add(new LetterDie(new string[] { "E", "G", "I", "N", "T", "V" }) { Name = "EGINTV" });
		Dice.Add(new LetterDie(new string[] { "E", "H", "I", "N", "P", "S" }) { Name = "EHINPS" });
		Dice.Add(new LetterDie(new string[] { "E", "L", "P", "S", "T", "U" }) { Name = "ELPSTU" });
		Dice.Add(new LetterDie(new string[] { "G", "I", "L", "R", "U", "W" }) { Name = "GILRUW" });
	}

	private void Init_New4x4()
	{
		Dice.Add(new LetterDie(new string[] { "A", "A", "E", "E", "G", "N" }) { Name = "AAEEGN" });
		Dice.Add(new LetterDie(new string[] { "A", "B", "B", "J", "O", "O" }) { Name = "ABBJOO" });
		Dice.Add(new LetterDie(new string[] { "A", "C", "H", "O", "P", "S" }) { Name = "ACHOPS" });
		Dice.Add(new LetterDie(new string[] { "A", "F", "F", "K", "P", "S" }) { Name = "AFFKPS" });
		Dice.Add(new LetterDie(new string[] { "A", "O", "O", "T", "T", "W" }) { Name = "AOOTTW" });
		Dice.Add(new LetterDie(new string[] { "C", "I", "M", "O", "T", "U" }) { Name = "CIMOTU" });
		Dice.Add(new LetterDie(new string[] { "D", "E", "I", "L", "R", "X" }) { Name = "DEILRX" });
		Dice.Add(new LetterDie(new string[] { "D", "E", "L", "R", "V", "Y" }) { Name = "DELRVY" });
		Dice.Add(new LetterDie(new string[] { "D", "I", "S", "T", "T", "Y" }) { Name = "DISTTY" });
		Dice.Add(new LetterDie(new string[] { "E", "E", "G", "H", "N", "W" }) { Name = "EEGHNW" });
		Dice.Add(new LetterDie(new string[] { "E", "E", "I", "N", "S", "U" }) { Name = "EEINSU" });
		Dice.Add(new LetterDie(new string[] { "E", "H", "R", "T", "V", "W" }) { Name = "EHRTVW" });
		Dice.Add(new LetterDie(new string[] { "E", "I", "O", "S", "S", "T" }) { Name = "EIOSST" });
		Dice.Add(new LetterDie(new string[] { "E", "L", "R", "T", "T", "Y" }) { Name = "ELRTTY" });
		Dice.Add(new LetterDie(new string[] { "H", "I", "M", "N", "U", "Qu" }) { Name = "HIMNUQu" });
		Dice.Add(new LetterDie(new string[] { "H", "L", "N", "N", "R", "Z" }) { Name = "HLNNRZ" });
	}

	private void Init_BigBoggleOriginal()
	{
		Dice.Add(new LetterDie(new string[] { "A", "A", "A", "F", "R", "S" }) { Name = "AAAFRS" });
		Dice.Add(new LetterDie(new string[] { "A", "A", "E", "E", "E", "E" }) { Name = "AAEEEE" });
		Dice.Add(new LetterDie(new string[] { "A", "A", "F", "I", "R", "S" }) { Name = "AAFIRS" });
		Dice.Add(new LetterDie(new string[] { "A", "D", "E", "N", "N", "N" }) { Name = "ADENNN" });
		Dice.Add(new LetterDie(new string[] { "A", "E", "E", "E", "E", "M" }) { Name = "AEEEEM" });

		Dice.Add(new LetterDie(new string[] { "A", "E", "E", "G", "M", "U" }) { Name = "AEEGMU" });
		Dice.Add(new LetterDie(new string[] { "A", "E", "G", "M", "N", "N" }) { Name = "AEGMNN" });
		Dice.Add(new LetterDie(new string[] { "A", "F", "I", "R", "S", "Y" }) { Name = "AFIRSY" });
		Dice.Add(new LetterDie(new string[] { "B", "J", "K", "Qu", "X", "Z" }) { Name = "BJKQuXZ" });
		Dice.Add(new LetterDie(new string[] { "C", "C", "E", "N", "S", "T" }) { Name = "CCENST" });

		Dice.Add(new LetterDie(new string[] { "C", "E", "I", "I", "L", "T" }) { Name = "CEIILT" });
		Dice.Add(new LetterDie(new string[] { "C", "E", "I", "L", "P", "T" }) { Name = "CEILPT" });
		Dice.Add(new LetterDie(new string[] { "C", "E", "I", "P", "S", "T" }) { Name = "CEIPST" });
		Dice.Add(new LetterDie(new string[] { "D", "D", "H", "N", "O", "T" }) { Name = "DDHNOT" });
		Dice.Add(new LetterDie(new string[] { "D", "H", "H", "L", "O", "R" }) { Name = "DHHLOR" });

		Dice.Add(new LetterDie(new string[] { "D", "H", "H", "L", "O", "R" }) { Name = "DHHLOR2" });
		Dice.Add(new LetterDie(new string[] { "D", "H", "L", "N", "O", "R" }) { Name = "DHLNOR" });
		Dice.Add(new LetterDie(new string[] { "E", "I", "I", "I", "T", "T" }) { Name = "EIIITT" });
		Dice.Add(new LetterDie(new string[] { "E", "M", "O", "T", "T", "T" }) { Name = "EMOTTT" });
		Dice.Add(new LetterDie(new string[] { "E", "N", "S", "S", "S", "U" }) { Name = "ENSSSU" });

		Dice.Add(new LetterDie(new string[] { "F", "I", "P", "R", "S", "Y" }) { Name = "FIPRSY" });
		Dice.Add(new LetterDie(new string[] { "G", "O", "R", "R", "V", "W" }) { Name = "GORRVW" });
		Dice.Add(new LetterDie(new string[] { "I", "P", "R", "R", "R", "Y" }) { Name = "IPRRRY" });
		Dice.Add(new LetterDie(new string[] { "N", "O", "O", "T", "U", "W" }) { Name = "NOOTUW" });
		Dice.Add(new LetterDie(new string[] { "O", "O", "O", "T", "T", "U" }) { Name = "OOOTTU" });
	}

	private void Init_BigBoggleDeluxe()
	{
		Dice.Add(new LetterDie(new string[] { "A", "A", "A", "F", "R", "S" }) { Name = "AAAFRS" });
		Dice.Add(new LetterDie(new string[] { "A", "A", "E", "E", "E", "E" }) { Name = "AAEEEE" });
		Dice.Add(new LetterDie(new string[] { "A", "A", "F", "I", "R", "S" }) { Name = "AAFIRS" });
		Dice.Add(new LetterDie(new string[] { "A", "D", "E", "N", "N", "N" }) { Name = "ADENNN" });
		Dice.Add(new LetterDie(new string[] { "A", "E", "E", "E", "E", "M" }) { Name = "AEEEEM" });

		Dice.Add(new LetterDie(new string[] { "A", "E", "E", "G", "M", "U" }) { Name = "AEEGMU" });
		Dice.Add(new LetterDie(new string[] { "A", "E", "G", "M", "N", "N" }) { Name = "AEGMNN" });
		Dice.Add(new LetterDie(new string[] { "A", "F", "I", "R", "S", "Y" }) { Name = "AFIRSY" });
		Dice.Add(new LetterDie(new string[] { "B", "J", "K", "Qu", "X", "Z" }) { Name = "BJKQuXZ" });
		Dice.Add(new LetterDie(new string[] { "C", "C", "N", "S", "T", "W" }) { Name = "CCNSTW" });

		Dice.Add(new LetterDie(new string[] { "C", "E", "I", "I", "L", "T" }) { Name = "CEIILT" });
		Dice.Add(new LetterDie(new string[] { "C", "E", "I", "L", "P", "T" }) { Name = "CEILPT" });
		Dice.Add(new LetterDie(new string[] { "C", "E", "I", "P", "S", "T" }) { Name = "CEIPST" });
		Dice.Add(new LetterDie(new string[] { "D", "H", "H", "N", "O", "T" }) { Name = "DHHNOT" });
		Dice.Add(new LetterDie(new string[] { "D", "H", "H", "L", "O", "R" }) { Name = "DHHLOR" });

		Dice.Add(new LetterDie(new string[] { "D", "H", "L", "N", "O", "R" }) { Name = "DHLNOR" });
		Dice.Add(new LetterDie(new string[] { "D", "D", "L", "N", "O", "R" }) { Name = "DDLNOR" });
		Dice.Add(new LetterDie(new string[] { "E", "I", "I", "I", "T", "T" }) { Name = "EIIITT" });
		Dice.Add(new LetterDie(new string[] { "E", "M", "O", "T", "T", "T" }) { Name = "EMOTTT" });
		Dice.Add(new LetterDie(new string[] { "E", "N", "S", "S", "S", "U" }) { Name = "ENSSSU" });

		Dice.Add(new LetterDie(new string[] { "F", "I", "P", "R", "S", "Y" }) { Name = "FIPRSY" });
		Dice.Add(new LetterDie(new string[] { "G", "O", "R", "R", "V", "W" }) { Name = "GORRVW" });
		Dice.Add(new LetterDie(new string[] { "H", "I", "P", "R", "R", "Y" }) { Name = "HIPRRY" });
		Dice.Add(new LetterDie(new string[] { "N", "O", "O", "T", "U", "W" }) { Name = "NOOTUW" });
		Dice.Add(new LetterDie(new string[] { "O", "O", "O", "T", "T", "U" }) { Name = "OOOTTU" });
	}

	private void Init_SuperBigBoggle2012()
	{
		Dice.Add(new LetterDie(new string[] { "A", "A", "A", "F", "R", "S" }) { Name = "AAAFRS" });
		Dice.Add(new LetterDie(new string[] { "A", "A", "E", "E", "E", "E" }) { Name = "AAEEEE" });
		Dice.Add(new LetterDie(new string[] { "A", "A", "E", "E", "O", "O" }) { Name = "AAEEOO" });
		Dice.Add(new LetterDie(new string[] { "A", "A", "F", "I", "R", "S" }) { Name = "AAFIRS" });
		Dice.Add(new LetterDie(new string[] { "A", "B", "D", "E", "I", "O" }) { Name = "ABDEIO" });
		Dice.Add(new LetterDie(new string[] { "A", "D", "E", "N", "N", "N" }) { Name = "ADENNN" });

		Dice.Add(new LetterDie(new string[] { "A", "E", "E", "E", "E", "M" }) { Name = "AEEEEM" });
		Dice.Add(new LetterDie(new string[] { "A", "E", "E", "G", "M", "U" }) { Name = "AEEGMU" });
		Dice.Add(new LetterDie(new string[] { "A", "E", "G", "M", "N", "N" }) { Name = "AEGMNN" });
		Dice.Add(new LetterDie(new string[] { "A", "E", "I", "L", "M", "N" }) { Name = "AEILMN" });
		Dice.Add(new LetterDie(new string[] { "A", "E", "I", "N", "O", "U" }) { Name = "AEINOU" });
		Dice.Add(new LetterDie(new string[] { "A", "F", "I", "R", "S", "Y" }) { Name = "AFIRSY" });

		Dice.Add(new LetterDie(new string[] { "An", "Er", "He", "In", "Qu", "Th" }) { Name = "AnErHeInQuTh" });
		Dice.Add(new LetterDie(new string[] { "B", "B", "J", "K", "X", "Z" }) { Name = "BBJKXZ" });
		Dice.Add(new LetterDie(new string[] { "C", "C", "E", "N", "S", "T" }) { Name = "CCENST" });
		Dice.Add(new LetterDie(new string[] { "C", "D", "D", "L", "N", "N" }) { Name = "CDDLNN" });
		Dice.Add(new LetterDie(new string[] { "C", "E", "I", "I", "T", "T" }) { Name = "CEIITT" });
		Dice.Add(new LetterDie(new string[] { "C", "E", "I", "P", "S", "T" }) { Name = "CEIPST" });

		Dice.Add(new LetterDie(new string[] { "C", "F", "G", "N", "U", "Y" }) { Name = "CFGNUY" });
		Dice.Add(new LetterDie(new string[] { "D", "D", "H", "N", "O", "T" }) { Name = "DDHNOT" });
		Dice.Add(new LetterDie(new string[] { "D", "H", "H", "L", "O", "R" }) { Name = "DHHLOR" });
		Dice.Add(new LetterDie(new string[] { "D", "H", "H", "N", "O", "W" }) { Name = "DHHNOW" });
		Dice.Add(new LetterDie(new string[] { "D", "H", "L", "N", "O", "R" }) { Name = "DHLNOR" });
		Dice.Add(new LetterDie(new string[] { "E", "H", "I", "L", "R", "S" }) { Name = "EHILRS" });

		Dice.Add(new LetterDie(new string[] { "E", "I", "I", "L", "S", "T" }) { Name = "EIILST" });
		Dice.Add(new LetterDie(new string[] { "E", "I", "L", "P", "S", "T" }) { Name = "EILPST" });
		Dice.Add(new LetterDie(new string[] { "E", "I", "O", "#", "#", "#" }) { Name = "EIO###" });
		Dice.Add(new LetterDie(new string[] { "E", "M", "T", "T", "T", "O" }) { Name = "EMTTTO" });
		Dice.Add(new LetterDie(new string[] { "E", "N", "S", "S", "S", "U" }) { Name = "ENSSSU" });
		Dice.Add(new LetterDie(new string[] { "G", "O", "R", "R", "V", "W" }) { Name = "GORRVW" });

		Dice.Add(new LetterDie(new string[] { "H", "I", "R", "S", "T", "V" }) { Name = "HIRSTV" });
		Dice.Add(new LetterDie(new string[] { "H", "O", "P", "R", "S", "T" }) { Name = "HOPRST" });
		Dice.Add(new LetterDie(new string[] { "I", "P", "R", "S", "Y", "Y" }) { Name = "IPRSYY" });
		Dice.Add(new LetterDie(new string[] { "J", "K", "Qu", "W", "X", "Z" }) { Name = "JKQuWXZ" });
		Dice.Add(new LetterDie(new string[] { "N", "O", "O", "T", "U", "W" }) { Name = "NOOTUW" });
		Dice.Add(new LetterDie(new string[] { "O", "O", "O", "T", "T", "U" }) { Name = "OOOTTU" });

	}

}
