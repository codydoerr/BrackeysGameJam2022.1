using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletDeathWait;
    [SerializeField] float bloom;
    [SerializeField] float bulletSpeedDampening;
    [SerializeField] GameObject objectSpawnOnDeath;
    bool firstSpawn;
    Vector3[] points = new Vector3[2];
    BoxCollider2D col;
    LineRenderer lr;
    Rigidbody2D bulletRB;
    public GameObject myOwner;

    // Start is called before the first frame update
    void Start()
    {

        if (GetComponent<LineRenderer>())
        {
            col = GetComponent<BoxCollider2D>();
            lr = GetComponent<LineRenderer>();
            points[0] = transform.position;
        }

        bulletRB = GetComponent<Rigidbody2D>();
        if (objectSpawnOnDeath != null)
        {
            if(objectSpawnOnDeath.GetComponent<PlayerHurtbox>())
                if (objectSpawnOnDeath.GetComponent<PlayerHurtbox>().damageType == EnemyHealth.shieldTypes.Pink)
                    firstSpawn = true;
            if (objectSpawnOnDeath.GetComponent<EnemyHurtbox>())
                if (objectSpawnOnDeath.GetComponent<EnemyHurtbox>().damageType == EnemyHealth.shieldTypes.Pink)
                    firstSpawn = true;

        }
        DestroyBullet(bulletDeathWait);
        transform.Rotate(0, 0, Random.Range(-bloom, bloom));
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<LineRenderer>())
        {
            points[1] = transform.position;
            col.size = new Vector2(0.125f,(points[0] - points[1]).magnitude);
            col.offset = new Vector2(0, (-(points[0] - points[1]).magnitude / 2));
            lr.SetPositions(points);
        }
        if (bulletSpeed < 0)
        {
            transform.up = (Vector2)transform.position - (Vector2)myOwner.transform.position;
        }
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
        bulletSpeed -= bulletSpeedDampening * Time.deltaTime;

        if (bulletSpeed < 0 && Vector2.Distance(transform.position, myOwner.transform.position) < .2f)
        {
            DestroyBullet(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)//layer 10 is Walls
        {
            if (bulletSpeedDampening == 0 && lr == null)
            {
                DestroyBullet(0);
            }
            else if (bulletSpeed > 0 && lr == null)
            {
                bulletSpeed = -bulletSpeed;
            }
            else if (lr != null)
            {
                bulletSpeed = 0;
            }
        }
    }
    private void DestroyBullet(float seconds)
    {
        if (objectSpawnOnDeath != null && !firstSpawn)
        {
            Instantiate(objectSpawnOnDeath, transform.position, transform.rotation);
        }
        Destroy(gameObject,seconds);
        firstSpawn = false;
    }
    public void HitCharacter()
    {
        if (bulletSpeedDampening == 0 && lr != null)
            DestroyBullet(0);
        else if(bulletSpeedDampening != 0)
        {
            if (bulletSpeed > 0)
            {
                bulletSpeed = -bulletSpeed;
            }
        }
    }

}
