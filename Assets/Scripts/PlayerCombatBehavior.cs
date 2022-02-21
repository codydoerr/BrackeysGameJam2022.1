using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatBehavior : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float mousePosition;
    int currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
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
