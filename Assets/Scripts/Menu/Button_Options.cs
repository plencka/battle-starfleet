using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Button_Options : ButtonBase
{
    public GameObject optionsScreen;
    public override void Click()
    {
        optionsScreen.SetActive(true);
    }
}