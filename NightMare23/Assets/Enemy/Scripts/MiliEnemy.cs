using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiliEnemy : MonoBehaviour
{
    //движение
    float speed;
    public float jumpImp;
    public float angrySpeed = 3f;
    public float chillSpeed = 2f;

    [SerializeField]
    private AudioSource stepSound;
    float stepTimer;
    public float startStepTimer = 2;

    //остановка после получения урона
    private float stopTime;
    public float startStopTime;

    //патрулирование
    public int positionOfPatrol;

    //хп врага
    public int health;

    //Награда за убийство
    public int coinsDrop = 100;

    //визуализация получения урона
    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;

    //перезарядка
    float recharge;
    public float startRecharge;

    public int damage;

    //место патрулирования и границы
    public Transform pointChill;
    public Transform limitRight;
    public Transform limitLeft;

    //напраление
    bool moveingRight = true;

    //позиция игрока и прерывание преследования
    Transform player;
    public float stoppingDistance;
    MiliEnemyAngryDistance miliEnemyAngry;

    //состояния
    [HideInInspector]
    public bool chill = false;
    [HideInInspector]
    public bool angry = false;
    [HideInInspector]
    public bool goback = false;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        miliEnemyAngry = GetComponentInChildren<MiliEnemyAngryDistance>();

        rb = GetComponent<Rigidbody2D>();

        speed = chillSpeed;

        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
    }

    // Update is called once per frame
    void Update()
    {
        recharge += Time.deltaTime;

        if (Vector2.Distance(transform.position, pointChill.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goback = false;
        }
        else
        {
            goback = true;
            angry = false;
        }

        /*if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goback = true;
            angry = false;
        }*/

        //Границы преследования
        if ((transform.position.x >= limitRight.position.x) || (transform.position.x <= limitLeft.position.x))
        {
            angry = false;
        }

        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goback == true)
        {
            GoBack();
        }  

        //затормаживание после получения урона
        if (stopTime <= 0)
        {
            if (chill == true || goback == true)
            {
                speed = chillSpeed;
            }
            else if(angry == true)
            {
                speed = angrySpeed;
            }
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
    }

    void Chill()
    {
        if (transform.position.x > pointChill.position.x + positionOfPatrol)
        {
            transform.localScale = new Vector2(4, 4);
            moveingRight = false;
        } 
        else if (transform.position.x < pointChill.position.x - positionOfPatrol)
        {
            transform.localScale = new Vector2(-4, 4);
            moveingRight = true;
        }

        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        //Поворот в сторону игрока
        if (transform.position.x > player.position.x)
        {
            transform.localScale = new Vector2(4, 4);
        }
        else if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector2(-4, 4);
        }

        speed = angrySpeed;
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointChill.position, speed * Time.deltaTime);

        //Поворот в сторону возврата
        if (transform.position.x > pointChill.position.x)
        {
            transform.localScale = new Vector2(4, 4);
        }
        else if (transform.position.x < pointChill.position.x)
        {
            transform.localScale = new Vector2(-4, 4);
        }

        speed = chillSpeed;
    }

    //Получение урона
    public void TakeDamage(int damage)
    {
        health -= damage;

        stopTime = startStopTime;

        if (health <= 0)
        {
            Inventory.coins += coinsDrop;
            StatisticsShow.coinsCount += coinsDrop;
            gameObject.SetActive(false);
            StopCoroutine("ResetMaterial");
        }
        else
        {
            StartCoroutine("ResetMaterial");
        }
    }

    IEnumerator ResetMaterial()
    {
        spriteRend.material = matBlink;
        yield return new WaitForSeconds(.2f);
        spriteRend.material = matDefault;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (recharge >= startRecharge)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<HPSystem>().Damage(damage);
                recharge = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            rb.velocity = Vector2.up * jumpImp;
        }
    }
}
