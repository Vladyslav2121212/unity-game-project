using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CPSCounter : MonoBehaviour
{
    public Text cpsText;
    private Queue<float> clickTimes = new Queue<float>();

    void Update()
    {
        float currentTime = Time.time;

        while (clickTimes.Count > 0 && currentTime - clickTimes.Peek() > 1f)
        {
            clickTimes.Dequeue();
        }

        // Обновляем текст CPS
        cpsText.text = "CPS: " + clickTimes.Count;
    }

    public void RegisterClick()
    {
        clickTimes.Enqueue(Time.time);
    }
}


