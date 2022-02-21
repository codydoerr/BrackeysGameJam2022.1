using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] float cameraSpeed;
    [SerializeField] GameObject[] cameraLocations;
    int cameraLocation;
    private void Start()
    {
        transform.SetParent(null);
    }
    void Update()
    {
        transform.position = Vector2.Lerp(new Vector3(transform.position.x, transform.position.y,10),new Vector3(cameraLocations[cameraLocation].transform.position.x, cameraLocations[cameraLocation].transform.position.y,10), cameraSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeGunnerView();
        }
    }
    
    public void ChangeGunnerView()
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
