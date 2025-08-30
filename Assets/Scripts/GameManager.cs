using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    public void IncreaseScore()
    {
        score++;
    }
    
    public void Gameover()
    {
        Debug.Log("Game Over! Your score: " + score);
    }
}
