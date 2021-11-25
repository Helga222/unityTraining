using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {

	public static List<int> ScoreCumulative (List<int> rolls){
		List<int> cumulativeScores = new List<int>();
		int runningTotal = 0;
		foreach (int frameScore in ScoreFrames(rolls)) {
			runningTotal+=frameScore;
			cumulativeScores.Add (runningTotal);
		}
		return cumulativeScores;
	}

	//мое гениальное решение
/*	public static List<int> ScoreFrames (List<int> rolls){
		List<int> frameList = new List<int>();
		int colRolls = rolls.Count; //количество брошенных мячей
		bool bonus = false; //бонус за спэйр
		List<int> rollsArray= rolls.GetRange (0, colRolls);
		for (int i=0; i<rollsArray.Count;i++) {
			if (i % 2 != 0) {
				if (frameList.Count==10) {return frameList;}
				int sumFrame=rollsArray[i]+rollsArray[i-1]; //сумма за фрейм 1 человека (кроме страйка)
				if (bonus==true) {						//расчет суммарных очков после спэйр
					//frameList.Add ((sumFrame-rollsArray[i])+10);
					if (rollsArray[i] == 0 && rollsArray[i-1] == 10) {
						try {frameList.Add (rollsArray[i+1]+rollsArray[i+2]+10);}
						catch {
							return frameList;
						}
					};
					bonus=false; 
				}
				if (sumFrame != 10 ) {					//если НЕ спэйр
					frameList.Add (sumFrame);
				} else if (rollsArray[i] !=0) {
					bonus = true;	
				}
			} 
			else {
				if (frameList.Count==10) {return frameList;} 				
				if (bonus==true) {						//расчет суммарных очков после спэйр
					frameList.Add (rollsArray[i]+10); 
					bonus=false;
				}				
				if (rollsArray[i] == 10) {				//если страйк, то ждем следующие броски
					bonus=true;
					rollsArray.Insert(i+1,0);  // при страйке на место 2 попадания ставим 0 для облегчения расчетов
				}
			}
		}
		return frameList;

	}

*/	//Udemy
	public static List<int> ScoreFrames (List<int> rolls){
		List<int> frames = new List<int>();
		for (int i = 1; i < rolls.Count; i += 2) {
			if (frames.Count == 10) {break;}
			if (rolls [i - 1] + rolls [i] < 10) {
				frames.Add (rolls[i-1]+rolls[i]);
			}

			if (rolls.Count - i <= 1) { break;}

			if (rolls [i - 1] == 10) {
				i--;
				frames.Add (10+rolls[i+1]+rolls[i+2]);				
			}
			else if (rolls [i - 1] + rolls [i] == 10) {
				frames.Add (10+rolls[i+1]);
			}
		}

		return frames;

	}
		
}
