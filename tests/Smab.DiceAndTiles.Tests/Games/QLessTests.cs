﻿using Smab.DiceAndTiles.Games.QLess;

namespace Smab.DiceAndTiles.Tests.Games;

public class QLessTests
{
	private static readonly string[] _wordsList = ["HAM", "WHAM"];
	private static readonly IDictionaryService _dictionaryOfWords = new DictionaryService(_wordsList);

	[Fact]
	public void Should_Have_12_Dice()
	{
		QLessDice qLessDice = new();
		qLessDice.Board.ShouldBeEmpty();
		qLessDice.Dice.Count.ShouldBe(12);
		qLessDice.Rack.Count.ShouldBe(12);
	}

	[Fact]
	public void Instances_Should_Not_Share_Dice()
	{
		QLessDice qLessDice1 = new();
		string rack1 = string.Join("", qLessDice1.Rack.OrderBy(p => p.Die.Display).Select(x => x.Die.Display));

		QLessDice qLessDice2 = new();
		string rack2 = string.Join("", qLessDice2.Rack.OrderBy(p => p.Die.Display).Select(x => x.Die.Display));

		rack1.ShouldNotBe(rack2);

		rack1 = string.Join("", qLessDice1.Rack.OrderBy(p => p.Die.Display).Select(x => x.Die.Display));
		rack1.ShouldNotBe(rack2);
	}

	[Fact]
	public void Play_A_Game()
	{
		QLessDice qLessDice = new();
		qLessDice.HasDictionary.ShouldBeFalse();

		foreach (LetterDie die in qLessDice.Dice)
		{
			die.UpperFaceIndex = 0;
		}

		qLessDice.Board.ShouldBeEmpty();
		qLessDice.Dice.Count.ShouldBe(12);
		qLessDice.Rack.Count.ShouldBe(12);

		Die die0 = qLessDice.Rack.Single(p => p.Col == 0).Die;
		Die die7 = qLessDice.Rack.Single(p => p.Col == 7).Die;

		qLessDice.PlaceOnBoard(die0, 5, 5).ShouldBeTrue();
		qLessDice.Board.Count.ShouldBe(1);
		qLessDice.Rack.Count.ShouldBe(11);

		qLessDice.PlaceOnBoard(die7, 5, 5).ShouldBeFalse();
		qLessDice.Board.Count.ShouldBe(1);
		qLessDice.Rack.Count.ShouldBe(11);

		qLessDice.PlaceOnBoard(die7, 4, 5).ShouldBeTrue();
		qLessDice.Board.Count.ShouldBe(2);
		qLessDice.Rack.Count.ShouldBe(10);

		QLessDice.Status status = qLessDice.GameStatus();
		((QLessDice.Errors)status).ErrorReasons.ShouldHaveFlag(QLessDice.ErrorReasons.TwoLetterWords);
		((QLessDice.Errors)status).ErrorReasons.ShouldHaveFlag(QLessDice.ErrorReasons.MissingDice);
		((QLessDice.Errors)status).ErrorReasons.ShouldNotHaveFlag(QLessDice.ErrorReasons.MultipleBlocks);

		qLessDice.PlaceOnRack(die7, 4).ShouldBeFalse();
		qLessDice.Board.Count.ShouldBe(2);
		qLessDice.Rack.Count.ShouldBe(10);

		qLessDice.PlaceOnRack(die7).ShouldBeTrue();
		qLessDice.Board.Count.ShouldBe(1);
		qLessDice.Rack.Count.ShouldBe(11);


		int row = 0;
		for (int i = 0; i < qLessDice.Dice.Count; i++)
		{
			row = (row + 2) % 10;
			qLessDice.PlaceOnBoard(qLessDice.Dice[i], i, row).ShouldBeTrue();
		}

		status = qLessDice.GameStatus();
		_ = status.ShouldBeOfType<QLessDice.Errors>();
		((QLessDice.Errors)status).ErrorReasons.ShouldNotHaveFlag(QLessDice.ErrorReasons.TwoLetterWords);
		((QLessDice.Errors)status).ErrorReasons.ShouldNotHaveFlag(QLessDice.ErrorReasons.MissingDice);
		((QLessDice.Errors)status).ErrorReasons.ShouldHaveFlag(QLessDice.ErrorReasons.MultipleBlocks);

		for (int i = 0; i < qLessDice.Dice.Count; i++)
		{
			row = 1;
			qLessDice.PlaceOnBoard(qLessDice.Dice[i], i, row).ShouldBeTrue();
		}

		status = qLessDice.GameStatus();
		_ = status.ShouldBeOfType<QLessDice.Win>();
	}

	[Fact]
	public void Play_A_Game_With_A_Dictionary()
	{
		QLessDice qLessDice = new(_dictionaryOfWords);
		qLessDice.HasDictionary.ShouldBeTrue();

		foreach (LetterDie die in qLessDice.Dice)
		{
			die.UpperFaceIndex = 0;
		}

		Die die0 = qLessDice.Rack.First(p => p.Die.Display == "W").Die;
		Die die1 = qLessDice.Rack.First(p => p.Die.Display == "H").Die;
		Die die2 = qLessDice.Rack.First(p => p.Die.Display == "A").Die;
		Die die3 = qLessDice.Rack.First(p => p.Die.Display == "M").Die;

		qLessDice.PlaceOnBoard(die0, 0, 1).ShouldBeTrue();
		qLessDice.PlaceOnBoard(die1, 1, 1).ShouldBeTrue();
		qLessDice.PlaceOnBoard(die2, 2, 1).ShouldBeTrue();

		QLessDice.Status status = qLessDice.GameStatus();
		_ = status.ShouldBeOfType<QLessDice.Errors>();
		((QLessDice.Errors)status).ErrorReasons.ShouldHaveFlag(QLessDice.ErrorReasons.Misspelt);

		qLessDice.PlaceOnBoard(die3, 3, 1).ShouldBeTrue();
		status = qLessDice.GameStatus();
		_ = status.ShouldBeOfType<QLessDice.Errors>();
		((QLessDice.Errors)status).ErrorReasons.ShouldNotHaveFlag(QLessDice.ErrorReasons.Misspelt);
	}
}
