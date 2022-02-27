using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviors : MonoBehaviour
{
    [SerializeField] float time = 10;
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject curEnemies;
    [SerializeField] GameObject boss;
    public bool roomNotEmpty;
    // Start is called before the first frame update
    void Start()
    {
        if(enemies.Length !=0 && curEnemies)
        {
            curEnemies = enemies[0];
        }
        roomNotEmpty = true;
        if (time != 0)
        {
            StartCoroutine(laserTime(time));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Length != 0)
        {
            if (boss)
            {
                if (boss.GetComponent<EnemyHealth>().currentSheild > 5)
                {
                    curEnemies = enemies[1];
                }
                else if (boss.GetComponent<EnemyHealth>().currentSheild > 10)
                {
                    curEnemies = enemies[2];
                }
                else if (boss.GetComponent<EnemyHealth>().currentSheild > 15)
                {
                    curEnemies = enemies[3];
                }
            }
        }
    }
    IEnumerator laserTime(float seconds)
    {
        while (roomNotEmpty)
        {
            yield return new WaitForSeconds(seconds);
            if (enemies.Length != 0)
            {
                Instantiate(curEnemies, transform.position, transform.rotation);
            }
            else
                Instantiate(spawn,transform.position,transform.rotation);
        }
    }
}
