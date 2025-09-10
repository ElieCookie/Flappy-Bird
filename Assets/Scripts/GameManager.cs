using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject playButton;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject getReadyScreen;
    private int score = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                PauseGame();
            }
            else if (Time.timeScale == 0f && !gameOverScreen.activeSelf && !getReadyScreen.activeSelf)
            {
                ResumeGame();
            }
        }
    }
    public void Awake()
    {
        Application.targetFrameRate = 60;
        gameOverScreen.SetActive(false);
        resumeButton.SetActive(false);
        pauseButton.SetActive(false);
        InitializeGame();
    }

    public void InitializeGame()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
    }

    public void StartGame()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOverScreen.SetActive(false);
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        getReadyScreen.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    
    public void Gameover()
    {
        gameOverScreen.SetActive(true);
        playButton.SetActive(true);
        pauseButton.SetActive(false);
        resumeButton.SetActive(false);
        getReadyScreen.SetActive(false);
        InitializeGame();
    }
}
