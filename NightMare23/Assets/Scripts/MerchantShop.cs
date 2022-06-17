using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantShop : MonoBehaviour
{
    public static bool heartSold = false;

    public static bool armorSold = false;

    [SerializeField]
    GameObject armorButton, heartButton, shop;

    [SerializeField] private PlayerDataLoadSave savePlayer;

    [SerializeField]
    private AudioSource buttonSound;

    private void Update()
    {
        if (heartSold == true)
        {
            heartButton.SetActive(false);
        }
        else
        {
            heartButton.SetActive(true);
        }

        if (armorSold == true)
        {
            armorButton.SetActive(false);
        }
        else
        {
            armorButton.SetActive(true);
        }
    }

    public void heartPrice()
    {
        buttonSound.Play();

        if (Inventory.coins >= 2500)
        {
            Inventory.coins -= 2500;
            heartSold = true;
            HPSystem.Health = 4;
            savePlayer.SavePlayer();
        }
    }

    public void armorPrice()
    {
        buttonSound.Play();

        if (Inventory.coins >= 5000 && !armorSold)
        {
            Inventory.coins -= 5000;
            armorSold = true;
            HPSystem.Armor = 1;
            savePlayer.SavePlayer();
        }
    }

    public void ShopButton()
    {
        buttonSound.Play();

        shop.SetActive(true);
    }
}
