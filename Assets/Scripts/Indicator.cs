using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public GameObject owner;
    public Vector2 offest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (owner != null)
            transform.position = (Vector2)owner.transform.position + offest;
        else
            Destroy(gameObject);
    }
}
