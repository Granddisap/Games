using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem
{
    public static int[] doorData = new int[20];

    public DoorSystem(DoorIndex doorIndex)
    {

        for(int i=0; i<doorData.Length; i++)
        {
            doorData[i] = doorIndex.openDoor;
        }
    }
}
