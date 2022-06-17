using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && HPSystem.Health < 3 && MerchantShop.heartSold == false)
        {
            HPSystem.Health += 1;
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player") && HPSystem.Health < 4 && MerchantShop.heartSold == true)
        {
            HPSystem.Health += 1;
            Destroy(gameObject);
        }
    }
}
