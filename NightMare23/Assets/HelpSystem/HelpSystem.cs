using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpSystem : MonoBehaviour
{
    [SerializeField] private GameObject textHelp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textHelp.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textHelp.SetActive(false);
        }
    }
}
