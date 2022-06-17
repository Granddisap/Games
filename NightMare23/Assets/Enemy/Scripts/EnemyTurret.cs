using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    //Хп турели
    public int health;

    //Награда за убийство
    public int coinsDrop = 150;

    //визуализация получения урона
    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;

    //Хп игрока
    //public HPSystem hpPlayer;

    [HideInInspector]
    public float distance;

    public float wakeRange;

    //Стрельба
    [HideInInspector]
    public float bulletTimer;
    public float startBulletTimer;
    public float bulletSpeed;

    [HideInInspector]
    public bool awake = false;

    public GameObject bullet;
    public Animator anim;
    public Transform shootPointRight;
    Player target;

    [SerializeField]
    private AudioSource shootSound;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        target = FindObjectOfType<Player>();

        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("awake", awake);

        distance = Vector3.Distance(transform.position, target.transform.position);//дистанция до игрока

        if (transform.rotation.y == 0)
        {
            if (target.transform.position.x < transform.position.x)
            {
                awake = false;
            }
            else if (target.transform.position.x > transform.position.x)
            {
                AwakeTurret();
            }
        }
        else
        {
            if (target.transform.position.x > transform.position.x)
            {
                awake = false;
            }
            else if (target.transform.position.x < transform.position.x)
            {
                AwakeTurret();
            }
        }
    }

    void AwakeTurret()//укорачиваем код
    {
        if (distance < wakeRange)
        {
            awake = true;
        }

        if (distance > wakeRange)
        {
            awake = false;
        }
    }

    public void Attack(bool shoot)
    {
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();

        if (shoot)
        {
            shootSound.Play();

            GameObject bulletClone;
            bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }

    //Получение урона
    public void TakeDamage(int damage)
    {
        health -= damage;

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
}
