using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string mainScene;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(mainScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
