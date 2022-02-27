using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtbox : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCharacter>() != null)
        {
            collision.GetComponent<PlayerCharacter>().TakeDamage(damage);
            if (GetComponent<Projectile>())
                GetComponent<Projectile>().HitCharacter();
            else
                Destroy(gameObject);
        }
    }
}
