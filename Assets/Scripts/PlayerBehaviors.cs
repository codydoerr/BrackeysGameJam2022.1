using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviors : MonoBehaviour
{
    CameraBehavior camScript;
    int currentWeapon = 0;
    int currentHologram = 0;
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
            currentWeapons[currentWeapon].GetComponent<WeaponsBehaviors>().FireWeapon(currentWeapon);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            camScript.ChangeGunnerView();
            currentWeapon = camScript.cameraLocation;
            currentHologram = camScript.cameraLocation;
        }
    }
    public GameObject GetCurrentPlayer()
    {
        return holograms[currentHologram];
    }
}
