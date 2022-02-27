using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private Animator anim;
    private string newScene;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    public void ResetScene()
    {
        newScene = SceneManager.GetActiveScene().name;
        anim.SetTrigger("Scene End");
    }

    public void LoadScene(string sceneName)
    {
        newScene = sceneName;
        anim.SetTrigger("Scene End");
    }

    public void LoadSceneEnd()
    {
        if (newScene == "Level 1")
            FindObjectOfType<Music>().playingGameMusic = true;
        else if(newScene == "Title")
            FindObjectOfType<Music>().playingGameMusic = false;

        SceneManager.LoadScene(newScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
