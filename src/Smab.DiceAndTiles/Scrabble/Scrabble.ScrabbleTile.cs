using System;
using System.Diagnostics;

namespace Smab.DiceAndTiles.Scrabble
{
	[DebuggerDisplay("{Letter} - {NumericValue}")]
	public class ScrabbleTile : LetterTile
	{
		public int NumericValue => Face.NumericValue ?? 0;
		public string Letter => Face.Value ?? throw new NullReferenceException("Every tile must have a letter or a blank associated with it.");

		public ScrabbleTile(string letter, int value) : base(new (string, int)[] { (letter, value) })
		{

		}
	}
}
