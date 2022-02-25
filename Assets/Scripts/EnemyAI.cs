using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float preferedDistance;
    public float visionRange;
    public bool strafes;

    [Header("Attacking")]
    public float reloadTime;
    public GameObject projectile;
    public GameObject bulletSpawn;

    private PlayerBehaviors player;
    private GameObject currentCharacter;
    private bool awake;
    private Rigidbody2D rb;
    private bool strafeRight;
    private Vector2 lastPlayerPos;
    private bool canAttack;

    private void Start()
    {
        awake = true;
        canAttack = true;
        player = FindObjectOfType<PlayerBehaviors>();
        rb = GetComponent<Rigidbody2D>();

        if(strafes)
        {
            strafeRight = Random.value > .5;
        }
    }

    void FixedUpdate()
    {
        currentCharacter = player.characters[player.currentCharacter].gameObject;

        if(awake && CanSeePlayer())
        {
            lastPlayerPos = currentCharacter.transform.position;
            transform.up = currentCharacter.transform.position - transform.position;

            Vector2 direction = Vector2.zero;
            if (Vector2.Distance(transform.position, currentCharacter.transform.position) > preferedDistance)
                direction = currentCharacter.transform.position - transform.position;
            else if (Mathf.Abs(Vector2.Distance(transform.position, currentCharacter.transform.position) - preferedDistance) > .25f)
                direction = transform.position - currentCharacter.transform.position;
            else if (strafes)
            {
                if(strafeRight)
                    direction = Vector2.Perpendicular(transform.position - currentCharacter.transform.position);
                else
                    direction = -Vector2.Perpendicular(transform.position - currentCharacter.transform.position);
            }

            if (direction != Vector2.zero)
                direction.Normalize();

            rb.MovePosition((Vector2)transform.position + (direction * speed * Time.fixedDeltaTime));

            if (canAttack)
                StartCoroutine(Shoot());
        }
        else if (awake)
        {
            if (Vector2.Distance(transform.position, lastPlayerPos) > .1f)
            {
                transform.up = lastPlayerPos - (Vector2)transform.position;
                Vector2 direction = lastPlayerPos - (Vector2)transform.position;

                direction.Normalize();
                rb.MovePosition((Vector2)transform.position + (direction * speed * Time.fixedDeltaTime));
            }
        }
    }

    private bool CanSeePlayer()
    {
        int layerMask = (LayerMask.GetMask("Player")) | (LayerMask.GetMask("Walls"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (currentCharacter.transform.position - transform.position).normalized * visionRange, visionRange, layerMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "Player")
        {
            return true;
        }

        return false;
    }

    private IEnumerator Shoot()
    {
        canAttack = false;
        yield return new WaitForSeconds(reloadTime);
        Instantiate(projectile, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        canAttack = true;
    }
}
