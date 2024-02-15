using Smab.DiceAndTiles.Games.Scrabble;

namespace Smab.DiceAndTiles.Test.Games;
public class ScrabbleTests
{
	[Fact]
	public void Check_English_Distribution()
	{
		Scrabble scrabble = new Scrabble();

		scrabble.English_ScrabbleTiles.Count().ShouldBe(100);

		foreach ((ScrabbleTile Tile, int Count) item in Scrabble.English_Distribution)
		{
			scrabble.English_ScrabbleTiles.Where(t => t.Letter == item.Tile.Letter).Count().ShouldBe(item.Count);
			scrabble.English_ScrabbleTiles.Where(t => t.Letter == item.Tile.Letter).First().Score.ShouldBe(item.Tile.Score);
		}

		scrabble.English_ScrabbleTiles.Where(t => t.Letter == "A").Count().ShouldBe(9);
		scrabble.English_ScrabbleTiles.Where(t => t.Letter == "A").First().Score.ShouldBe(1);

		scrabble.English_ScrabbleTiles.Where(t => t.Letter == "Z").Count().ShouldBe(1);
		scrabble.English_ScrabbleTiles.Where(t => t.Letter == "Z").First().Score.ShouldBe(10);

		scrabble.English_ScrabbleTiles.Where(t => t.Letter == "#").Count().ShouldBe(2);
		scrabble.English_ScrabbleTiles.Where(t => t.Letter == "#").First().Score.ShouldBe(0);
	}
}
