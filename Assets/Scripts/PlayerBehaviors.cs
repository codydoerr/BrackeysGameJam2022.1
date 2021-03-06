using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviors : MonoBehaviour
{
    [SerializeField] float alphaChange;
    [SerializeField] GameObject [] currentWeapons;
    public PlayerCharacter [] characters;
    [SerializeField] Color[] characterColors;
    [SerializeField] GameObject selectionCircle;
    [SerializeField] GameObject nextSelectionCircle;
    [SerializeField] float switchTimeWait;
    [SerializeField] WallsDetection[] detectionWalls;
    [SerializeField] AudioSource footstepSound;
    [SerializeField] AudioSource switchSound;
    [SerializeField] AudioSource failedSwitchSound;
    int closestCharacter;
    float distance;
    bool changingView = false;
    bool canSwitch = true;
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
        changingView = false;
        playerRB = GetComponent<Rigidbody2D>();
        StartCoroutine(PlayFootsteps());

        for (int i = 0; i < characters.Length; i++)
        {
            if (i != currentCharacter)
            {
                characters[i].sprite.color = new Color(1, 1, 1, alphaChange);
                characters[i].col.enabled = false;
            }
            else
            {
                characters[i].sprite.color = new Color(1, 1, 1, 1);
                characters[i].col.enabled = true;
                selectionCircle.transform.SetPositionAndRotation(characters[i].transform.position, Quaternion.identity);
                selectionCircle.GetComponent<SpriteRenderer>().color = new Color(characterColors[i].r, characterColors[i].g, characterColors[i].b, 1);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        closestCharacter = FindClosestCharacter();
        nextSelectionCircle.transform.position = characters[closestCharacter].transform.position;
        if (detectionWalls[closestCharacter].IsWallThere())
            nextSelectionCircle.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, .3f);
        else
            nextSelectionCircle.GetComponent<SpriteRenderer>().color = new Color(.75f, .75f, .75f, .3f);


        if (Input.GetMouseButton(0))
        {
            currentWeapons[currentCharacter].GetComponent<WeaponsBehaviors>().FireWeapon(currentCharacter);
        }
        if ((Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(1)) && canSwitch)
        {
            changingView = true;
            StartCoroutine(SwitchTimer(switchTimeWait));
        }
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private int FindClosestCharacter()
    {
        int closestCharacter = 0;
        float closestDistance = 20;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        for(int i = 0; i < characters.Length; i++)
        {
            if(Vector2.Distance((Vector2)characters[i].transform.position, mousePosition) < closestDistance)
            {
                closestCharacter = i;
                closestDistance = Vector2.Distance((Vector2)characters[i].transform.position, mousePosition);
            }
        }
        return closestCharacter;
    }
    public void ChangeGunnerView(int newGunner)
    {
        if (!detectionWalls[newGunner].IsWallThere())
        {
            if (newGunner != currentCharacter)
            {
                currentCharacter = newGunner;
                switchSound.Play();
                for (int i = 0; i < characters.Length; i++)
                {
                    if (i != currentCharacter)
                    {
                        characters[i].sprite.color = new Color(1, 1, 1, alphaChange);
                        characters[i].col.enabled = false;
                    }
                    else
                    {
                        characters[i].sprite.color = new Color(1, 1, 1, 1);
                        characters[i].col.enabled = true;
                        selectionCircle.transform.SetPositionAndRotation(characters[i].transform.position, Quaternion.identity);
                        selectionCircle.GetComponent<SpriteRenderer>().color = new Color(characterColors[i].r, characterColors[i].g, characterColors[i].b, 1);
                    }
                }
            }
        }
        else
        {
            failedSwitchSound.Play();
        }
    }
    IEnumerator SwitchTimer(float seconds)
    {
        canSwitch = false;
        ChangeGunnerView(closestCharacter);
        canSwitch = true;
        yield return new WaitForSeconds(seconds);
        changingView = false;
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

    private IEnumerator PlayFootsteps()
    {
        while (true)
        {
            Xinput = Input.GetAxis("Horizontal");
            Yinput = Input.GetAxis("Vertical");

            direction = new Vector2(Xinput, Yinput);

            if (direction.magnitude > .5f)
            {
                footstepSound.Play();
                yield return new WaitForSeconds(.3f);
            }
            yield return new WaitForSeconds(.001f);
        }
    }
}
