namespace Smab.DiceAndTiles.Games.Boggle;

public partial record class BoggleDice
{
	private static readonly List<LetterDie> _Dice_Classic4x4 =
	[
		new([ "A", "A", "C", "I", "O", "T" ]),
		new([ "A", "B", "I", "L", "T", "Y" ]),
		new([ "A", "B", "J", "M", "O", "Qu" ]),
		new([ "A", "C", "D", "E", "M", "P" ]),

		new([ "A", "C", "E", "L", "R", "S" ]),
		new([ "A", "D", "E", "N", "V", "Z" ]),
		new([ "A", "H", "M", "O", "R", "S" ]),
		new([ "B", "I", "F", "O", "R", "X" ]),

		new([ "D", "E", "N", "O", "S", "W" ]),
		new([ "D", "K", "N", "O", "T", "U" ]),
		new([ "E", "E", "F", "H", "I", "Y" ]),
		new([ "E", "G", "K", "L", "U", "Y" ]),

		new([ "E", "G", "I", "N", "T", "V" ]),
		new([ "E", "H", "I", "N", "P", "S" ]),
		new([ "E", "L", "P", "S", "T", "U" ]),
		new([ "G", "I", "L", "R", "U", "W" ]),
	];

	private static readonly List<LetterDie> _Dice_New4x4 =
	[
		new([ "A", "A", "E", "E", "G", "N" ]),
		new([ "A", "B", "B", "J", "O", "O" ]),
		new([ "A", "C", "H", "O", "P", "S" ]),
		new([ "A", "F", "F", "K", "P", "S" ]),
		new([ "A", "O", "O", "T", "T", "W" ]),
		new([ "C", "I", "M", "O", "T", "U" ]),
		new([ "D", "E", "I", "L", "R", "X" ]),
		new([ "D", "E", "L", "R", "V", "Y" ]),
		new([ "D", "I", "S", "T", "T", "Y" ]),
		new([ "E", "E", "G", "H", "N", "W" ]),
		new([ "E", "E", "I", "N", "S", "U" ]),
		new([ "E", "H", "R", "T", "V", "W" ]),
		new([ "E", "I", "O", "S", "S", "T" ]),
		new([ "E", "L", "R", "T", "T", "Y" ]),
		new([ "H", "I", "M", "N", "U", "Qu" ]),
		new([ "H", "L", "N", "N", "R", "Z" ]),
	];

	private static readonly List<LetterDie> _Dice_BigBoggleOriginal =
	[
		new([ "A", "A", "A", "F", "R", "S" ]),
		new([ "A", "A", "E", "E", "E", "E" ]),
		new([ "A", "A", "F", "I", "R", "S" ]),
		new([ "A", "D", "E", "N", "N", "N" ]),
		new([ "A", "E", "E", "E", "E", "M" ]),

		new([ "A", "E", "E", "G", "M", "U" ]),
		new([ "A", "E", "G", "M", "N", "N" ]),
		new([ "A", "F", "I", "R", "S", "Y" ]),
		new([ "B", "J", "K", "Qu", "X", "Z" ]),
		new([ "C", "C", "E", "N", "S", "T" ]),

		new([ "C", "E", "I", "I", "L", "T" ]) ,
		new([ "C", "E", "I", "L", "P", "T" ]) { },
		new([ "C", "E", "I", "P", "S", "T" ]) ,
		new([ "D", "D", "H", "N", "O", "T" ]) ,
		new([ "D", "H", "H", "L", "O", "R" ], new DieId("DHHLOR1")),

		new([ "D", "H", "H", "L", "O", "R" ], new DieId("DHHLOR2")),
		new([ "D", "H", "L", "N", "O", "R" ]),
		new([ "E", "I", "I", "I", "T", "T" ]),
		new([ "E", "M", "O", "T", "T", "T" ]),
		new([ "E", "N", "S", "S", "S", "U" ]),

		new([ "F", "I", "P", "R", "S", "Y" ]),
		new([ "G", "O", "R", "R", "V", "W" ]),
		new([ "I", "P", "R", "R", "R", "Y" ]),
		new([ "N", "O", "O", "T", "U", "W" ]),
		new([ "O", "O", "O", "T", "T", "U" ]),
	];

	private static readonly List<LetterDie> _Dice_BigBoggleDeluxe =
	[
		new([ "A", "A", "A", "F", "R", "S" ]),
		new([ "A", "A", "E", "E", "E", "E" ]),
		new([ "A", "A", "F", "I", "R", "S" ]),
		new([ "A", "D", "E", "N", "N", "N" ]),
		new([ "A", "E", "E", "E", "E", "M" ]),

		new([ "A", "E", "E", "G", "M", "U" ]),
		new([ "A", "E", "G", "M", "N", "N" ]),
		new([ "A", "F", "I", "R", "S", "Y" ]),
		new([ "B", "J", "K", "Qu", "X", "Z" ]),
		new([ "C", "C", "N", "S", "T", "W" ]),

		new([ "C", "E", "I", "I", "L", "T" ]),
		new([ "C", "E", "I", "L", "P", "T" ]),
		new([ "C", "E", "I", "P", "S", "T" ]),
		new([ "D", "H", "H", "N", "O", "T" ]),
		new([ "D", "H", "H", "L", "O", "R" ]),

		new([ "D", "H", "L", "N", "O", "R" ]),
		new([ "D", "D", "L", "N", "O", "R" ]),
		new([ "E", "I", "I", "I", "T", "T" ]),
		new([ "E", "M", "O", "T", "T", "T" ]),
		new([ "E", "N", "S", "S", "S", "U" ]),

		new([ "F", "I", "P", "R", "S", "Y" ]),
		new([ "G", "O", "R", "R", "V", "W" ]),
		new([ "H", "I", "P", "R", "R", "Y" ]),
		new([ "N", "O", "O", "T", "U", "W" ]),
		new([ "O", "O", "O", "T", "T", "U" ]),
	];

	private static readonly List<LetterDie> _Dice_SuperBigBoggle2012 =
	[
		new([ "A", "A", "A", "F", "R", "S" ]),
		new([ "A", "A", "E", "E", "E", "E" ]),
		new([ "A", "A", "E", "E", "O", "O" ]),
		new([ "A", "A", "F", "I", "R", "S" ]),
		new([ "A", "B", "D", "E", "I", "O" ]),
		new([ "A", "D", "E", "N", "N", "N" ]),

		new([ "A", "E", "E", "E", "E", "M" ]),
		new([ "A", "E", "E", "G", "M", "U" ]),
		new([ "A", "E", "G", "M", "N", "N" ]),
		new([ "A", "E", "I", "L", "M", "N" ]),
		new([ "A", "E", "I", "N", "O", "U" ]),
		new([ "A", "F", "I", "R", "S", "Y" ]),

		new([ "An", "Er", "He", "In", "Qu", "Th" ]),
		new([ "B", "B", "J", "K", "X", "Z" ]),
		new([ "C", "C", "E", "N", "S", "T" ]),
		new([ "C", "D", "D", "L", "N", "N" ]),
		new([ "C", "E", "I", "I", "T", "T" ]),
		new([ "C", "E", "I", "P", "S", "T" ]),

		new([ "C", "F", "G", "N", "U", "Y" ]),
		new([ "D", "D", "H", "N", "O", "T" ]),
		new([ "D", "H", "H", "L", "O", "R" ]),
		new([ "D", "H", "H", "N", "O", "W" ]),
		new([ "D", "H", "L", "N", "O", "R" ]),
		new([ "E", "H", "I", "L", "R", "S" ]),

		new([ "E", "I", "I", "L", "S", "T" ]),
		new([ "E", "I", "L", "P", "S", "T" ]),
		new([ "E", "I", "O", "#", "#", "#" ]),
		new([ "E", "M", "T", "T", "T", "O" ]),
		new([ "E", "N", "S", "S", "S", "U" ]),
		new([ "G", "O", "R", "R", "V", "W" ]),

		new([ "H", "I", "R", "S", "T", "V" ]),
		new([ "H", "O", "P", "R", "S", "T" ]),
		new([ "I", "P", "R", "S", "Y", "Y" ]),
		new([ "J", "K", "Qu", "W", "X", "Z" ]),
		new([ "N", "O", "O", "T", "U", "W" ]),
		new([ "O", "O", "O", "T", "T", "U" ]),
	];

}
