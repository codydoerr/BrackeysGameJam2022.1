using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsBehaviors : MonoBehaviour
{
    [SerializeField] GameObject bulletType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FireWeapon(int weapon)
    {
        Instantiate(bulletType,transform.position,Quaternion.identity);
        Debug.Log("Bango" + weapon);
    }
}
