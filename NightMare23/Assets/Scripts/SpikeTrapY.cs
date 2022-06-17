using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapY : MonoBehaviour
{
    float time;
    bool moveingUP = true;
    public float speed = 1f;
    public float maxY;
    public float minY;
    public int damage;

    public HPSystem hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > maxY)
        {
            moveingUP = false;
        }
        else if (transform.position.y < minY)
        {
            moveingUP = true;
        }

        if (moveingUP)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hp.Damage(damage);
        }
    }
}
