using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public int coins;
    public int key;
    public int numberLvl;

    public bool doorOpen;
    public bool hearthSold;
    public bool armorSold;

    public float[] position;

    public int[] doorSaveData;

    public PlayerData(Player player)
    {
        coins = Inventory.coins;
        key = Inventory.key;

        numberLvl = SceneManager.GetActiveScene().buildIndex;

        doorOpen = Door.doorOpen;

        doorSaveData = new int[20];
        for(int i=0; i < doorSaveData.Length; i++)
        {
            doorSaveData[i] = DoorSystem.doorData[i];
        }

        hearthSold = MerchantShop.heartSold;
        armorSold = MerchantShop.armorSold;

        position = new float[3];
        var playerPosition = player.transform.position;
        position[0] = playerPosition.x;
        position[1] = playerPosition.y;
        position[2] = playerPosition.z;
    }
}
