using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsDataSaveLoad : MonoBehaviour
{
    [SerializeField] private Text keyCount, coinsCount, damageCount, dieCount, LastLvl, time;

    private void Update()
    {
        keyCount.text = StatisticsShow.keyCount.ToString();
        coinsCount.text = StatisticsShow.coinsCount.ToString();

        damageCount.text = StatisticsShow.damageCount.ToString();
        dieCount.text = StatisticsShow.dieCount.ToString();

        LastLvl.text = StatisticsShow.currentLvl.ToString();

        if (StatisticsShow.timeMin < 10 && StatisticsShow.timeSec < 10)
        {
            time.text = "0" + StatisticsShow.timeMin.ToString() + ":0" + StatisticsShow.timeSec.ToString();
        }
        else if (StatisticsShow.timeSec < 10)
        {
            time.text = StatisticsShow.timeMin.ToString() + ":0" + StatisticsShow.timeSec.ToString();
        }
        else if (StatisticsShow.timeMin < 10)
        {
            time.text = "0" + StatisticsShow.timeMin.ToString() + ":" + StatisticsShow.timeSec.ToString();
        }
        else
        {
            time.text = StatisticsShow.timeMin.ToString() + ":" + StatisticsShow.timeSec.ToString();
        }
    }

    public void SaveStatistics()
    {
        BinarySavingStatistics.SaveStatistics();
    }
    
    public void LoadStatistics()
    {
        StatisticsData data = BinarySavingStatistics.LoadStatistics();

        StatisticsShow.keyCount = data.keyCount;
        StatisticsShow.coinsCount = data.coinsCount;
    }

    public void ConstLoadStatistics()
    {
        StatisticsData data = BinarySavingStatistics.LoadStatistics();

        StatisticsShow.damageCount = data.damageCount;
        StatisticsShow.dieCount = data.dieCount;

        StatisticsShow.currentLvl = data.currentLvl;

        StatisticsShow.timeMin = data.timeMin;
        StatisticsShow.timeSec = data.timeSec;
    }
}
