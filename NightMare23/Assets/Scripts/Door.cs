using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    Collider2D col;

    [SerializeField]
    private AudioSource doorSound;

    [SerializeField]
    GameObject doorTrigger;

    public static bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();

        if (doorOpen == true)
        {
            anim.SetBool("Open", true);
            col.enabled = false;

            doorTrigger.SetActive(false);
        }
        else
        {
            anim.SetBool("Open", false);
            col.enabled = true;

            doorTrigger.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        doorSound.Play();

        doorOpen = true;
        anim.SetBool("Open", true);
        col.enabled = false;
        doorTrigger.SetActive(false);
    }
}
