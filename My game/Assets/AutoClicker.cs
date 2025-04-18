using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    public Clicker clicker;  
    public int coinsRequired = 20; 
    public float autoClickInterval = 1f; 
    private bool isAutoClickerActive = false;
    private float lastClickTime = 0f; 

    void Update()
    {
        
        if (clicker.score >= coinsRequired && !isAutoClickerActive)
        {
            ActivateAutoClicker();
        }

        
        if (isAutoClickerActive)
        {
            if (Time.time - lastClickTime >= autoClickInterval)
            {
                AutoClick();
            }
        }
    }

    void ActivateAutoClicker()
    {
       
        isAutoClickerActive = true;
        Debug.Log("Auto Clicker Activated!");
    }

    void AutoClick()
    {
       
        clicker.OnClick();
        lastClickTime = Time.time;  
    }

    
    public void DeactivateAutoClicker()
    {
        isAutoClickerActive = false;
        Debug.Log("Auto Clicker Deactivated!");
    }
}




