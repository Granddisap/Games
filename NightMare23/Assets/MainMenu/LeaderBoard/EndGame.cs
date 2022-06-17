using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject addScore, player;
    [SerializeField] private InputField inputField;
    [SerializeField] private LeaderBoard leaderBoard;
    [SerializeField] private float x;

    private int score = 0;

    public void Yes()
    {
        Time.timeScale = 1;

        //награждаем за полученный урон
        if(StatisticsShow.damageCount > 124 && StatisticsShow.damageCount < 151)
        {
            score += 1000;
        }
        else if(StatisticsShow.damageCount > 99 && StatisticsShow.damageCount < 125)
        {
            score += 2000;
        }
        else if (StatisticsShow.damageCount > 74 && StatisticsShow.damageCount < 100)
        {
            score += 3000;
        }
        else if (StatisticsShow.damageCount > 49 && StatisticsShow.damageCount < 75)
        {
            score += 5000;
        }
        else if (StatisticsShow.damageCount > 24 && StatisticsShow.damageCount < 50)
        {
            score += 8000;
        }
        else if (StatisticsShow.damageCount > 5 && StatisticsShow.damageCount < 25)
        {
            score += 12000;
        }
        else if (StatisticsShow.damageCount > 2 && StatisticsShow.damageCount < 6)
        {
            score += 20000;
        }
        else if (StatisticsShow.damageCount > 0 && StatisticsShow.damageCount < 3)
        {
            score += 30000;
        }
        else if (StatisticsShow.damageCount == 0)
        {
            score += 42000;
        }
        else
        {
            score += 0;
        }


        //награждаем за смерти
        if(StatisticsShow.dieCount > 30 && StatisticsShow.dieCount < 41)
        {
            score += 1000;
        }
        else if (StatisticsShow.dieCount > 25 && StatisticsShow.dieCount < 31)
        {
            score += 2000;
        }
        else if (StatisticsShow.dieCount > 20 && StatisticsShow.dieCount < 26)
        {
            score += 3000;
        }
        else if (StatisticsShow.dieCount > 15 && StatisticsShow.dieCount < 21)
        {
            score += 5000;
        }
        else if (StatisticsShow.dieCount > 10 && StatisticsShow.dieCount < 16)
        {
            score += 8000;
        }
        else if (StatisticsShow.dieCount > 5 && StatisticsShow.dieCount < 11)
        {
            score += 12000;
        }
        else if (StatisticsShow.dieCount > 2 && StatisticsShow.dieCount < 6)
        {
            score += 20000;
        }
        else if (StatisticsShow.dieCount > 0 && StatisticsShow.dieCount < 3)
        {
            score += 30000;
        }
        else if (StatisticsShow.dieCount == 0)
        {
            score += 42000;
        }
        else
        {
            score += 0;
        }

        //награждаем за ключи
        if(StatisticsShow.keyCount == 0)
        {
            score += 0;
        }
        else if (StatisticsShow.keyCount > 0 && StatisticsShow.keyCount < 3)
        {
            score += 5000;
        }
        else if (StatisticsShow.keyCount > 2 && StatisticsShow.keyCount < 6)
        {
            score += 8000;
        }
        else if (StatisticsShow.keyCount > 5 && StatisticsShow.keyCount < 10)
        {
            score += 12000;
        }
        else
        {
            score += 18000;
        }

        //награждаем за монеты
        score += StatisticsShow.coinsCount;

        //награждаем за время
        if(StatisticsShow.timeMin < 5)
        {
            score += 42000;
        }
        else if (StatisticsShow.timeMin > 4 && StatisticsShow.timeMin < 10)
        {
            score += 30000;
        }
        else if (StatisticsShow.timeMin > 9 && StatisticsShow.timeMin < 15)
        {
            score += 20000;
        }
        else if (StatisticsShow.timeMin > 14 && StatisticsShow.timeMin < 20)
        {
            score += 12000;
        }
        else if (StatisticsShow.timeMin > 19)
        {
            score += 8000;
        }

        leaderBoard.AddHighscoreEntry(score, inputField.text);

        addScore.SetActive(false);
    }

    public void No()
    {
        Time.timeScale = 1;
        addScore.SetActive(false);
        player.transform.position = new Vector2(player.transform.position.x + x, player.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            addScore.SetActive(true);
        }
    }
}
