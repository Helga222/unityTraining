using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {

	[Test]
	public void T00PassingTest ()
	{
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01Bowl1 ()
	{
		int[] rolls = {1};
		string rollsString = "1";
		Assert.AreEqual (rollsString,ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T02X ()
	{
		int[] rolls = {10};
		string rollsString = "X ";
		Assert.AreEqual (rollsString,ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T03Bowl19 ()
	{
		int[] rolls = {1,9};
		string rollsString = "1/";
		Assert.AreEqual (rollsString,ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T04Bowl191 ()
	{
		int[] rolls = {1,9,1};
		string rollsString = "1/1";
		Assert.AreEqual (rollsString,ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T05StrikeInLastFrame ()
	{
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,1, 1};
		string rollsString = "111111111111111111X11";

		Assert.AreEqual (rollsString,ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T06Bowl0 ()
	{
		int[] rolls = {0};
		string rollsString = "-";

		Assert.AreEqual (rollsString,ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T07Bowl010 ()
	{
		int[] rolls = {0,10};
		string rollsString = "-/";

		Assert.AreEqual (rollsString,ScoreDisplay.FormatRolls(rolls.ToList()));
	}
}
