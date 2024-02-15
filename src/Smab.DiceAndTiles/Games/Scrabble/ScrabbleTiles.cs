namespace Smab.DiceAndTiles.Games.Scrabble;
public partial class Scrabble
{
	public readonly static List<(ScrabbleTile Tile, int Count)> English_Distribution =
	[
		(new('#',  0),  2),
		(new('A',  1),  9),
		(new('B',  3),  2),
		(new('C',  3),  2),
		(new('D',  2),  4),
		(new('E',  1), 12),
		(new('F',  4),  2),
		(new('G',  2),  3),
		(new('H',  4),  2),
		(new('I',  1),  9),
		(new('J',  8),  1),
		(new('K',  5),  1),
		(new('L',  1),  4),
		(new('M',  3),  2),
		(new('N',  1),  6),
		(new('O',  1),  8),
		(new('P',  3),  2),
		(new('Q', 10),  1),
		(new('R',  1),  6),
		(new('S',  1),  4),
		(new('T',  1),  6),
		(new('U',  1),  4),
		(new('V',  4),  2),
		(new('W',  4),  2),
		(new('X',  8),  1),
		(new('Y',  4),  2),
		(new('Z', 10),  1),
	];

	public readonly List<ScrabbleTile> English_ScrabbleTiles =
		[.. English_Distribution
			.Select(dist => Enumerable.Repeat(new ScrabbleTile(dist.Tile.Letter, dist.Tile.Score), dist.Count))
			.SelectMany(tiles => tiles)
		];
}
