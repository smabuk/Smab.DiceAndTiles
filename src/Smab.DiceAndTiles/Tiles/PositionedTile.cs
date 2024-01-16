namespace Smab.DiceAndTiles;

public record PositionedTile(ITile Tile, int Col, int Row, int? Index = null);
