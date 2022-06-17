using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [HideInInspector]
    public bool pressurePlate;

    [HideInInspector]
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != null)
        {
            pressurePlate = true;
            anim.SetBool("plateDown", true);
        }
    }
}
