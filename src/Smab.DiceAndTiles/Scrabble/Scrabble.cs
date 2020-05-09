﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smab.DiceAndTiles.Scrabble
{
	public partial class ScrabbleGame : IScrabbleGame
	{

		public List<ScrabbleTile> Tiles { get; set; } = new List<ScrabbleTile>();
		public int NoOfTiles { get => Tiles.Count; }
		public List<ScrabbleTile> Board { get; set; } = new List<ScrabbleTile>();
		public int NoOfTilesOnBoard { get => Board.Count; }
		public int BoardSize { get; set; } = 15 * 15;
		public List<ScrabbleTile> Bag { get; set; } = new List<ScrabbleTile>();

		public ScrabbleType Type { get; set; } = ScrabbleType.English;

		public ScrabbleGame(ScrabbleType type = ScrabbleType.English)
		{
			Type = type;
			switch (type)
			{
				case ScrabbleType.English:
					Init_English();
					break;
				case ScrabbleType.English_SuperScrabble:
					Init_English_SuperScrabble();
					break;
				default:
					break;
			}
		}

		public void ShakeAndFillBag()
		{
			List<ScrabbleTile> bag = new List<ScrabbleTile>(Tiles);

			Bag = new List<ScrabbleTile>();
			Random rnd = new Random();

			foreach (var tile in bag)
			{
				//die.Roll();
				tile.Orientation = rnd.Next(0, 4) * 90;
				if (tile.Face.Name == "#")
				{
					tile.Face.Display = "■";
				}
			}
			do
			{
				int i = rnd.Next(0, bag.Count);
				Bag.Add(bag[i]);
				bag.Remove(bag[i]);
			} while (bag.Count > 0);

		}

		private void Init_English()
		{
			var ScrabbleTileDistribution = new[]
				{
					(Letter: "#", Value:  0, NoOfTiles:  2),
					(Letter: "A", Value:  1, NoOfTiles:  9),
					(Letter: "B", Value:  3, NoOfTiles:  2),
					(Letter: "C", Value:  3, NoOfTiles:  2),
					(Letter: "D", Value:  2, NoOfTiles:  4),
					(Letter: "E", Value:  1, NoOfTiles: 12),
					(Letter: "F", Value:  4, NoOfTiles:  2),
					(Letter: "G", Value:  2, NoOfTiles:  3),
					(Letter: "H", Value:  4, NoOfTiles:  2),
					(Letter: "I", Value:  1, NoOfTiles:  9),
					(Letter: "J", Value:  8, NoOfTiles:  1),
					(Letter: "K", Value:  5, NoOfTiles:  1),
					(Letter: "L", Value:  1, NoOfTiles:  4),
					(Letter: "M", Value:  3, NoOfTiles:  2),
					(Letter: "N", Value:  1, NoOfTiles:  6),
					(Letter: "O", Value:  1, NoOfTiles:  8),
					(Letter: "P", Value:  3, NoOfTiles:  2),
					(Letter: "Q", Value: 10, NoOfTiles:  1),
					(Letter: "R", Value:  1, NoOfTiles:  6),
					(Letter: "S", Value:  1, NoOfTiles:  4),
					(Letter: "T", Value:  1, NoOfTiles:  6),
					(Letter: "U", Value:  1, NoOfTiles:  4),
					(Letter: "V", Value:  4, NoOfTiles:  2),
					(Letter: "W", Value:  4, NoOfTiles:  2),
					(Letter: "X", Value:  8, NoOfTiles:  1),
					(Letter: "Y", Value:  4, NoOfTiles:  2),
					(Letter: "Z", Value: 10 ,NoOfTiles:  1)
				};

			foreach (var distribution in ScrabbleTileDistribution)
			{
				for (int i = 1; i <= distribution.NoOfTiles; i++)
				{
					Tiles.Add(new ScrabbleTile(distribution.Letter, distribution.Value)
					{
						Name = $"{distribution.Letter}{i}"
					});
				}
			}

			BoardSize = 15 * 15;

		}
		private void Init_English_SuperScrabble()
		{
			var ScrabbleTileDistribution = new[]
				{
					(Letter: "#", Value:  0, NoOfTiles:  4),
					(Letter: "A", Value:  1, NoOfTiles: 16),
					(Letter: "B", Value:  3, NoOfTiles:  4),
					(Letter: "C", Value:  3, NoOfTiles:  6),
					(Letter: "D", Value:  2, NoOfTiles:  8),
					(Letter: "E", Value:  1, NoOfTiles: 24),
					(Letter: "F", Value:  4, NoOfTiles:  4),
					(Letter: "G", Value:  2, NoOfTiles:  5),
					(Letter: "H", Value:  4, NoOfTiles:  5),
					(Letter: "I", Value:  1, NoOfTiles: 13),
					(Letter: "J", Value:  8, NoOfTiles:  2),
					(Letter: "K", Value:  5, NoOfTiles:  2),
					(Letter: "L", Value:  1, NoOfTiles:  7),
					(Letter: "M", Value:  3, NoOfTiles:  6),
					(Letter: "N", Value:  1, NoOfTiles: 13),
					(Letter: "O", Value:  1, NoOfTiles: 15),
					(Letter: "P", Value:  3, NoOfTiles:  4),
					(Letter: "Q", Value: 10, NoOfTiles:  2),
					(Letter: "R", Value:  1, NoOfTiles: 13),
					(Letter: "S", Value:  1, NoOfTiles: 10),
					(Letter: "T", Value:  1, NoOfTiles: 15),
					(Letter: "U", Value:  1, NoOfTiles:  7),
					(Letter: "V", Value:  4, NoOfTiles:  3),
					(Letter: "W", Value:  4, NoOfTiles:  4),
					(Letter: "X", Value:  8, NoOfTiles:  2),
					(Letter: "Y", Value:  4, NoOfTiles:  4),
					(Letter: "Z", Value: 10 ,NoOfTiles:  2)
				};

			foreach (var distribution in ScrabbleTileDistribution)
			{
				for (int i = 1; i <= distribution.NoOfTiles; i++)
				{
					Tiles.Add(new ScrabbleTile(distribution.Letter, distribution.Value)
					{
						Name = $"{distribution.Letter}{i}"
					});
				}
			}

			BoardSize = 21 * 21;
		}

	}
}