using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    #region Singleton
    public static GameState Instance { get; private set; }

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

    public float topBallHeight = 0.0f;
    public float ballFloor = -10.0f;
    public GameObject ball;
    public Text scoreText;
    public Text finalScoreText;
    public List<GameObject> gameOverObjects;

    // Use this for initialization
    void Start () {
        ball = GameObject.FindGameObjectWithTag("Ball");
	}
	
	// Update is called once per frame
	void Update () {
        // Touch Input
        for(int i=0; i<Input.touchCount; i++)
        {
            RaycastHit2D rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.touches[i].position), Vector2.zero);
            if (rayHit.collider != null)
            {
                if (rayHit.collider.tag == "GravityShape")
                {
                    if (Input.touches[i].phase == TouchPhase.Began)
                    {
                        GravityShape gravityShape = rayHit.collider.gameObject.GetComponent<GravityShape>();
                        gravityShape.OnTap();
                    }
                }
            }
        }
        //  Update ball info
        if(ball.transform.position.y > topBallHeight)
        {
            topBallHeight = ball.transform.position.y;
            ballFloor = topBallHeight - 40.0f;
            scoreText.text = ((int)((topBallHeight*9.44f/12.0f)+0.5f)).ToString() + " ft";
        } else if(ball.transform.position.y <= ballFloor)
        {
            if (PlayerPrefs.HasKey("highScore"))
            {
                if (PlayerPrefs.GetInt("highScore") < (int)((topBallHeight * 9.44f / 12.0f) + 0.5f))
                {
                    PlayerPrefs.SetInt("highScore", (int)((topBallHeight * 9.44f / 12.0f) + 0.5f));
                }
            }
            else
            {
                PlayerPrefs.SetInt("highScore", (int)((topBallHeight * 9.44f / 12.0f) + 0.5f));
            }
            finalScoreText.text = ((int)((topBallHeight * 9.44f / 12.0f) + 0.5f)).ToString() + " ft";
            MenuManager.Instance.highScore = PlayerPrefs.GetInt("highScore");
            scoreText.gameObject.SetActive(false);
            foreach (GameObject o in gameOverObjects)
            {
                o.SetActive(true);
            }
        }
	}

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
