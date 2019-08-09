namespace Smab.DiceAndTiles
{
	public interface IDie
	{
		byte NoOfFaces { get; set; }
		//Random Rnd { get; set; }
		void Roll();

		byte Version { get; }
	}

	public interface IDie<T> : IDie
	{
		T FaceValue { get; set; }
	}

}
