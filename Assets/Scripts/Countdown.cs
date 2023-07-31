using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private int timeInSeconds = 600;

    public Text timeText;

    public Slider slider;
    //text thing go here

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("removeSecond", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float minutes = Mathf.Floor(timeInSeconds / 60);
        float seconds = Mathf.RoundToInt(timeInSeconds % 60);

        string minutesStr = "";
        string secondsStr = "";

        if (minutes < 10) {
            minutesStr = "0" + minutes.ToString();
        }
        else {
            minutesStr = minutes.ToString();
        }
        if (seconds < 10) {
            secondsStr = "0" + Mathf.RoundToInt(seconds).ToString();
        }
        else {
            secondsStr = Mathf.RoundToInt(seconds).ToString();
        }
        if (timeInSeconds <= 0) {
            minutesStr = "00";
            secondsStr = "00";
        }

        timeText.text = minutesStr + ":" + secondsStr;

        if (timeInSeconds <= 600) {
            slider.value = ((float)timeInSeconds / 600);
        }
        else {
            slider.value = 1;
        }
    }

    private void removeSecond() {
        timeInSeconds -= 1;
    }

    public void removeTime(int timeRemovedSeconds)
    {
        timeInSeconds -= timeRemovedSeconds;
    }

    public void AddTime(int timeAdded) {
        timeInSeconds += timeAdded;
    }
}
