using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatisticsData
{
    public int keyCount, coinsCount, damageCount, dieCount, currentLvl, timeMin, timeSec;

    public StatisticsData()
    {
        keyCount = StatisticsShow.keyCount;
        coinsCount = StatisticsShow.coinsCount;

        damageCount = StatisticsShow.damageCount;
        dieCount = StatisticsShow.dieCount;

        currentLvl = StatisticsShow.currentLvl;

        timeMin = StatisticsShow.timeMin;
        timeSec = StatisticsShow.timeSec;
    }
}
