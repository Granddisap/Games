using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDataSaveLoad : MonoBehaviour
{
    [SerializeField]
    private Transform savingItem;

    public void SaveScene()
    {
        BinarySavingSystem.SaveScene(savingItem);
    }

    public void LoadScene()
    {
        for (int i = 0; i < savingItem.childCount; i++)
        {
            Destroy(savingItem.GetChild(i).gameObject);
        }

        SceneData data = BinarySavingSystem.LoadScene();

        for(int i = 0; i < data.objectNamesItem.Length; i++)
        {
            var prefabName = GetPrefabNameItem(data, i);

            GameObject goToSpawn = Resources.Load<GameObject>($"ItemPrefabs/{prefabName}");
            Vector3 spawnPosition = new Vector3(data.objectPositionsItem[i].x, data.objectPositionsItem[i].y, data.objectPositionsItem[i].z);
            GameObject sceneObject = Instantiate(goToSpawn , spawnPosition, Quaternion.identity);

            sceneObject.transform.SetParent(savingItem);
        }
    }

    private static string GetPrefabNameItem(SceneData data, int i)
    {
        string prefabName = "";

        if(data.objectNamesItem[i].IndexOf(" ") > 0)
        {
            int whiteSpaceIndex = data.objectNamesItem[i].IndexOf(" ");
            int length = data.objectNamesItem[i].Length;
            prefabName = data.objectNamesItem[i].Remove(whiteSpaceIndex, data.objectNamesItem[i].Length-whiteSpaceIndex);
        }
        else if (data.objectNamesItem[i].IndexOf("(") > 0)
        {
            int whiteSpaceIndex = data.objectNamesItem[i].IndexOf("(");
            int length = data.objectNamesItem[i].Length;
            prefabName = data.objectNamesItem[i].Remove(whiteSpaceIndex, data.objectNamesItem[i].Length - whiteSpaceIndex);
        }
        else
        {
            prefabName = data.objectNamesItem[i];
        }

        return prefabName;
    }
}
