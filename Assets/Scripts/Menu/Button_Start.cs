using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Button_Start : ButtonBase
{
    public string mainScene;
    public override void Click()
    {
        SceneManager.LoadScene(mainScene);
    }
}
