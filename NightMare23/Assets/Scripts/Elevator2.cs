using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator2 : MonoBehaviour
{
    float dirY;
    float speed = 2f;

    public bool moveingUp = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        if (transform.position.y > 0.57f)
        {
            StartCoroutine(Delay());
            moveingUp = false;
        }
        else if (transform.position.y < -17.93f)
        {
            StartCoroutine(Delay());
            moveingUp = true;
        }

        if (moveingUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }

    IEnumerator Delay()
    {
        
        yield return new WaitForSeconds(1.5f);
        
    }
}
