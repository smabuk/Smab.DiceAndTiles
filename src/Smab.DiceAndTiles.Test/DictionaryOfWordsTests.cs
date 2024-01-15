﻿namespace Smab.DiceAndTiles.Test;

public class DictionaryOfWordsTests
{
	private static readonly string[] _wordsList = ["this", "is", "a", "sample", "word", "list", "of", "words"];
	private static readonly DictionaryOfWords _dictionaryOfWords = new(_wordsList);

	[Theory]
	[InlineData("this")]
	[InlineData("THIS")]
	[InlineData("word")]
	[InlineData("words")]
	public void Is_AWord(string word)
	{
		bool actual = _dictionaryOfWords.IsWord(word);
		Assert.True(actual);
	}

	[Theory]
	[InlineData("")]
	[InlineData("bad")]
	[InlineData("wor")]
	[InlineData("wordier")]
	public void Is_Not_AWord(string word)
	{
		bool actual = _dictionaryOfWords.IsWord(word);
		Assert.False(actual);
	}
}