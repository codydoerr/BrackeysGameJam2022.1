using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public enum shieldTypes { Orange, Green, Blue, Pink, None};

    public SpriteRenderer shield;
    public shieldTypes[] shields;
    public int currentSheild;
    public AudioSource shieldBreak;
    public AudioSource shieldDelfect;

    private void Start()
    {
        currentSheild = shields.Length - 1;
        SetShieldColor();
    }

    public void TakeDamage(shieldTypes damageType)
    {
        if (currentSheild > -1 && damageType != shieldTypes.None)
        {
            if (shields[currentSheild] == damageType)
            {
                shieldBreak.Play();
                currentSheild--;
                SetShieldColor();
            }
            else
            {
                shieldDelfect.Play();
            }
        }
        else if (damageType != shieldTypes.None)
            Destroy(gameObject);
    }


    private void SetShieldColor()
    {
        if (currentSheild > -1)
            shield.color = GetSheildColor(currentSheild);
        else
            shield.color = new Color(0, 0, 0, 0);
    }

    private Color GetSheildColor(int shield)
    {
        if(shields[shield] == shieldTypes.Orange)
            return new Color(.827f, 0.552f, 0.274f);
        else if (shields[shield] == shieldTypes.Green)
            return new Color(0.219f, 0.658f, 0.219f);
        else if (shields[shield] == shieldTypes.Blue)
            return new Color(.4f, .6f, .8f);
        else
            return new Color(.8f, .4f, .733f);
    }
}
