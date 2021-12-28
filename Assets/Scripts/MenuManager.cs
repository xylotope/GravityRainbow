using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    #region Singleton
    public static MenuManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion Singleton

    public Text highScoreText;
    public int highScore = 0;

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        else
        {
            PlayerPrefs.SetInt("highScore", 0);
        }
        highScoreText.text = "High Score - " + highScore.ToString() + " ft";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
