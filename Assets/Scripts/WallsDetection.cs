using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsDetection : MonoBehaviour
{
    bool isWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsWallThere()
    {
        return isWall;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isWall = true;
        Debug.Log(isWall);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isWall = false;
        Debug.Log(isWall);
    }
}
