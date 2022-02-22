using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviors : MonoBehaviour
{
    [SerializeField] float alphaChange;
    [SerializeField] GameObject [] currentWeapons;
    [SerializeField] PlayerCharacter [] characters;
    public int currentCharacter;
    Vector2 direction;
    [SerializeField] float speed;
    float Xinput;
    float Yinput;
    Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Awake()
    {

    }
    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        ChangeGunnerView();
    }
    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButton(0))
        {
            currentWeapons[currentCharacter].GetComponent<WeaponsBehaviors>().FireWeapon(currentCharacter);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeGunnerView();
        }
    }
    private void FixedUpdate()
    {
        Movement();
    }
    public void ChangeGunnerView()
    {
        currentCharacter++;
        currentCharacter = currentCharacter % 4;
        for (int i = 0; i < characters.Length; i++)
        {
            if (i != currentCharacter)
            {
                characters[i].sprite.color = new Color(1,1,1,alphaChange);
                characters[i].col.enabled = false;
            }
            else
            {
                characters[i].sprite.color = new Color(1,1,1,1);
                characters[i].col.enabled = true;
            }
        }

        /*if (press != KeyCode.Space)
        {
            switch (press)
            {
                case KeyCode.Alpha1:
                    cameraLocation = 0;
                    return;
                case KeyCode.Alpha2:
                    cameraLocation = 1;
                    return;
                case KeyCode.Alpha3:
                    cameraLocation = 2;
                    return;
                case KeyCode.Alpha4:
                    cameraLocation = 3;
                    return;
            }
        }
        else
        {

        }
        */

    }
    void Movement()
    {
            Xinput = Input.GetAxis("Horizontal");
            Yinput = Input.GetAxis("Vertical");

            direction = new Vector2(Xinput, Yinput);

            if (direction.magnitude > 1)
            {
                direction.Normalize();
            }
            playerRB.MovePosition((Vector2)transform.position + (direction * speed * Time.fixedDeltaTime));
        
    }
}
