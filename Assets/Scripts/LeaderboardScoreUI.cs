using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderboardScoreUI : MonoBehaviour
{

	public RowUI rowUI;
	public ScoreManager scoreManager;


	void Start()
	{
		//scoreManager.AddScore(new Score("Tolulope", 6));
		

		var scores = scoreManager.GetHighScores().ToArray();
		for (int i = 0; i < scores.Length; i++)
		{
			var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
			row.rank.text = (i + 1).ToString();
			row.score.text = scores[i].score.ToString();
		}
	}

}
