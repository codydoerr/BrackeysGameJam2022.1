using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float mousePosition;
    Vector3 aimPosition;

    [SerializeField] CameraBehavior camScript;

    public SpriteRenderer sprite;
    public Collider2D col;

    void FixedUpdate()
    {
        aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = aimPosition - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
    public Vector3 GetAimPosition()
    {
        return aimPosition;
    }

}
