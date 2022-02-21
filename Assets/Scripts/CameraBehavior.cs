using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] float cameraSpeed;
    [SerializeField] GameObject[] cameraLocations;
    int cameraLocation;
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, cameraLocations[cameraLocation].transform.position, cameraSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeWeapons();
        }
    }
    
    public void ChangeWeapons()
    {
        cameraLocation++;
        cameraLocation = cameraLocation % 4;
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
