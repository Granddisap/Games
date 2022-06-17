using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    [SerializeField] private HPSystem hp;
    public int damage;

    //перезарядка
    float recharge;
    public float startRecharge;

    private void Update()
    {
        recharge += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (recharge >= startRecharge)
        {
            if (collision.CompareTag("Player"))
            {
                hp.Damage(damage);
                recharge = 0;
            }
        }
    }
}
