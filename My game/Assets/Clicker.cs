using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Clicker : MonoBehaviour
{
    public Text scoreText;
    public Text statsText;
    public int score = 0;
    public int clickValue = 1;

    private int totalClicks = 0;
    private float startTime;

    private Queue<float> clickTimestamps = new Queue<float>();

    void Start()
    {
        if (scoreText == null || statsText == null)
        {
            Debug.LogError("UI елементи не призначено в інспекторі");
            return;
        }

        startTime = Time.time;
        UpdateUI();
    }

    public void OnClick()
    {
        score += clickValue;
        totalClicks++;

        clickTimestamps.Enqueue(Time.time);

        FindObjectOfType<CPSCounter>()?.RegisterClick();

        UpdateUI();
    }

    void UpdateUI()
    {
        while (clickTimestamps.Count > 0 && Time.time - clickTimestamps.Peek() > 1f)
        {
            clickTimestamps.Dequeue();
        }

        float elapsedTime = Time.time - startTime;
        float averageCPS = elapsedTime > 0 ? totalClicks / elapsedTime : 0;
        int currentCPS = clickTimestamps.Count;
        string timePlayed = FormatTime(elapsedTime);

        scoreText.text = "Монети: " + score;

        statsText.text =
            "📊 Статистика:\n" +
            "- Всього кліків: " + totalClicks + "\n" +
            "- Всього монет: " + score + "\n" +
            "- Середній CPS: " + averageCPS.ToString("F2") + "\n" +
            "- Поточний CPS: " + currentCPS + "\n" +
            "- Час у грі: " + timePlayed;
    }

    string FormatTime(float seconds)
    {
        int minutes = (int)(seconds / 60);
        int secs = (int)(seconds % 60);
        return minutes + "хв " + secs + "с";
    }
}






