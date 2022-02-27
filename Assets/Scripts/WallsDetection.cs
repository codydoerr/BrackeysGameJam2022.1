    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsDetection : MonoBehaviour
{
    int isWall;
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
        return isWall>0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isWall++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isWall--;
    }
}
