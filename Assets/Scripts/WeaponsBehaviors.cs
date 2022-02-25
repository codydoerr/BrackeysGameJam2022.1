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
        Vector2 shootDir = transform.parent.parent.GetComponent<PlayerCharacter>().GetAimPosition() - transform.position;
        float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg - 90f;
        Projectile bul = Instantiate(bulletType, transform.position,Quaternion.Euler(0,0,angle)).GetComponent<Projectile>();
        bul.myOwner = gameObject.transform.parent.parent.gameObject;//<3
        canFire = false;
        yield return new WaitForSeconds(seconds);
        canFire = true;
    }
}
