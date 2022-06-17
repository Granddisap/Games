using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static int key;
    [SerializeField] private Text textKey;

    public static int coins;
    [SerializeField] private Text textCoins;

    // Update is called once per frame
    void Update()
    {
        textKey.text = key.ToString();
        textCoins.text = coins.ToString();
    }
}
