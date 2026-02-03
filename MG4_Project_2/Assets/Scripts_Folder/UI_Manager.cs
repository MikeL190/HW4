using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] arrayOfScreens;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Button gameOverButton;

    private int currentScore = 0;
    private int highScore = 0;

    public static UI_Manager Instance { get; private set; }
    public Bird_Controller User_Player { get; private set; }

    public delegate void ButtonDelegate();
    public event ButtonDelegate Button_Event;

    private void Awake()
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

    private void Start()
    {
        User_Player = GameObject.FindWithTag("Player").GetComponent<Bird_Controller>();

        User_Player.Pass_Obstacle_Event += Update_Text;
        User_Player.Collide_Obstacle_Event += Show_Death_Screen;
        Button_Event += Reset_UI;

        gameOverButton.onClick.AddListener(GameOverButton_Clicked);

        Reset_UI();
    }

    private void OnDisable()
    {
        User_Player.Pass_Obstacle_Event -= Update_Text;
        User_Player.Collide_Obstacle_Event -= Show_Death_Screen;
        Button_Event -= Reset_UI;
    }

    public void GameOverButton_Clicked()
    {
        Button_Event?.Invoke();
    }

    public void Update_Text()
    {
        currentScore++;
        scoreText.text = "Score " + currentScore;
        Update_HighScore();
    }

    private void Update_HighScore()
    {
        if(currentScore > highScore)
        {
            highScore = currentScore;
            highScoreText.text = "High Score " + highScore;
        }
    }

    public void Reset_UI()
    {
        currentScore = 0;
        scoreText.text = "Score 0";
        highScoreText.text = "High Score " + highScore;

        Show_Screen("Gameplay");
    }

    public void Show_Death_Screen()
    {
        Show_Screen("GameOver");
    }    

    private void Show_Screen(string paramString)
    {
        int index = -1;

        switch(paramString)
        {
            case "Gameplay":
                index = 0;
                break;

            case "GameOver":
                index = 1;
                break;
        }

        for(int i = 0; i < arrayOfScreens.Length; i++)
        {
            if (i == index)
            {
                arrayOfScreens[i].SetActive(true);
            }
            else
            {
                arrayOfScreens[i].SetActive(false);
            }
        }
    }

}
