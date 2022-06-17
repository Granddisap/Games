using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneData
{
    public string[] objectNamesItem;
    public Hector[] objectPositionsItem;

    public SceneData(Transform parentTransform)
    {
        var childCountItem = parentTransform.childCount;
        objectNamesItem = new string[childCountItem];
        objectPositionsItem = new Hector[childCountItem];

        for (int i = 0; i < parentTransform.childCount; i++)
        {
            Transform currentObject = parentTransform.GetChild(i);

            objectNamesItem[i] = currentObject.name;

            var position = currentObject.position;
            objectPositionsItem[i] = new Hector(position.x, position.y, position.z);
        }
    }

    [System.Serializable]
    public class Hector
    {
        public float x;
        public float y;
        public float z;

        public Hector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
