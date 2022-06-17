using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TimeUser : MonoBehaviour
{
    [SerializeField] private Text timeInGame;

    private void Awake()
    {
        StartCoroutine(IETime());
    }

    private void Update()
    {
        if (StatisticsShow.timeMin < 10 && StatisticsShow.timeSec < 10)
        {
            timeInGame.text = "0" + StatisticsShow.timeMin.ToString() + ":0" + StatisticsShow.timeSec.ToString();
        }
        else if (StatisticsShow.timeSec < 10)
        {
            timeInGame.text = StatisticsShow.timeMin.ToString() + ":0" + StatisticsShow.timeSec.ToString();
        }
        else if (StatisticsShow.timeMin < 10)
        {
            timeInGame.text = "0" + StatisticsShow.timeMin.ToString() + ":" + StatisticsShow.timeSec.ToString();
        }
        else
        {
            timeInGame.text = StatisticsShow.timeMin.ToString() + ":" + StatisticsShow.timeSec.ToString();
        }
    }

    IEnumerator IETime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            StatisticsShow.timeSec++;

            if(StatisticsShow.timeSec == 60)
            {
                StatisticsShow.timeMin++;
                StatisticsShow.timeSec = 0;
            }
        }
    }
}
