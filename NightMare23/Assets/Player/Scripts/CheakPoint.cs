using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheakPoint : MonoBehaviour
{
    [SerializeField] GameObject chekPointAnim;

    [SerializeField] private PlayerDataLoadSave playerSave;
    [SerializeField] private SceneDataSaveLoad itemSave;
    [SerializeField] private StatisticsDataSaveLoad saveStat;

    [SerializeField] private AudioSource superCoinsSound, coinsSound;

    //Изменение места спавна после прохождения чекпоинта
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChekPoint"))
        {
            playerSave.SavePlayer();
            itemSave.SaveScene();
            saveStat.SaveStatistics();
            StartCoroutine("TimerAnim");
        }
        else if (collision.CompareTag("Coins"))
        {
            coinsSound.Play();
            StatisticsShow.coinsCount += 100;
        }
        else if (collision.CompareTag("SuperCoins"))
        {
            superCoinsSound.Play();
            StatisticsShow.coinsCount += 300;
        }
        else if (collision.CompareTag("Key"))
        {
            StatisticsShow.keyCount += 1;
        }
    }

    IEnumerator TimerAnim()
    {
        chekPointAnim.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        chekPointAnim.SetActive(false);
    }
}
