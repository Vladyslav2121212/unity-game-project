using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    public Sprite[] backgrounds;            
    public Image backgroundImage;           
    private int currentIndex = 0;

    public void ChangeBackground()
    {
        currentIndex = (currentIndex + 1) % backgrounds.Length;
        backgroundImage.sprite = backgrounds[currentIndex];
    }
}
