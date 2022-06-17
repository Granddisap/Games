using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    [SerializeField] private PlayerDataLoadSave playerLoad;
    [SerializeField] private SceneDataSaveLoad itemLoad;
    [SerializeField] private StatisticsDataSaveLoad statisticsDataSave;
    [SerializeField] private LoadEnemy loadEnemy;

    [SerializeField] private Player player;
    [SerializeField] private Collider2D colPlayer;

    [SerializeField] private float x = -7.3f, y = 4.13f;

    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetInt("Continue") == 1)
        {
            playerLoad.LoadPlayer();

            statisticsDataSave.LoadStatistics();
            statisticsDataSave.ConstLoadStatistics();

            if (PlayerPrefs.GetInt("NextScene") == 1)
            {
                player.transform.position = new Vector2(x, y);

                itemLoad.SaveScene();
                PlayerPrefs.SetInt("NextScene", 0);
            }
            else
            {
                itemLoad.LoadScene();
            }   
        }
        else
        {
            FirstPlayerData();
            FirstStatisticsData();
            PlayerPrefs.SetInt("Continue", 1);
        }

        loadEnemy.LoadEnemyButton();

        colPlayer.GetComponent<Collider2D>().enabled = true;
        player.verticalImpulse = 13;
        player.horizontalSpeed = 5;

        StatisticsShow.currentLvl = SceneManager.GetActiveScene().buildIndex;
    }

    public void FirstPlayerData()
    {
        Inventory.coins = 0;
        Inventory.key = 0;

        Door.doorOpen = false;

        for(int i=0; i<DoorSystem.doorData.Length; i++)
        {
            DoorSystem.doorData[i] = 0;
        }

        MerchantShop.heartSold = false;
        MerchantShop.armorSold = false;

        player.transform.position = new Vector2(-6f, -0.24f);

        playerLoad.SavePlayer();
        itemLoad.SaveScene();
    }

    public void FirstStatisticsData()
    {
        StatisticsShow.keyCount = 0;
        StatisticsShow.coinsCount = 0;

        StatisticsShow.damageCount = 0;
        StatisticsShow.dieCount = 0;

        StatisticsShow.timeMin = 0;
        StatisticsShow.timeSec = 0;

        statisticsDataSave.SaveStatistics();
    }
}
