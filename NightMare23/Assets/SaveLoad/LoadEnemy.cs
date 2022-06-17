using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEnemy : MonoBehaviour
{
    [SerializeField] private Transform loadEnemyTurret;

    [SerializeField] private Transform loadMiliEnemy;

    public void LoadEnemyButton()
    {
        for (int i = 0; i < loadEnemyTurret.childCount; i++)
        {
            loadEnemyTurret.GetChild(i).gameObject.SetActive(true);
            loadEnemyTurret.GetChild(i).GetComponent<EnemyTurret>().health = 3;
        }

        for (int i = 0; i < loadMiliEnemy.childCount; i++)
        {
            loadMiliEnemy.GetChild(i).gameObject.SetActive(true);
            loadMiliEnemy.GetChild(i).GetComponent<MiliEnemy>().health = 3;
        }
    }
}
