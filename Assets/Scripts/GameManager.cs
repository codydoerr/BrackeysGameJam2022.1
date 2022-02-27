using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] int currentHealth;
    bool isPaused;
    [SerializeField] GameObject healthBar;
    [SerializeField] PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        currentHealth = playerHealth.GetPlayerHealth();
        healthBar.GetComponent<Slider>().value = currentHealth;
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
                UnPauseGame();
            else if (!isPaused)
                PauseGame();
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }
    public void UnPauseGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }
}
