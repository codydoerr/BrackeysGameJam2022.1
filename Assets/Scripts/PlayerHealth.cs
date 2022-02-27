using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float invFrames;
    [SerializeField] int curHealth, maxHealth;
    [SerializeField] Animator playerHurtAnim;
    bool canTakeDamage;
    bool playerDead;

    // Start is called before the first frame update
    void Start()
    {
        canTakeDamage = true;
        curHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            if (damage > 0)
            {
                curHealth -= damage;
                StartCoroutine(InvFrames(invFrames));

                if (curHealth <= 0 && !playerDead)
                {
                    PlayerDeath();
                    playerDead = true;
                }
                else
                {
                    playerHurtAnim.SetTrigger("Hurt");
                }
            }
        }

    }
    public void HealDamage(int healAmount)
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
        playerHurtAnim.SetTrigger("Die");
    }
    IEnumerator InvFrames(float seconds)
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(seconds);
        canTakeDamage = true;
    }
    public int GetPlayerHealth()
    {
        return curHealth;
    }
}
