using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public Clicker clicker;
    public int upgradeCost = 50;
    public int upgradeValue = 1;

    public AudioClip upgradeSound;
    private AudioSource audioSource; 

    void Start()
    {
        if (clicker == null)
        {
            Debug.LogError("Clicker script is not assigned in the Inspector");
        }

        audioSource = GetComponent<AudioSource>(); 
        if (upgradeSound == null)
        {
            Debug.LogWarning("Upgrade sound is not assigned in the Inspector");
        }
    }

    public void BuyUpgrade()
    {
        if (clicker.score >= upgradeCost)
        {
            clicker.score -= upgradeCost;
            clicker.clickValue += upgradeValue;
            clicker.scoreText.text = "Coins: " + clicker.score;
            if (upgradeSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(upgradeSound);
            }
        }
        else
        {
            Debug.Log("Not enough coins for upgrade");
        }
    }
}


