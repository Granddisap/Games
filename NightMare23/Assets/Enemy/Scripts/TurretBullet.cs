using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger != true)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<HPSystem>().Damage(damage);
            }
            Destroy(gameObject);
        }
    }
}
