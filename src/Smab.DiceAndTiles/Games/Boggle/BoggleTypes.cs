using static Smab.DiceAndTiles.Games.Boggle.BoggleDice;

namespace Smab.DiceAndTiles.Games.Boggle;

public static class BoggleTypes
{
	public const string BigBoggleOriginal  = "big";
	public const string BigBoggleChallenge = "challenge";
	public const string Classic4x4         = "classic";
	public const string BigBoggleDeluxe    = "deluxe";
	public const string New4x4             = "new";
	public const string SuperBigBoggle2012 = "superbig";

	public static string[] ValidBoggleTypes = [
		BigBoggleOriginal,
		BigBoggleChallenge,
		Classic4x4,
		BigBoggleDeluxe,
		New4x4,
		SuperBigBoggle2012,
		.. Enum.GetValues<BoggleType>().Select(b => b.ToString())
		];

	public static BoggleType ToBoggleType(this string type)
	{
		return type.ToLower() switch
		{
			BigBoggleOriginal  => BoggleType.BigBoggleOriginal,
			BigBoggleChallenge => BoggleType.BigBoggleChallenge,
			Classic4x4         => BoggleType.Classic4x4,
			BigBoggleDeluxe    => BoggleType.BigBoggleDeluxe,
			New4x4             => BoggleType.New4x4,
			SuperBigBoggle2012 => BoggleType.SuperBigBoggle2012,
			_ when Enum.TryParse(type, true, out BoggleType boggleType) => boggleType,
			_ => throw new ArgumentException($"'{type}' is not a valid for shortcut to a {nameof(BoggleType)}", nameof(type)),
		};
	}
}
