using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevDeth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine("elevDeth");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine("elevDeth");
    }

    IEnumerator elevDeth()
    {
        while (true)
        {
            yield return new WaitForSeconds(.3f);
            HPSystem.Health = 0;
        }
    }
}
