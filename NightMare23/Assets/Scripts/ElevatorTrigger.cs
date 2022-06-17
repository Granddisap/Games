using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    [HideInInspector]
    public bool moveElevator = false;

    public AudioSource elTriggerSound;

    public Elevator MovUp;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.L) && MovUp.moveingUp == false)
        {
            elTriggerSound.Play();
            moveElevator = true;
        }
    }
}
