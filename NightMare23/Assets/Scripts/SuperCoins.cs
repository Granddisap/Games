using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCoins : MonoBehaviour
{
    //[SerializeField]
    //AudioSource superCoinsSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //superCoinsSound.Play();
            Inventory.coins += 300;
            Destroy(gameObject);
        }
    }
}
