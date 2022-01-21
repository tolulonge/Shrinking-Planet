using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject gameOverUI;

	public ScoreManager scoreManager;

	public float rotation = 0;

	void Awake ()
	{
		instance = this;
	}

	public void EndGame ()
	{
		gameOverUI.SetActive(true);
		scoreManager.AddScore(new Score(Mathf.Round(Planet.Score * 100f) / 100f));
		//scoreManager.AddScore(new Score("Topmost", Planet.Score));
	}



	public void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public float deltaTime;

	void Update()
	{
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		float fps = 1.0f / deltaTime;
		//Debug.Log(Mathf.Ceil(fps).ToString());
	}

	public void CheckPressing()
    {
		Debug.Log("Pressed");
		rotation = -1;
    }

	public void CheckRight()
	{
		Debug.Log("Pressed");
		rotation = 1;
	}

	public void CheckUnPress()
	{
		Debug.Log("UnPressed");
		rotation = 0;
	}

}
