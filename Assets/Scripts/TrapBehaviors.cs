using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviors : MonoBehaviour
{
    [SerializeField] float time = 10;
    [SerializeField] GameObject spawn;
    public bool roomNotEmpty;
    // Start is called before the first frame update
    void Start()
    {
        roomNotEmpty = true;
        if (time != 0)
        {
            StartCoroutine(laserTime(time));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator laserTime(float seconds)
    {
        while (roomNotEmpty)
        {
            yield return new WaitForSeconds(seconds);
            Instantiate(spawn,transform.position,transform.rotation);
        }
    }
}
