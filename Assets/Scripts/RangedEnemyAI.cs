using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : MonoBehaviour
{
    public float speed;
    public float visionRange;
    public float attackDelay;

    private GameObject player;
    private bool awake;

    void Update()
    {
        if(awake && canSeePlayer())
        {

        }
    }

    private bool canSeePlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position - player.transform.position, visionRange);

        if (hit.collider != null && hit.collider.gameObject.tag == "Player")
        {
            
        }

        return false;
    }
}
