using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletDeathWait;
    [SerializeField] float bloom;
    [SerializeField] float bulletSpeedDampening;
    Rigidbody2D bulletRB;
    public GameObject myOwner;
    bool returning;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        DestroyBullet(bulletDeathWait);
        transform.Rotate(0, 0, Random.Range(-bloom, bloom));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10 && myOwner.transform.parent.parent.GetComponent<PlayerBehaviors>().currentCharacter != 0)
        {
            DestroyBullet(0);
        }
        else {
            bulletSpeed = 0;
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
    private void DestroyBullet(float seconds)
    {
        Destroy(gameObject,seconds);
    }

}
