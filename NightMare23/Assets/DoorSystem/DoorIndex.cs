using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIndex : MonoBehaviour
{
    public int doorIndex;
    [HideInInspector]
    public int openDoor = 0;

    [SerializeField] private Animator anim;
    AudioSource openSound;

    private void Start()
    {
        openSound = GetComponent<AudioSource>();

        for(int i=0; i<DoorSystem.doorData.Length; i++)
        {
            if (i == doorIndex)
            {
                openDoor = DoorSystem.doorData[i];
                break;
            }
        }

        if(openDoor == 1)
        {
            GetComponent<Collider2D>().enabled = false;
            anim.SetBool("Open", true);
        }
        else
        {
            GetComponent<Collider2D>().enabled = true;
            anim.SetBool("Open", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetComponent<Collider2D>().enabled = false;
            anim.SetBool("Open", true);
            openSound.Play();

            openDoor = 1;
            DoorSystem.doorData[doorIndex] = openDoor;
        }
    }
}
