using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] float cameraSpeed;
    [SerializeField] GameObject[] cameraLocations;
    [SerializeField] PlayerBehaviors playerBeh;
    private void Start()
    {
        playerBeh = transform.parent.GetComponent<PlayerBehaviors>();
        transform.SetParent(null);

    }
    void LateUpdate()
    {
        transform.position = Vector2.Lerp(new Vector3(transform.position.x, transform.position.y,10),new Vector3(cameraLocations[playerBeh.currentCharacter].transform.position.x, cameraLocations[playerBeh.currentCharacter].transform.position.y,10), cameraSpeed * Time.deltaTime);
    }
}
