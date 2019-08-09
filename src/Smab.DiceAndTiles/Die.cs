﻿using System;
using System.Collections.Generic;

namespace Smab.DiceAndTiles
{
	public class Face
	{
		public string Name { get; set; } = string.Empty;
	}

	public class NumericFace : Face
	{
		public string Display { get; set; } = string.Empty;
		public int? Value { get; set; }
	}

	public class LetterFace : Face
	{
		public string Display { get; set; } = string.Empty;
		public string? Value { get; set; }
	}

	public class Die : IDie
	{
		public string Name { get; set; } = string.Empty;
		public byte NoOfFaces { get; set; } = 6;
		public byte Version { get; } = 1;
		protected Random Rnd { get; set; } = new Random();
		public int UpperFace { get; set; }

		public Die()
		{
		}

		public Die(byte faces)
		{
			NoOfFaces = faces;
		}

		public virtual void Roll()
		{
			UpperFace = Rnd.Next(0, NoOfFaces);
		}
	}
	public class NumericDie : Die
	{
		public List<NumericFace> Faces { get; set; } = new List<NumericFace>();
		public NumericFace FaceValue => Faces[UpperFace];

		public NumericDie() : base(6)
		{
			Initialise();
		}

		public NumericDie(byte faces) : base(faces)
		{
			Initialise();
		}

		private void Initialise()
		{
			for (int i = 1; i < NoOfFaces + 1; i++)
			{
				Faces.Add(new NumericFace
				{
					Name = i.ToString(),
					Display = i.ToString(),
					Value = i
				});
			}
		}
	}

	public class LetterDie : Die
	{
		public List<LetterFace> Faces { get; set; } = new List<LetterFace>();
		public LetterFace FaceValue => Faces[UpperFace];
		public int Orientation { get; set; } = 0;

		public LetterDie(string[] faces) : base((byte)faces.Length)
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
	}

}
