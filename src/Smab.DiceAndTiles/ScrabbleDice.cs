using System;
using System.Collections.Generic;

namespace Smab.DiceAndTiles
{
	public partial class ScrabbleDice : IScrabbleDice
	{
		public List<LetterDie> Dice { get; set; } = new List<LetterDie>();
		public int NoOfDice { get => Dice.Count; }
		public List<LetterDie> Board { get; set; } = new List<LetterDie>();
		public int NoOfDiceOnBoard { get => Board.Count; }
		public int BoardSize { get; set; }
		public List<LetterDie> Rack { get; set; } = new List<LetterDie>();

		public ScrabbleDice()
		{
			Init_ScrabbleDice();
			BoardSize = 9;
		}

		public void ShakeAndFillRack()
		{
			List<LetterDie> bag = new List<LetterDie>(Dice);

			Rack = new List<LetterDie>();
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
				Rack.Add(bag[i]);
				bag.Remove(bag[i]);
			} while (bag.Count > 0);

		}

		private void Init_ScrabbleDice()
		{
			Dice.Add(new LetterDie(new (string, int)[] { ("A", 1), ("E", 1), ("I", 1), ("O", 1), ("U", 1), ("Y", 4) }) { Name = "AEIOUY1" });
			Dice.Add(new LetterDie(new (string, int)[] { ("A", 1), ("E", 1), ("I", 1), ("O", 1), ("U", 1), ("Y", 4) }) { Name = "AEIOUY2" });
			Dice.Add(new LetterDie(new (string, int)[] { ("A", 1), ("E", 1), ("I", 1), ("L", 1), ("O", 1), ("#", 0) }) { Name = "AEILO#" });
			Dice.Add(new LetterDie(new (string, int)[] { ("B", 3), ("F", 4), ("H", 4), ("N", 1), ("W", 4), ("#", 0) }) { Name = "BFHNW#" });
			Dice.Add(new LetterDie(new (string, int)[] { ("C", 3), ("D", 2), ("G", 2), ("T", 1), ("V", 4), ("#", 0) }) { Name = "CDGTV#" });
			Dice.Add(new LetterDie(new (string, int)[] { ("J", 8), ("K", 5), ("Q", 10), ("X", 8), ("Z", 10), ("#", 0) }) { Name = "JKQXZ#" });
			Dice.Add(new LetterDie(new (string, int)[] { ("M", 3), ("N", 1), ("P", 3), ("R", 1), ("S", 1), ("#", 0) }) { Name = "MNPRS#" });
		}

	}
}
