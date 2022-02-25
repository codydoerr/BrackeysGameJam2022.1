using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public enum shieldTypes { Orange, Green, Blue, Pink};

    public SpriteRenderer shield;
    public shieldTypes[] shields;
    int currentSheild;

    private void Start()
    {
        currentSheild = shields.Length - 1;
    }

    public void TakeDamage(shieldTypes damageType)
    {
        if(shields[currentSheild] == damageType)
        {
            currentSheild--;
        }
    }

    private Color GetSheildColor()
    {
        return new Color (1,1,1,1);
    }
}
