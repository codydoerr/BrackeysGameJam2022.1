using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtbox : MonoBehaviour
{
    [SerializeField] EnemyHealth.shieldTypes damageType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>() != null)
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damageType);
            if (GetComponent<Projectile>())
                GetComponent<Projectile>().HitCharacter();
            else
                Destroy(gameObject);
        }
    }
}
