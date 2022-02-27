using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMoveEnemyScript : MonoBehaviour
{
    [SerializeField] GameObject moveHere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().MovePosition(moveHere.transform.position);
    }
}
