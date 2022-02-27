using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaBossBehavior : MonoBehaviour
{
    [SerializeField] GameObject spawnLocation;
    [SerializeField] EnemyAI aiScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aiScript.attackingRight)
        {
            spawnLocation.transform.localPosition = new Vector2(.225f,.625f);
        }
        else
        {
            spawnLocation.transform.localPosition = new Vector2(-.225f,.625f);
        }
    }
}
