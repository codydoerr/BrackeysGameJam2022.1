using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public enum shieldTypes { Orange, Green, Blue, Pink};

    public SpriteRenderer shield;
    public shieldTypes[] shields;
    public int currentSheild;

    private void Start()
    {
        currentSheild = shields.Length - 1;
        SetShieldColor();
    }

    public void TakeDamage(shieldTypes damageType)
    {
        if (currentSheild > -1)
        {
            if (shields[currentSheild] == damageType)
            {
                currentSheild--;
                SetShieldColor();
            }
        }
        else
            Destroy(gameObject);
    }

    private void SetShieldColor()
    {
        if (currentSheild > -1)
            shield.color = GetSheildColor();
        else
            shield.color = new Color(0, 0, 0, 0);
    }

    private Color GetSheildColor()
    {
        if(shields[currentSheild] == shieldTypes.Orange)
            return new Color(.827f, 0.552f, 0.274f);
        else if (shields[currentSheild] == shieldTypes.Green)
            return new Color(0.219f, 0.658f, 0.219f);
        else if (shields[currentSheild] == shieldTypes.Blue)
            return new Color(.4f, .6f, .8f);
        else
            return new Color(.8f, .4f, .733f);
    }
}
