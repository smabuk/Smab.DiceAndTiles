namespace Smab.DiceAndTiles.Games.QLess;

internal record PositionedQLessDie(Die Die, int Col, int Row, Location Location) : PositionedDie(Die, Col, Row)
{
	public PositionedQLessDie(Die Die, int Col) : this(Die, Col, int.MinValue, Location.Rack) { }
	public PositionedQLessDie(Die Die, int Col, int Row) : this(Die, Col, Row, Location.Board) { }

	public PositionedQLessDie PlaceOnBoard(int col, int row) => this with { Col = col, Row = row, Location = Location.Board };
	public PositionedQLessDie PlaceOnRack(int col) => this with { Col = col, Row = int.MinValue, Location = Location.Rack };
}
