using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapX : MonoBehaviour
{
    float time;
    bool moveingSide = true;
    public float speed = 1f;
    public float limitRight;
    public float limitLeft;

    public int damage;

    [SerializeField] private HPSystem hp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > limitRight)
        {
            moveingSide = false;
        }
        else if (transform.position.x < limitLeft)
        {
            moveingSide = true;
        }

        if (moveingSide)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
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