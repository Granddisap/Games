using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataLoadSave : MonoBehaviour
{
    [SerializeField] private Player player;

    public void SavePlayer()
    {
        BinarySavingSystem.SavePlayer(player);
    }

    public void LoadPlayer()
    {
        PlayerData data = BinarySavingSystem.LoadPlayer();

        Inventory.coins = data.coins;
        Inventory.key = data.key;

        Door.doorOpen = data.doorOpen;

        for(int i=0; i<data.doorSaveData.Length; i++)
        {
            DoorSystem.doorData[i] = data.doorSaveData[i];
        }

        MerchantShop.heartSold = data.hearthSold;
        MerchantShop.armorSold = data.armorSold;

        player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
    }
}
