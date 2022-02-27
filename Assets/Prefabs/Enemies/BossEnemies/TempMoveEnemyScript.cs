using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMoveEnemyScript : MonoBehaviour
{
    [SerializeField] GameObject moveHere;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = gameObject.GetComponent<EnemyAI>().speed*2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y > 30)
            GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + new Vector2(0,-1)*Time.fixedDeltaTime*speed);
    }
}
