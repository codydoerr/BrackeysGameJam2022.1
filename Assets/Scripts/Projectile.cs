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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == myOwner)
        {
            DestroyBullet(0);
        }
        else if(collision.gameObject.layer == 10)//layer 10 is Walls
        { 

            if (bulletSpeed > 0)
            {
                bulletSpeed = 0;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (bulletSpeed < 0)
        {
            transform.up = transform.position - myOwner.transform.position;
        }
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
        bulletSpeed -= bulletSpeedDampening * Time.deltaTime;
    }
    IEnumerator LaserDamage(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    private void DestroyBullet(float seconds)
    {
        if(objectSpawnOnDeath != null)
        {
            Instantiate(objectSpawnOnDeath);
        }
        Destroy(gameObject,seconds);
    }

    public void HitCharacter()
    {

    }

}
