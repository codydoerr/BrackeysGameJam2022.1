using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject[] enemies;
    private Animator myAnim;
    private Collider2D col;

    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        myAnim = GetComponent<Animator>();
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!open)
        {
            bool enemiesAlive = false;
            foreach (GameObject en in enemies)
            {
                if (en != null)
                    enemiesAlive = true;
            }

            if (enemiesAlive == false)
                OpenDoor();
        }
    }

    private void OpenDoor()
    {
        open = true;
        col.enabled = false;
        myAnim.SetTrigger("Open");
    }


}
