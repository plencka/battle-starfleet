using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Button_Exit : ButtonBase
{
    public override void Click()
    {
#if UNITY_EDITOR
        Debug.Log("Application Quit.");
#else
        Application.Quit();
#endif
    }
}
