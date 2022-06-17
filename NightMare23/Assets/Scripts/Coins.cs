using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    //[SerializeField] private AudioSource coinsSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //coinsSound.Play();
            Inventory.coins += 100;
            Destroy(gameObject);
        }
    }
}
