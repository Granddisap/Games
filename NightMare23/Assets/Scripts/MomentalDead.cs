using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomentalDead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HPSystem.Health = 0;
        }
    }
}
