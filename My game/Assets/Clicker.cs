using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public Text scoreText;  
    public int score = 0;  
    public int clickValue = 1; 

    void Start()
    {
        
        if (scoreText == null)
        {
            Debug.LogError("Score Text is not assigned in the Inspector");
        }
    }

    public void OnClick()
    {
        score += clickValue;
        scoreText.text = "Coins: " + score;
    }
}



