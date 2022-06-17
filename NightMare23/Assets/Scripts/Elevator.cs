using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float limitUp;
    public float limitBot;

    float speed = 2f;

    [HideInInspector]
    public bool moveingUp = true;

    public PressurePlate presPlate, presPlateAnim;

    public ElevatorTrigger elTrigger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (presPlate.pressurePlate == true)
        {
            if (transform.position.y > limitUp)
            {
                moveingUp = false;
                presPlateAnim.anim.SetBool("plateDown", false);
                presPlate.pressurePlate = false;
            }
            else if (transform.position.y < limitBot)
            {
                moveingUp = true;
                presPlateAnim.anim.SetBool("plateDown", false);
                presPlate.pressurePlate = false;
            }

            if (moveingUp)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
            }
            else if (!moveingUp)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            }
        }
        else if (elTrigger.moveElevator == true)
        {
            if (transform.position.y < limitBot)
            {
                moveingUp = true;
                elTrigger.moveElevator = false;
                presPlate.pressurePlate = true;
            }

            if (!moveingUp)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            }
        }
    }
}
