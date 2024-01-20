﻿namespace Smab.DiceAndTiles.Test;

public class QLessDiceTests
{
	[Fact]
	public void Should_Have_12_Dice()
	{
		QLessDice qLessDice = new();
		qLessDice.Board.ShouldBeEmpty();
		qLessDice.Dice.Count.ShouldBe(12);
		qLessDice.Rack.Count.ShouldBe(12);
	}

	[Fact]
	public void Play_A_Game()
	{
		QLessDice qLessDice = new();

		foreach (var die in qLessDice.Dice)
		{
			die.UpperFace = 0;
		}

		qLessDice.Board.ShouldBeEmpty();
		qLessDice.Dice.Count.ShouldBe(12);
		qLessDice.Rack.Count.ShouldBe(12);

		Die die0 = qLessDice.Rack.Single(d => d.Col == 0).Die;
		Die die7 = qLessDice.Rack.Single(d => d.Col == 7).Die;

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

}
