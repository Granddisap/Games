using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private PlayerDataLoadSave savePlayer;
    [SerializeField] private SceneDataSaveLoad saveScene;
    [SerializeField] private StatisticsDataSaveLoad saveStatistics;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (Inventory.key > 0)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                door.Open();
                Inventory.key -= 1;

                savePlayer.SavePlayer();
                saveScene.SaveScene();
                saveStatistics.SaveStatistics();

                gameObject.SetActive(false);
            }
        }
    }
}
