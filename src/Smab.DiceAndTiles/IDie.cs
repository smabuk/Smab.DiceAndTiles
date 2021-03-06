﻿namespace Smab.DiceAndTiles
{
	public interface IDie
	{
		int NoOfFaces { get; set; }
		//Random Rnd { get; set; }
		void Roll();

		int Version { get; }
	}

	public interface IDie<T> : IDie
	{
		T FaceValue { get; set; }
	}

}
