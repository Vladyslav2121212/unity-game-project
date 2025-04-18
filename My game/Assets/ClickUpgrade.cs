using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public Clicker clicker; 
    public int upgradeCost = 50; 
    public int upgradeValue = 1; 

    void Start()
    {
        
        if (clicker == null)
        {
            Debug.LogError("Clicker script is not assigned in the Inspector");
        }
    }

    public void BuyUpgrade()
    {
       
        if (clicker.score >= upgradeCost)
        {
            
            clicker.score -= upgradeCost;

            
            clicker.clickValue += upgradeValue;

           
            clicker.scoreText.text = "Coins: " + clicker.score;
        }
        else
        {
            Debug.Log("Not enough coins for upgrade");
        }
    }
}

