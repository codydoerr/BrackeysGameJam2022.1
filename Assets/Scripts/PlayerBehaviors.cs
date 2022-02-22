using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviors : MonoBehaviour
{
    CameraBehavior camScript;
    [SerializeField] GameObject [] currentWeapons;
    [SerializeField] GameObject [] holograms;

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
            currentWeapons[camScript.cameraLocation].GetComponent<WeaponsBehaviors>().FireWeapon(camScript.cameraLocation);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            camScript.ChangeGunnerView();
        }
    }
    public GameObject GetCurrentPlayer()
    {
        return holograms[camScript.cameraLocation];
    }
}
