using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_ChangeScene : ButtonBase
{
    [SerializeField]
    private string sceneName;
    public override void Click()
    {
        SceneManager.LoadScene(sceneName);
    }
}
