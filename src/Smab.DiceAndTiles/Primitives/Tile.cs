using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smab.DiceAndTiles
{
	public class Tile : ITile
	{
		public enum TileShape
		{
			Triangle,
			Square,
			Hexagon
		}

		public string Name { get; set; } = string.Empty;
		public int NoOfFaces { get; set; } = 1;
		public int NoOfEdges { get; set; } = 4;
		public TileShape Shape { get; set; } = TileShape.Square;
		public int Version { get; } = 1;
		public int UpperFace { get; set; }

		public Tile()
		{
		}
		public Tile(int faces)
		{

			NoOfFaces = faces;
		}

		public Tile(TileShape shape)
		{
			Shape = shape;
			NoOfEdges = Shape switch
			{
				TileShape.Triangle => 3,
				TileShape.Square => 4,
				TileShape.Hexagon => 6,
				_ => 4
			};
		}
	}
	public class LetterTile : Tile
	{
		public List<LetterFace> Faces { get; set; } = new List<LetterFace>();
		public LetterFace Face => Faces[UpperFace];
		public int Orientation { get; set; } = 0;

		public LetterTile() : base(1)
		{
		}

		public LetterTile(string[] faces) : base(faces.Length)
		{
			foreach (var f in faces)
			{
				Faces.Add(new LetterFace
				{
					Name = f,
					Display = f,
					Value = f
				});
			}
		}
		public LetterTile((string face, int numericValue)[] faces) : base(faces.Length)
		{
			foreach (var (face, numericValue) in faces)
			{
				Faces.Add(new LetterFace
				{
					Name = face,
					Display = face,
					Value = face,
					NumericValue = numericValue
				});
			}
		}
	}
}
