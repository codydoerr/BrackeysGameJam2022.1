using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviors : MonoBehaviour
{
    CameraBehavior camScript;
    int currentWeapon = 0;
    [SerializeField] GameObject [] currentWeapons;
    // Start is called before the first frame update
    void Awake()
    {
        camScript = Camera.main.GetComponent<CameraBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            currentWeapons[currentWeapon].GetComponent<WeaponsBehaviors>().FireWeapon(currentWeapon);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeWeapon();
            camScript.ChangeGunnerView();
        }
    }
    public void ChangeWeapon()
    {
        currentWeapon++;
        currentWeapon = currentWeapon % 4;
        /*if (press != KeyCode.Space)
        {
            switch (press)
            {
                case KeyCode.Alpha1:
                    cameraLocation = 0;
                    return;
                case KeyCode.Alpha2:
                    cameraLocation = 1;
                    return;
                case KeyCode.Alpha3:
                    cameraLocation = 2;
                    return;
                case KeyCode.Alpha4:
                    cameraLocation = 3;
                    return;
            }
        }
        else
        {

        }
        */

    }

}
