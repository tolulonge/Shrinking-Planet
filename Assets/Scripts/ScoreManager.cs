using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public ScoreData sd;

    private void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderBy(x => x.score).Take(10);
    }

    public void AddScore(Score score)
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
        sd.scores.Add(score);
        SaveScore();
    }

    private void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        Debug.Log(json);
        PlayerPrefs.SetString("scores", json);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
