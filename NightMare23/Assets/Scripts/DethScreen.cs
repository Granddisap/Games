using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethScreen : MonoBehaviour
{
    [SerializeField] private GameObject dethScreen, anyKey;

    [SerializeField] private PlayerDataLoadSave playerLoad;
    [SerializeField] private SceneDataSaveLoad itemLoad;
    [SerializeField] private StatisticsDataSaveLoad statisticsLoad;
    [SerializeField] private LoadEnemy loadEnemy;

    [SerializeField] private Collider2D player;
    [SerializeField] private Player playerMove;

    private void Update()
    {
        if (dethScreen.activeSelf)
        {
            StartCoroutine("pressLKey");

            player.GetComponent<Collider2D>().enabled = false;
            playerMove.verticalImpulse = 0;
            playerMove.horizontalSpeed = 0;

            if (Input.GetKeyDown(KeyCode.L))
            {
                player.GetComponent<Collider2D>().enabled = true;
                playerMove.verticalImpulse = 13;
                playerMove.horizontalSpeed = 5;

                playerLoad.LoadPlayer();
                itemLoad.LoadScene();
                statisticsLoad.LoadStatistics();
                loadEnemy.LoadEnemyButton();

                dethScreen.SetActive(false);
                StopCoroutine("pressLKey");
            }
        }
    }

    IEnumerator pressLKey()//задержка появления надписи "prees L"
    {
        yield return new WaitForSeconds(1f);
        anyKey.SetActive(true);
    }
}
