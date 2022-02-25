using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public enum sheildTypes { Orange, Green, Blue, Pink};

    public SpriteRenderer sheild;
    public sheildTypes[] sheilds;
    int currentSheild;

    private void Start()
    {
        currentSheild = sheilds.Length - 1;
    }

    public void TakeDamage(sheildTypes damageType)
    {
        if(sheilds[currentSheild] == damageType)
        {
            currentSheild--;
        }
    }

    private Color GetSheildColor()
    {
        return new Color (1,1,1,1);
    }
}
