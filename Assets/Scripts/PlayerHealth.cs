using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float curHealth, maxHealth, invFrames;
    bool canTakeDamage;
    bool playerDead;

    // Start is called before the first frame update
    void Start()
    {
        canTakeDamage = true;
        curHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {
            curHealth -= damage;
            StartCoroutine(InvFrames(invFrames));

            if (curHealth < 0 && !playerDead)
            {
                PlayerDeath();
                playerDead = true;
            }
        }

    }
    public void HealDamage(float healAmount)
    {
        if (curHealth < maxHealth)
        {
            curHealth += healAmount;
            if (curHealth > maxHealth)
            {
                curHealth = maxHealth;
            }
        }
    }
    void PlayerDeath()
    {
        Debug.Log("Wow such loser");
    }
    IEnumerator InvFrames(float seconds)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(seconds);
        canTakeDamage = true;
    }
}
