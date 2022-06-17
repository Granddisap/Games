using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    public static int Health = 3;
    public static int Armor = 0;
    bool canHit = true;
    [SerializeField] private GameObject Heart1, Heart2, Heart3, Heart4, Armor1, dethScreen;

    [SerializeField] private AudioSource takeDamage, dethSound;

    [SerializeField] private Collider2D player;

    public Animator anim;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Player playerScale;

    //визуализация бессмертия
    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
    }

    void Update()
    {
        if (Health <= 0 && !dethScreen.activeSelf)
        {
            dethScreen.SetActive(true);
            dethSound.Play();
            Die();     
        }

        switch (Health)
        {
            case 4:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(true);
                break;
            case 3:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                Heart4.SetActive(false);
                break;
            case 2:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                break;
            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                Heart4.SetActive(false);
                break;
        }

        if (Armor > 0)
        {
            Armor1.SetActive(true);
        }
        else
        {
            Armor1.SetActive(false);
        }
    }

    public void Damage(int damage)
    {
        if (canHit == true)
        {
            StatisticsShow.damageCount += damage;

            takeDamage.Play();
            StartCoroutine("damageVisual");
            if (MerchantShop.armorSold == false)
            {
                Health -= damage;
            }
            else
            {
                if (Armor > 0)
                {
                    Armor -= damage;
                }
                else
                {
                    Health -= damage;
                }
                StopCoroutine("ResetArmor");
                StartCoroutine("ResetArmor");
            }
            StartCoroutine("ResetCanHit");
        }
    }

    public void Die()
    {
        StatisticsShow.dieCount += 1;

        //Куплено или нет сердечко
        if (MerchantShop.heartSold == false)
        {
            Health = 3;
        }
        else if (MerchantShop.heartSold == true)
        {
            Health = 4;
        }
    }

    private IEnumerator damageVisual()//визуализация урона по игроку
    {
        /*SpriteRenderer playerColor = player.GetComponentInChildren<SpriteRenderer>();
        float colorR = playerColor.color.r;
        float colorG = playerColor.color.g;
        float colorB = playerColor.color.b;
        playerColor.color = new Color(1, 0.554f, 0.554f);*/

        anim.SetBool("isTakeDamage", true);

        //отбрасывание
        if (playerScale.isFacingRight == false)
        {
            rb.AddForce(Vector2.right * 6, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.left * 6, ForceMode2D.Impulse);
        }
        playerScale.horizontalSpeed = 0;
        rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.2f);
        //playerColor.color = new Color(colorR, colorG, colorB);
        anim.SetBool("isTakeDamage", false);

        //обратно возвращаем скорость
        playerScale.horizontalSpeed = 5;
    }

    private IEnumerator ResetArmor()
    {
        yield return new WaitForSeconds(3f);
        Armor = 1;
    }

    private IEnumerator ResetCanHit()
    {
        canHit = false;

        spriteRend.material = matBlink;//визуализация бессмертия
        InvokeRepeating("MatDefault", .1f, .2f);//
        yield return new WaitForSeconds(.6f);
        CancelInvoke();
        spriteRend.material = matDefault;

        canHit = true;
    }

    //визуализация бессмертия
    private void MatBlink()
    {
        spriteRend.material = matBlink;
    }
    private void MatDefault()
    {
        spriteRend.material = matDefault;
        Invoke("MatBlink", .1f);
    }//
}
