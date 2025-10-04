using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;  
    private int score = 0;

    void Start()
    {
        
        scoreText.text = "Poeni: " + score; 
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Poeni: " + score;
    }
}
