using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTime : MonoBehaviour
{
    public Text PlayTimeText;
    private float playTime;

    private void Start()
    {
        playTime = 0f;
    }

    private void Update()
    {
        playTime += Time.deltaTime;

        int hours = Mathf.FloorToInt(playTime / 3600f);
        int minutes = Mathf.FloorToInt((playTime % 3600f) / 60);
        int seconds = Mathf.FloorToInt(playTime % 60f);

        PlayTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
