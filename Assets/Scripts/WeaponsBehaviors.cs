using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsBehaviors : MonoBehaviour
{
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
        switch (weapon)
        {
            case 0:
                Debug.Log("Bango" + weapon);
                return;
            case 1:
                Debug.Log("Bango" + weapon);
                return;
            case 2:
                Debug.Log("Bango" + weapon);
                return;
            case 3:
                Debug.Log("Bango" + weapon);
                return;
        }

    }
}
