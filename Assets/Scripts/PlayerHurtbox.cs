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
            switch (damageType)
            {
                case EnemyHealth.shieldTypes.Orange:
                    collision.GetComponent<EnemyHealth>().TakeDamage(damageType);
                    break;
                case EnemyHealth.shieldTypes.Green:
                    collision.GetComponent<EnemyHealth>().TakeDamage(damageType);
                    break;
                case EnemyHealth.shieldTypes.Blue:
                    collision.GetComponent<EnemyHealth>().TakeDamage(damageType);
                    break;
                case EnemyHealth.shieldTypes.Pink:
                    collision.GetComponent<EnemyHealth>().TakeDamage(damageType);
                    break;
            }

        }
    }
}
