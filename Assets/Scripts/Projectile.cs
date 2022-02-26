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
    Rigidbody2D bulletRB;
    public GameObject myOwner;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        DestroyBullet(bulletDeathWait);
        transform.Rotate(0, 0, Random.Range(-bloom, bloom));
    }

    // Update is called once per frame
    void Update()
    {
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
            if(bulletSpeedDampening == 0)
            {
                DestroyBullet(0);
            }
            else if (bulletSpeed > 0)
            {
                bulletSpeed = -bulletSpeed;
            }
        }
    }

    IEnumerator LaserDamage(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (objectSpawnOnDeath != null)
        {
            Instantiate(objectSpawnOnDeath, transform.position, Quaternion.identity);
        }
    }

    private void DestroyBullet(float seconds)
    {
        StartCoroutine(LaserDamage(seconds));
        Destroy(gameObject,seconds);
    }

    public void HitCharacter()
    {
        if (bulletSpeedDampening == 0)
            DestroyBullet(0);
        else
        {
            if (bulletSpeed > 0)
            {
                bulletSpeed = -bulletSpeed;
            }
        }
    }

}
