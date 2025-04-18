using UnityEngine;
using UnityEngine.UI; 

public class Clicker : MonoBehaviour
{
    public Text coinText; 
    private int coinCount = 0; 
    public void OnClick()
    {
        coinCount++; 
        coinText.text = "Coins: " + coinCount; 
    }
}

