using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Передвижение
    public float horizontalSpeed;
    float speedX;
    public float verticalImpulse;

    //атака
    public Transform attackPos;
    public LayerMask miliEnemy;
    public LayerMask turretEnemy;
    public float attackRange;
    public int damage;

    //Проверка направления
    [HideInInspector]
    public bool isFacingRight = true;

    //Проверка на прыжки
    [HideInInspector]
    public bool isGrounded = false;

    bool isAttack = false;

    Animator anim;

    Rigidbody2D rb;

    //Взаимодействие с платформами
    int playerObject, platformObject;
    bool jumpDown;

    [SerializeField]
    private RigidbodyInterpolation2D _type;

    [SerializeField]
    private AudioSource jumpSound;
    [SerializeField]
    private AudioSource attackMissSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = _type;

        anim = GetComponent<Animator>();

        playerObject = LayerMask.NameToLayer("Player");
        platformObject = LayerMask.NameToLayer("Platform");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && isAttack == false)
        {
            speedX = -horizontalSpeed * Time.deltaTime;
            if (isFacingRight)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.D) && isAttack == false)
        {
            speedX = horizontalSpeed * Time.deltaTime;
            if (!isFacingRight)
            {
                Flip();
            }
        }
        else
        {
            speedX = 0;
        }
        transform.Translate(speedX, 0, 0);

        //атака
        if (Input.GetKeyDown(KeyCode.K) && isAttack == false)
        {
            isAttack = true;
            anim.Play("GG_Attack");

            StartCoroutine(ResetAttack());
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !Input.GetKey(KeyCode.S))
        {
            jumpSound.Play();
            rb.velocity = new Vector2(0, verticalImpulse);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }

    
        if (isGrounded == true)
        {
            anim.SetBool("isJump", false);
        }
        else
        {
            anim.SetBool("isJump", true);
        }


        //Взаимодеуствие с платформами
        if (rb.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(playerObject, platformObject, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(playerObject, platformObject, false);
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            StartCoroutine("jumpOff");
        }
    }

    //Функция вызывается на определенном кадре в анимации GG_Attack
    public void OnAttack()
    {
        attackMissSound.Play();

        Collider2D[] miliEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, miliEnemy);//поиск милишных врагов в радиусе
        for (int i = 0; i < miliEnemies.Length; i++)
        {
            miliEnemies[i].GetComponent<MiliEnemy>().TakeDamage(damage);
        }

        Collider2D[] turretEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, turretEnemy);//поиск врагов турелей в радиусе
        for (int j = 0; j < turretEnemies.Length; j++)
        {
            turretEnemies[j].GetComponent<EnemyTurret>().TakeDamage(damage);
        }
    }

    //Перезарядка атаки
    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(.3f);
        isAttack = false;
    }

    //Отключение столкновения с платформой при прыжке
    IEnumerator jumpOff()
    {
        jumpDown = true;
        Physics2D.IgnoreLayerCollision(playerObject, platformObject, true);
        yield return new WaitForSeconds(0.3f);
        Physics2D.IgnoreLayerCollision(playerObject, platformObject, false);
        jumpDown = false;
    }

    //Перемещения игрока вместе с лифтом
    private void OnCollisionStay2D(Collision2D collision)
    {
        if  (
            collision.gameObject.tag == "Ground" || 
            collision.gameObject.tag == "Elevator" || 
            collision.gameObject.tag == "TurretEnemy" || 
            collision.gameObject.tag == "Platform"
            )
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Elevator")
        {
            this.transform.parent = collision.transform;
        }
    }

    //Отключение премещения игрока вместе с лифтом
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;

        if (collision.gameObject.tag == "Elevator")
        {
            this.transform.parent = null;
        }
    }


    //Отражение спрайта в сторону перемещения
    void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
