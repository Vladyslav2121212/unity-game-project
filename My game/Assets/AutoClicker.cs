using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AutoClicker : MonoBehaviour
{
    public Button autoClickerButton;
    public Button clickButton;
    public Text scoreText;

    private bool isAutoClicking = false;

    void Start()
    {
        autoClickerButton.onClick.AddListener(ActivateAutoClicker);
        autoClickerButton.interactable = false;
    }

    void Update()
    {
        int currentScore = ExtractScore(scoreText.text);
        if (currentScore >= 20 && !isAutoClicking)
        {
            autoClickerButton.interactable = true;
        }
    }

    void ActivateAutoClicker()
    {
        if (!isAutoClicking)
        {
            isAutoClicking = true;
            autoClickerButton.interactable = false;
            StartCoroutine(AutoClick());
        }
    }

    IEnumerator AutoClick()
    {
        while (true)
        {
            clickButton.onClick.Invoke();
            yield return new WaitForSeconds(1f); // 1 раз в секунду
        }
    }

    int ExtractScore(string rawText)
    {
        string digitsOnly = new string(rawText.Where(char.IsDigit).ToArray());

        if (int.TryParse(digitsOnly, out int result))
            return result;
        else
            return 0;
    }
}


