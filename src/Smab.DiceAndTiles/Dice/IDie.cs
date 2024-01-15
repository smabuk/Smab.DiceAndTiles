namespace Smab.DiceAndTiles;

public interface IDie
{
	int NoOfFaces { get; }
	void Roll();
}

public interface IDie<T> : IDie
{
	T FaceValue { get; set; }
}
