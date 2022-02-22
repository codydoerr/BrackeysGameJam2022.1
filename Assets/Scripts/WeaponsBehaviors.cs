using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsBehaviors : MonoBehaviour
{
    bool canFire = true;
    [SerializeField] float fireWait;
    [SerializeField] GameObject bulletType;
    // Start is called before the first frame update
    public void FireWeapon(int weapon)
    {
        if(canFire)
        {
            StartCoroutine(WeaponFireWait(fireWait));
            Debug.Log("Bango" + weapon);
        }

    }
    IEnumerator WeaponFireWait(float seconds)
    {

        Instantiate(bulletType, transform.position, Quaternion.identity);
        canFire = false;
        yield return new WaitForSeconds(seconds);
        canFire = true;

    }
}
