using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject playButton;
    private int score = 0;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        gameOverScreen.SetActive(false);
        PauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void StartGame()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOverScreen.SetActive(false);
        playButton.SetActive(false);

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
        PauseGame();
    }
}
