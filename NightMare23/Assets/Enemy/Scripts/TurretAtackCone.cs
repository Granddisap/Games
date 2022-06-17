using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAtackCone : MonoBehaviour
{
    EnemyTurret enemyTurret;

    void Awake()
    {
        enemyTurret = gameObject.GetComponentInParent<EnemyTurret>();
    }

    void Update()
    {
        enemyTurret.bulletTimer += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (enemyTurret.bulletTimer >= enemyTurret.startBulletTimer)
        {
            if (collision.CompareTag("Player"))
            {
                enemyTurret.Attack(true);
                enemyTurret.anim.SetBool("shoot", true);
                enemyTurret.bulletTimer = 0;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemyTurret.anim.SetBool("shoot", false);
        enemyTurret.bulletTimer = 0;
    }
}
