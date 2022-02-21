using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatBehavior : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float mousePosition;
    int currentWeapon;
    [SerializeField] CameraBehavior camScript;
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

}
